using System;
using iFlota.Forms.Servicios;
using iFlota.Forms.ViewModels.Base;

namespace iFlota.Forms.ViewModels.Vehiculos
{
	public class VehiculosViewModel : BaseViewModel
	{
		IDatosServicio datosServicio;

		public VehiculosViewModel()
		{
			this.Titulo = "Vehiculos";
		}
	}
}

