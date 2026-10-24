using System;
using System.Globalization;
using System.Windows;
using Pro.UI.Converters;

namespace ProPresenter.UI.Converters;

public class MacroAddVisibilityMultiConverter : MultiValueConverterBase<Visibility>
{
	protected override Visibility ConvertValues(object?[] values, Type targetType, object? parameter, CultureInfo culture)
	{
		if (!(values[0] is int num) || !(values[1] is string value) || num <= 0 || !string.IsNullOrEmpty(value))
		{
			return Visibility.Collapsed;
		}
		return Visibility.Visible;
	}
}
