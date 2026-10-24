using System;
using System.Globalization;
using System.Windows.Data;

namespace Pro.UI.Converters;

public class TypeOfConverter : IValueConverter
{
	public object Convert(object? value, Type targetType, object parameter, CultureInfo culture)
	{
		return value?.GetType() ?? typeof(object);
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
