using System;
using System.Globalization;
using System.Windows.Data;
using ProPresenter.DO.Calendar;

namespace ProPresenter.UI.Calendar;

public class CheckEventDayConverter : IMultiValueConverter
{
	public object? Convert(object?[] values, Type targetType, object? parameter, CultureInfo culture)
	{
		if (values.Length == 2 && values[0] is EventDay eventDay && values[1] is EventDay eventDay2)
		{
			return eventDay.HasFlag(eventDay2);
		}
		return false;
	}

	public object?[] ConvertBack(object? value, Type[] targetTypes, object? parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}
