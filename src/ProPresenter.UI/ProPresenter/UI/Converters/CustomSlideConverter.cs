using System;
using System.Globalization;
using System.Windows.Data;
using ProPresenter.DO.Slide.Custom;

namespace ProPresenter.UI.Converters;

public class CustomSlideConverter : IValueConverter
{
	public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		return value as CustomSlide;
	}

	public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}
