using System;
using System.Threading.Tasks;
using iFlota.Forms.Servicios;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;

[assembly: Dependency(typeof(iFlota.Forms.Droid.Servicios.Autenticador))]
namespace iFlota.Forms.Droid.Servicios
{
    /// <summary>
    /// Clase que implementa la interfaz de autenticador de la libreria portable
    /// </summary>
    public class Autenticador : IAutenticador
	{
        // Cliente del servicio mobil de azure
        MobileServiceClient mobileClient;
        // Usuario autenticado del servicio mobil de azure
		MobileServiceUser mobileUser;

		public Autenticador() {
            //Inicializacion de la libreria de azure
            mobileClient = new MobileServiceClient(Constants.ApplicationURL);
		}
        
		public async Task<MobileServiceUser> Autenticar(string autoridad)
		{
			try
			{
                // Llama a la interfaz de loggueo de azure, de acuerdo a la autoridad escogida
                var resultado= await mobileClient.LoginAsync(Xamarin.Forms.Forms.Context, autoridad);
				return resultado;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public Task<bool> DesAutenticar(string autoridad)
		{
            // TODO: Falta realizar
            throw new NotImplementedException();
		}

		public Task<string> ExtraerToken(string autoridad)
		{
            // TODO: Falta realizar
            throw new NotImplementedException();
		}
	}
}

