using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Dominio
{
    public class ListadoClientesCumplidores : Listado
    {
        public ListadoClientesCumplidores(int anio, int trimestre) : base(anio, trimestre) { }

        public override void procesar(DataTable tabla)
        {
            foreach(DataRow row in tabla.Rows)
            {
                ClienteCumplidor cumplidor = new ClienteCumplidor(Convert.ToString(row["NOMBRE"]), Convert.ToString(row["APELLIDO"]), Convert.ToInt32(row["DNI"]), Convert.ToInt32(row["TOTAL"]));
                this.listado.Add(cumplidor);
            }
        }
    }

    class ClienteCumplidor
    {
        private string nombre;
        private string apellido;
        private int dni;
        private int porcentaje;

        public ClienteCumplidor(string nombre, string apellido, int dni, int porcentaje)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.porcentaje = porcentaje;
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

        public string Apellido
        {
            get
            {
                return apellido;
            }

            set
            {
                apellido = value;
            }
        }

        public int DNI
        {
            get
            {
                return dni;
            }

            set
            {
                dni = value;
            }
        }

        public int PorcentajeFacturasPagas
        {
            get
            {
                return this.porcentaje;
            }

            set
            {
                porcentaje = value;
            }
        }
    }
}
