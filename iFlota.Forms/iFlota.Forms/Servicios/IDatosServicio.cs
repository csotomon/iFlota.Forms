using System.Collections.Generic;
using System.Threading.Tasks;
using iFlota.Forms.Modelos;


namespace iFlota.Forms.Servicios
{
    /// <summary>
    /// Interfaz para la implementacion multiplataforma de obtecion de datos del servico
    /// mobil de azure
    /// </summary>
	public interface IDatosServicio
	{
        /// <summary>
        /// Obtiene los vehiculos matriculados para el id de usuario indicado
        /// </summary>
        /// <param name="usuarioId"></param>
        /// <returns>Lista de vehiculos matriculados para ese usuario</returns>
		Task<IEnumerable<Vehiculo>> GetVehiculosPorUsuarioAsync(string usuarioId);
        /// <summary>
        /// Obtiene el usuario los datos de un usuario dado el email y el proveedor OAuth
        /// </summary>
        /// <param name="email"></param>
        /// <param name="conector"></param>
        /// <returns>El usuario en la base de datos</returns>
		Task<Usuario> getUsuarioByEmailConector(string email, string conector);
	}
}

