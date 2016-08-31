using iFlota.Forms.Util;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iFlota.Forms.Managers
{
    public class LoginManager : Singleton<LoginManager>
    {
        public bool Autenticado = false;
    }
}
