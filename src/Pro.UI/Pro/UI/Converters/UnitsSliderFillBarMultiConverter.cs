using System;
using System.Globalization;

namespace Pro.UI.Converters;

public class UnitsSliderFillBarMultiConverter : MultiValueConverterBase<double>
{
	protected override double ConvertValues(object?[] values, Type targetType, object? parameter, CultureInfo culture)
	{
		if (values.Length < 2 || !(values[0] is double num) || !(values[1] is double num2))
		{
			return 0.0;
		}
		return num2 + num / 2.0;
	}
}
