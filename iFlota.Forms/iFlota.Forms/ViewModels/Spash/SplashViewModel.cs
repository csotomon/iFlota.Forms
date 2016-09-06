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
        //readonly IConfigFetcher _ConfigFetcher;
        bool estaPResentandoLoginUI;

        public bool EstaPresentandoLoginUI {
            get { return estaPResentandoLoginUI; }
            set
            {
                estaPResentandoLoginUI = value;
                OnPropertyChanged("EstaPresentandoLoginUI");
            } 
        }

        string username = "alambrito@mane.com";
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                OnPropertyChanged("Username");
            }
        }

        //string password


        public SplashViewModel(INavigation navegacion = null) : base(navegacion)
        {

        }



    }
}
