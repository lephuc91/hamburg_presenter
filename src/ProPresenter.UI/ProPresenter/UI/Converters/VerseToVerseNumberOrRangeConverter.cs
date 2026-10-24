using System;
using System.Globalization;
using System.Windows.Data;
using ProPresenter.DO.Bibles;

namespace ProPresenter.UI.Converters;

public class VerseToVerseNumberOrRangeConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		if (!(value is Verse verse))
		{
			return string.Empty;
		}
		if (verse.StartNumber != verse.EndNumber)
		{
			return $"{verse.StartNumber}-{verse.EndNumber}";
		}
		return verse.StartNumber.ToString();
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
