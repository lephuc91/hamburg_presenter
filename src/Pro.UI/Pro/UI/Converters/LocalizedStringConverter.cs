using System;
using System.Globalization;
using System.Windows.Data;
using Pro.Localization;

namespace Pro.UI.Converters;

public class LocalizedStringConverter : IValueConverter
{
	public object Convert(object? value, Type targetType, object parameter, CultureInfo culture)
	{
		if (value is string key)
		{
			return LocalizedStrings.Get(key);
		}
		return string.Empty;
	}

	public object ConvertBack(object? value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
