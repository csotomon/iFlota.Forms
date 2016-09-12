using System;
using System.Threading.Tasks;
using iFlota.Forms.Servicios;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;

[assembly: Dependency(typeof(iFlota.Forms.Droid.Servicios.Autenticador))]
namespace iFlota.Forms.Droid.Servicios
{
	public class Autenticador : IAutenticador
	{
		MobileServiceClient mobileClient;
		MobileServiceUser mobileUser;

		public Autenticador() {
			mobileClient = new MobileServiceClient(Constants.ApplicationURL);
		}

		public async Task<MobileServiceUser> Autenticar(string autoridad, string recurso, string clienteId, string returnUri)
		{
			try
			{
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
			throw new NotImplementedException();
		}

		public Task<string> ExtraerToken(string autoridad)
		{
			throw new NotImplementedException();
		}
	}
}

