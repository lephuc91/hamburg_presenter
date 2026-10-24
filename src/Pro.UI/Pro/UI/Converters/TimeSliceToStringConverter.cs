using System;
using System.Globalization;
using Pro.Common.Time;

namespace Pro.UI.Converters;

public class TimeSliceToStringConverter : ValueConverterBase<TimeSlice, string>
{
	public bool DisplayMilliseconds { get; set; }

	public object? ZeroValue { get; set; }

	protected override string ConvertValue(TimeSlice value, Type targetType, object? parameter, CultureInfo culture)
	{
		return ((ZeroValue != null && value == TimeSlice.Zero) ? ZeroValue.ToString() : TimeSliceHelper.TimeSliceToString(value, DisplayMilliseconds)) ?? string.Empty;
	}
}
