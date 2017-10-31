using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.DB
{
    public class DB
    {
        private static readonly DB instancia = new DB();

        private DB()
        {
            
        }

        public DB Instancia
        {
            get
            {
                return instancia;
            }
        }


    }
}
