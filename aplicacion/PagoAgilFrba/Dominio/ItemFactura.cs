using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Dominio
{
    public class ItemFactura
    {
        private Factura factura;
        private int cantidad;
        private double monto;

        public Factura Factura
        {
            get
            {
                return factura;
            }

            set
            {
                factura = value;
            }
        }

        public int Cantidad
        {
            get
            {
                return cantidad;
            }

            set
            {
                cantidad = value;
            }
        }

        public double Monto
        {
            get
            {
                return monto;
            }

            set
            {
                monto = value;
            }
        }
    }
}
