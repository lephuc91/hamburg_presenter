using System;
using System.Globalization;
using System.Windows.Data;

namespace Pro.UI.Converters;

public class IsNotNullToBoolConverter : IValueConverter
{
	public object Convert(object? value, Type targetType, object parameter, CultureInfo culture)
	{
		return value != null && !value.GetType().IsValueType;
	}

	public object ConvertBack(object? value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}
