using System;
using System.Globalization;
using System.Windows.Data;
using Pro.Common.Time;

namespace Pro.UI.Converters;

public class TimeSliceToDoubleSecondConverter : IValueConverter
{
	public int RoundDecimalPlace { get; set; }

	public object Convert(object? value, Type targetType, object parameter, CultureInfo culture)
	{
		if (value is TimeSlice timeSlice)
		{
			return Math.Round(timeSlice.TotalSeconds, RoundDecimalPlace);
		}
		return Binding.DoNothing;
	}

	public object ConvertBack(object? value, Type targetType, object parameter, CultureInfo culture)
	{
		return (value is double) ? TimeSlice.FromSeconds((double)value) : TimeSlice.Zero;
	}
}
