using iFlota.Forms.Paginas.Base;
using iFlota.Forms.ViewModels.Spash;
using iFlota.Forms.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace iFlota.Forms.Paginas.Splash
{
    public partial class SplashPage : SplashPageXaml
    {
        readonly IAutenticacionServicio autenticacionServicio;
        public SplashPage()
        {
            InitializeComponent();
            BindingContext = new SplashViewModel();
        }
    }

    public abstract class SplashPageXaml : ModelBoundContentPage<SplashViewModel>
    {
        /*
        public SplashPageXaml() {
            BindingContext = new SplashViewModel();
        }
        */
    }
}
