using iFlota.Forms.Paginas.Base;
using iFlota.Forms.ViewModels.Spash;
using iFlota.Forms.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using iFlota.Forms.Localizacion;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using iFlota.Forms.Statics;
using iFlota.Forms.Modelos;

namespace iFlota.Forms.Paginas.Splash
{
    /// <summary>
    /// Clase que implementa el xaml de la pagina splash y hereda de
    /// la clase MVVM
    /// </summary>
	public partial class SplashPage : SplashPageXaml
	{
        /// <summary>
        /// Implementacion del servicio de autenticacion multiplataforma
        /// </summary>
        readonly IAutenticacionServicio autenticacionServicio;
		public SplashPage()
		{
			InitializeComponent();
			BindingContext = new SplashViewModel();
			autenticacionServicio = App.AutenticacionServicio;

            //Listener de click sobre el boton
			LoginButton.GestureRecognizers.Add(
				new TapGestureRecognizer()
				{
					NumberOfTapsRequired = 1,
					Command = new Command(BotonLoginPresionado)
				});
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();

			// Pausa pra mostar las animaciones de los botones.
			await Task.Delay(App.VelocidadAnimacion);

            //Muestra la animacion del boton de login.
            await LoginButton.ScaleTo(1, (uint)App.VelocidadAnimacion, Easing.SinIn);
			await SkipSignInButton.ScaleTo(1, (uint)App.VelocidadAnimacion, Easing.SinIn);
		}

        /// <summary>
        /// Se ejecuta cuando el boton es presionado
        /// </summary>
		async void BotonLoginPresionado()
		{
            // Llamado al listener de la plase principal de la aplicación
            // Se ejecuta solo se detecta una conexion de datos
            await App.EjecutarSiConectado(async () =>
				{
					// Dispara en el view model el indicador de que se está presentando la interfaz de login
					ViewModel.EstaPresentandoLoginUI = true;

                    //Se la autenticacion es correcta
					if (await Autenticar())
					{
                        //llama la funcion que quita la pantalla de splash y muestra la principal de la aplicacion
                        App.CargarPrincipal();

						// Manda un mensaje de broadcast para indicar que se ha auntenticado
                        // Esto se hace para disparar el metodo onAppering en android
                        MessagingCenter.Send(this, MessagingServiceConstantes.AUTENTICADO);
					}
				});
		}

        /// <summary>
        /// Autentica al usuario ante azure
        /// </summary>
        /// <returns>Verdadero si se antentico</returns>
		async Task<bool> Autenticar()
		{
			bool exitoso = false;

			try
			{
                // llama la interfaz de autenticado de azure contra el servicio de microsoft
                // TODO: Manejar multi proveedor de autenticacion
                var registrado = await autenticacionServicio.AutenticarAsync(MobileServiceAuthenticationProvider.MicrosoftAccount.ToString());
				if (registrado)
				{
                    // Llama al servicio multiplataforma para la obtencion de datos del usuario
                    IDatosServicio datosServicio = DependencyService.Get<IDatosServicio>();
					var identidad = App.AutenticacionServicio.Identidad;
                    // Obtiene los datos del API REST dado el email y el proveedor de autenticacion
					Usuario usuario = await datosServicio.getUsuarioByEmailConector(identidad.UserId, identidad.ProviderName);
					if (usuario != null)
					{
						App.Usuario = usuario;
						exitoso = true;
					}
				}

			}
			catch (Exception ex)
			{
                // TODO: mensaje multi lenguaje
                if (!(ex is InvalidOperationException && ex.Message== "Authentication was cancelled by the user.") )
				{ 
					await DisplayAlert("Login error", "An unknown login error has occurred. Please try again.", "OK");
				}
			}
			finally
			{
				// When the App.Authenticate() returns, the login UI is hidden, regardless of success (for example, if the user taps "Cancel" in iOS).
				// This means the SplashPage will be visible again, so we need to make the sign in button clickable again by hiding the activity indicator (via the IsPresentingLoginUI property).
				ViewModel.EstaPresentandoLoginUI = false;
			}

			return exitoso;
		}


	}

    /// <summary>
    /// Clase que hereda de la clase base tipo Content y asigna el Modelo
    /// </summary>
    public abstract class SplashPageXaml : ModelBoundContentPage<SplashViewModel>
    {
        
    }
}
