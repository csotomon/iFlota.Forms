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
    /// <summary>
    /// Implementacion de la interfaz de servicio de autenticacion
    /// </summary>
	public class AutenticacionServicio : IAutenticacionServicio
    {
        IAutenticador autenticador;
		MobileServiceUser serviceUser;
		Identidad identidad;

        public AutenticacionServicio()
        {
            // Obtiene la implementacion del servicio de autenticador multiplataforma
            autenticador = DependencyService.Get<IAutenticador>();
        }

        /// <summary>
        /// Indicado si el usuario está autenticado o no
        /// </summary>
        /// <value>Retorna verdadero si el usuario esta autenticado, de lo contrario falso</value>
        public bool EstaAutenticado
        {
            get { return serviceUser != null;}
        }
        /// <summary>
        /// Identidad OAuth del usuario
        /// </summary>
		public Identidad Identidad
		{
			get{ return identidad; }
		}

        /// <summary>
        /// Objeto MobileServiceUser obtenido de los servicios mobiles de Azure.
        /// </summary>
		public MobileServiceUser ServiceUser
		{
			get{ return serviceUser;}
		}

        /// <summary>
        /// Autenticar el usuario de acuerdo al servicio de autenticacion OAuth dado
        /// </summary>
        /// <param name="servicio"></param>
        /// <returns></returns>
		public async Task<bool> AutenticarAsync(string servicio)
        {
            // Llama al servicio del autenticador
            serviceUser = await autenticador.Autenticar(servicio);

            // Hace un llamado al API de azure para obtener la identidad del usuario atenticado
            using (var clienteHTTP = new HttpClient())
			{ 
				var url = Constants.ApplicationURL + "/.auth/me";
				clienteHTTP.DefaultRequestHeaders.Add("X-ZUMO-AUTH", serviceUser.MobileServiceAuthenticationToken);

				var response = await clienteHTTP.GetStringAsync(url);
                // Remueve el primer y ultimo caracter de la respuesta del servicio para cumplir el estadar JSON
                response = response.Remove(0, 1);
				response = response.Remove(response.Length - 1);

                // Covierte el resultado JSON a el objeto identidad
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
