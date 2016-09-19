using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace iFlota.Forms.Conversores
{
    /// <summary>
    /// Clase que Invierte el valor booleando dado
    /// </summary>
    class InvertirBooleanConverter : IValueConverter
    {
        /// <summary>
        /// Convierte el valor booleando dado en un xaml
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>falso si el valor es verdadero, verdadero si el valor es falso</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(bool)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(bool)value;
        }
    }
}
