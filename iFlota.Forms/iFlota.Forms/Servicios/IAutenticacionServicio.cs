using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iFlota.Forms.Modelos;
using Microsoft.WindowsAzure.MobileServices;

namespace iFlota.Forms.Servicios
{
    /// <summary>
    /// Interfaz para la implementacion multiplataforma del servicio de autenticacion
    /// </summary>
    public interface IAutenticacionServicio
    {
        /// <summary>
        /// Metodo que realiza la atenticacion del usuario
        /// </summary>
        /// <param name="servicio">Servicio OAuth para autenticar</param>
        /// <returns>Verdadero si se autentico, de lo contrario falso</returns>
        Task<bool> AutenticarAsync(string servicio);

        /// <summary>
        /// Metodo para cerrar la sesión del usuario
        /// </summary>
        /// <returns>retorna verdador si se logro cerrar la sesion, de lo contrario falso</returns>
        Task<bool> SalirAsync();

        /// <summary>
        /// Metodo para obtener el token de la sesion OAuth
        /// </summary>
        /// <returns>Retorna el token de la sesión</returns>
        Task<string> GetTokenAsync();

        /// <summary>
        /// Propiedad que me permite saber si el usuario esta autenticado
        /// </summary>
        bool EstaAutenticado { get; }

        /// <summary>
        /// Propiedad que me permite obtener el MobileServiceUSer de azure
        /// </summary>
		MobileServiceUser ServiceUser { get; }

        /// <summary>
        /// Propiedad que me permite obtener la identidad OAuth del usuario atenticado
        /// </summary>
		Identidad Identidad { get;}
    }
}
