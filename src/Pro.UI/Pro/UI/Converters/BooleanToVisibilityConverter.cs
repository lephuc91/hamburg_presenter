using System;
using System.Globalization;
using System.Windows;

namespace Pro.UI.Converters;

public class BooleanToVisibilityConverter : ValueConverterBase<bool, Visibility>
{
	public bool Invert { get; set; }

	public bool IsCollapsing { get; set; } = true;

	protected override Visibility ConvertValue(bool value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (!(Invert ? (!value) : value))
		{
			if (!IsCollapsing)
			{
				return Visibility.Hidden;
			}
			return Visibility.Collapsed;
		}
		return Visibility.Visible;
	}
}
