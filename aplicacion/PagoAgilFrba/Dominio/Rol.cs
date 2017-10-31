using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Dominio
{
    public class Rol
    {
       
        private string nombre;
        private List<Funcionalidad> funcionalidades;

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }

        public List<Funcionalidad> Funcionalidades
        {
            get
            {
                return this.funcionalidades;
            }
        }
    }
}
