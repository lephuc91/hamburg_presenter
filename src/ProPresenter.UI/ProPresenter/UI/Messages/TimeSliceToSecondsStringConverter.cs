using System;
using System.Globalization;
using System.Windows.Data;
using Pro.Common.Time;
using Pro.Localization;

namespace ProPresenter.UI.Messages;

public class TimeSliceToSecondsStringConverter : IValueConverter
{
	public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (!(value is TimeSlice timeSlice))
		{
			return string.Empty;
		}
		return LocalizedStrings.Get("MESSAGES_WINDOW_DISMISS_OPTION_AFTER_TIME_SECONDS_title", new object[1] { timeSlice.TotalSeconds });
	}

	public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}
