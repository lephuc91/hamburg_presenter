using System;
using System.Globalization;
using System.Linq;
using Pro.UI.Converters;

namespace ProPresenter.UI.PresentationView;

public class IsCustomDurationConverter : MultiValueConverterBase<bool>
{
	protected override bool ConvertValues(object?[] values, Type targetType, object? parameter, CultureInfo culture)
	{
		if (values.Length == 2 && values[0] is double num && values[1] is double[] source && !source.Contains(num))
		{
			return num >= 0.0;
		}
		return false;
	}
}
