using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iFlota.Forms.Statics
{
    /// <summary>
    /// Clase para el manejo de constantes para la interfaz de usuario xaml
    /// </summary>
    public static class TamanosFila
    {
        public readonly static double AltoFilaLargaDouble = 60;
        public readonly static double AltoFilaMedianaDouble = 44;
        public readonly static double AltoFilaPequenaDouble = 30;

        public static int AltoFilaLargaInt { get { return (int)AltoFilaLargaDouble; } }
        public static int AltoFilaMedianaInt { get { return (int)AltoFilaMedianaDouble; } }
        public static int AltoFilaPequenaInt { get { return (int)AltoFilaPequenaDouble; } }
    }
}
