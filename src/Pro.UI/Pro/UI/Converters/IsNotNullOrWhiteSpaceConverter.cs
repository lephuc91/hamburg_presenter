using System;
using System.Globalization;
using System.Windows.Data;

namespace Pro.UI.Converters;

public class IsNotNullOrWhiteSpaceConverter : IValueConverter
{
	public object Convert(object? value, Type targetType, object parameter, CultureInfo culture)
	{
		return !string.IsNullOrWhiteSpace(value as string);
	}

	public object ConvertBack(object? value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}
