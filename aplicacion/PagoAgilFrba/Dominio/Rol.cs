using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Dominio
{
    public class Rol
    {
       
        private string nombre;

        private List<Funcionalidad> funcionalidades = new List<Funcionalidad>();

        private bool activo = true;

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
        public List<Funcionalidad> Funcionalidades
        {
            get
            {
                return this.funcionalidades;
            }
            set
            {
                this.funcionalidades = value;
            }
        }

        public String ListaFuncionalidades
        {
            get
            {
                return this.funcionalidades.Aggregate("", (prev, next) => (prev == "") ? next.Descripcion : (prev + ", " + next.Descripcion));
            }
        }

        public bool Activo
        {
            get
            {
                return activo;
            }

            set
            {
                activo = value;
            }
        }

        public void agregarFuncionalidad(Funcionalidad funcionalidad)
        {
            this.funcionalidades.Add(funcionalidad);
        }


    }
}
