using PagoAgilFrba.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.DB
{
    public class DB
    {
        private static readonly DB instancia = new DB();
        private SqlConnection conexion;

        private Dictionary<Type, Dictionary<int, object>> repositorio;


        private DB()
        {
            this.repositorio = new Dictionary<Type, Dictionary<int, object>>();            

            this.conexion = new SqlConnection();
            this.conexion.ConnectionString = "Data Source=RONAN-PC\\SQLEXPRESS;Initial Catalog=GD2C2017;Integrated Security=True";
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
        /*
        public Respuesta creacion(String nombre, Dictionary<string, object> valores)
        {
            SqlCommand comando = this.comando(nombre, valores);

            SqlParameter retorno = new SqlParameter("@FLAG_ERROR", SqlDbType.Int);
            retorno.Size = sizeof(int);
            retorno.Direction = ParameterDirection.Output;
            comando.Parameters.Add(retorno);

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
        }*/



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

        public List<T> agregar<T>(Respuesta respuesta, Func<DataRow, T> funcion, string id)
        {
            List<T> lista = new List<T>();
            foreach(var row in respuesta.Tabla.AsEnumerable())
            {
                T nuevo = funcion(row);
                this.crearSiNoExiste(nuevo.GetType(), Convert.ToInt32(row[id]), nuevo);
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

        public List<RendicionFacturas> obtenerRendiciones()
        {
            return new List<RendicionFacturas>();
        }

        protected int id(object objeto)
        {
            return this.repositorio[objeto.GetType()].FirstOrDefault(x => x.Value == objeto).Key;
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
            return (List<Rubro>)this.repositorio[typeof(Rubro)].Values.Cast<Rubro>().ToList();
        }

        public List<Empresa> obtenerEmpresas(string nombre, string cuit, Rubro rubro)
        {
            this.obtenerRubros();
            Respuesta respuesta = this.obtener("GET_EMPRESAS_ACTIVAS", new Dictionary<string, object>(){{"nombre", nombre}, {"cuit", cuit}, {"id_rubro", rubro == null ? 0 : this.id(rubro)}});

            return this.agregar<Empresa>(respuesta, delegate (DataRow row)
            {
                return new Empresa()
                {
                    Nombre    = Convert.ToString(row["NOMBRE"]),
                    Cuit      = Convert.ToString(row["CUIT"]),
                    Direccion = Convert.ToString(row["DIRECCION"]),     
                    Rubro     = (Rubro)this.repositorio[typeof(Rubro)][Convert.ToInt32(row["ID_RUBRO"])]               
                };
            }, "ID_EMPRESA");
            
        }
        

        public List<Rol> obtenerRolesParaUsuario(Usuario usuario)
        {
            Respuesta respuesta = this.obtenerConEfecto("GET_ROLES_POR_USUARIO", new Dictionary<string, object>() { { "ID_USUARIO", this.repositorio[typeof(Usuario)].Keys.FirstOrDefault() } });

            return this.agregar<Rol>(respuesta,
                delegate (DataRow row)
                {
                    return new Rol()
                    {
                        Nombre = Convert.ToString(row["DESCRIPCION"]),
                        Funcionalidades = this.obtenerFuncionalidadesPorRol(Convert.ToString(row["DESCRIPCION"]))
                    };
                }, "ID_ROL");
        }

        protected List<Funcionalidad> obtenerFuncionalidadesPorRol(string descripcion)
        {
            Respuesta respuesta = this.obtenerConEfecto("GET_FUNCIONALIDADES_POR_ROL", new Dictionary<string, object>() { { "DESCRIPCION", descripcion } });

            return this.agregar<Funcionalidad>(respuesta,
                delegate (DataRow row)
                {
                    return new Funcionalidad() { Descripcion = Convert.ToString(row["DESCRIPCION"]) };
                }, "ID_FUNCIONALIDAD");
        }

        public List<Sucursal> obtenerSucursalesParaUsuario(Usuario usuario)
        {
            Respuesta respuesta = this.obtenerConEfecto("GET_SUCURSALES_POR_USUARIO", new Dictionary<string, object>() { { "ID_USUARIO", this.repositorio[typeof(Usuario)].Keys.FirstOrDefault() } });

            return this.agregar<Sucursal>(respuesta,
                delegate (DataRow row)
                {
                    return new Sucursal()
                    {
                        Nombre = Convert.ToString(row["NOMBRE"]),
                    };
                }, "ID_SUCURSAL");
        }

        public List<Sucursal> obtenerSucursales(string nombre, string direccion, int codigoPostal)
        {
            return new List<Sucursal>();
        }

        public List<Factura> obtenerFacturas(Empresa selectedItem)
        {
            return new List<Factura>();
        }

        public List<Factura> obtenerFacturasPagas()
        {
            return new List<Factura>();
        }

        public List<Rol> obtenerRoles()
        {
            return new List<Rol>();
        }


        public List<Cliente> obtenerClientes(string text1, string text2, string text3)
        {
            List<Cliente> clientes = new List<Cliente>();
            clientes.Add(new Cliente());
            return clientes;
        }

        public List<FormaDePago> obtenerFormasDePago()
        {
            List<FormaDePago> formasDePago = new List<FormaDePago>();            
            return formasDePago;
        }


        public void crearRol(Rol rolNuevo)
        {
            //
        }

        public Respuesta crearEmpresa(Empresa nueva)
        {
            return this.modificacion("SP_ABM_EMPRESA_ALTA", new Dictionary<string, object>() { {"nombre", nueva.Nombre } , {"cuit", nueva.Cuit }, { "direccion", nueva.Direccion }, { "id_rubro", this.id(nueva.Rubro) } });
        }

        public void crearSucursal(Sucursal nueva)
        {
        }


        public void crearCliente(Cliente nuevo)
        {
            
        }


        public void crearFactura(Factura factura)
        {

        }

        public void crearItem(ItemFactura item)
        {

        }

        public void crearPago(Pago pago)
        {

        }

        public void crearRendicion(RendicionFacturas rendicion)
        {
            
        }

        public Respuesta modificarEmpresa(Empresa modificada)
        {
            return this.modificacion("SP_ABM_EMPRESA_MODIFICAR", new Dictionary<string, object>() { {"id_empresa", this.id(modificada) }, { "nombre", modificada.Nombre }, { "cuit", modificada.Cuit }, { "direccion", modificada.Direccion }, { "id_rubro", this.id(modificada.Rubro) } });
        }

        public Respuesta modificarRol(Rol modificado)
        {
            return this.modificacion("SP_ABM_ROL_MODIFICAR_NOMBRE", new Dictionary<string, object>() { { "id_rol", this.id(modificado) }, { "desc_rol", modificado.Nombre }});
        }

        public Respuesta modificarSucursal(Sucursal modificada)
        {
            return this.modificacion("SP_ABM_SUCURSAL_MODIFICAR_NOMBRE", new Dictionary<string, object>() { { "id_sucursal", this.id(modificada) }, { "nombre", modificada.Nombre }, {"direccion", modificada.Direccion }, { "codigo_postal", modificada.CodigoPostal } });
        }

        public Respuesta modificarCliente(Cliente modificado)
        {
            return this.modificacion("SP_ABM_CLIENTE_MODIFICAR_NOMBRE", new Dictionary<string, object>() { { "id_cliente", this.id(modificado) }, { "nombre", modificado.Nombre }, { "apellido", modificado.Apellido}, { "dni", modificado.DNI }, { "direccion", modificado.Direccion }, { "telefono", modificado.Telefono}, { "mail", modificado.Email }, { "fec_nac", modificado.FechaDeNacimiento }, { "codigo_postal", modificado.CodigoPostal } });
        }


        public Respuesta eliminarEmpresa(Empresa empresa)
        {
            return this.modificacion("SP_ABM_EMPRESA_ACTIVAR_DESACTIVAR", new Dictionary<string, object>() { { "id_empresa", this.id(empresa)}, { "activo", 0}});
        }

        public Respuesta eliminarRol(Rol rol)
        {
            return this.modificacion("SP_ABM_ROL_ACTIVAR_DESACTIVAR", new Dictionary<string, object>() { { "id_empresa", this.id(rol) }, { "activo", 0 } });
        }


        public Respuesta eliminarSucursal(Sucursal sucursal)
        {
            return this.modificacion("SP_ABM_SUCURSAL_ACTIVAR_DESACTIVAR", new Dictionary<string, object>() { { "id_empresa", this.id(sucursal) }, { "activo", 0 } });
        }

        public Respuesta eliminarCliente(Cliente cliente)
        {
            return this.modificacion("SP_ABM_CLIENTE_ACTIVAR_DESACTIVAR", new Dictionary<string, object>() { { "id_empresa", this.id(cliente) }, { "activo", 0 } });
        }

        public void devolverFactura(Factura factura, string motivo)
        {

        }
        
        public void devolverRendicion(RendicionFacturas selectedItem, string text)
        {
            
        }
    }
}
