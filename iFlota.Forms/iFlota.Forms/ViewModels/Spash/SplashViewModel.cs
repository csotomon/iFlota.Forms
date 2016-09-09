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
        private bool estaPresentandoLoginUI;

        public bool EstaPresentandoLoginUI {
            get { return estaPresentandoLoginUI; }
            set
            {
                estaPresentandoLoginUI = value;
                OnPropertyChanged("EstaPresentandoLoginUI");
            } 
        }

        private string username = "alambrito@mane.com";
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                OnPropertyChanged("Username");
            }
        }

        private string password = "12345";
        public string Password
        {
            get { return password; }
             
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }


        public SplashViewModel(INavigation navegacion = null) : base(navegacion)
        {

        }



    }
}
