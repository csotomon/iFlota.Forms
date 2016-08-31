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
        private MobileServiceUser mobileUser;
        private MobileServiceClient mobileClient;

        public MobileServiceClient MobileClient
        {
            get { return mobileClient; }
        }

        public MobileServiceUser MobileUser
        {
            get { return mobileUser; }
        }

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

        protected Singleton(){
            mobileClient = new MobileServiceClient(Constants.ApplicationURL);
        }
    }
}
