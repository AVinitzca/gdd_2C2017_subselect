using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Dominio
{
    public class ListadoClientesMasPagos : Listado
    {
        private List<CobroPorEmpresa> cobrosPorEmpresa = new List<CobroPorEmpresa>();

        public ListadoClientesMasPagos(int anio, int trimestre) : base(anio, trimestre){ }
        

        public override void procesar(DataTable tabla)
        {
            // Agrega al listado los Clientes con mas pagos
            // Procesando la tabla de la DB
            foreach (DataRow row in tabla.Rows)
            {
                ClienteMasPagos cobro = new ClienteMasPagos(Convert.ToString(row["NOMBRE"]), Convert.ToString(row["APELLIDO"]), Convert.ToInt32(row["DNI"]), Convert.ToInt32(row["CANTIDAD"]));
                this.listado.Add(cobro);
            }
        }
    }

    class ClienteMasPagos
    {
        private string nombre;
        private string apellido;
        private int dni;
        private double cantidadPagos;

        public ClienteMasPagos(string nombre, string apellido, int dni, double cantidadPagos)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.cantidadPagos = cantidadPagos;
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

        public double CantidadPagos
        {
            get
            {
                return cantidadPagos;
            }

            set
            {
                cantidadPagos = value;
            }
        }
    }
}
