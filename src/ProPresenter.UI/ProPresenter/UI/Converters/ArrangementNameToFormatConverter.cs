using System;
using System.Globalization;
using Pro.UI.Converters;

namespace ProPresenter.UI.Converters;

public class ArrangementNameToFormatConverter : ValueConverterBase<string, string>
{
	protected override string ConvertValue(string value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (!string.IsNullOrEmpty(value))
		{
			return " - [ " + value + " ]";
		}
		return string.Empty;
	}
}
