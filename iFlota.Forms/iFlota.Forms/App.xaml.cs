using iFlota.Forms.Managers;
using iFlota.Forms.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace iFlota.Forms
{
    public partial class App : Application
    {
        public static bool UsuarioLoggeado { get; set; }
        public App()
        {
            InitializeComponent();

            if (!LoginManager.Instancia.Autenticado)
                //MainPage = new NavigationPage(new LoginPage());
                MainPage = new MainPage();
            else
                MainPage = new NavigationPage(new iFlota.Forms.MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
