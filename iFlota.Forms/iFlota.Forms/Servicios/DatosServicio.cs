using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iFlota.Forms.Modelos;
using iFlota.Forms.Servicios;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;

[assembly: Dependency(typeof(DatosServicio))]
namespace iFlota.Forms.Servicios
{
	public class DatosServicio: IDatosServicio
	{
		private MobileServiceClient mobileClient;
		private IMobileServiceTable<Vehiculo> vehiculoTabla;

		public DatosServicio()
		{
			mobileClient = new MobileServiceClient(Constants.ApplicationURL);
			mobileClient.CurrentUser = App.AutenticacionServicio.Usuario;
			vehiculoTabla = mobileClient.GetTable<Vehiculo>();
		}

		public Task<IEnumerable<Vehiculo>> GetVehiculosPorUsuario(string usuario)
		{
			//https://iflota.azurewebsites.net/tables/Vehiculo?ZUMO-API-VERSION=2.0.0&$expand=Usuarios&$filter=Usuarios/any(c:%20c/Email%20eq%20%27csotomon@hotmail.com%27)
			vehiculoTabla.Where(a => a.Usuarios.);

			throw new NotImplementedException();
		}
	}
}

