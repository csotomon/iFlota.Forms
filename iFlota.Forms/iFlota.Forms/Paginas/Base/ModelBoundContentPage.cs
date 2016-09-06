using iFlota.Forms.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace iFlota.Forms.Paginas.Base
{
    public abstract class ModelBoundContentPage<T>: ContentPage where T:BaseViewModel
    {
        protected T ViewModel {
            get { return base.BindingContext as T; }
        }

        public new T BindingContext
        {
            set
            {
                base.BindingContext = value;
                base.OnPropertyChanged("BindingContext");
            }
        }
    }
}
