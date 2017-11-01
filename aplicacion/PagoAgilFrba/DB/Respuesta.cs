using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.DB
{
    public class Respuesta
    {
        private int codigo;
        private string mensaje;

        public Respuesta(int codigo, string mensaje)
        {
            this.codigo = codigo;
            this.mensaje = mensaje;
        }

        public int Codigo
        {
            get
            {
                return codigo;
            }

            set
            {
                codigo = value;
            }
        }

        public string Mensaje
        {
            get
            {
                return mensaje;
            }

            set
            {
                mensaje = value;
            }
        }
    }
}
