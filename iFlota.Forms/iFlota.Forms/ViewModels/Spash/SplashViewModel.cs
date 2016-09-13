using iFlota.Forms.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace iFlota.Forms.ViewModels.Spash
{
    public class SplashViewModel : BaseViewModel
    {
        private bool estaPresentandoLoginUI;

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
