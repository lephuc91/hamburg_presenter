using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Pro.UI.Converters;

public class ValueToVisibilityConverter : IValueConverter
{
	public bool IsCollapsing { get; set; } = true;

	public bool IsInverted { get; set; }

	public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		bool flag = EvaluateValue(value, parameter);
		if (IsInverted)
		{
			flag = !flag;
		}
		if (flag)
		{
			return Visibility.Visible;
		}
		return (!IsCollapsing) ? Visibility.Hidden : Visibility.Collapsed;
	}

	public object ConvertBack(object value, Type targetType, object? parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}

	protected virtual bool EvaluateValue(object? value, object? parameter)
	{
		if (!(value is bool result))
		{
			if (value is Visibility visibility)
			{
				return visibility == Visibility.Visible;
			}
			return object.Equals(value, parameter);
		}
		return result;
	}
}
