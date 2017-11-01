using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Dominio
{
    public class Rubro
    {
        private string descripcion;

        public string Descripcion
        {
            get
            {
                return descripcion;
            }
            set
            {
                this.descripcion = value;
            }
        }
    }
}
