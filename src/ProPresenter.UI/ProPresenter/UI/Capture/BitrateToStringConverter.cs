using System;
using System.Globalization;
using Pro.UI.Converters;
using ProPresenter.DO.Capture;

namespace ProPresenter.UI.Capture;

public class BitrateToStringConverter : ValueConverterBase<uint, string>
{
	protected override string ConvertValue(uint value, Type targetType, object? parameter, CultureInfo culture)
	{
		return value.BitrateToString();
	}
}
