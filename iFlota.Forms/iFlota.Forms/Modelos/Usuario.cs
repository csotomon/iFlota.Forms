namespace iFlota.Forms.Modelos
{
    /// <summary>
    /// Clase que representa la informaciòn del usuario obtenida desde el API REST
    /// </summary>
    public class Usuario
	{

		public string Id { get; set; }
		public string Email { get; set; }
		public string Nombres { get; set; }
		public string Apellidos { get; set; }
		public string Foto { get; set; }
		public string Conector { get; set; }
		public bool Bloqueado { get; set; }
	}
}

