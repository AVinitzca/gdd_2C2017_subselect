using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Configuracion
{
    public class Configuracion
    {
        private static Dictionary<String, object> configuracion;
        private static string error = null;

        public static void inicializar()
        {
            configuracion = new Dictionary<string, object>();
            try
            {
                string[] lineas = System.IO.File.ReadAllLines(@"../configuracion.dat");
                foreach (string linea in lineas)
                {
                    string[] separado = linea.Split('=');
                    configuracion.Add(separado[0], separado[1]);
                }
                error = null;
            }
            catch(Exception excepcion)
            {
                error = excepcion.Message;
            }
        }

        public static string Error
        {
            get
            {
                return error;
            }
        }

        public static bool TieneError
        {
            get
            {
                return error != null;
            }
        }

        public object valor(string clave)
        {
            object valor = null;
            configuracion.TryGetValue(clave, out valor);
            return valor;
        }

    }
}
