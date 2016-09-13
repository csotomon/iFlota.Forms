using iFlota.Forms.Localizacion;
using iFlota.Forms.Paginas.Splash;
using System;

using Xamarin.Forms;
using System.Threading.Tasks;
using Plugin.Connectivity;
using iFlota.Forms.Modelos;

namespace iFlota.Forms
{
	public partial class App : Application
    {
        private static Servicios.IAutenticacionServicio autenticacionServicio;
		public static int VelocidadAnimacion = 250;
        public static bool UsuarioLoggeado { get; set; }
		public static Usuario Usuario { get; set;} 
		static Application app;
		public static Application AppActual
		{
			get { return app; }
		}

		public static Servicios.IAutenticacionServicio AutenticacionServicio 
		{ 
			get { return autenticacionServicio; }
		}

		/// <summary>
		/// Indica si el dispositivo tiene conexion.
		/// </summary>
		/// <value><c>true</c> Si el dispositivo tiene conexion, de lo contrario <c>false</c>.</value>
		public static bool EstaConectado
		{
			//Verifica si el dispositivo tiene conexion
			get { return CrossConnectivity.Current.IsConnected; }
		}

        public App()
        {
            InitializeComponent();

			app = this;

            if (Device.OS == TargetPlatform.iOS || Device.OS == TargetPlatform.Android)
            {
                var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
                RecursosTexto.Culture = ci;
                DependencyService.Get<ILocalize>().SetLocale(ci);
            }

			autenticacionServicio = DependencyService.Get<Servicios.IAutenticacionServicio>();

			if(!autenticacionServicio.EstaAutenticado)
				MainPage = new SplashPage();
            //MainPage = new LoginPage();

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

		public static async Task EjecutarSiConectado(Func<Task> accionAEjecutar)
		{
			if (EstaConectado)
			{
				await accionAEjecutar();
			}
			else
			{
				await MostarAlertaConexionRed();
			}
		}

		static async Task MostarAlertaConexionRed()
		{
			
			await AppActual.MainPage.DisplayAlert(
				RecursosTexto.NetworkConnection_Alert_Title,
				RecursosTexto.NetworkConnection_Alert_Message,
				RecursosTexto.NetworkConnection_Alert_Confirm);
		}

		public static void CargarPrincipal()
		{
			if (Device.OS == TargetPlatform.iOS)
			{
				//AppActual.MainPage = new RootTabPage();
				AppActual.MainPage = new VehiculoPage();
			}
			else
			{
				//AppActual.MainPage = new RootPage();
				AppActual.MainPage = new VehiculoPage();
			}
		}

    }
}
