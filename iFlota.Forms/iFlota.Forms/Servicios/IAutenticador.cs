using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iFlota.Forms.Servicios
{
    interface IAutenticador
    {
        Task<MobileServiceUser> Autenticar(string autoridad, string recurso, string clienteId, string returnUri);

        Task<bool> DesAutenticar(string autoridad);

        Task<string> ExtraerToken(string autoridad);
    }
}
