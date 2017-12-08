using PagoAgilFrba.DB;
using System.Collections.Generic;

namespace PagoAgilFrba.Dominio
{
    public class Usuario
    {
        private string username;
        private string password;
        private List<Rol> posiblesRoles;
        private List<Sucursal> posiblesSucursales;
        // Son enteros que guardan los IDs seleccionados
        // Para evitar problemas de sincronizacion
        private int rolSeleccionado;
        private int sucursalSeleccionada;

        private static Usuario logeado;

        public Usuario(string username, string password)
        {
            this.Username = username;
            this.Password = password;
            this.posiblesRoles = new List<Rol>();
            this.posiblesSucursales = new List<Sucursal>();
        }

        public Respuesta logear()
        {
            // Trata de logear en la DB
            Respuesta respuesta = DB.DB.Instancia.logear(this);
            // Si todo sale bien, busca los roles y sucursales posibles
            // Tambien se autoasigna como logeado
            if(respuesta.Codigo == 0)
            {
                DB.DB.Instancia.obtenerRolesParaUsuario(this);
                DB.DB.Instancia.obtenerSucursalesParaUsuario(this);
                logeado = this;
            }
            return respuesta;            
        }

        public List<Rol> Roles
        {
            get
            {
                return this.posiblesRoles;
            }         
        }
        public List<Sucursal> Sucursales
        {
            get
            {
                return this.posiblesSucursales;
            }            
        }
        public void asignarRol(Rol rol)
        {
            this.rolSeleccionado = DB.DB.Instancia.id(rol);
        }

        public void asignarSucursal(Sucursal sucursal)
        {
            this.sucursalSeleccionada = DB.DB.Instancia.id(sucursal);
        }

        public Rol Rol
        {
            get
            {
                return (Rol)DB.DB.Instancia.encontrar(typeof(Rol), this.rolSeleccionado);
            }
        }

        public static Usuario Logeado
        {
            get
            {
                return logeado;
            }
        }

        public Sucursal Sucursal
        {
            get
            {
                return (Sucursal)DB.DB.Instancia.encontrar(typeof(Sucursal), this.sucursalSeleccionada);
            }
        }

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }
    }
}
