using System;
using System.Globalization;
using Pro.Common.Strings;
using Pro.UI.Converters;

namespace ProPresenter.UI.Thumbnails;

public class ListContentConverter : ValueConverterBase<string, string>
{
	protected override string ConvertValue(string value, Type targetType, object? parameter, CultureInfo culture)
	{
		return LineBreaks.Replace(value, " ");
	}
}
