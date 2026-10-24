using System;
using System.Globalization;
using System.Windows;

namespace Pro.UI.Converters;

public class IsNotNullToVisibilityConverter : ValueConverterBase<object, object>
{
	public bool IsInverted { get; set; }

	protected override object ConvertValue(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		bool flag = value == null;
		if (IsInverted)
		{
			flag = !flag;
		}
		return flag ? Visibility.Collapsed : Visibility.Visible;
	}

	protected override bool ValidateValue(object? value)
	{
		return value != DependencyProperty.UnsetValue;
	}
}
