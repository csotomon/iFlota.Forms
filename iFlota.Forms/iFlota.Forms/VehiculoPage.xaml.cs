using iFlota.Forms.DataObjects;
using iFlota.Forms.Managers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace iFlota.Forms
{
    public partial class VehiculoPage : ContentPage
    {
        ObservableCollection<Vehiculo> vehiculos = new ObservableCollection<Vehiculo>();
        public VehiculoPage()
        {
            InitializeComponent();
            vehiculos.Add(new Vehiculo { Placas = "ABC 123" });
            vehiculos.Add(new Vehiculo { Placas = "DEF 456" });
            //listaVehiculos.ItemsSource = LoginManager.Instancia.Usuario.Vehiculos;
            listaVehiculos.ItemsSource = vehiculos;
        }

        private async void OnSeleccion(object sender, EventArgs e)
        {
            //LoginManager.Instancia.Vehiculo = (Vehiculo)listaVehiculos.SelectedItem;
            //Application.Current.MainPage = new MainPage();
        }
    }
}
