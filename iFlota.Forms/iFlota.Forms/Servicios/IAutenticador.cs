using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iFlota.Forms.Servicios
{
    /// <summary>
    /// Interfaz para la implementación multiplataforma del autenticador
    /// La idea es permitir una autenticacion de varios servicios OAuth
    /// </summary>
    public interface IAutenticador
    {
        /// <summary>
        /// Realiza la atenticacion del usuario
        /// </summary>
        /// <param name="autoridad">Servicio contra el que se va a atenticar</param>
        /// <returns></returns>
        Task<MobileServiceUser> Autenticar(string autoridad);

        /// <summary>
        /// Cierra la sesion del usuario
        /// </summary>
        /// <param name="autoridad">autoridad en la que se va a cerrar la sesion</param>
        /// <returns></returns>
        Task<bool> DesAutenticar(string autoridad);
        /// <summary>
        /// Obtiene el token de autenticacion de la atoridad dada
        /// </summary>
        /// <param name="autoridad">autoridad de la que se va a extraer el token</param>
        /// <returns></returns>
        Task<string> ExtraerToken(string autoridad);
    }
}
