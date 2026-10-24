using System;
using System.Globalization;
using System.Windows.Data;

namespace ProPresenter.UI.SlideEditor.Inspectors.ScrollingText;

public class FadeRightConverter : IValueConverter
{
	public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		return (value is double num) ? (1.0 - num) : 0.0;
	}

	public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		return (value is double num) ? (1.0 - num) : 0.0;
	}
}
