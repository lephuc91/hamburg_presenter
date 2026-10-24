using System;
using System.Globalization;
using Pro.UI.Converters;

namespace ProPresenter.UI.Settings.PageTemplates.Inputs;

public class DecibelToLabelConverter : ValueConverterBase<double, string>
{
	protected override string ConvertValue(double value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (!(value < -60.0))
		{
			return value.ToString("N0");
		}
		return double.NegativeInfinity.ToString();
	}
}
