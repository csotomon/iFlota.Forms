using iFlota.Forms.Paginas.Base;
using iFlota.Forms.ViewModels.Vehiculos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using System.Collections.ObjectModel;
using iFlota.Forms.Modelos;


namespace iFlota.Forms.Paginas.Vehiculos
{
    public partial class VehiculosPage : VehiculosPageXaml
    {
        ObservableCollection<Vehiculo> vehiculos = new ObservableCollection<Vehiculo>();

		public VehiculosPage()
        {
            InitializeComponent();
            Title = "Vehiculos";
        }
    }

    public abstract class VehiculosPageXaml : ModelBoundContentPage<VehiculosViewModel> { }
}


