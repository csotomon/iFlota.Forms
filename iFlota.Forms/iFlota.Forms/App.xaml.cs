using iFlota.Forms.Managers;
using iFlota.Forms.Paginas.Splash;
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
        readonly iFlota.Forms.Servicios.IAutenticacionServicio _AutenticacionServicio;

        public static bool UsuarioLoggeado { get; set; }
        public App()
        {
            InitializeComponent();

            MainPage = new SplashPage();

            /*
            _AutenticacionServicio = DependencyService.Get<iFlota.Forms.Servicios.IAutenticacionServicio>();

            //TextResources.Culture = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();

            if (!_AutenticacionServicio.EstaAutenticado)
                //MainPage = new NavigationPage(new LoginPage());
                MainPage = new MainPage();
            else
                MainPage = new NavigationPage(new iFlota.Forms.MainPage());
                */
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
