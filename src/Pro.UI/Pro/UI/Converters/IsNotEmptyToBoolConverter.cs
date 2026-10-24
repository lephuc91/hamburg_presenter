using System;
using System.Collections;
using System.Globalization;
using System.Windows.Data;

namespace Pro.UI.Converters;

public class IsNotEmptyToBoolConverter : IValueConverter
{
	public object Convert(object? value, Type targetType, object parameter, CultureInfo culture)
	{
		return value is IEnumerable enumerable && enumerable.GetEnumerator().MoveNext();
	}

	public object ConvertBack(object? value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}
