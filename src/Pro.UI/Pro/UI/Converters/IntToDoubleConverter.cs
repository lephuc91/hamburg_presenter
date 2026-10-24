using System;
using System.Globalization;
using System.Windows.Data;

namespace Pro.UI.Converters;

public class IntToDoubleConverter : IValueConverter
{
	public object Convert(object? value, Type targetType, object parameter, CultureInfo culture)
	{
		if (value is int num)
		{
			return (double)num;
		}
		return 0.0;
	}

	public object ConvertBack(object? value, Type targetType, object parameter, CultureInfo culture)
	{
		if (value is double num)
		{
			return (int)num;
		}
		return 0;
	}
}
