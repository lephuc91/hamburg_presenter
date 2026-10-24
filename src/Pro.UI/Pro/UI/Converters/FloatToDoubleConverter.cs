using System;
using System.Globalization;
using System.Windows.Data;

namespace Pro.UI.Converters;

public class FloatToDoubleConverter : IValueConverter
{
	public object Convert(object? value, Type targetType, object parameter, CultureInfo culture)
	{
		if (value is float num)
		{
			return (double)num;
		}
		return 0.0;
	}

	public object ConvertBack(object? value, Type targetType, object parameter, CultureInfo culture)
	{
		if (value is double num)
		{
			return (float)num;
		}
		return 0f;
	}
}
