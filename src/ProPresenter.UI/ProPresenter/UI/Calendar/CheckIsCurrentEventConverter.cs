using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using ProPresenter.DO.Calendar;

namespace ProPresenter.UI.Calendar;

public class CheckIsCurrentEventConverter : IMultiValueConverter
{
	public object? Convert(object?[] values, Type targetType, object? parameter, CultureInfo culture)
	{
		if (values.Length == 2 && values[0] is IEnumerable<Event> source && values[1] is Event @event)
		{
			return source.Any() && source.FirstOrDefault() == @event;
		}
		return false;
	}

	public object?[] ConvertBack(object? value, Type[] targetTypes, object? parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}
