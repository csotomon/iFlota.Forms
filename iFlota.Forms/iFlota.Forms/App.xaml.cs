using iFlota.Forms.Localizacion;
using iFlota.Forms.Paginas.Splash;
using System;

using Xamarin.Forms;
using System.Threading.Tasks;
using Plugin.Connectivity;
using iFlota.Forms.Modelos;
using iFlota.Forms.Paginas.Vehiculos;

namespace iFlota.Forms
{
	public partial class App : Application
    {
        /// <summary>
        /// Servicio de atenticacion multiplataforma
        /// </summary>
        private static Servicios.IAutenticacionServicio autenticacionServicio;
        /// <summary>
        /// Velocidad de las animaciones de las paginas de la aplicacion
        /// </summary>
		public static int VelocidadAnimacion = 250;
        /// <summary>
        /// variable para hacer seguimiento de si el usuario esta loggeado o no
        /// </summary>
        public static bool UsuarioLoggeado { get; set; }
        //Informacion del usuario loggeado
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
			//Verifica si el dispositivo tiene conexion a internet
			get { return CrossConnectivity.Current.IsConnected; }
		}

        public App()
        {
            InitializeComponent();

			app = this;

            // Si el dispositivo es un android o un IOS, trae la información de la configuracion
            // Regional
            // TODO: Falta la plataforma de windows phone
            if (Device.OS == TargetPlatform.iOS || Device.OS == TargetPlatform.Android)
            {
                var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
                RecursosTexto.Culture = ci;
                DependencyService.Get<ILocalize>().SetLocale(ci);
            }

			autenticacionServicio = DependencyService.Get<Servicios.IAutenticacionServicio>();

            //Si el usuario no esta autenticado muestra el splash
            if (!autenticacionServicio.EstaAutenticado)
                MainPage = new SplashPage();
            else
                CargarPrincipal();


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

        /// <summary>
        /// Ejecuta la accion dada solo si esta conectado a la red
        /// </summary>
        /// <param name="accionAEjecutar">funcion a ejecutar</param>
        /// <returns>Retorna la tarea asincronica</returns>
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
        /// <summary>
        /// Muestra una alerta de problema de conexion a internet
        /// </summary>
        /// <returns>Retorna la tarea asincronica</returns>
		static async Task MostarAlertaConexionRed()
		{
			
			await AppActual.MainPage.DisplayAlert(
				RecursosTexto.NetworkConnection_Alert_Title,
				RecursosTexto.NetworkConnection_Alert_Message,
				RecursosTexto.NetworkConnection_Alert_Confirm);
		}
        /// <summary>
        /// Carga la pagina principal de la aplicacion
        /// </summary>
		public static void CargarPrincipal()
		{
			if (Device.OS == TargetPlatform.iOS)
			{
				// TODO: Debo mostrar una pagina con tabs, por ahora muestro la pagina de contenido
				AppActual.MainPage = new VehiculosPage();
			}
			else
			{
				AppActual.MainPage = new VehiculosPage();
			}
		}

    }
}
