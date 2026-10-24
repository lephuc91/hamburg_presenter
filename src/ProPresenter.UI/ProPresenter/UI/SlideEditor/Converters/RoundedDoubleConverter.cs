using System;
using System.Globalization;
using System.Windows.Data;

namespace ProPresenter.UI.SlideEditor.Converters;

public class RoundedDoubleConverter : IValueConverter
{
	public bool IsNegativeAllowed { get; set; }

	public RoundedDoubleConverter()
	{
		IsNegativeAllowed = false;
	}

	public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (value is double value2)
		{
			return IsNegativeAllowed ? Math.Round(value2, 0) : Math.Abs(Math.Round(value2, 0));
		}
		return value;
	}

	public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (!(value is double))
		{
			return null;
		}
		return (double)value;
	}
}
