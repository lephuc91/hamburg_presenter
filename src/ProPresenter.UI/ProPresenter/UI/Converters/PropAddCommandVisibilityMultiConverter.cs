using System;
using System.Globalization;
using System.Windows;
using Pro.UI.Converters;

namespace ProPresenter.UI.Converters;

internal class PropAddCommandVisibilityMultiConverter : MultiValueConverterBase<Visibility>
{
	protected override Visibility ConvertValues(object?[] values, Type targetType, object? parameter, CultureInfo culture)
	{
		if (values.Length >= 2 && values[0] is int num)
		{
			string value = (values[1] as string) ?? string.Empty;
			if (num == 0 && string.IsNullOrEmpty(value))
			{
				return Visibility.Visible;
			}
		}
		return Visibility.Collapsed;
	}
}
