using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using ProPresenter.DO.Timer;

namespace ProPresenter.UI.SlideEditor.Inspectors.Links;

public class TimerFormatStrikethroughConverter : IValueConverter
{
	public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (!(value is TimerFormatStyle timerFormatStyle))
		{
			return Binding.DoNothing;
		}
		if ((uint)(timerFormatStyle - 3) <= 1u)
		{
			return TextDecorations.Strikethrough;
		}
		return null;
	}

	public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
