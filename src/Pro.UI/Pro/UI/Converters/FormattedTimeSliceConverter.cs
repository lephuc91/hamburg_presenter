using System;
using System.Globalization;
using Pro.Common.Time;

namespace Pro.UI.Converters;

public class FormattedTimeSliceConverter : ValueConverterBase<TimeSlice, string>
{
	protected override string ConvertValue(TimeSlice value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (value.Hours > 0)
		{
			return $"{value.Hours:00}:{value.Minutes:00}:{value.Seconds:00}";
		}
		return $"{value.Minutes:00}:{value.Seconds:00}";
	}
}
