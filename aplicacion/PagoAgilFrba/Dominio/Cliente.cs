using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Dominio
{
    public class Cliente
    {
        private string nombre;
        private string apellido;
        private int dni;
        private string email;
        private int telefono;
        private string direccion;
        private int codigoPostal;
        private DateTime fechaDeNacimiento;

        public Cliente()
        {

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
                return this.dni;
            }

            set
            {
                dni = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public int Telefono
        {
            get
            {
                return telefono;
            }

            set
            {
                telefono = value;
            }
        }

        public string Direccion
        {
            get
            {
                return direccion;
            }

            set
            {
                direccion = value;
            }
        }

        public int CodigoPostal
        {
            get
            {
                return codigoPostal;
            }

            set
            {
                codigoPostal = value;
            }
        }

        public DateTime FechaDeNacimiento
        {
            get
            {
                return fechaDeNacimiento;
            }

            set
            {
                fechaDeNacimiento = value;
            }
        }

        public string NombreCompleto
        {
            get
            {
                return this.nombre + " " + this.apellido;
            }
        }
    }
}
