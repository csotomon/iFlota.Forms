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
        public async Task<bool> Login(MobileServiceAuthenticationProvider servicio)
        {
            var success = false;
            var message = string.Empty;
            MobileServiceUser user;
            try
            {
                user = await LoginManager.Instancia.MobileClient.LoginAsync(Xamarin.Forms.Forms.Context, servicio);
                if (user != null)
                {
                    message = string.Format("you are now signed-in as {0}.",
                        user.UserId);
                    success = true;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            return success;
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