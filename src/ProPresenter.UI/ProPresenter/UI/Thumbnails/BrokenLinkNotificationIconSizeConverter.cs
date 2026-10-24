using System;
using System.Globalization;
using Pro.UI.Converters;

namespace ProPresenter.UI.Thumbnails;

public class BrokenLinkNotificationIconSizeConverter : ValueConverterBase<double, double>
{
	protected override double ConvertValue(double value, Type targetType, object? parameter, CultureInfo culture)
	{
		return value * 0.9;
	}
}
