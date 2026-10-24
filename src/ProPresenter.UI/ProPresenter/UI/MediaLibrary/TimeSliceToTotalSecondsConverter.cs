using System;
using System.Globalization;
using System.Windows.Data;
using Pro.Common.Time;

namespace ProPresenter.UI.MediaLibrary;

public class TimeSliceToTotalSecondsConverter : IValueConverter
{
	public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (!(value is TimeSlice timeSlice))
		{
			return string.Empty;
		}
		return $"{timeSlice.TotalSeconds:0.###} s";
	}

	public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}
