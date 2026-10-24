using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using Pro.Localization;
using ProPresenter.DO.Bibles;

namespace ProPresenter.UI.Bibles.Converters;

public class AbbreviationToBibleNameConverter : IMultiValueConverter
{
	public object? Convert(object?[] values, Type targetType, object? parameter, CultureInfo culture)
	{
		if (values.Length < 2)
		{
			throw new ArgumentException("AbbreviationToBibleNameConverter requires at least two values to compare.");
		}
		object obj = values[0];
		string abv = obj as string;
		if (abv == null || !(values[1] is LoadedBibleCollection source))
		{
			return Binding.DoNothing;
		}
		return source.FirstOrDefault((BibleBase b) => b.TrackingAbbreviation.Equals(abv, StringComparison.OrdinalIgnoreCase))?.Name ?? LocalizedStrings.Get("GLOBAL_NONE");
	}

	public object?[] ConvertBack(object? value, Type[] targetTypes, object? parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}
