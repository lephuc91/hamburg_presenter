using System;
using System.Globalization;
using System.Windows.Data;

namespace Pro.UI.Converters;

public class IsInstanceOfTypeConverter : IValueConverter
{
	public Type Type { get; set; } = typeof(object);

	public object Convert(object? value, Type targetType, object parameter, CultureInfo culture)
	{
		return Type.IsAssignableFrom(value?.GetType() ?? typeof(object));
	}

	public object ConvertBack(object? value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
