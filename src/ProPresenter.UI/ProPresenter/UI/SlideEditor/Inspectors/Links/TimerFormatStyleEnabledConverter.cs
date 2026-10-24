using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using ProPresenter.DO.Timer;

namespace ProPresenter.UI.SlideEditor.Inspectors.Links;

public class TimerFormatStyleEnabledConverter : IMultiValueConverter
{
	public object Convert(object?[] values, Type targetType, object? parameter, CultureInfo culture)
	{
		return values.Length == 2 && values[0] is IEnumerable<TimerFormatStyle> source && values[1] is TimerFormatStyle value && source.Contains(value);
	}

	public object[] ConvertBack(object? value, Type[] targetTypes, object? parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
