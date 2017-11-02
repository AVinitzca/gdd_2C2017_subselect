using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.Utils
{
    public class UtilFunctions
    {
        public static void addRange<T>(ref BindingList<T> list, List<T> collection)
        {
            foreach(T t in collection)
            {
                if(!list.Contains(t))
                {
                    list.Add(t);
                }
            }            
            foreach (T t in list)
            {
                if (!collection.Contains(t))
                {
                    list.Remove(t);
                }
            }
        }
    }
}
