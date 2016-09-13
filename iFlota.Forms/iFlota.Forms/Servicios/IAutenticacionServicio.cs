using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iFlota.Forms.Modelos;
using Microsoft.WindowsAzure.MobileServices;

namespace iFlota.Forms.Servicios
{
    public interface IAutenticacionServicio
    {
        Task<bool> AutenticarAsync(string servicio);

        Task<bool> SalirAsync();

        Task<string> GetTokenAsync();

        bool EstaAutenticado { get; }

		MobileServiceUser ServiceUser { get; }

		Identidad Identidad { get;}
    }
}
