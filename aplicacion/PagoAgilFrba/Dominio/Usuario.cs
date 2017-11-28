using PagoAgilFrba.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Dominio
{
    public class Usuario
    {
        private string username;
        private string password;
        private List<Rol> posiblesRoles;
        private List<Sucursal> posiblesSucursales;
        private Rol rolSeleccionado;
        private Sucursal sucursalSeleccionada;

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
            Respuesta respuesta = DB.DB.Instancia.logear(this);
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
            this.rolSeleccionado = rol;
        }

        public void asignarSucursal(Sucursal sucursal)
        {
            this.sucursalSeleccionada = sucursal;
        }

        public Rol Rol
        {
            get
            {
                return this.rolSeleccionado;
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
                return this.sucursalSeleccionada;
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
