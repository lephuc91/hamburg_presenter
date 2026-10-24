using System;
using System.Globalization;
using System.Windows;

namespace Pro.UI.Converters;

public class FrameworkElementToRectConverter : MultiValueConverterBase<Rect>
{
	protected override Rect ConvertValues(object?[] values, Type targetType, object? parameter, CultureInfo culture)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		double num = (double)values[0];
		double num2 = (double)values[1];
		return new Rect(0.0, 0.0, num, num2);
	}

	protected override bool ValidateValues(object?[] values)
	{
		if (values == null || values.Length != 2)
		{
			return false;
		}
		if (values[0] == null || values[1] == null)
		{
			return false;
		}
		if (values[0] != null && !(values[0] is double))
		{
			return false;
		}
		if (values[1] != null && !(values[1] is double))
		{
			return false;
		}
		return true;
	}
}
