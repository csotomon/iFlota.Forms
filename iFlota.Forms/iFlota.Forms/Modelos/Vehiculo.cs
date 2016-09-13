using System;
using System.Collections.Generic;

namespace iFlota.Forms.Modelos
{
	public class Vehiculo
	{
		public string Id { get; set; }
		public string Placas { get; set; }
		//public Empresa Empresa { get; set; }
		public DateTime FechaCompra { get; set; }
		public string Consesionario { get; set; }
		public float ValorCompra { get; set; }
		public string Matricula { get; set; }
		public DateTime fechaMatricula { get; set; }
		public int Kilometraje { get; set; }
	}
}

