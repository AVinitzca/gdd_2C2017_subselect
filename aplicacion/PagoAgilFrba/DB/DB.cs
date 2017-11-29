using PagoAgilFrba.Dominio;
using PagoAgilFrba.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PagoAgilFrba.DB
{
    public class DB
    {
        private static readonly DB instancia = new DB();
        private SqlConnection conexion;

        private Dictionary<Type, Dictionary<int, object>> repositorio;
        private List<Type> parcialmenteCargados;
        private List<Listado> listados;
        
		private DB()
        {
            this.repositorio = new Dictionary<Type, Dictionary<int, object>>();
            this.listados = new List<Listado>();
            this.parcialmenteCargados = new List<Type>();

            this.conexion = new SqlConnection();
			this.conexion.ConnectionString = "Data Source=RONAN-PC\\SQLEXPRESS;Initial Catalog=GD2C2017;Integrated Security=True";
			//this.conexion.ConnectionString = "Data Source=localhost\\SQLSERVER2012;Initial Catalog=GD2C2017;Integrated Security=True";
			this.conexion.Open();
        }

        public static DB Instancia
        {
            get
            {
                return instancia;
            }
        }

        protected SqlCommand comando(string nombre, Dictionary<string, object> valores)
        {
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
            SqlCommand comando = this.comando(nombre, valores);
            
            SqlParameter id = new SqlParameter("@ID_" + nombre.Split('_')[2], SqlDbType.Int);
            id.Size = sizeof(int);
            id.Direction = ParameterDirection.Output;
            comando.Parameters.Add(id);

            SqlParameter retorno = new SqlParameter("@FLAG_ERROR", SqlDbType.Int);
            retorno.Size = sizeof(int);
            retorno.Direction = ParameterDirection.Output;
            comando.Parameters.Add(retorno);

            SqlParameter mensaje = new SqlParameter("@MENSAJE", SqlDbType.VarChar);
            mensaje.Size = 255 * sizeof(char);
            mensaje.Direction = ParameterDirection.Output;
            comando.Parameters.Add(mensaje);

            comando.ExecuteNonQuery();
            Respuesta respuesta = new Respuesta();
            
            respuesta.Codigo = (int)retorno.Value;
            respuesta.Mensaje = mensaje.Value.ToString();
            if(respuesta.Codigo == 0)
            {
                respuesta.Id = (int)id.Value;
            }
            

            return respuesta;
        }


        public Respuesta creacion(String nombre, Dictionary<string, object> valores, string nombreID)
        {
            SqlCommand comando = this.comando(nombre, valores);

            SqlParameter id = new SqlParameter(nombreID, SqlDbType.Int);
            id.Size = sizeof(int);
            id.Direction = ParameterDirection.Output;
            comando.Parameters.Add(id);

            SqlParameter retorno = new SqlParameter("@FLAG_ERROR", SqlDbType.Int);
            retorno.Size = sizeof(int);
            retorno.Direction = ParameterDirection.Output;
            comando.Parameters.Add(retorno);

            SqlParameter mensaje = new SqlParameter("@MENSAJE", SqlDbType.VarChar);
            mensaje.Size = 255 * sizeof(char);
            mensaje.Direction = ParameterDirection.Output;
            comando.Parameters.Add(mensaje);

            comando.ExecuteNonQuery();
            Respuesta respuesta = new Respuesta();
            respuesta.Id = (int)id.Value;
            respuesta.Codigo = (int)retorno.Value;
            respuesta.Mensaje = mensaje.Value.ToString();

            return respuesta;
        }

        public Respuesta modificacion(String nombre, Dictionary<string, object> valores)
        {
            SqlCommand comando = this.comando(nombre, valores);
            
            SqlParameter retorno = new SqlParameter("@FLAG_ERROR", SqlDbType.Int);
            retorno.Size = sizeof(int);
            retorno.Direction = ParameterDirection.Output;
            comando.Parameters.Add(retorno);
            
            SqlParameter mensaje = new SqlParameter("@MENSAJE", SqlDbType.VarChar);
            mensaje.Size = 255 * sizeof(char);
            mensaje.Direction = ParameterDirection.Output;
            comando.Parameters.Add(mensaje);

            comando.ExecuteNonQuery();
            Respuesta respuesta = new Respuesta();
            respuesta.Codigo = (int)retorno.Value;
            respuesta.Mensaje = mensaje.Value.ToString();

            return respuesta;
        }



        public Respuesta obtenerConEfecto(String nombre, Dictionary<string, object> valores)
        {            
            SqlCommand comando = this.comando(nombre, valores);

            SqlParameter retorno = new SqlParameter("@ID_ERROR", SqlDbType.Int);
            retorno.Size = sizeof(int);
            retorno.Direction = ParameterDirection.Output;
            comando.Parameters.Add(retorno);

            SqlParameter mensaje = new SqlParameter("@DESC_ERROR", SqlDbType.VarChar);
            mensaje.Size = 255 * sizeof(char);
            mensaje.Direction = ParameterDirection.Output;
            comando.Parameters.Add(mensaje);
                        
            Respuesta respuesta = new Respuesta();

            SqlDataReader reader = comando.ExecuteReader();
            respuesta.Tabla = new DataTable();
            respuesta.Tabla.Load(reader);

            respuesta.Codigo = (int)retorno.Value;
            respuesta.Mensaje = mensaje.Value.ToString();
            return respuesta;
        }

        public Respuesta obtener(String nombre, Dictionary<string, object> valores)
        {
            SqlCommand comando = this.comando(nombre, valores);

            Respuesta respuesta = new Respuesta();

            SqlDataReader reader = comando.ExecuteReader();
            respuesta.Tabla = new DataTable();
            respuesta.Tabla.Load(reader);

            respuesta.Codigo = 0;
            respuesta.Mensaje = "";
            return respuesta;
        }

        public Respuesta obtener(String nombre)
        {
            SqlCommand comando = this.comando(nombre, new Dictionary<string, object>());
            
            Respuesta respuesta = new Respuesta();

            SqlDataReader reader = comando.ExecuteReader();
            respuesta.Tabla = new DataTable();
            respuesta.Tabla.Load(reader);

            respuesta.Codigo = 0;
            respuesta.Mensaje = "";
            return respuesta;
        }

        public Respuesta logear(Usuario usuario)
        {
            SqlCommand comando = this.comando("LOGIN_USUARIO", new Dictionary<string, object> { { "username", usuario.Username }, { "password", usuario.Password } });

            SqlParameter retorno = new SqlParameter("@ID_ERROR", SqlDbType.Int);
            retorno.Size = sizeof(int);
            retorno.Direction = ParameterDirection.Output;
            comando.Parameters.Add(retorno);

            SqlParameter mensaje = new SqlParameter("@DESC_ERROR", SqlDbType.VarChar);
            mensaje.Size = 255 * sizeof(char);
            mensaje.Direction = ParameterDirection.Output;
            comando.Parameters.Add(mensaje);

            SqlParameter idUsuario = new SqlParameter("@ID_USUARIO", SqlDbType.VarChar);
            idUsuario.Size = sizeof(int);
            idUsuario.Direction = ParameterDirection.Output;
            comando.Parameters.Add(idUsuario);
            
            comando.ExecuteNonQuery();
            
            Respuesta respuesta = new Respuesta();
            respuesta.Codigo = (int)retorno.Value;
            respuesta.Mensaje = mensaje.Value.ToString();

            if(respuesta.Codigo == 0)
            {
                this.repositorio[typeof(Usuario)] = new Dictionary<int, object>();
                this.repositorio[typeof(Usuario)][Convert.ToInt32(idUsuario.Value)] = usuario;
            }

            return respuesta;
        }

        protected Respuesta crear(string procedure, Dictionary<string, object> valores, object objeto)
        {
            Respuesta respuesta = this.creacion(procedure, valores);
            if(respuesta.Codigo == 0)
            {
                this.crearSiNoExiste(objeto.GetType(), respuesta.Id, objeto);
            }
            return respuesta;
        }

        protected Respuesta crear(string procedure, Dictionary<string, object> valores, object objeto, string nombreID)
        {
            Respuesta respuesta = this.creacion(procedure, valores, nombreID);
            if (respuesta.Codigo == 0)
            {
                this.crearSiNoExiste(objeto.GetType(), respuesta.Id, objeto);
            }
            return respuesta;
        }

        protected void agregarParcialmenteCargado(Type tipo)
        {
            if(!this.parcialmenteCargados.Contains(tipo))
            {
                this.parcialmenteCargados.Add(tipo);
            }
        }

        public List<T> agregar<T>(Respuesta respuesta, Func<DataRow, T> funcion, string id)
        {
            List<T> lista = new List<T>();
            foreach(var row in respuesta.Tabla.AsEnumerable())
            {
                T nuevo = funcion(row);
                if(this.existe(nuevo.GetType(), Convert.ToInt32(row[id])))
                {
                    this.repositorio[nuevo.GetType()][Convert.ToInt32(row[id])] = nuevo;
                }
                else
                {
                    this.crearSiNoExiste(nuevo.GetType(), Convert.ToInt32(row[id]), nuevo);
                }                
                lista.Add(nuevo);
            }
            return lista;
        }

        public void crearSiNoExiste(Type tipo, int id, object valor)
        {
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
            return this.repositorio.ContainsKey(tipo) && !this.parcialmenteCargados.Contains(tipo);
        }

        public bool existe(Type tipo, int id)
        {
            return this.existe(tipo) && this.repositorio[tipo].ContainsKey(id);
        }

        protected int id(object objeto)
        {
            return this.repositorio[objeto.GetType()].FirstOrDefault(x => x.Value == objeto).Key;
        }

        protected List<T> obtenerDeRepositorio<T>(Type t)
        {
            return this.repositorio[t].Values.Cast<T>().ToList();
        }


        public List<Rubro> obtenerRubros()
        {
            if(!this.repositorio.ContainsKey(typeof(Rubro)))
            {
                Respuesta respuesta = this.obtener("GET_RUBROS");

                this.agregar<Rubro>(respuesta, delegate (DataRow row)
                {
                    return new Rubro() { Descripcion = Convert.ToString(row["DESCRIPCION"]) };
                }, "ID_RUBRO");
            }
            return this.obtenerDeRepositorio<Rubro>(typeof(Rubro));
        }

        public List<Empresa> obtenerEmpresas(string nombre, string cuit, Rubro rubro, bool activa)
        {            
            if(!this.existe(typeof(Empresa)))
            {
                this.obtenerRubros();
                Respuesta respuesta = this.obtener("GET_EMPRESAS", new Dictionary<string, object>() { { "nombre", nombre }, { "cuit", cuit }, { "id_rubro", rubro == null ? 0 : this.id(rubro) } });

                this.parcialmenteCargados.Remove(typeof(Empresa));
                this.agregar<Empresa>(respuesta, delegate (DataRow row)
                {
                    return new Empresa()
                    {
                        Nombre = Convert.ToString(row["NOMBRE"]),
                        Cuit = Convert.ToString(row["CUIT"]),
                        Direccion = Convert.ToString(row["DIRECCION"]),
                        Rubro = (Rubro)this.repositorio[typeof(Rubro)][Convert.ToInt32(row["ID_RUBRO"])],
                        Activo = Convert.ToBoolean(row["ACTIVO"]),
                    };
                }, "ID_EMPRESA");
            }
            return this.obtenerDeRepositorio<Empresa>(typeof(Empresa)).Where(empresa =>
                UtilFunctions.Contains(empresa.Nombre, nombre) &&
                UtilFunctions.Contains(empresa.Cuit, cuit) &&
                ((rubro != null) ? empresa.Rubro == rubro : true) &&
                ((activa == true) ? empresa.Activo : true)
            ).ToList();
        }


        public List<Funcionalidad> obtenerFuncionalidades()
        {
            if(!this.existe(typeof(Funcionalidad)))
            {
                Respuesta respuesta = this.obtener("GET_ALL_FUNCIONALIDADES", new Dictionary<string, object>());

                this.parcialmenteCargados.Remove(typeof(Funcionalidad));
                this.agregar<Funcionalidad>(respuesta, delegate (DataRow row)
                {
                    return new Funcionalidad()
                    {
                        Descripcion = Convert.ToString(row["DESCRIPCION"])
                    };
                }, "ID_FUNCIONALIDAD");                
            }
            return this.obtenerDeRepositorio<Funcionalidad>(typeof(Funcionalidad));
        }

        public List<RendicionFacturas> obtenerRendiciones()
        {
            if(!this.existe(typeof(RendicionFacturas)))
            {
                if (!this.existe(typeof(Empresa)))
                {
                    this.obtenerEmpresas("", "", null, false);
                }

                this.parcialmenteCargados.Remove(typeof(RendicionFacturas));
                Respuesta respuesta = this.obtener("GET_RENDICIONES");
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
            Respuesta respuesta = this.obtenerConEfecto("GET_ROLES_POR_USUARIO", new Dictionary<string, object>() { { "ID_USUARIO", this.repositorio[typeof(Usuario)].Keys.FirstOrDefault() } });

            foreach (DataRow row in respuesta.Tabla.Rows)
            {
                int id = Convert.ToInt32(row["ID_ROL"]);
                if (!this.existe(typeof(Rol), id))
                {
                    Rol rol = new Rol() { Nombre = Convert.ToString(row["DESCRIPCION"]), Activo = Convert.ToBoolean(row["ACTIVO"])};
                    this.obtenerFuncionalidadesPorRol(rol);
                    this.crearSiNoExiste(typeof(Rol), id, rol);
                    this.agregarParcialmenteCargado(typeof(Rol));
                }
                usuario.Roles.Add((Rol)this.repositorio[typeof(Rol)][id]);
            }
        }

        protected void obtenerFuncionalidadesPorRol(Rol rol)
        {
            Respuesta respuesta = this.obtenerConEfecto("GET_FUNCIONALIDADES_POR_ROL", new Dictionary<string, object>() { { "DESCRIPCION", rol.Nombre } });
             
            foreach (DataRow row in respuesta.Tabla.Rows)
            {
                int id = Convert.ToInt32(row["ID_FUNCIONALIDAD"]);
                if (!this.existe(typeof(Funcionalidad), id))
                {
                    Funcionalidad funcionalidadDeRol = new Funcionalidad() { Descripcion = Convert.ToString(row["DESCRIPCION"]) };
                    this.crearSiNoExiste(typeof(Funcionalidad), id, funcionalidadDeRol);
                    this.agregarParcialmenteCargado(typeof(Funcionalidad));
                }
                rol.agregarFuncionalidad((Funcionalidad)this.repositorio[typeof(Funcionalidad)][id]);
            }
        }

        public void obtenerSucursalesParaUsuario(Usuario usuario)
        {
            Respuesta respuesta = this.obtenerConEfecto("GET_SUCURSALES_POR_USUARIO", new Dictionary<string, object>() { { "ID_USUARIO", this.repositorio[typeof(Usuario)].Keys.FirstOrDefault() } });
            
            foreach (DataRow row in respuesta.Tabla.Rows)
            {
                int id = Convert.ToInt32(row["ID_SUCURSAL"]);
                if (!this.existe(typeof(Sucursal), id))
                {
                    Sucursal sucursalDeUsuario = new Sucursal() { Nombre = Convert.ToString(row["NOMBRE"]) };
                    this.crearSiNoExiste(typeof(Sucursal), id, sucursalDeUsuario);
                    this.agregarParcialmenteCargado(typeof(Sucursal));
                }
                usuario.Sucursales.Add((Sucursal)this.repositorio[typeof(Sucursal)][Convert.ToInt32(row["ID_SUCURSAL"])]);
            }
        }

        public List<Sucursal> obtenerSucursales(string nombre, string direccion, int codigoPostal, bool activas)
        {
            if (!this.existe(typeof(Sucursal)))
            {
                Respuesta respuesta = this.obtener("GET_SUCURSALES", new Dictionary<string, object>() {
                    { "nombre", ""},
                    { "direccion", ""},
                    { "codigo_postal", 0},
                });

                this.parcialmenteCargados.Remove(typeof(Sucursal));
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

            return this.obtenerDeRepositorio<Sucursal>(typeof(Sucursal)).Where(sucursal =>
                UtilFunctions.Contains(sucursal.Nombre, nombre) &&
                UtilFunctions.Contains(sucursal.Direccion, direccion) &&
                ((codigoPostal != 0) ? sucursal.CodigoPostal == codigoPostal : true) &&
                (activas == true ? (sucursal.Activa) : true)).ToList();
        }

        public List<Factura> obtenerFacturas(Empresa empresa)
        {
            if (!this.existe(typeof(Factura)))
            {
                if (!this.existe(typeof(Empresa)))
                {
                    this.obtenerEmpresas("", "", null, false);
                }
                Respuesta respuesta = this.obtener("GET_FACTURA_POR_EMPRESA", new Dictionary<string, object>() { { "id_empresa", this.id(empresa) } });

                this.parcialmenteCargados.Remove(typeof(Factura));
                this.agregar<Factura>(respuesta,
                    delegate (DataRow row)
                    {
                        if (!this.existe(typeof(Cliente), Convert.ToInt32(row["ID_CLIENTE"])))
                        {
                            this.obtenerClientes(null, null, 0, false);
                        }
                        return new Factura()
                        {
                            NumeroFactura = Convert.ToInt32(row["NRO_FACTURA"]),
                            Cliente = (Cliente)this.repositorio[typeof(Cliente)][Convert.ToInt32(row["ID_CLIENTE"])],
                            Empresa = empresa,
                            Creacion = Convert.ToDateTime(row["FECHA"]),
                            Vencimiento = Convert.ToDateTime(row["FECHA_VENCIMIENTO"]),
                            Total = Convert.ToDouble(row["TOTAL"]),
                        };
                    }, "NRO_FACTURA");                
            }

            return this.obtenerDeRepositorio<Factura>(typeof(Factura)).Where(factura => empresa == null || factura.Empresa == empresa).ToList();
        }

        public List<Factura> obtenerFacturasPagas()
        {
            Respuesta respuesta = this.obtener("GET_FACTURAS_PAGAS_NO_RENDIDAS", new Dictionary<string, object>());

            List<Factura> facturas = new List<Factura>();
            if(respuesta.Codigo == 0)
            {
                foreach(DataRow row in respuesta.Tabla.Rows)
                {
                    facturas.Add(new Factura() {NumeroFactura = Convert.ToInt32(row["NRO_FACTURA"]), Total = Convert.ToDouble(row["TOTAL"])});                    
                }
            }            
            if(!this.existe(typeof(Factura)))
            {
                this.repositorio.Add(typeof(Factura), new Dictionary<int, object>());
                foreach (Factura factura in facturas)
                {
                    if (!this.repositorio[typeof(Factura)].Values.Contains(factura))
                    {
                        this.repositorio[typeof(Factura)].Add(factura.NumeroFactura, factura);
                    }
                }
            }
            else
            {
                foreach (Factura factura in facturas)
                {
                    if (!this.existe(typeof(Factura), factura.NumeroFactura))
                    {
                        this.repositorio[typeof(Factura)].Add(factura.NumeroFactura, factura);
                    }
                }
            }            
            return facturas;
        }
        

        public List<Rol> obtenerRoles(string descripcion, bool activo)
        {
            if(!this.existe(typeof(Rol)))
            {
                Respuesta respuesta = this.obtener("GET_ROLES_POR_DESCRIPCION", new Dictionary<string, object>() { { "DESCRIPCION_ROL", "" } });

                this.parcialmenteCargados.Remove(typeof(Rol));
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

            return this.obtenerDeRepositorio<Rol>(typeof(Rol)).Where(rol => UtilFunctions.Contains(rol.Nombre, descripcion) && (activo == true) ? rol.Activo : true).ToList();
        }


        public List<Cliente> obtenerClientes(string nombre, string apellido, int dni, bool activo)
        {
            if (!this.existe(typeof(Cliente)))
            {
                Respuesta respuesta = this.obtener("GET_CLIENTES", new Dictionary<string, object>()
                {
                    { "nombre", ""},
                    { "apellido", ""},
                    { "DNI", 0}, }
                );

                this.parcialmenteCargados.Remove(typeof(Cliente));
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
            return this.obtenerDeRepositorio<Cliente>(typeof(Cliente)).Where(cliente => 
                UtilFunctions.Contains(cliente.Nombre, nombre) &&
                UtilFunctions.Contains(cliente.Apellido, apellido) && 
                ((dni != 0) ? cliente.DNI == dni : true) &&
                ((activo == true) ? cliente.Activo : true)
            ).ToList();
        }

        public List<FormaDePago> obtenerFormasDePago()
        {
            if (!this.existe(typeof(FormaDePago)))
            {
                Respuesta respuesta = this.obtener("GET_FORMAS_PAGO", new Dictionary<string, object>() { });

                this.parcialmenteCargados.Remove(typeof(FormaDePago));
                this.agregar<FormaDePago>(respuesta,
                    delegate (DataRow row)
                    {
                        return new FormaDePago()
                        {
                            Descripcion = Convert.ToString(row["DESCRIPCION"])
                        };
                    }, "ID_FORMA_PAGO");                
            }
            return this.obtenerDeRepositorio<FormaDePago>(typeof(FormaDePago));
        }


        public Respuesta crearRol(Rol rolNuevo)
        {
            Respuesta respuesta = this.creacion("SP_ABM_ROL_ALTA", new Dictionary<string, object>() { { "DESC_ROL", rolNuevo.Nombre } });
            if(respuesta.Codigo != 0)
            {
                return respuesta;
            }
            else
            {
                Respuesta respuestaFuncionalidad;
                foreach (Funcionalidad funcionalidad in rolNuevo.Funcionalidades)
                {
                    respuestaFuncionalidad = this.modificacion("SP_ABM_ROL_AGREGAR_FUNCIONALIDAD", new Dictionary<string, object>() { { "DESC_ROL", rolNuevo.Nombre }, { "DESC_FUNCIONALIDAD", funcionalidad.Descripcion } });
                    if(respuestaFuncionalidad.Codigo != 0)
                    {
                        return respuestaFuncionalidad;
                    }
                }
                this.crearSiNoExiste(typeof(Rol), respuesta.Id, rolNuevo);
                return respuesta;
            }            
        }

        public Respuesta crearEmpresa(Empresa nueva)
        {
            Respuesta respuesta =  this.crear("SP_ABM_EMPRESA_ALTA", new Dictionary<string, object>() {
                {"nombre", nueva.Nombre},
                {"cuit", nueva.Cuit},
                {"direccion", nueva.Direccion},
                {"id_rubro", this.id(nueva.Rubro)},                
            }, nueva);
            if(respuesta.Codigo == 0)
            {
                this.crearSiNoExiste(typeof(Empresa), respuesta.Id, nueva);
            }
            return respuesta;
        }

        public Respuesta crearSucursal(Sucursal nueva)
        {
            Respuesta respuesta = this.crear("SP_ABM_SUCURSAL_ALTA", new Dictionary<string, object>() {
                {"nombre", nueva.Nombre},                
                {"direccion", nueva.Direccion},
                {"codigo_postal", nueva.CodigoPostal },
            }, nueva);

            if (respuesta.Codigo == 0)
            {
                this.crearSiNoExiste(typeof(Sucursal), respuesta.Id, nueva);
            }
            return respuesta;
        }


        public Respuesta crearCliente(Cliente nuevo)
        {
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
                this.crearSiNoExiste(typeof(Cliente), respuesta.Id, nuevo);
            }
            return respuesta;
        }


        public Respuesta crearFactura(Factura nueva)
        {
            Respuesta respuesta = this.crear("SP_ABM_FACTURACION_ALTA", new Dictionary<string, object>() {
                {"id_cliente", this.id(nueva.Cliente)},
                {"id_empresa", this.id(nueva.Empresa)},
                {"fecha", nueva.Creacion},
                {"fecha_vencimiento", nueva.Vencimiento},
            }, nueva, "NRO_FACTURA");

            if(respuesta.Codigo == 0)
            {
                Respuesta respuestaItems;
                foreach (ItemFactura itemFactura in nueva.Items)
                {
                    respuestaItems = this.creacion("SP_ABM_ITEM_FACTURA_ALTA", new Dictionary<string, object>() { { "NRO_FACTURA", respuesta.Id}, { "CANTIDAD", itemFactura.Cantidad }, {"MONTO", itemFactura.Monto } });
                    if (respuestaItems.Codigo != 0)
                    {
                        return respuestaItems;
                    }
                }
                this.crearSiNoExiste(typeof(Factura), respuesta.Id, nueva);                
            }
            return respuesta;
        }

        public Respuesta crearPago(Pago pago)
        {
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
                foreach (Factura factura in pago.Facturas)
                {
                    this.crearPagoFactura(pago, factura, respuesta.Id);
                }
                this.crearSiNoExiste(typeof(Pago), respuesta.Id, pago);
            }
            return respuesta;
        }

        protected Respuesta crearPagoFactura(Pago pago, Factura factura, int nroPago)
        {
            return this.modificacion("SP_ABM_PAGO_FACTURA_ALTA", new Dictionary<string, object>() {
                {"nro_pago", nroPago},
                {"nro_factura", this.id(factura)},
            });
        }

        public Respuesta crearRendicion(RendicionFacturas rendicion)
        {
            Respuesta respuesta = this.crear("SP_ABM_RENDICION_ALTA", new Dictionary<string, object>()
            {
                {"fecha_rendicion", rendicion.Fecha },
                {"id_empresa", this.id(rendicion.Empresa) },
                {"item", 0 },
                {"porcentaje", rendicion.Porcentaje }                
            }, rendicion, "NRO_RENDICION");

            if (respuesta.Codigo == 0)
            {
                this.crearSiNoExiste(typeof(RendicionFacturas), respuesta.Id, rendicion);
            }
            return respuesta;
        }

        public Respuesta modificarEmpresa(Empresa modificada)
        {
            return this.modificacion("SP_ABM_EMPRESA_MODIFICAR", new Dictionary<string, object>() { {"id_empresa", this.id(modificada) }, { "nombre", modificada.Nombre }, { "cuit", modificada.Cuit }, { "direccion", modificada.Direccion }, { "id_rubro", this.id(modificada.Rubro) } });
        }

        public Respuesta modificarRol(Rol modificado, List<Funcionalidad> aAgregar, List<Funcionalidad> aBorrar)
        {
            Respuesta respuesta = this.modificacion("SP_ABM_ROL_MODIFICAR_NOMBRE", new Dictionary<string, object>() { { "id_rol", this.id(modificado) }, { "desc_rol", modificado.Nombre }});
            if(respuesta.Codigo == 0)
            {
                Respuesta deFuncionalidad;
                foreach (Funcionalidad funcionalidad in aAgregar)
                {
                    deFuncionalidad = this.modificacion("SP_ABM_ROL_AGREGAR_FUNCIONALIDAD", new Dictionary<string, object>() { { "desc_rol", modificado.Nombre }, { "desc_funcionalidad", funcionalidad.Descripcion } });
                    if(deFuncionalidad.Codigo != 0)
                    {
                        return deFuncionalidad;
                    }
                }
                
                foreach (Funcionalidad funcionalidad in aBorrar)
                {
                    deFuncionalidad = this.modificacion("SP_ABM_ROL_QUITAR_FUNCIONALIDAD", new Dictionary<string, object>() { { "desc_rol", modificado.Nombre }, { "desc_funcionalidad", funcionalidad.Descripcion } });
                    if (deFuncionalidad.Codigo != 0)
                    {
                        return deFuncionalidad;
                    }
                }
            }
            return respuesta;
        }

        public Respuesta modificarSucursal(Sucursal modificada)
        {
            return this.modificacion("SP_ABM_SUCURSAL_MODIFICAR", new Dictionary<string, object>() { { "id_sucursal", this.id(modificada) }, { "nombre", modificada.Nombre }, {"direccion", modificada.Direccion }, { "codigo_postal", modificada.CodigoPostal } });
        }

        public Respuesta modificarCliente(Cliente modificado)
        {
            return this.modificacion("SP_ABM_CLIENTE_MODIFICAR", new Dictionary<string, object>() { { "id_cliente", this.id(modificado) }, { "nombre", modificado.Nombre }, { "apellido", modificado.Apellido}, { "dni", modificado.DNI }, { "direccion", modificado.Direccion }, { "telefono", modificado.Telefono}, { "mail", modificado.Email }, { "fec_nac", modificado.FechaDeNacimiento }, { "codigo_postal", modificado.CodigoPostal } });
        }


        public Respuesta cambiarEstado(Empresa empresa)
        {            
            Respuesta respuesta = this.modificacion("SP_ABM_EMPRESA_ACTIVAR_DESACTIVAR", new Dictionary<string, object>() { { "id_empresa", this.id(empresa)}, { "activo", empresa.Activo}});
            if(respuesta.Codigo == 0)
            {
                empresa.Activo = !empresa.Activo;
            }
            return respuesta;
        }

        public Respuesta cambiarEstado(Rol rol)
        {
            Respuesta respuesta = this.modificacion("SP_ABM_ROL_ACTIVAR_DESACTIVAR", new Dictionary<string, object>() { { "id_rol", this.id(rol) }, { "activo", rol.Activo } });
            if (respuesta.Codigo == 0)
            {
                rol.Activo = !rol.Activo;
            }
            return respuesta;
        }


        public Respuesta cambiarEstado(Sucursal sucursal)
        {
            Respuesta respuesta = this.modificacion("SP_ABM_SUCURSAL_ACTIVAR_DESACTIVAR", new Dictionary<string, object>() { { "id_sucursal", this.id(sucursal) }, { "activo", sucursal.Activa } });
            if (respuesta.Codigo == 0)
            {
                sucursal.Activa = !sucursal.Activa;
            }
            return respuesta;
        }

        public Respuesta cambiarEstado(Cliente cliente)
        {
            Respuesta respuesta =  this.modificacion("SP_ABM_CLIENTE_ACTIVAR_DESACTIVAR", new Dictionary<string, object>() { { "id_cliente", this.id(cliente) }, { "activo", cliente.Activo } });
            if (respuesta.Codigo == 0)
            {
                cliente.Activo = !cliente.Activo;
            }
            return respuesta;
        }

        public Respuesta devolverFactura(Factura factura, string motivo)
        {
            return this.modificacion("DEVOLUCION_FACTURAS_PAGADAS", new Dictionary<string, object>() { { "nro_factura", this.id(factura) }, { "motivo", motivo } });
        }
        
        public Respuesta devolverRendicion(RendicionFacturas rendicion, string motivo)
        {
            return this.modificacion("DEVOLUCION_RENDICION", new Dictionary<string, object>() { { "nro_rendicion", this.id(rendicion) }, { "motivo", motivo } });
        }

        public List<object> obtenerListado(Type tipoListado, int anio, int trimestre)
        {
            Listado seleccionado = this.listados.Find(listado => listado.GetType() == tipoListado && listado.Anio == anio && listado.Trimestre == trimestre);
            if(seleccionado == null)
            {
                Respuesta respuesta = this.obtener(Configuracion.Configuracion.valor(tipoListado.Name).ToString(), new Dictionary<string, object>()
                {
                    {"ANO", anio},
                    {"MES_INI", trimestre * 3 - 2},
                    {"MES_FIN", trimestre * 3},
                });
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
            return seleccionado.Filas;
        }

    }
}
