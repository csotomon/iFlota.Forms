using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using iFlota.Forms.Util;
using iFlota.Forms.Managers;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;


[assembly: Xamarin.Forms.Dependency(typeof(iFlota.Forms.Droid.AutenticacionServicio))]
namespace iFlota.Forms.Droid
{
    public class AutenticacionServicio : IAutenticacionServicio
    {
        /// <summary>
        /// Hace login en el proveedor deseado
        /// </summary>
        /// <param name="servicio">El proveedor de autenticacion</param>
        /// <returns></returns>
        public async Task<MobileServiceUser> Login(MobileServiceAuthenticationProvider servicio)
        {
            try
            {
                return await LoginManager.Instancia.MobileClient.LoginAsync(Xamarin.Forms.Forms.Context, servicio);
               
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// Cierra sesión en el auth de azure
        /// </summary>
        public void Logout()
        {
            LoginManager.Instancia.MobileClient.LogoutAsync();
        }
    }
}