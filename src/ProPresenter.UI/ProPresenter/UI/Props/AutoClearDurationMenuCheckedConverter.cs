using System;
using System.Globalization;
using Pro.UI.Converters;

namespace ProPresenter.UI.Props;

public class AutoClearDurationMenuCheckedConverter : MultiValueConverterBase<bool>
{
	protected override bool ConvertValues(object?[] values, Type targetType, object? parameter, CultureInfo culture)
	{
		if (values.Length > 3 && values[0] is double num && values[1] is double num2 && num == num2)
		{
			object obj = values[2];
			return !(obj is bool) || !(bool)obj;
		}
		return false;
	}
}
