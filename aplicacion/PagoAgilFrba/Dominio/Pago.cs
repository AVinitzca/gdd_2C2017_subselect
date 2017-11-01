using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Dominio
{
    public class Pago
    {
        private DateTime fecha;
        private FormaDePago formaDePago;
        private Sucursal sucursal;
        private List<Factura> facturas;
        private Empresa empresa;
        private Cliente cliente;
        private double total;

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

        public FormaDePago FormaDePago
        {
            get
            {
                return formaDePago;
            }

            set
            {
                formaDePago = value;
            }
        }

        public Sucursal Sucursal
        {
            get
            {
                return sucursal;
            }

            set
            {
                sucursal = value;
            }
        }

        public List<Factura> Facturas
        {
            get
            {
                return facturas;
            }

            set
            {
                facturas = value;
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

        public Cliente Cliente
        {
            get
            {
                return cliente;
            }

            set
            {
                cliente = value;
            }
        }

        public double Total
        {
            get
            {
                return total;
            }

            set
            {
                total = value;
            }
        }
    }
}
