using iFlota.Forms.ViewModels.Base;
using Xamarin.Forms;

namespace iFlota.Forms.Paginas.Base
{
    /// <summary>
    /// Clase genérica tipo ContentPage para ser implementada por las páginas
    /// xaml y ayuda a manejar el modelo MVVM
    /// </summary>
    /// <typeparam name="TViewModel">View Model de la página</typeparam>
    public abstract class ModelBoundContentPage<TViewModel> : ContentPage where TViewModel : BaseViewModel
    {
        /// <summary>
        /// Obtiene el View Model generico del bindingConext
        /// </summary>
        /// <value>View Model de la pagina</value>
        protected TViewModel ViewModel {
            get { return base.BindingContext as TViewModel; }
        }

        /// <summary>
        /// Setea el View Model de la página
        /// </summary>
        public new TViewModel BindingContext
        {
            set
            {
                base.BindingContext = value;
                // Dispara el listener de cambios
                base.OnPropertyChanged("BindingContext");
            }
        }
    }
}
