using System.Collections.Generic;
using System.Threading.Tasks;
using iFlota.Forms.Modelos;


namespace iFlota.Forms.Servicios
{
	public interface IDatosServicio
	{
		Task<IEnumerable<Vehiculo>> GetVehiculosPorUsuario(string usuario);
	}
}

