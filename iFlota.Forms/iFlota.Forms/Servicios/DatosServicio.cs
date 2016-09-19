using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iFlota.Forms.Modelos;
using iFlota.Forms.Servicios;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;


// Permite que esta clase sea llamada como un servicio multiplataforma
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
			var listaDatos = new List<Vehiculo>();

            //Hace un llamado al api rest de azure haciendo un filtrado tipo oData 
            IEnumerable<Vehiculo> resultado = await vehiculoTabla.ReadAsync<Vehiculo>("$filter=Usuarios/any(c: c/Id eq '" + usuarioId + "')");
			foreach (var vehiculo in resultado) 
			{ 
				listaDatos.Add(vehiculo);
			}

			return listaDatos;
		}
                
		public async Task<Usuario> getUsuarioByEmailConector(string email, string conector)
		{
            //Consulta a la table azure
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

