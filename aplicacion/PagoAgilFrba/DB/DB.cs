using PagoAgilFrba.Dominio;
using PagoAgilFrba.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace PagoAgilFrba.DB
{
    public class DB
    {
        private static readonly DB instancia = new DB();
        private SqlConnection conexion;

        private Dictionary<Type, Dictionary<int, object>> repositorio;
        private Dictionary<Type, Dictionary<int, object>> parcialmenteCargados;
        private List<Listado> listados;
        
		private DB()
        {
            // Crea el repositorio de objetos,
            // El repositorio de parcialmente cargados
            // Los listados
            // Y se conecta con los parametros dados en la configuracion
            this.repositorio = new Dictionary<Type, Dictionary<int, object>>();
            this.parcialmenteCargados = new Dictionary<Type, Dictionary<int, object>>();
            this.listados = new List<Listado>();            

            this.conexion = new SqlConnection();
            this.conexion.ConnectionString =
                "Data Source=" + Configuracion.Configuracion.valor("db_datasource") +
                "\\" + Configuracion.Configuracion.valor("db_sqltype") +
                ";Initial Catalog=" + Configuracion.Configuracion.valor("db_catalog") +
                ";Integrated Security=True";
			this.conexion.Open();
        }

        public static DB Instancia
        {
            // Devuelve la instancia estatica
            get
            {
                return instancia;
            }
        }

        protected SqlCommand comando(string nombre, Dictionary<string, object> valores)
        {
            // Ejecuta un stored procedure en la DB, agregando los parametros necesarios incluidos en el diccionario dado
            // Usa el nombre de la DB y la conexion creada
            SqlCommand comando = new SqlCommand(Configuracion.Configuracion.valor("nombre_db") + "." + nombre, this.conexion);
            comando.CommandType = CommandType.StoredProcedure;

            foreach (string clave in valores.Keys)
            {
                comando.Parameters.AddWithValue("@" + clave, valores[clave]);
            }
            return comando;
        }
        
        public Respuesta creacion(String nombre, Dictionary<string, object> valores)
        {
            // Crea un comando, usando el nombre de la stored procedure dado y los parametros en el diccionario
            SqlCommand comando = this.comando(nombre, valores);


            // Obtiene el ID de ese objeto, usando el nombre del objeto creado
            SqlParameter id = new SqlParameter("@ID_" + nombre.Split('_')[2], SqlDbType.Int);
            id.Size = sizeof(int);
            id.Direction = ParameterDirection.Output;
            comando.Parameters.Add(id);

            // Obtiene el tipo de error
            SqlParameter retorno = new SqlParameter("@FLAG_ERROR", SqlDbType.Int);
            retorno.Size = sizeof(int);
            retorno.Direction = ParameterDirection.Output;
            comando.Parameters.Add(retorno);

            // Obtiene el mensaje de error
            SqlParameter mensaje = new SqlParameter("@MENSAJE", SqlDbType.VarChar);
            mensaje.Size = 255 * sizeof(char);
            mensaje.Direction = ParameterDirection.Output;
            comando.Parameters.Add(mensaje);

            // Ejecuta la stored procedure y obtiene su respuesta
            comando.ExecuteNonQuery();
            Respuesta respuesta = new Respuesta();
            
            respuesta.Codigo = (int)retorno.Value;
            respuesta.Mensaje = mensaje.Value.ToString();

            // Si todo salio bien, obtiene el ID del objeto creado
            if(respuesta.Codigo == 0)
            {
                respuesta.Id = (int)id.Value;
            }
            

            return respuesta;
        }


        public Respuesta creacion(String nombre, Dictionary<string, object> valores, string nombreID)
        {
            // Crea un comando, usando el nombre de la stored procedure dado y los parametros en el diccionario
            SqlCommand comando = this.comando(nombre, valores);

            // Obtiene el ID de ese objeto, usando el parametro que lo indica
            SqlParameter id = new SqlParameter(nombreID, SqlDbType.Int);
            id.Size = sizeof(int);
            id.Direction = ParameterDirection.Output;
            comando.Parameters.Add(id);

            // Obtiene el tipo de error
            SqlParameter retorno = new SqlParameter("@FLAG_ERROR", SqlDbType.Int);
            retorno.Size = sizeof(int);
            retorno.Direction = ParameterDirection.Output;
            comando.Parameters.Add(retorno);

            // Obtiene el mensaje de error
            SqlParameter mensaje = new SqlParameter("@MENSAJE", SqlDbType.VarChar);
            mensaje.Size = 255 * sizeof(char);
            mensaje.Direction = ParameterDirection.Output;
            comando.Parameters.Add(mensaje);

            // Ejecuta la stored procedure y obtiene su respuesta
            comando.ExecuteNonQuery();
            Respuesta respuesta = new Respuesta();
            respuesta.Codigo = (int)retorno.Value;
            respuesta.Mensaje = mensaje.Value.ToString();
            // Si todo salio bien, obtiene el ID del objeto creado
            if (respuesta.Codigo == 0)
            {
                respuesta.Id = (int)id.Value;
            }
            

            return respuesta;
        }

        public Respuesta modificacion(String nombre, Dictionary<string, object> valores)
        {
            // Crea un comando, usando el nombre de la stored procedure dado y los parametros en el diccionario
            SqlCommand comando = this.comando(nombre, valores);

            // Obtiene el tipo de error
            SqlParameter retorno = new SqlParameter("@FLAG_ERROR", SqlDbType.Int);
            retorno.Size = sizeof(int);
            retorno.Direction = ParameterDirection.Output;
            comando.Parameters.Add(retorno);

            // Obtiene el mensaje de error
            SqlParameter mensaje = new SqlParameter("@MENSAJE", SqlDbType.VarChar);
            mensaje.Size = 255 * sizeof(char);
            mensaje.Direction = ParameterDirection.Output;
            comando.Parameters.Add(mensaje);

            // Ejecuta la stored procedure y obtiene su respuesta
            comando.ExecuteNonQuery();
            Respuesta respuesta = new Respuesta();
            respuesta.Codigo = (int)retorno.Value;
            respuesta.Mensaje = mensaje.Value.ToString();

            return respuesta;
        }



        public Respuesta obtenerConEfecto(String nombre, Dictionary<string, object> valores)
        {
            // Crea un comando, usando el nombre de la stored procedure dado y los parametros en el diccionario      
            SqlCommand comando = this.comando(nombre, valores);

            // Obtiene el tipo de error
            SqlParameter retorno = new SqlParameter("@ID_ERROR", SqlDbType.Int);
            retorno.Size = sizeof(int);
            retorno.Direction = ParameterDirection.Output;
            comando.Parameters.Add(retorno);

            // Obtiene el mensaje de error
            SqlParameter mensaje = new SqlParameter("@DESC_ERROR", SqlDbType.VarChar);
            mensaje.Size = 255 * sizeof(char);
            mensaje.Direction = ParameterDirection.Output;
            comando.Parameters.Add(mensaje);

            // Ejecuta la stored procedure y obtiene su respuesta
            Respuesta respuesta = new Respuesta();

            SqlDataReader reader = comando.ExecuteReader();
            // Tambien guarda una tabla, que devuelve esta stored procedure
            respuesta.Tabla = new DataTable();
            respuesta.Tabla.Load(reader);

            respuesta.Codigo = (int)retorno.Value;
            respuesta.Mensaje = mensaje.Value.ToString();
            return respuesta;
        }

        public Respuesta obtener(String nombre, Dictionary<string, object> valores)
        {
            // Crea un comando, usando el nombre de la stored procedure dado y los parametros en el diccionario      
            SqlCommand comando = this.comando(nombre, valores);

            Respuesta respuesta = new Respuesta();

            // Ejecuta la stored procedure y obtiene su respuesta
            SqlDataReader reader = comando.ExecuteReader();
            // Guarda la tabla con los datos obtenidos en la respuesta
            respuesta.Tabla = new DataTable();
            respuesta.Tabla.Load(reader);

            // Si llego hasta aca, es porque todo salio bien
            // Pone el codigo en 0, sin error
            respuesta.Codigo = 0;
            respuesta.Mensaje = "";
            return respuesta;
        }

        public Respuesta obtener(String nombre)
        {
            // Crea un comando, usando el nombre de la stored procedure dado
            // El diccionario vacio es porque no se necesitan parametros
            SqlCommand comando = this.comando(nombre, new Dictionary<string, object>());
            
            Respuesta respuesta = new Respuesta();

            // Ejecuta la stored procedure y obtiene su respuesta
            SqlDataReader reader = comando.ExecuteReader();
            // Guarda la tabla con los datos obtenidos en la respuesta
            respuesta.Tabla = new DataTable();
            respuesta.Tabla.Load(reader);

            // Si llego hasta aca, es porque todo salio bien
            // Pone el codigo en 0, sin error
            respuesta.Codigo = 0;
            respuesta.Mensaje = "";
            return respuesta;
        }

        public Respuesta logear(Usuario usuario)
        {
            // Crea un comando con el nombre de Login y los parametros del usuario a logear
            SqlCommand comando = this.comando("LOGIN_USUARIO", new Dictionary<string, object> { { "username", usuario.Username }, { "password", usuario.Password } });

            // Obtiene el tipo de error
            SqlParameter retorno = new SqlParameter("@ID_ERROR", SqlDbType.Int);
            retorno.Size = sizeof(int);
            retorno.Direction = ParameterDirection.Output;
            comando.Parameters.Add(retorno);

            // Obtiene el mensaje de error
            SqlParameter mensaje = new SqlParameter("@DESC_ERROR", SqlDbType.VarChar);
            mensaje.Size = 255 * sizeof(char);
            mensaje.Direction = ParameterDirection.Output;
            comando.Parameters.Add(mensaje);

            // Obtiene el id del usuario
            SqlParameter idUsuario = new SqlParameter("@ID_USUARIO", SqlDbType.VarChar);
            idUsuario.Size = sizeof(int);
            idUsuario.Direction = ParameterDirection.Output;
            comando.Parameters.Add(idUsuario);

            // Ejecuta la stored procedure y obtiene su respuesta
            comando.ExecuteNonQuery();
            
            Respuesta respuesta = new Respuesta();
            respuesta.Codigo = (int)retorno.Value;
            respuesta.Mensaje = mensaje.Value.ToString();

            // Si todo salio bien, obtiene el id del usuario y lo almacena en el repositorio
            if (respuesta.Codigo == 0)
            {
                this.repositorio[typeof(Usuario)] = new Dictionary<int, object>();
                this.repositorio[typeof(Usuario)][Convert.ToInt32(idUsuario.Value)] = usuario;
            }

            return respuesta;
        }

        protected Respuesta crear(string procedure, Dictionary<string, object> valores, object objeto)
        {
            // Crea al objeto segun el nombre de la procedure y el diccionario
            Respuesta respuesta = this.creacion(procedure, valores);
            if(respuesta.Codigo == 0)
            {
                // Si todo salio bien, crea el objeto en el repositorio
                this.crearSiNoExiste(objeto.GetType(), respuesta.Id, objeto);
            }
            return respuesta;
        }

        protected Respuesta crear(string procedure, Dictionary<string, object> valores, object objeto, string nombreID)
        {
            // Crea al objeto segun el nombre de la procedure, el diccionario y el nombre del ID devuelto
            Respuesta respuesta = this.creacion(procedure, valores, nombreID);
            if (respuesta.Codigo == 0)
            {
                // Si todo salio bien, crea el objeto en el repositorio
                this.crearSiNoExiste(objeto.GetType(), respuesta.Id, objeto);
            }
            return respuesta;
        }

        protected void agregarParcialmenteCargado(Type tipo)
        {
            // Agrega un tipo al repositorio de parcialmente cargados
            if(!this.parcialmenteCargados.ContainsKey(tipo))
            {
                this.parcialmenteCargados.Add(tipo, new Dictionary<int, object>());
            }
        }

        protected void agregarParcialmenteCargado(Type tipo, int id, object objeto)
        {
            // Agrega un objeto al repositorio de parcialmente cargados
            // Asegurando que exista su tipo
            this.agregarParcialmenteCargado(tipo);
            this.parcialmenteCargados[tipo].Add(id, objeto);
        }

        public List<T> agregar<T>(Respuesta respuesta, Func<DataRow, T> funcion, string idName)
        {
            // Agrega un objeto al repositorio
            // Mergeando si existe en los parcialmente cargados
            // Pisandolo si ya existe
            List<T> lista = new List<T>();
            foreach(var row in respuesta.Tabla.AsEnumerable())
            {
                int id = Convert.ToInt32(row[idName]);
                T nuevo = funcion(row);
                if (this.existe(nuevo.GetType(), id))
                {
                    this.repositorio[nuevo.GetType()][id] = nuevo;
                }
                else
                {
                    this.crearSiNoExiste(nuevo.GetType(), id, nuevo);
                }
                
                if(this.parcialmenteCargados.ContainsKey(nuevo.GetType()) && this.parcialmenteCargados[nuevo.GetType()].ContainsKey(id))
                {
                    this.parcialmenteCargados[nuevo.GetType()][id] = this.repositorio[nuevo.GetType()][id];
                }
                
                lista.Add(nuevo);
            }
            return lista;
        }

        public void crearSiNoExiste(Type tipo, int id, object valor)
        {
            // Crea al objeto en el repositorio solo si no existe todavia
            if (!this.repositorio.ContainsKey(tipo))
            {
                this.repositorio[tipo] = new Dictionary<int, object>();
            }
            if(!this.repositorio[tipo].ContainsKey(id))
            {
                this.repositorio[tipo][id] = valor;
            }
        }

        public bool existe(Type tipo)
        {
            // Devuelve si el tipo existe en el repositorio
            return this.repositorio.ContainsKey(tipo);
        }

        public bool existe(Type tipo, int id)
        {
            // Devuelve si el tipo e id existen en el repositorio
            return this.existe(tipo) && this.repositorio[tipo].ContainsKey(id);
        }

        public int id(object objeto)
        {
            // Obtiene el ID segun el objeto dado
            // Infiere su tipo y se fija si el repositorio lo contiene
            // Tambien se fija si existe en parcialmente cargados
            if(this.repositorio.ContainsKey(objeto.GetType()) && this.repositorio[objeto.GetType()].ContainsValue(objeto))
            {
                return this.repositorio[objeto.GetType()].FirstOrDefault(x => x.Value == objeto).Key;
            }
            else if (this.parcialmenteCargados.ContainsKey(objeto.GetType()) && this.parcialmenteCargados[objeto.GetType()].ContainsValue(objeto))
            {
                return this.parcialmenteCargados[objeto.GetType()].FirstOrDefault(x => x.Value == objeto).Key;
            }
            return -1;
        }

        public object encontrar(Type tipo, int id)
        {
            // Devuelve al objeto del repositorio (parcialmente cargado o no)
            // Segun tipo e ID
            if (this.repositorio.ContainsKey(tipo) && this.repositorio[tipo].ContainsKey(id))
            {
                return this.repositorio[tipo][id];
            }
            else if (this.parcialmenteCargados.ContainsKey(tipo) && this.parcialmenteCargados[tipo].ContainsKey(id))
            {
                return this.parcialmenteCargados[tipo][id];
            }
            return null;
        }

        protected List<T> obtenerDeRepositorio<T>(Type t)
        {
            // Devuelve la lista de objetos de un mismo tipo
            return this.repositorio[t].Values.Cast<T>().ToList();
        }


        public List<Rubro> obtenerRubros()
        {
            // Obtiene los rubros si no existian
            if(!this.repositorio.ContainsKey(typeof(Rubro)))
            {
                Respuesta respuesta = this.obtener("GET_RUBROS");

                // Especifica como agregar un rubro nuevo en base a una row de la tabla devuelta por la DB
                this.agregar<Rubro>(respuesta, delegate (DataRow row)
                {
                    return new Rubro() { Descripcion = Convert.ToString(row["DESCRIPCION"]) };
                }, "ID_RUBRO");
            }
            // Devuelve los objetos con el tipo Rubro
            return this.obtenerDeRepositorio<Rubro>(typeof(Rubro));
        }

        public List<Empresa> obtenerEmpresas(string nombre, string cuit, Rubro rubro, bool activa)
        {
            // Verifica si existen las empresas
            if (!this.existe(typeof(Empresa)))
            {
                // Obtiene los rubros si no existian
                this.obtenerRubros();

                // Obtiene las empresas de la DB
                Respuesta respuesta = this.obtener("GET_EMPRESAS", new Dictionary<string, object>() { { "nombre", nombre }, { "cuit", cuit }, { "id_rubro", rubro == null ? 0 : this.id(rubro) } });

                // Especifica como agregar un rubro nuevo en base a una row de la tabla devuelta por la DB
                this.agregar<Empresa>(respuesta, delegate (DataRow row)
                {
                    return new Empresa()
                    {
                        Nombre = Convert.ToString(row["NOMBRE"]),
                        Cuit = Convert.ToString(row["CUIT"]),
                        Direccion = Convert.ToString(row["DIRECCION"]),
                        Rubro = (Rubro)this.repositorio[typeof(Rubro)][Convert.ToInt32(row["ID_RUBRO"])],
                        DiaRendicion = Convert.ToInt32(row["DIA_REND"]),
                        Activo = Convert.ToBoolean(row["ACTIVO"]),
                    };
                }, "ID_EMPRESA");
            }
            // Devuelve los objetos con el tipo Empresa
            // Segun el nombre y cuit dados (si existen)
            // Y segun el rubro y si esta activa o no (si se especifica)
            return this.obtenerDeRepositorio<Empresa>(typeof(Empresa)).Where(empresa =>
                UtilFunctions.Contains(empresa.Nombre, nombre) &&
                UtilFunctions.Contains(empresa.Cuit, cuit) &&
                ((rubro != null) ? empresa.Rubro == rubro : true) &&
                ((activa == true) ? empresa.Activo : true)
            ).ToList();
        }


        public List<Funcionalidad> obtenerFuncionalidades()
        {
            // Verifica si existen las funcionalidades
            if (!this.existe(typeof(Funcionalidad)))
            {
                // Obtiene las funcionalidades de la DB
                Respuesta respuesta = this.obtener("GET_ALL_FUNCIONALIDADES", new Dictionary<string, object>());

                // Especifica como agregar una funcionalidad nueva en base a una row de la tabla devuelta por la DB
                this.agregar<Funcionalidad>(respuesta, delegate (DataRow row)
                {
                    return new Funcionalidad()
                    {
                        Descripcion = Convert.ToString(row["DESCRIPCION"])
                    };
                }, "ID_FUNCIONALIDAD");                
            }
            // Devuelve los objetos del tipo Funcionalidad
            return this.obtenerDeRepositorio<Funcionalidad>(typeof(Funcionalidad));
        }

        public List<RendicionFacturas> obtenerRendiciones()
        {
            // Verifica si existen las rendiciones
            if (!this.existe(typeof(RendicionFacturas)))
            {
                // Obtiene las empresas si no existian
                if (!this.existe(typeof(Empresa)))
                {
                    this.obtenerEmpresas("", "", null, false);
                }

                // Obtiene las rendiciones de la DB
                Respuesta respuesta = this.obtener("GET_RENDICIONES");
                // Especifica como agregar una funcionalidad nueva en base a una row de la tabla devuelta por la DB
                this.agregar<RendicionFacturas>(respuesta, delegate (DataRow row)
                {                    
                    RendicionFacturas rendicion = new RendicionFacturas() { Empresa = (Empresa)this.repositorio[typeof(Empresa)][Convert.ToInt32(row["ID_EMPRESA"])], Fecha = Convert.ToDateTime(row["FECHA_REDENCION"])};
                    return rendicion;
                }, "NRO_REDENCION");                
            }
            return this.obtenerDeRepositorio<RendicionFacturas>(typeof(RendicionFacturas));            
        }

        public void obtenerRolesParaUsuario(Usuario usuario)
        {
            // Obtiene los roles del usuario
            Respuesta respuesta = this.obtenerConEfecto("GET_ROLES_POR_USUARIO", new Dictionary<string, object>() { { "ID_USUARIO", this.repositorio[typeof(Usuario)].Keys.FirstOrDefault() } });

            // Crea cada Rol en base a la tabla respuesta
            // Los agrega al usuario y a los parcialmente cargados
            foreach (DataRow row in respuesta.Tabla.Rows)
            {
                int id = Convert.ToInt32(row["ID_ROL"]);
                if (!this.existe(typeof(Rol), id))
                {
                    Rol rol = new Rol() { Nombre = Convert.ToString(row["DESCRIPCION"]), Activo = Convert.ToBoolean(row["ACTIVO"]) };
                    this.agregarParcialmenteCargado(typeof(Rol), id, rol);
                }
                if (this.repositorio.ContainsKey(typeof(Rol)) && this.repositorio[typeof(Rol)].ContainsKey(id))
                {
                    usuario.Roles.Add((Rol)this.repositorio[typeof(Rol)][id]);
                }
                else if (this.parcialmenteCargados[typeof(Rol)].ContainsKey(id))
                {
                    usuario.Roles.Add((Rol)this.parcialmenteCargados[typeof(Rol)][id]);
                }
            }
        }

        public void obtenerFuncionalidadesPorRol(Rol rol)
        {
            // Obtiene las funcionalidades del rol
            Respuesta respuesta = this.obtenerConEfecto("GET_FUNCIONALIDADES_POR_ROL", new Dictionary<string, object>() { { "DESCRIPCION", rol.Nombre } });

            // Crea cada Funcionalidad en base a la tabla respuesta
            // Los agrega al Rol y a los parcialmente cargados
            foreach (DataRow row in respuesta.Tabla.Rows)
            {
                int id = Convert.ToInt32(row["ID_FUNCIONALIDAD"]);

                if (!this.existe(typeof(Funcionalidad), id))
                {
                    Funcionalidad funcionalidadDeRol = new Funcionalidad() { Descripcion = Convert.ToString(row["DESCRIPCION"]) };
                    this.agregarParcialmenteCargado(typeof(Funcionalidad), id, funcionalidadDeRol);
                }
                if (this.repositorio.ContainsKey(typeof(Funcionalidad)) && this.repositorio[typeof(Funcionalidad)].ContainsKey(id))
                {
                    rol.Funcionalidades.Add(id);
                }
                else if (this.parcialmenteCargados[typeof(Funcionalidad)].ContainsKey(id))
                {
                    rol.Funcionalidades.Add(id);
                }
            }
        }

        public void obtenerSucursalesParaUsuario(Usuario usuario)
        {
            // Obtiene las sucursales del usuario
            Respuesta respuesta = this.obtenerConEfecto("GET_SUCURSALES_POR_USUARIO", new Dictionary<string, object>() { { "ID_USUARIO", this.repositorio[typeof(Usuario)].Keys.FirstOrDefault() } });

            // Crea cada Sucursal en base a la tabla respuesta
            // Las agrega al usuario y a los parcialmente cargados
            foreach (DataRow row in respuesta.Tabla.Rows)
            {
                int id = Convert.ToInt32(row["ID_SUCURSAL"]);
                if (!this.existe(typeof(Sucursal), id))
                {
                    Sucursal sucursalDeUsuario = new Sucursal() { Nombre = Convert.ToString(row["NOMBRE"]), Activa = Convert.ToBoolean(row["ACTIVO"]) };
                    this.agregarParcialmenteCargado(typeof(Sucursal), id, sucursalDeUsuario);
                }
                if(this.repositorio.ContainsKey(typeof(Sucursal)) && this.repositorio[typeof(Sucursal)].ContainsKey(id))
                {
                    usuario.Sucursales.Add((Sucursal)this.repositorio[typeof(Sucursal)][id]);
                }
                else if(this.parcialmenteCargados[typeof(Sucursal)].ContainsKey(id))
                {
                    usuario.Sucursales.Add((Sucursal)this.parcialmenteCargados[typeof(Sucursal)][id]);
                }
            }
        }

        public List<Sucursal> obtenerSucursales(string nombre, string direccion, int codigoPostal, bool activas)
        {
            // Verifica si existen las sucursales
            if (!this.existe(typeof(Sucursal)))
            {
                // Obtiene las sucursales de la DB sin filtros
                Respuesta respuesta = this.obtener("GET_SUCURSALES", new Dictionary<string, object>() {
                    { "nombre", ""},
                    { "direccion", ""},
                    { "codigo_postal", 0},
                });

                // Crea y agrega las sucursales especificando como procesar una row de la tabla de la DB
                this.agregar<Sucursal>(respuesta,
                    delegate (DataRow row)
                    {
                        return new Sucursal()
                        {
                            Nombre = Convert.ToString(row["NOMBRE"]),
                            Direccion = Convert.ToString(row["DIRECCION"]),
                            CodigoPostal = Convert.ToInt32(row["CODIGO_POSTAL"]),
                            Activa = Convert.ToBoolean(row["ACTIVO"])
                        };
                }, "ID_SUCURSAL");                
            }

            // Devuelve las Sucursales
            // Segun (si se requiere) nombre, direccion, codigo postal y si estan activas
            return this.obtenerDeRepositorio<Sucursal>(typeof(Sucursal)).Where(sucursal =>
                UtilFunctions.Contains(sucursal.Nombre, nombre) &&
                UtilFunctions.Contains(sucursal.Direccion, direccion) &&
                ((codigoPostal != 0) ? sucursal.CodigoPostal == codigoPostal : true) &&
                (activas == true ? (sucursal.Activa) : true)).ToList();
        }
        
        public List<Factura> obtenerFacturas()
        {
            // Verifica si existen las facturas
            if (!this.existe(typeof(Factura)))
            {
                // Obtiene las facturas de la DB
                Respuesta respuesta = this.obtener("GET_FACTURAS_NO_PAGA");

                // Crea y agrega las facturas especificando como procesar una row de la tabla de la DB
                this.agregar<Factura>(respuesta,
                    delegate (DataRow row)
                    {
                        // Obtiene clientes y empresas si no existian
                        if (!this.existe(typeof(Cliente), Convert.ToInt32(row["ID_CLIENTE"])))
                        {
                            this.obtenerClientes(null, null, 0, false);
                        }
                        if (!this.existe(typeof(Empresa), Convert.ToInt32(row["ID_EMPRESA"])))
                        {
                            this.obtenerEmpresas("", "", null, false);
                        }

                        // Crea y agrega las facturas especificando como procesar una row de la tabla de la DB
                        return new Factura()
                        {
                            NumeroFactura = Convert.ToInt32(row["NRO_FACTURA"]),
                            Cliente = (Cliente)this.repositorio[typeof(Cliente)][Convert.ToInt32(row["ID_CLIENTE"])],
                            Empresa = (Empresa)this.repositorio[typeof(Empresa)][Convert.ToInt32(row["ID_EMPRESA"])],
                            Creacion = Convert.ToDateTime(row["FECHA"]),
                            Vencimiento = Convert.ToDateTime(row["FECHA_VENCIMIENTO"]),
                            Total = Convert.ToDouble(row["TOTAL"]),
                            Paga = Convert.ToBoolean(row["PAGADO"]),
                            Rendida = Convert.ToBoolean(row["RENDIDO"])
                        };
                    }, "NRO_FACTURA");
            }
            // Devuelve las Facturas
            return this.obtenerDeRepositorio<Factura>(typeof(Factura)).ToList();
        }

        public List<Factura> obtenerFacturas(Empresa empresa)
        {
            // Obtiene las facturas segun empresa
            return this.obtenerFacturas().Where(factura => empresa == null || factura.Empresa == empresa).ToList();
        }

        public List<Factura> obtenerFacturasPagas()
        {
            // Obtiene las facturas segun si fueron pagas o no
            return this.obtenerFacturas().Where(factura => factura.Paga).ToList();
        }
        

        public List<Rol> obtenerRoles(string descripcion, bool activo)
        {
            // Verifica si existen los Roles
            if (!this.existe(typeof(Rol)))
            {
                // Obtiene los Roles de la DB
                Respuesta respuesta = this.obtener("GET_ROLES_POR_DESCRIPCION", new Dictionary<string, object>() { { "DESCRIPCION_ROL", "" } });

                // Crea y agrega los Roles especificando como procesar una row de la tabla de la DB
                this.agregar<Rol>(respuesta,
                    delegate (DataRow row)
                    {
                        Rol rol = new Rol()
                        {
                            Nombre = Convert.ToString(row["DESCRIPCION"]),
                            Activo = Convert.ToBoolean(row["ACTIVO"]),                                             
                        };
                        this.obtenerFuncionalidadesPorRol(rol);
                        return rol;
                }, "ID_ROL");                
            }

            // Devuelve las Facturas
            return this.obtenerDeRepositorio<Rol>(typeof(Rol)).Where(rol => UtilFunctions.Contains(rol.Nombre, descripcion) && (activo == true) ? rol.Activo : true).ToList();
        }


        public List<Cliente> obtenerClientes(string nombre, string apellido, int dni, bool activo)
        {
            // Verifica si existen los Clientes
            if (!this.existe(typeof(Cliente)))
            {
                // Obtiene los Clientes de la DB
                Respuesta respuesta = this.obtener("GET_CLIENTES", new Dictionary<string, object>()
                {
                    { "nombre", ""},
                    { "apellido", ""},
                    { "DNI", 0}, }
                );

                // Crea y agrega los Clientes especificando como procesar una row de la tabla de la DB
                this.agregar<Cliente>(respuesta,
                    delegate (DataRow row)
                    {
                        return new Cliente()
                        {
                            Nombre = Convert.ToString(row["NOMBRE"]),
                            Apellido = Convert.ToString(row["APELLIDO"]),
                            DNI = Convert.ToInt32(row["DNI"]),
                            Direccion = Convert.ToString(row["DIRECCION"]),
                            Telefono = Convert.ToInt32(row["TELEFONO"]),
                            Email = Convert.ToString(row["MAIL"]),
                            FechaDeNacimiento = Convert.ToDateTime(row["F_NACIMIENTO"]),
                            CodigoPostal = Convert.ToInt32(row["CODIGO_POSTAL"]),
                            Activo = Convert.ToBoolean(row["ACTIVO"]),
                        };
                    }, "ID_CLIENTE");
            }
            // Devuelve los Clientes
            // Filtrando (si se requiere) por nombre, apellido, dni y si estan activos
            return this.obtenerDeRepositorio<Cliente>(typeof(Cliente)).Where(cliente => 
                UtilFunctions.Contains(cliente.Nombre, nombre) &&
                UtilFunctions.Contains(cliente.Apellido, apellido) && 
                ((dni != 0) ? cliente.DNI == dni : true) &&
                ((activo == true) ? cliente.Activo : true)
            ).ToList();
        }

        public List<FormaDePago> obtenerFormasDePago()
        {
            // Verifica si existen las Formas de Pago   
            if (!this.existe(typeof(FormaDePago)))
            {
                // Busca las formas de pago en la DB
                Respuesta respuesta = this.obtener("GET_FORMAS_PAGO", new Dictionary<string, object>() { });
                
                // Crea y agrega las formas de pago especificando como procesar una row de la tabla de la DB
                this.agregar<FormaDePago>(respuesta,
                    delegate (DataRow row)
                    {
                        return new FormaDePago()
                        {
                            Descripcion = Convert.ToString(row["DESCRIPCION"])
                        };
                    }, "ID_FORMA_PAGO");                
            }
            // Devuelve las formas de pago
            return this.obtenerDeRepositorio<FormaDePago>(typeof(FormaDePago));
        }

        public List<ItemFactura> obtenerItemsFactura(Factura factura)
        {
            // Busca los Items de Factura para una Factura dada  
            Respuesta respuesta = this.obtener("GET_ITEMS", new Dictionary<string, object>() { {"nro_factura", factura.NumeroFactura } });

            // Crea y agrega los Items de Factura especificando como procesar una row de la tabla de la DB
            this.agregar<ItemFactura>(respuesta,
                delegate (DataRow row)
                {
                    return new ItemFactura()
                    {
                        Cantidad = Convert.ToInt32(row["CANTIDAD"]),
                        Monto = Convert.ToDouble(row["MONTO"]),
                        Factura = factura,
                    };
                }, "ID_ITEM");
            
            // Devuelve los items de la factura dada
            return this.obtenerDeRepositorio<ItemFactura>(typeof(ItemFactura)).Where(item => item.Factura == factura).ToList();
        }

        public Respuesta crearRol(Rol rolNuevo)
        {
            // Ejecuta el comando de creacion de Rol
            Respuesta respuesta = this.creacion("SP_ABM_ROL_ALTA", new Dictionary<string, object>() { { "DESC_ROL", rolNuevo.Nombre } });
            if(respuesta.Codigo != 0)
            {
                return respuesta;
            }
            else
            {
                // Si todo salio bien
                // Agrega funcionalidades del rol avisando a la DB
                Respuesta respuestaFuncionalidad;
                foreach (int funcionalidad in rolNuevo.Funcionalidades)
                {
                    respuestaFuncionalidad = this.modificacion("SP_ABM_ROL_AGREGAR_FUNCIONALIDAD", new Dictionary<string, object>() { { "DESC_ROL", rolNuevo.Nombre }, { "DESC_FUNCIONALIDAD", ((Funcionalidad)this.encontrar(typeof(Funcionalidad), funcionalidad)).Descripcion } });
                    if(respuestaFuncionalidad.Codigo != 0)
                    {
                        return respuestaFuncionalidad;
                    }
                }
                // Crea el objeto en el repositorio
                this.crearSiNoExiste(typeof(Rol), respuesta.Id, rolNuevo);
                return respuesta;
            }            
        }

        public Respuesta crearEmpresa(Empresa nueva)
        {
            // Ejecuta el comando de creacion de Empresa
            Respuesta respuesta =  this.crear("SP_ABM_EMPRESA_ALTA", new Dictionary<string, object>() {
                {"nombre", nueva.Nombre},
                {"cuit", nueva.Cuit},
                {"direccion", nueva.Direccion},
                {"id_rubro", this.id(nueva.Rubro)},  
                {"dia_rend", nueva.DiaRendicion},  
            }, nueva);
            if(respuesta.Codigo == 0)
            {
                // Crea el objeto en el repositorio
                this.crearSiNoExiste(typeof(Empresa), respuesta.Id, nueva);
            }
            return respuesta;
        }

        public Respuesta crearSucursal(Sucursal nueva)
        {
            // Ejecuta el comando de creacion de la sucursal
            Respuesta respuesta = this.crear("SP_ABM_SUCURSAL_ALTA", new Dictionary<string, object>() {
                {"nombre", nueva.Nombre},                
                {"direccion", nueva.Direccion},
                {"codigo_postal", nueva.CodigoPostal },
            }, nueva);

            if (respuesta.Codigo == 0)
            {
                // Crea el objeto en el repositorio
                this.crearSiNoExiste(typeof(Sucursal), respuesta.Id, nueva);
            }
            return respuesta;
        }


        public Respuesta crearCliente(Cliente nuevo)
        {
            // Ejecuta el comando de creacion del Cliente
            Respuesta respuesta = this.crear("SP_ABM_CLIENTE_ALTA", new Dictionary<string, object>() {
                {"nombre", nuevo.Nombre},
                {"apellido", nuevo.Apellido},
                {"DNI", nuevo.DNI },                
                {"direccion", nuevo.Direccion},
                {"telefono", nuevo.Telefono },
                {"mail", nuevo.Email},
                {"fec_nac", nuevo.FechaDeNacimiento },
                {"codigo_postal", nuevo.CodigoPostal },
            }, nuevo);

            if (respuesta.Codigo == 0)
            {
                // Crea el objeto en el repositorio
                this.crearSiNoExiste(typeof(Cliente), respuesta.Id, nuevo);
            }
            return respuesta;
        }


        public Respuesta crearFactura(Factura nueva)
        {
            // Ejecuta el comando de creacion de la Factura
            Respuesta respuesta = this.crear("SP_ABM_FACTURACION_ALTA", new Dictionary<string, object>() {
                {"id_cliente", this.id(nueva.Cliente)},
                {"id_empresa", this.id(nueva.Empresa)},
                {"fecha", nueva.Creacion},
                {"fecha_vencimiento", nueva.Vencimiento},
            }, nueva, "NRO_FACTURA");

            if(respuesta.Codigo == 0)
            {
                // Crea cada Item Factura, usando el comando de DB
                Respuesta respuestaItems;
                foreach (ItemFactura itemFactura in nueva.Items)
                {
                    respuestaItems = this.creacion("SP_ABM_ITEM_FACTURA_ALTA", new Dictionary<string, object>() { { "NRO_FACTURA", respuesta.Id}, { "CANTIDAD", itemFactura.Cantidad }, {"MONTO", itemFactura.Monto } });
                    if (respuestaItems.Codigo != 0)
                    {
                        return respuestaItems;
                    }
                }
                nueva.NumeroFactura = respuesta.Id;
                // Crea el objeto en el repositorio
                this.crearSiNoExiste(typeof(Factura), respuesta.Id, nueva);                
            }
            return respuesta;
        }

        public Respuesta crearPago(Pago pago)
        {
            // Ejecuta el comando de creacion del Pago
            Respuesta respuesta = this.crear("SP_ABM_PAGO_ALTA", new Dictionary<string, object>() {
                {"fecha", pago.Fecha},
                {"total", pago.Total},
                {"id_forma_pago", this.id(pago.FormaDePago)},
                {"id_sucursal", this.id(Usuario.Logeado.Sucursal)},
                {"id_cliente", this.id(pago.Cliente)},
                {"id_empresa", this.id(pago.Empresa) },
                {"item_pago", 0 },                
            }, pago, "NRO_PAGO");

            if (respuesta.Codigo == 0)
            {
                // Si todo salio bien
                // Crea el pago para cada factura del Pago
                foreach (Factura factura in pago.Facturas)
                {
                    this.crearPagoFactura(pago, factura, respuesta.Id);
                }
                // Crea el objeto en el repositorio
                this.crearSiNoExiste(typeof(Pago), respuesta.Id, pago);
            }
            return respuesta;
        }

        protected Respuesta crearPagoFactura(Pago pago, Factura factura, int nroPago)
        {
            // Crea cada pago de factura
            return this.modificacion("SP_ABM_PAGO_FACTURA_ALTA", new Dictionary<string, object>() {
                {"nro_pago", nroPago},
                {"nro_factura", this.id(factura)},
            });
        }

        public Respuesta crearRendicion(RendicionFacturas rendicion)
        {
            // Ejecuta el comando de creacion de Rendicion
            Respuesta respuesta = this.creacion("SP_ABM_RENDICION_ALTA", new Dictionary<string, object>()
            {
                {"fecha_rendicion", rendicion.Fecha },
                {"id_empresa", this.id(rendicion.Empresa) },
                {"item", 0 },
                {"porcentaje", rendicion.Porcentaje }
            }, "NRO_RENDICION");

            if (respuesta.Codigo == 0)
            {
                // Si todo salio bien
                // Obtiene las rendiciones
                if (!this.existe(typeof(RendicionFacturas)) || this.repositorio[typeof(RendicionFacturas)].Count <= 1)
                {
                    this.obtenerRendiciones();
                }
                // Crea el objeto en el repositorio
                this.crearSiNoExiste(typeof(RendicionFacturas), respuesta.Id, rendicion);
            }
            return respuesta;
        }

        public Respuesta modificarEmpresa(Empresa modificada)
        {
            // Modifica la empresa con la stored procedure
            return this.modificacion("SP_ABM_EMPRESA_MODIFICAR", new Dictionary<string, object>() { {"id_empresa", this.id(modificada) }, { "nombre", modificada.Nombre }, { "cuit", modificada.Cuit }, { "direccion", modificada.Direccion }, { "id_rubro", this.id(modificada.Rubro) }, { "dia_rend", modificada.DiaRendicion } });
        }

        public Respuesta modificarRol(Rol modificado, List<int> aAgregar, List<int> aBorrar)
        {
            // Modifica un Rol con la stored procedure
            Respuesta respuesta = this.modificacion("SP_ABM_ROL_MODIFICAR_NOMBRE", new Dictionary<string, object>() { { "id_rol", this.id(modificado) }, { "desc_rol", modificado.Nombre }});
            if(respuesta.Codigo == 0)
            {
                // Si todo salio bien, tiene que agregar y borrar funcionalidades nuevas/viejas
                // Usa las listas de aAgregar y aBorrar (ver ABMRol)

                Respuesta deFuncionalidad;
                // Para cada funcionalidad a agregar, agrega la relacion con el Rol
                foreach (int funcionalidad in aAgregar)
                {
                    Funcionalidad agregar = (Funcionalidad)this.encontrar(typeof(Funcionalidad), funcionalidad);
                    deFuncionalidad = this.modificacion("SP_ABM_ROL_AGREGAR_FUNCIONALIDAD", new Dictionary<string, object>() { { "desc_rol", modificado.Nombre }, { "desc_funcionalidad", agregar.Descripcion } });
                    if(deFuncionalidad.Codigo != 0)
                    {
                        return deFuncionalidad;
                    }
                }

                // Para cada funcionalidad a borrar, borra la relacion con el Rol
                foreach (int funcionalidad in aBorrar)
                {
                    Funcionalidad borrar = (Funcionalidad)this.encontrar(typeof(Funcionalidad), funcionalidad);
                    deFuncionalidad = this.modificacion("SP_ABM_ROL_QUITAR_FUNCIONALIDAD", new Dictionary<string, object>() { { "desc_rol", modificado.Nombre }, { "desc_funcionalidad", borrar.Descripcion } });
                    if (deFuncionalidad.Codigo != 0)
                    {
                        return deFuncionalidad;
                    }
                }
            }
            return respuesta;
        }

        public Respuesta modificarFactura(Factura modificada, List<ItemFactura> anteriores)
        {
            // Modifica la factura con la stored procedure
            Respuesta respuesta = this.modificacion("SP_ABM_FACTURACION_MODIFICACION", new Dictionary<string, object>()
            {
                {"nro_factura", modificada.NumeroFactura },
                {"id_cliente", this.id(modificada.Cliente) },
                {"id_empresa", this.id(modificada.Empresa) },
                {"fecha", modificada.Creacion },
                {"fecha_vencimiento", modificada.Vencimiento },
            });

            if(respuesta.Codigo == 0)
            {
                
                foreach(ItemFactura item in modificada.Items)
                {
                    Respuesta respuestaItem;
                    if (anteriores.Contains(item))
                    {
                        // Modifica items modificados para la factura
                        respuestaItem = this.modificarItemFactura(item);
                        if(respuestaItem.Codigo != 0)
                        {
                            return respuestaItem;
                        }
                    }
                    else
                    {
                        // Agrega items nuevos
                        respuestaItem = this.creacion("SP_ABM_ITEM_FACTURA_ALTA", new Dictionary<string, object>() { { "NRO_FACTURA", modificada.NumeroFactura }, { "CANTIDAD", item.Cantidad }, { "MONTO", item.Monto } });
                        if (respuestaItem.Codigo != 0)
                        {
                            return respuestaItem;
                        }
                    }
                    Respuesta respuestaBorrar;
                    foreach(ItemFactura itemABorrar in anteriores.Except(modificada.Items))
                    {
                        // Borra items de factura que ya no existan
                        respuestaBorrar = this.borrarItemFactura(itemABorrar);
                        if(respuestaItem.Codigo != 0)
                        {
                            return respuestaBorrar;
                        }
                    }
                }
                return respuesta;
            }
            else
            {
                return respuesta;
            }
        }

        protected Respuesta modificarItemFactura(ItemFactura item)
        {
            // Modifica items de la factura dada con la stored procedure
            return this.modificacion("SP_ABM_ITEMS_FACTURA_MODIFICAR", new Dictionary<string, object>() { { "ID_ITEM", this.id(item) }, { "CANTIDAD", item.Cantidad }, { "MONTO", item.Monto } });
        }

        public Respuesta modificarSucursal(Sucursal modificada)
        {
            // Modifica la sucursal dada con la stored procedure
            return this.modificacion("SP_ABM_SUCURSAL_MODIFICAR", new Dictionary<string, object>() { { "id_sucursal", this.id(modificada) }, { "nombre", modificada.Nombre }, {"direccion", modificada.Direccion }, { "codigo_postal", modificada.CodigoPostal } });
        }

        public Respuesta modificarCliente(Cliente modificado)
        {
            // Modifica al cliente dado con la stored procedure
            return this.modificacion("SP_ABM_CLIENTE_MODIFICAR", new Dictionary<string, object>() { { "id_cliente", this.id(modificado) }, { "nombre", modificado.Nombre }, { "apellido", modificado.Apellido}, { "dni", modificado.DNI }, { "direccion", modificado.Direccion }, { "telefono", modificado.Telefono}, { "mail", modificado.Email }, { "fec_nac", modificado.FechaDeNacimiento }, { "codigo_postal", modificado.CodigoPostal } });
        }


        public Respuesta cambiarEstado(Empresa empresa)
        {            
            // Realiza el borrado logico de la empresa
            Respuesta respuesta = this.modificacion("SP_ABM_EMPRESA_ACTIVAR_DESACTIVAR", new Dictionary<string, object>() { { "id_empresa", this.id(empresa)}, { "activo", empresa.Activo}});
            if(respuesta.Codigo == 0)
            {
                // Si todo salio bien, actualiza su estado
                empresa.Activo = !empresa.Activo;
            }
            return respuesta;
        }

        public Respuesta cambiarEstado(Rol rol)
        {
            // Realiza el borrado logico del rol
            Respuesta respuesta = this.modificacion("SP_ABM_ROL_ACTIVAR_DESACTIVAR", new Dictionary<string, object>() { { "id_rol", this.id(rol) }, { "activo", rol.Activo } });
            if (respuesta.Codigo == 0)
            {
                // Si todo salio bien, actualiza su estado
                rol.Activo = !rol.Activo;
            }
            return respuesta;
        }


        public Respuesta cambiarEstado(Sucursal sucursal)
        {
            // Realiza el borrado logico de la Sucursal
            Respuesta respuesta = this.modificacion("SP_ABM_SUCURSAL_ACTIVAR_DESACTIVAR", new Dictionary<string, object>() { { "id_sucursal", this.id(sucursal) }, { "activo", sucursal.Activa } });
            if (respuesta.Codigo == 0)
            {
                // Si todo salio bien, actualiza su estado
                sucursal.Activa = !sucursal.Activa;
            }
            return respuesta;
        }

        public Respuesta cambiarEstado(Cliente cliente)
        {
            // Realiza el borrado logico del cliente
            Respuesta respuesta =  this.modificacion("SP_ABM_CLIENTE_ACTIVAR_DESACTIVAR", new Dictionary<string, object>() { { "id_cliente", this.id(cliente) }, { "activo", cliente.Activo } });
            if (respuesta.Codigo == 0)
            {
                // Si todo salio bien, actualiza su estado
                cliente.Activo = !cliente.Activo;
            }
            return respuesta;
        }

        public Respuesta borrarItemFactura(ItemFactura item)
        {
            // Borra el item de la factura, no es borrado logico
            return this.modificacion("SP_ABM_ITEMS_FACTURA_ELIMINAR", new Dictionary<string, object>() { { "id_item", this.id(item) } });
        }

        public Respuesta devolverFactura(Factura factura, string motivo)
        {
            // Avisa una devolucion de una factura
            return this.modificacion("DEVOLUCION_FACTURAS_PAGADAS", new Dictionary<string, object>() { { "nro_factura", this.id(factura) }, { "motivo", motivo } });
        }
        
        public Respuesta devolverRendicion(RendicionFacturas rendicion, string motivo)
        {
            // Avisa una devolucion de una rendicion
            return this.modificacion("DEVOLUCION_RENDICION", new Dictionary<string, object>() { { "nro_rendicion", this.id(rendicion) }, { "motivo", motivo } });
        }

        public Respuesta borrarFactura(int nro_factura)
        {
            // Borra logicamente la factura dada
            return this.modificacion("BORRAR_FACTURAS", new Dictionary<string, object>() { { "NRO_FACTURA", nro_factura } });
        }

        public List<object> obtenerListado(Type tipoListado, int anio, int trimestre)
        {
            
            Listado seleccionado = null;//this.listados.Find(listado => listado.GetType() == tipoListado && listado.Anio == anio && listado.Trimestre == trimestre);
            // Obtiene el listado de la DB
            Respuesta respuesta = this.obtener(Configuracion.Configuracion.valor(tipoListado.Name).ToString(), new Dictionary<string, object>()
            {
                {"ANO", anio},
                {"MES_INI", trimestre * 3 - 2},
                {"MES_FIN", trimestre * 3},
            });
            // Si todo salio bien, procesa el listado segun su tipo 
            // Y lo devuelve
            if(respuesta.Codigo == 0)
            {
                Listado listado = (Listado)tipoListado.GetConstructors()[0].Invoke(new object[2] {anio, trimestre});
                listado.procesar(respuesta.Tabla);                    
                this.listados.Add(listado);
                return listado.Filas;
            }
            else
            {
                return new List<object>();
            }
        }

        public void recargarFacturas()
        {
            // Solo si ya estaban cargadas. Si no, no importa
            if(this.existe(typeof(Factura)))
            {
                // Las borra del repositorio y las vuelve a cargar
                this.repositorio.Remove(typeof(Factura));
                this.obtenerFacturas();
            }
        }

        public void recargarRendiciones()
        {
            // Solo si ya estaban cargadas. Si no, no importa
            if (this.existe(typeof(RendicionFacturas)))
            {
                // Las borra del repositorio y las vuelve a cargar
                this.repositorio.Remove(typeof(RendicionFacturas));
                this.obtenerRendiciones();
            }
        }

    }
}
