using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Dominio
{
    public class ListadoCobrosPorEmpresa : Listado
    {        

        public ListadoCobrosPorEmpresa(int anio, int trimestre) : base(anio, trimestre) { }
           
        public override void procesar(DataTable tabla)
        {
            foreach (DataRow row in tabla.Rows)
            {
                CobroPorEmpresa cobro = new CobroPorEmpresa(Convert.ToString(row["NOMBRE"]), Convert.ToString(row["CUIT"]), Convert.ToDouble(row["TOTAL"]));
                this.listado.Add(cobro);
            }
        }
                
    }

    class CobroPorEmpresa
    {
        private string nombre;
        private string cuit;
        private double total;

        public CobroPorEmpresa(string nombre, string cuit, double total)
        {
            this.nombre = nombre;
            this.cuit = cuit;
            this.total = total;
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Cuit
        {
            get
            {
                return cuit;
            }

            set
            {
                cuit = value;
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
