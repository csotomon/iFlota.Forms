using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

/// <summary>
/// ViewModel básico para ser heredado por otras clases. 
/// </summary>
namespace iFlota.Forms.ViewModels.Base
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        bool puedeCargarMas;
        public const string puedeCargarMasPropertyName = "PuedeCargarMas";

        public bool PuedeCargarMas
        {
            get { return puedeCargarMas; }
            set { SetProperty(ref puedeCargarMas, value, puedeCargarMasPropertyName); }
        }

        bool estaOcupado;
        public const string estaOcupadoPropertyName = "EstaOcupado";

        public bool EstaOcupado {
            get { return estaOcupado; }
            set { SetProperty(ref estaOcupado, value, estaOcupadoPropertyName); }
        }

        string titulo = String.Empty;
        public const string tituloPropertyName = "Titulo";

        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;

        public string Titulo {
            get { return titulo; }
            set { SetProperty(ref titulo, value, tituloPropertyName); }
        }

        string subtitulo = String.Empty;
        public const string subtituloPropertyName = "Subtitulo";

        public string Subtitulo
        {
            get { return subtitulo; }
            set { SetProperty(ref subtitulo, value, subtituloPropertyName); }
        }

        string icono = null;
        public const string IconoPropertyName = "Icono";

        public string Icono
        {
            get { return icono; }
            set { SetProperty(ref icono, value, IconoPropertyName); }
        }



        public INavigation Navigation { get; set; }

        public bool EstaInicializado { get; set; }

      
        public BaseViewModel(INavigation navigation = null)
        {
            Navigation = navigation;
        }

        public async Task PushModalAsync(Page page)
        {
            if (Navigation != null)
                await Navigation.PushModalAsync(page);
        }

        public async Task PopModalAsync()
        {
            if (Navigation != null)
                await Navigation.PopModalAsync();
        }

        public async Task PushAsync(Page page)
        {
            if (Navigation != null)
                await Navigation.PushAsync(page);
        }

        public async Task PopAsync()
        {
            if (Navigation != null)
                await Navigation.PopAsync();
        }

        protected void SetProperty<U>(
            ref U backingStore, U valor,
            string propertyName,
            Action onChanged = null,
            Action<U> onChanging = null)
        {
            if (EqualityComparer<U>.Default.Equals(backingStore, valor))
                return;

            if (onChanging != null)
                onChanging(valor);

            OnPropertyChanging(propertyName);

            backingStore = valor;

            if (onChanged != null)
                onChanged();

            OnPropertyChanged(propertyName);
        }

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void OnPropertyChanging(string propertyName)
        {
            if (PropertyChanging == null)
                return;

            PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
        }
    }
}
