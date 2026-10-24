using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using Pro.Common.Mathematics;

namespace Pro.UI.Converters;

public class SliderFillBarMultiConverter : MarkupExtension, IMultiValueConverter
{
	public object Convert(object[]? values, Type targetType, object parameter, CultureInfo culture)
	{
		if (values == null || values == DependencyProperty.UnsetValue || values.Length < 7 || !(values[0] is double num) || !(values[1] is double num2) || !(values[2] is double num3) || !(values[3] is double num4) || !(values[4] is double num5) || !(values[5] is double num6) || !(values[6] is bool flag))
		{
			return Binding.DoNothing;
		}
		double num7 = num / 2.0;
		if (Math.Abs(num5 - num2) < double.Epsilon)
		{
			return (!flag) ? 0.0 : num4;
		}
		if (Math.Abs(num5 - num3) < double.Epsilon)
		{
			return (!flag) ? num4 : 0.0;
		}
		double num8 = num6 + num7;
		num8 = ((!flag) ? num8 : (num4 - num8));
		return num8.Clamp(0.0, num4);
	}

	public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
	{
		return Enumerable.Repeat(Binding.DoNothing, targetTypes.Length).ToArray();
	}

	public override object ProvideValue(IServiceProvider serviceProvider)
	{
		return this;
	}
}
