using System;
using iFlota.Forms.Servicios;
using iFlota.Forms.ViewModels.Base;
using Xamarin.Forms;

namespace iFlota.Forms.ViewModels.Vehiculos
{
	public class VehiculosViewModel : BaseViewModel
	{
		IDatosServicio datosServicio;

		public VehiculosViewModel()
		{
			this.Titulo = "Vehiculos";
            datosServicio= DependencyService.Get<IDatosServicio>();

        }
	}
}

