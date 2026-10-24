using System;
using System.Globalization;
using System.Windows.Data;
using Pro.Common.Utility;

namespace ProPresenter.UI.SlideEditor.Converters;

public class TabItemWidthConverter : IMultiValueConverter
{
	public object Convert(object?[] values, Type targetType, object? parameter, CultureInfo culture)
	{
		if (values.Length == 2 && values[0] is double num && values[1] is InspectorTab value)
		{
			double num2 = num / (double)value.CountBits() - 2.0;
			return (num2 <= 1.0) ? 0.0 : Math.Truncate(num2);
		}
		return 0.0;
	}

	public object[] ConvertBack(object? value, Type[] targetTypes, object? parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}
