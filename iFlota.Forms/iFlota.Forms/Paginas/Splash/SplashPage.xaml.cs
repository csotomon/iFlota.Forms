using iFlota.Forms.Paginas.Base;
using iFlota.Forms.ViewModels.Spash;
using iFlota.Forms.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using iFlota.Forms.Localizacion;

namespace iFlota.Forms.Paginas.Splash
{
    public partial class SplashPage : SplashPageXaml
    {
        readonly IAutenticacionServicio autenticacionServicio;
        public SplashPage()
        {
            InitializeComponent();
            BindingContext = new SplashViewModel();
            //SplashTitle.Text = RecursosTexto.Splash_Title;
        }

		protected async override void OnAppearing()
		{
			base.OnAppearing();

			// fetch the demo credentials
			//await ViewModel.LoadDemoCredentials();

			// pause for a moment before animations
			await Task.Delay(App.VelocidadAnimacion);

			// Sequentially animate the login buttons. ScaleTo() makes them "grow" from a singularity to the full button size.
			await SignInButton.ScaleTo(1, (uint)App.VelocidadAnimacion, Easing.SinIn);
			await SkipSignInButton.ScaleTo(1, (uint)App.VelocidadAnimacion, Easing.SinIn);
		}
    }

    public abstract class SplashPageXaml : ModelBoundContentPage<SplashViewModel>
    {
        
    }
}
