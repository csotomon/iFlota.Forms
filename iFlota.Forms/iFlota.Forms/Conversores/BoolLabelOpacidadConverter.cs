﻿using System;
using System.Globalization;
using Xamarin.Forms;

namespace iFlota.Forms.Conversores
{
	public class BoolLabelOpacidadConverter : IValueConverter
	{
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

