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
                return this.funcionalidades.Aggregate("", (prev, next) => prev + ", " + next.Descripcion);
            }
        }

        public void agregarFuncionadlidad(Funcionalidad funcionalidad)
        {
            this.funcionalidades.Add(funcionalidad);
        }


    }
}
