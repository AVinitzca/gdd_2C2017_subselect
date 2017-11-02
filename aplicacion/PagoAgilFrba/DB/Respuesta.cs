using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.DB
{
    public class Respuesta
    {
        private int codigo;
        private string mensaje;
        private DataTable tabla;

        public Respuesta()
        {
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

        public DataTable Tabla
        {
            get
            {
                return this.tabla;
            }
            set
            {
                this.tabla = value;   
            }
        }

    }
}
