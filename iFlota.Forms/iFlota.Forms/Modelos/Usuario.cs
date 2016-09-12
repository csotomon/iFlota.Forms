using System;
using System.Collections.Generic;

namespace iFlota.Forms.Modelos
{
	public class Usuario
	{
		public Usuario()
		{
			public string Id { get; set; }
			public string Email { get; set; }
			public string Nombres { get; set; }
			public string Apellidos { get; set; }
			public string Foto { get; set; }
			public string Conector { get; set; }
			public bool Bloqueado { get; set; }
			public IEnumerable<Vehiculo> Vehiculos { get; set; }
		}
	}
}

