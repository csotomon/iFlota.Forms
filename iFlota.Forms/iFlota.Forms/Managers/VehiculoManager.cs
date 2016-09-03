using iFlota.Forms.DataObjects;
using iFlota.Forms.Util;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iFlota.Forms.Managers
{
    class VehiculoManager:Singleton<VehiculoManager>
    {
        private IMobileServiceTable<Vehiculo> tabla;

        public VehiculoManager()
        {
            tabla = LoginManager.Instancia.MobileClient.GetTable<Vehiculo>();
        }
    }
}
