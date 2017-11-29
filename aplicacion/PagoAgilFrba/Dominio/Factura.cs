using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Dominio
{
    public class Factura : IEquatable<Factura>
    {
        private int numeroFactura;
        private Cliente cliente;
        private Empresa empresa;
        private DateTime creacion;
        private DateTime vencimiento;
        private List<ItemFactura> items;

        public Factura()
        {
            this.items = new List<ItemFactura>();
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

        public DateTime Creacion
        {
            get
            {
                return creacion;
            }

            set
            {
                creacion = value;
            }
        }

        public DateTime Vencimiento
        {
            get
            {
                return vencimiento;
            }

            set
            {
                vencimiento = value;
            }
        }

        public List<ItemFactura> Items
        {
            get
            {
                return this.items;
            }
            set
            {
                this.items = value;
            }
        }

        private double total;

        public double Total
        {
            get
            {
                if(this.items.Count != 0)
                {
                    return this.items.Aggregate(0d, (prev, next) => prev + next.Cantidad * next.Monto);
                }
                else
                {
                    return this.total;
                }                
            }
            set
            {
                this.total = value;
            }
        }

        public int NumeroFactura
        {
            get
            {
                return this.numeroFactura;
            }
            set
            {
                this.numeroFactura = value;
            }
        }

        public bool Equals(Factura other)
        {
            return other.NumeroFactura == this.NumeroFactura;
        }

        public override int GetHashCode()
        {
            return this.NumeroFactura;
        }
    }
}
