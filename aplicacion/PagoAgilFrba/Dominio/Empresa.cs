using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Dominio
{
    public class Empresa
    {
        private string nombre;
        private string cuit;
        private string direccion;
        private Rubro rubro;

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }


        [Browsable(false)]
        public Rubro Rubro
        {
            get
            {
                return this.rubro;
            }
            set
            {
                this.rubro = value;
            }
        }


        public string RubroDescripcion
        {
            get
            {
                return this.rubro.Descripcion;
            }
        }

        public string Cuit
        {
            get
            {
                return this.cuit;
            }
            set
            {
                this.cuit = value;
            }
        }

        public string Direccion
        {
            get
            {
                return this.direccion;
            }
            set
            {
                this.direccion = value;
            }
        }

        public object Clone()
        {
            return new Empresa();
        }
    }
}
