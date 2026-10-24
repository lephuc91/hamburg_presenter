using System;
using System.Globalization;
using Pro.Localization;

namespace Pro.UI.Converters;

public class EnumToContentConverter : ValueConverterBase<Enum, string>
{
	protected override string ConvertValue(Enum value, Type targetType, object? parameter, CultureInfo culture)
	{
		return LocalizedStrings.Get(value);
	}
}
