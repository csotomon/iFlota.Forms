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
        /// <summary>
        /// Variable del modelo que me permite mostar si la aplicacion esta ocupada en un proceso
        /// </summary>
        bool estaOcupado;
        public const string estaOcupadoPropertyName = "EstaOcupado";

        public bool EstaOcupado {
            get { return estaOcupado; }
            set { SetProperty(ref estaOcupado, value, estaOcupadoPropertyName); }
        }

        /// <summary>
        /// Titulo de la pagina
        /// </summary>
        string titulo = String.Empty;
        public const string tituloPropertyName = "Titulo";

        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;

        public string Titulo {
            get { return titulo; }
            set { SetProperty(ref titulo, value, tituloPropertyName); }
        }

        /// <summary>
        /// Subtitulo de la pagina
        /// </summary>
        string subtitulo = String.Empty;
        public const string subtituloPropertyName = "Subtitulo";

        public string Subtitulo
        {
            get { return subtitulo; }
            set { SetProperty(ref subtitulo, value, subtituloPropertyName); }
        }

        /// <summary>
        /// Icono de la plagina
        /// </summary>
        string icono = null;
        public const string IconoPropertyName = "Icono";

        public string Icono
        {
            get { return icono; }
            set { SetProperty(ref icono, value, IconoPropertyName); }
        }

        /// <summary>
        /// Objeto de navegacion de la pagina
        /// </summary>
        public INavigation Navigation { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="navigation">Navegador de la pagina</param>
        public BaseViewModel(INavigation navigation = null)
        {
            Navigation = navigation;
        }

        /// <summary>
        /// Agrega una pagina modal a la pila de navegacion
        /// </summary>
        /// <param name="page">pagina a agregar</param>
        /// <returns>Tarea Asincornica</returns>
        public async Task PushModalAsync(Page page)
        {
            if (Navigation != null)
                await Navigation.PushModalAsync(page);
        }

        /// <summary>
        /// Elimina la pagina modal actual de la pila ed navecacion
        /// </summary>
        /// <returns>Tarea Asincronica</returns>
        public async Task PopModalAsync()
        {
            if (Navigation != null)
                await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Agrega una pagina a la pila de navegacion
        /// </summary>
        /// <param name="page">pagina a agregar</param>
        /// <returns>Tarea Asincornica</returns>
        public async Task PushAsync(Page page)
        {
            if (Navigation != null)
                await Navigation.PushAsync(page);
        }

        /// <summary>
        /// Elimina la pagina actual de la pila ed navecacion
        /// </summary>
        /// <returns>Tarea Asincronica</returns>
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
