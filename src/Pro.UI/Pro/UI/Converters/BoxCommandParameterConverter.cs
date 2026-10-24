using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Pro.UI.Converters;

public abstract class BoxCommandParameterConverter<T> : IMultiValueConverter, IValueConverter
{
	public object Convert(object?[] values, Type targetType, object? parameter, CultureInfo culture)
	{
		T val = Box(values);
		if (val == null)
		{
			return DependencyProperty.UnsetValue;
		}
		return val;
	}

	public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		T val = Box(value);
		if (val == null)
		{
			return DependencyProperty.UnsetValue;
		}
		return val;
	}

	public object[] ConvertBack(object? value, Type[] targetTypes, object? parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}

	public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}

	protected abstract T Box(object?[] data);

	protected abstract T Box(object? data);
}
