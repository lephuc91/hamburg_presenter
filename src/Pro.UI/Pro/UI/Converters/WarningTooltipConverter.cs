using System;
using System.Globalization;
using System.Windows.Data;
using Pro.Localization.Services;

namespace Pro.UI.Converters;

public class WarningTooltipConverter : IMultiValueConverter
{
	private readonly ILocalization _localization;

	public WarningTooltipConverter(ILocalization localization)
	{
		_localization = localization;
	}

	public object Convert(object[] values, Type targetType, object? parameter, CultureInfo culture)
	{
		if (values == null || values.Length != 2)
		{
			return string.Empty;
		}
		object obj = values[0];
		bool num = obj is bool && (bool)obj;
		obj = values[1];
		bool flag = obj is bool && (bool)obj;
		if (num)
		{
			if (!flag)
			{
				return _localization.Get("PRESENTATION_HEADER_SIZE_MISMATCH_tooltip");
			}
			return _localization.Get("PRESENTATION_HEADER_MULTIPLE_ISSUES_tooltip");
		}
		if (flag)
		{
			return _localization.Get("PRESENTATION_HEADER_MISSING_FONTS_tooltip");
		}
		return string.Empty;
	}

	public object[] ConvertBack(object value, Type[] targetTypes, object? parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
