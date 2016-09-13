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
	public partial class SplashPage : SplashPageXaml
	{
		readonly IAutenticacionServicio autenticacionServicio;
		public SplashPage()
		{
			InitializeComponent();
			BindingContext = new SplashViewModel();
			autenticacionServicio = App.AutenticacionServicio;

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

			// fetch the demo credentials
			//await ViewModel.LoadDemoCredentials();

			// pause for a moment before animations
			await Task.Delay(App.VelocidadAnimacion);

			// Sequentially animate the login buttons. ScaleTo() makes them "grow" from a singularity to the full button size.
			await LoginButton.ScaleTo(1, (uint)App.VelocidadAnimacion, Easing.SinIn);
			await SkipSignInButton.ScaleTo(1, (uint)App.VelocidadAnimacion, Easing.SinIn);
		}

		async void BotonLoginPresionado()
		{
			System.Diagnostics.Debug.WriteLine("prueba");
			await App.EjecutarSiConectado(async () =>
				{
					// trigger the activity indicator through the IsPresentingLoginUI property on the ViewModel
					ViewModel.EstaPresentandoLoginUI = true;

					if (await Autenticar())
					{
						// Pop off the modally presented SplashPage.
						// Note that we're not popping the ADAL auth UI here; that's done automatcially by the ADAL library when the Authenticate() method returns.
						App.CargarPrincipal();

						// Broadcast a message that we have sucessdully authenticated.
						// This is mostly just for Android. We need to trigger Android to call the SalesDashboardPage.OnAppearing() method,
						// because unlike iOS, Android does not call the OnAppearing() method each time that the Page actually appears on screen.
						MessagingCenter.Send(this, MessagingServiceConstantes.AUTENTICADO);
					}
				});
		}

		async Task<bool> Autenticar()
		{
			bool exitoso = false;

			try
			{
				// The underlying call behind App.Authenticate() calls the ADAL library, which presents the login UI and awaits success.
				var registrado = await autenticacionServicio.AutenticarAsync(MobileServiceAuthenticationProvider.MicrosoftAccount.ToString());
				if (registrado)
				{
					IDatosServicio datosServicio = DependencyService.Get<IDatosServicio>();
					var identidad = App.AutenticacionServicio.Identidad;
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




    public abstract class SplashPageXaml : ModelBoundContentPage<SplashViewModel>
    {
        
    }
}
