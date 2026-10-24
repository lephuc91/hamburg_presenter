using System;
using System.Globalization;
using System.Windows.Data;
using Pro.Common.Time;

namespace Pro.UI.Converters;

public class TimeSliceToTimeFormatConverter : IValueConverter
{
	public enum TimeFormat
	{
		TotalSeconds,
		TotalMilliSeconds,
		TotalMinutes,
		TotalHours
	}

	public int SignificantDigits { get; set; }

	public TimeFormat ConversionUnit { get; set; }

	public object Convert(object? value, Type targetType, object parameter, CultureInfo culture)
	{
		if (value is TimeSlice time)
		{
			return Math.Round(GetTimeValue(time, ConversionUnit), SignificantDigits);
		}
		return Binding.DoNothing;
	}

	public object ConvertBack(object? value, Type targetType, object parameter, CultureInfo culture)
	{
		if (string.IsNullOrEmpty(value?.ToString()))
		{
			value = "0";
		}
		return GetTimeSliceValue(System.Convert.ToDouble(value), ConversionUnit);
	}

	private static double GetTimeValue(TimeSlice time, TimeFormat format)
	{
		return format switch
		{
			TimeFormat.TotalSeconds => time.TotalSeconds, 
			TimeFormat.TotalMilliSeconds => time.TotalMilliseconds, 
			TimeFormat.TotalMinutes => time.TotalMinutes, 
			TimeFormat.TotalHours => time.TotalHours, 
			_ => throw new NotSupportedException("Unknown Unit Conversion"), 
		};
	}

	private static TimeSlice GetTimeSliceValue(double value, TimeFormat format)
	{
		return format switch
		{
			TimeFormat.TotalSeconds => TimeSlice.FromSeconds(value), 
			TimeFormat.TotalMilliSeconds => TimeSlice.FromMilliseconds(value), 
			TimeFormat.TotalMinutes => TimeSlice.FromMinutes(value), 
			TimeFormat.TotalHours => TimeSlice.FromHours(value), 
			_ => throw new NotSupportedException("Unknown Unit Conversion"), 
		};
	}
}
