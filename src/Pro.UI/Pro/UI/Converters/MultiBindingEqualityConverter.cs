using System;
using System.Globalization;
using System.Windows.Data;

namespace Pro.UI.Converters;

public class MultiBindingEqualityConverter : IMultiValueConverter
{
	public object Convert(object?[] values, Type targetType, object? parameter, CultureInfo culture)
	{
		bool flag = default(bool);
		int num;
		if (parameter is bool)
		{
			flag = (bool)parameter;
			num = 1;
		}
		else
		{
			num = 0;
		}
		int num2 = num & (flag ? 1 : 0);
		object firstVal = ((values != null) ? values[0] : null);
		bool flag2 = Array.TrueForAll(values ?? Array.Empty<object>(), (object v) => v?.Equals(firstVal) ?? (v == firstVal));
		return (num2 != 0) ? (!flag2) : flag2;
	}

	public object[] ConvertBack(object value, Type[] targetTypes, object? parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}
