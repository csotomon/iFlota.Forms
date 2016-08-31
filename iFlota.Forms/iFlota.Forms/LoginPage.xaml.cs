using iFlota.Forms.Util;
using iFlota.Forms.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;

namespace iFlota.Forms
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

           

        }

        private async void OnHacerLogin(object sender, EventArgs e)
        {
            IAutenticacionServicio autenticar = DependencyService.Get<IAutenticacionServicio>();
            Button boton = (Button)sender;
            if (sender == MicrosoftButton)
            {
                bool test= await LoginManager.Instancia.Autenticar(Microsoft.WindowsAzure.MobileServices.MobileServiceAuthenticationProvider.MicrosoftAccount);
            }
            else if (sender == FacebooktButton)
            {
                bool test = await LoginManager.Instancia.Autenticar(Microsoft.WindowsAzure.MobileServices.MobileServiceAuthenticationProvider.Facebook);
            }
            else if (sender == GoogleButton)
            {
                bool test = await LoginManager.Instancia.Autenticar(Microsoft.WindowsAzure.MobileServices.MobileServiceAuthenticationProvider.Google);
            }


        }
    }
}
