using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iFlota.Forms.Servicios
{
    interface IAutenticacionServicio
    {
        Task<bool> AutenticarAsync();

        Task<bool> SalirAsync();

        Task<string> GetTokenAsync();

        bool EstaAutenticado { get; }
    }
}
