using System;
using System.Globalization;
using System.Windows.Media;
using Pro.Common.Utility;

namespace Pro.UI.Converters;

public class ColorInverterConverter : ValueConverterBase<object, SolidColorBrush>
{
	protected override SolidColorBrush ValidationFailResult { get; } = Brushes.Black;

	protected override SolidColorBrush ConvertValue(object value, Type targetType, object? parameter, CultureInfo culture)
	{
		Color color = Colors.Black;
		if (value is SolidColorBrush solidColorBrush)
		{
			color = solidColorBrush.Color;
		}
		else if (value is Color color2)
		{
			color = color2;
		}
		if (!color.IsLuminous())
		{
			return Brushes.White;
		}
		return Brushes.Black;
	}

	protected override bool ValidateValue(object? value)
	{
		if (value is SolidColorBrush || value is Color)
		{
			return true;
		}
		return false;
	}
}
