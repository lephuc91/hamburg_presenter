using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Pro.UI.Converters;

public class StringNullOrEmptyToVisibilityConverter : IValueConverter
{
	public bool IsInverted { get; set; }

	public object Convert(object? value, Type targetType, object parameter, CultureInfo culture)
	{
		bool flag = string.IsNullOrEmpty(value as string);
		if (IsInverted)
		{
			flag = !flag;
		}
		return (!flag) ? Visibility.Collapsed : Visibility.Visible;
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
