using System;
using System.Net.Http;
using System.Threading.Tasks;
using iFlota.Forms.Modelos;
using iFlota.Forms.Servicios;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using Xamarin.Forms;

[assembly: Dependency(typeof(AutenticacionServicio))]
namespace iFlota.Forms.Servicios
{
	public class AutenticacionServicio : IAutenticacionServicio
    {
        IAutenticador autenticador;
		IDatosServicio datosServicio;
		MobileServiceUser serviceUser;
		Identidad identidad;
		Usuario usuario;

        public AutenticacionServicio()
        {
            autenticador = DependencyService.Get<IAutenticador>();
        }


        public bool EstaAutenticado
        {
            get { return serviceUser != null;}
        }

		public Identidad Identidad
		{
			get{ return identidad; }
		}

		public MobileServiceUser ServiceUser
		{
			get{ return serviceUser;}
		}


		public async Task<bool> AutenticarAsync(string servicio)
        {
			serviceUser = await autenticador.Autenticar(servicio, null, null, null);

			using (var clienteHTTP = new HttpClient())
			{ 
				var url = Constants.ApplicationURL + "/.auth/me";
				clienteHTTP.DefaultRequestHeaders.Add("X-ZUMO-AUTH", serviceUser.MobileServiceAuthenticationToken);

				var response = await clienteHTTP.GetStringAsync(url);
				response = response.Remove(0, 1);
				response = response.Remove(response.Length - 1);

				identidad = JsonConvert.DeserializeObject<Identidad>(response);

			}
			return true;
        }

        public Task<string> GetTokenAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SalirAsync()
        {
            throw new NotImplementedException();
        }
    }
}
