using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Dominio
{
    public class ListadoEmpresasMayorMonto : Listado
    {
        public ListadoEmpresasMayorMonto(int anio, int trimestre) : base(anio, trimestre) { }

        public override void procesar(DataTable tabla)
        {
            // Agrega al listado de mayores montos cobrados por empresa
            // Procesando la tabla de la DB
            foreach (DataRow row in tabla.Rows)
            {
                EmpresaMayorMonto empresa = new EmpresaMayorMonto(Convert.ToString(row["NOMBRE"]), Convert.ToString(row["CUIT"]), Convert.ToDouble(row["MAXIMA"]));
                this.listado.Add(empresa);
            }
        }

    }

    class EmpresaMayorMonto
    {
        private string nombre;
        private string cuit;
        private double maxima;

        public EmpresaMayorMonto(string nombre, string cuit, double maxima)
        {
            this.nombre = nombre;
            this.cuit = cuit;
            this.maxima = maxima;
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

        public double CantidadRendida
        {
            get
            {
                return maxima;
            }

            set
            {
                maxima = value;
            }
        }
    }
}
