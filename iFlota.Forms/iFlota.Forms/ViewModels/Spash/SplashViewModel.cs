using iFlota.Forms.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace iFlota.Forms.ViewModels.Spash
{
    /// <summary>
    /// View Movel de la pagina de splash
    /// </summary>
    public class SplashViewModel : BaseViewModel
    {
        private bool estaPresentandoLoginUI;

        /// <summary>
        /// propiedad para saber si se esta presentado la interfaz de loggueo
        /// </summary>
        public bool EstaPresentandoLoginUI {
            get { return estaPresentandoLoginUI; }
            set
            {
                estaPresentandoLoginUI = value;
                OnPropertyChanged("EstaPresentandoLoginUI");
            } 
        }

        public SplashViewModel(INavigation navegacion = null) : base(navegacion)
        {

        }



    }
}
