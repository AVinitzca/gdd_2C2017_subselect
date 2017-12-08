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
            // Agrega una List a una BindingList
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
        public static bool Contains(string source, string toCheck)
        {
            if (string.IsNullOrEmpty(toCheck) || string.IsNullOrEmpty(source))
                return true;

            return source.IndexOf(toCheck, StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}
