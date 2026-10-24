using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace Pro.UI.Converters;

public class CountToBoolConverter : IValueConverter
{
	public bool IsInverted { get; set; }

	public int Value { get; set; }

	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		bool flag = ((value as IEnumerable)?.OfType<object>().Count() ?? 0) > Value;
		return IsInverted ? (!flag) : flag;
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
