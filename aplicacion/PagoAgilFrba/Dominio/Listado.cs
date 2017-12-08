using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Dominio
{
    public abstract class Listado
    {
        protected int anio;        
        protected int trimestre;
        protected List<object> listado;

        public Listado(int anio, int trimestre)
        {
            this.anio = anio;
            this.trimestre = trimestre;
            this.listado = new List<object>();
        }

        public string Nombre
        {
            get
            {
                return this.GetType().Name;
            }
        }
                
        public List<object> Filas
        {
            get
            {
                return this.listado;
            }
        }

        // Metodo para ser pisado por clases herederas
        // Procesa la tabla, cada listado lo hace a su manera
        public abstract void procesar(DataTable tabla);

        // Obtiene todos los listados existentes
        public static List<Listado> Listados
        {
            get
            {
                return new List<Listado>() {new ListadoCobrosPorEmpresa(0, 0), new ListadoEmpresasMayorMonto(0, 0), new ListadoClientesMasPagos(0, 0), new ListadoClientesCumplidores(0, 0)};
            }
        }
        
        public int Anio
        {
            get
            {
                return anio;
            }

            set
            {
                anio = value;
            }
        }

        public int Trimestre
        {
            get
            {
                return trimestre;
            }

            set
            {
                trimestre = value;
            }
        }
    }    
}
