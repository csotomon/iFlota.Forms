using iFlota.Forms.Util;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iFlota.Forms
{
    public class LoginManager : Singleton<LoginManager>
    {
        public bool Autenticado = false;
        public static IAutenticar Autenticador { get; set; }
        public async Task<bool> Autenticar(MobileServiceAuthenticationProvider servicio, object sender)
        {
            return true;
        }

        public static void Init(IAutenticar autenticador)
        {
            Autenticador = autenticador;
        }
    }
}
