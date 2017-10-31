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
        private Rol rolSeleccionado;

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
            /*             
            * DB.ejecutarProcedimiento({email, password});
            * 
            * 
            */
            logeado = this;
            return true;
        }

        public List<Rol> roles()
        {
            return this.posiblesRoles;
        }

        public void asignarRol(Rol rol)
        {
            this.rolSeleccionado = rol;
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
    }
}
