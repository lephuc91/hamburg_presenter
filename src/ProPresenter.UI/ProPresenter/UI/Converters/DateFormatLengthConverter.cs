using System;
using System.Globalization;
using System.Windows.Data;
using Pro.Localization;
using ProPresenter.DO.Timer;

namespace ProPresenter.UI.Converters;

public class DateFormatLengthConverter : IValueConverter
{
	public string? NoDateLabel { get; set; }

	public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (value is FormatLength formatLength)
		{
			if (formatLength == FormatLength.None)
			{
				return NoDateLabel;
			}
			return DateTimeFormatter.FormatDateTime(ClockData.SampleDate, formatLength, FormatLength.None, use24HourMode: false);
		}
		throw new ArgumentException($"The converted value needs to be of type {typeof(FormatLength)}, received value of type{value?.GetType().ToString() ?? "null"}", "value");
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}
