using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Dominio
{
    public class RendicionFacturas
    {
        private DateTime fecha;
        private double porcentaje;
        private Empresa empresa;

        public DateTime Fecha
        {
            get
            {
                return fecha;
            }

            set
            {
                fecha = value;
            }
        }

        public double Porcentaje
        {
            get
            {
                return porcentaje;
            }

            set
            {
                porcentaje = value;
            }
        }

        public Empresa Empresa
        {
            get
            {
                return empresa;
            }

            set
            {
                empresa = value;
            }
        }

        public string Detalle
        {
            get
            {
                return this.Empresa.Nombre + " - " + this.fecha.ToString();
            }
        }
    }
}
