using System;
using System.Globalization;
using System.Linq;
using Pro.UI.Components;
using ProPresenter.DO.Bibles;

namespace ProPresenter.UI.Bibles.Converters;

public class TranslationToBibleConverter : DataConverterBase<LoadedBibleCollection>
{
	public override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		string abbreviation = value as string;
		if (string.IsNullOrWhiteSpace(abbreviation))
		{
			return null;
		}
		return base.Data?.FirstOrDefault((BibleBase b) => b.TrackingAbbreviation.Equals(abbreviation, StringComparison.OrdinalIgnoreCase));
	}

	public override object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (value is BibleBase bibleBase)
		{
			return bibleBase.TrackingAbbreviation;
		}
		return null;
	}
}
