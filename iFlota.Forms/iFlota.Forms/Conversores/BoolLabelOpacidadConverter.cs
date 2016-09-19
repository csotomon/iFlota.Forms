using System;
using System.Globalization;
using Xamarin.Forms;

namespace iFlota.Forms.Conversores
{
    /// <summary>
    /// Clase que sirve para devolver un valor de opacidad de acuerdo a un valor booleando
    /// </summary>
	public class BoolLabelOpacidadConverter : IValueConverter
	{
        /// <summary>
        /// Recibe un valor booleando para definir el nivel de opacidad de el elemento xaml
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>0.5 si el valor es verdadero, 1 si es falso</returns>
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if ((bool)value)
			{
				return 0.5d;
			}
			else
			{
				return 1.0d;
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}

