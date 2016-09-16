using iFlota.Forms.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace iFlota.Forms.Paginas.Base
{
    public abstract class ModelBoundContentPage<TViewModel> : ContentPage where TViewModel : BaseViewModel
    {
        protected TViewModel ViewModel {
            get { return base.BindingContext as TViewModel; }
        }

        public new TViewModel BindingContext
        {
            set
            {
                base.BindingContext = value;
                base.OnPropertyChanged("BindingContext");
            }
        }
    }
}
