using System;
using System.Globalization;
using Pro.Localization;

namespace Pro.UI.Converters;

public class FormattedLocalizedStringConverter : ValueConverterBase<object, string>
{
	protected override string ConvertValue(object value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (!(parameter is string key))
		{
			throw new NotSupportedException();
		}
		if (value is Enum enumValue)
		{
			return LocalizedStrings.Get(key, new object[1] { LocalizedStrings.Get(enumValue) });
		}
		return LocalizedStrings.Get(key, value);
	}
}
