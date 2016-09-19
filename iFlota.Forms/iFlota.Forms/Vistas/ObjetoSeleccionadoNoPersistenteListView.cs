using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace iFlota.Forms.Vistas
{
    public class ObjetoSeleccionadoNoPersistenteListView : ListView
    {
        public ObjetoSeleccionadoNoPersistenteListView()
        {
            ItemSelected += (sender, e) => SelectedItem = null;
        }
    }
}
