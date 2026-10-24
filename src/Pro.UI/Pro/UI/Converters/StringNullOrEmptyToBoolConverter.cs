using System;
using System.Globalization;
using System.Windows.Data;

namespace Pro.UI.Converters;

public class StringNullOrEmptyToBoolConverter : IValueConverter
{
	public bool TrueWhenNonEmpty { get; set; } = true;

	public object Convert(object? value, Type targetType, object parameter, CultureInfo culture)
	{
		return TrueWhenNonEmpty ^ string.IsNullOrEmpty(value as string);
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
