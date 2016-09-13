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
		private IMobileServiceTable<Usuario> usuarioTabla;

		public DatosServicio()
		{
			mobileClient = new MobileServiceClient(Constants.ApplicationURL);
			mobileClient.CurrentUser = App.AutenticacionServicio.ServiceUser;
			vehiculoTabla = mobileClient.GetTable<Vehiculo>();
			usuarioTabla = mobileClient.GetTable<Usuario>();
		}

		public async Task<IEnumerable<Vehiculo>> GetVehiculosPorUsuarioAsync(string usuarioId)
		{
			//https://iflota.azurewebsites.net/tables/Vehiculo?ZUMO-API-VERSION=2.0.0&$expand=Usuarios&$filter=Usuarios/any(c:%20c/Email%20eq%20%27csotomon@hotmail.com%27)
			var listaDatos = new List<Vehiculo>();

			IEnumerable<Vehiculo> resultado = await vehiculoTabla.ReadAsync<Vehiculo>("$filter=Usuarios/any(c: c/Id eq '" + usuarioId + "')");
			foreach (var vehiculo in resultado) 
			{ 
				listaDatos.Add(vehiculo);
			}

			return listaDatos;
		}

		public async Task<Usuario> getUsuarioByEmailConector(string email, string conector)
		{
			var datos = await usuarioTabla
			    .Where(a => a.Email==email)
				.Where(b => b.Conector==conector)
			    .ToListAsync();
			if (datos.Count == 0)
				return null;
			else
			{
				return datos[0];
			}

		}
	}
}

