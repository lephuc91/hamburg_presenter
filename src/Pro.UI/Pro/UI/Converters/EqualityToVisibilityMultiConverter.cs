using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using Pro.Common.Extensions;
using Pro.Common.Mathematics;

namespace Pro.UI.Converters;

public class EqualityToVisibilityMultiConverter : MultiValueConverterBase<Visibility>
{
	public bool UseHidden { get; set; }

	protected override Visibility ConvertValues(object?[] values, Type targetType, object? parameter, CultureInfo culture)
	{
		if (values.All((object v) => v != null && v.GetType().IsPrimitive && v.IsNumericType()))
		{
			double.TryParse(values[0].ToString(), NumberStyles.Any, new NumberFormatInfo(), out var result);
			bool flag = true;
			for (int i = 1; i < values.Length; i++)
			{
				double.TryParse(values[i].ToString(), NumberStyles.Any, new NumberFormatInfo(), out var result2);
				if (!MathHelper.HasMinimalDifference(result, result2, 1))
				{
					flag = false;
				}
			}
			if (!flag)
			{
				if (!UseHidden)
				{
					return Visibility.Collapsed;
				}
				return Visibility.Hidden;
			}
			return Visibility.Visible;
		}
		if (!values.All((object v) => v?.Equals(values[0]) ?? false))
		{
			if (!UseHidden)
			{
				return Visibility.Collapsed;
			}
			return Visibility.Hidden;
		}
		return Visibility.Visible;
	}

	protected override bool ValidateValues(object?[] values)
	{
		return values.Length != 0;
	}
}
