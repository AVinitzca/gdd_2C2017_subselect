using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Dominio
{
    public class Usuario
    {
        private string email;
        private string password;
        private List<Rol> posiblesRoles;
        private List<Sucursal> posiblesSucursales;
        private Rol rolSeleccionado;
        private Sucursal sucursalSeleccionada;

        private static Usuario logeado;

        public Usuario(string email, string password)
        {
            this.email = email;
            this.password = password;
        }

        public bool logear()
        {
            this.posiblesRoles = new List<Rol>();
            Rol rol = new Rol();
            rol.Nombre = "RolTest";
            this.posiblesRoles.Add(rol);
            this.posiblesSucursales = new List<Sucursal>();
            Sucursal sucursal = new Sucursal();
            sucursal.Nombre = "Paternal";
            this.posiblesSucursales.Add(sucursal);
            /*             
            * DB.ejecutarProcedimiento({email, password});
            * 
            * 
            */
            logeado = this;
            return true;
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
        
    }
}
