using System;
using System.Globalization;
using System.Windows.Data;
using Pro.Common.Mathematics;
using Pro.UI.Components;

namespace Pro.UI.Converters;

public class AngleToDoubleConverter : DataConverterBase<bool>
{
	public override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (value is Angle<double> angle)
		{
			return base.Data ? angle.CartesianValue : angle.InvertedCartesianValue;
		}
		return Binding.DoNothing;
	}

	public override object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		return (value != null) ? new Angle<double>((double)value, base.Data) : Angle<double>.Zero;
	}
}
