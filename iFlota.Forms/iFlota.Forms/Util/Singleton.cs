using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iFlota.Forms.Util
{
    public class Singleton<T> where T : class, new()
    {
        private static T instancia = default(T);
        

        public static T Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new T();
                    //instancia = (T)Activator.CreateInstance(typeof(T));
                return instancia;
            }
        }
    }
}
