using System;
using System.Globalization;
using System.Windows.Data;
using ProPresenter.DO.Timer;

namespace ProPresenter.UI.SlideEditor.Inspectors.Links;

public class TimerFormatStyleToStringConverter : IValueConverter
{
	public string ShortString { get; set; } = string.Empty;

	public string LongString { get; set; } = string.Empty;

	public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (!(value is TimerFormatStyle))
		{
			return Binding.DoNothing;
		}
		switch ((TimerFormatStyle)value)
		{
		case TimerFormatStyle.None:
			return "--";
		case TimerFormatStyle.Short:
		case TimerFormatStyle.ShortTruncated:
			return ShortString;
		case TimerFormatStyle.Long:
		case TimerFormatStyle.LongTruncated:
			return LongString;
		default:
			throw new NotSupportedException();
		}
	}

	public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
