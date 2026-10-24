using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace Pro.UI.Converters;

public class PercentageConverter : MarkupExtension, IValueConverter
{
	public object Convert(object? value, Type targetType, object parameter, CultureInfo culture)
	{
		if (value == null || value == DependencyProperty.UnsetValue)
		{
			return DependencyProperty.UnsetValue;
		}
		return (double)value * 100.0;
	}

	public object ConvertBack(object? value, Type targetType, object parameter, CultureInfo culture)
	{
		if (value == null || value == DependencyProperty.UnsetValue)
		{
			return DependencyProperty.UnsetValue;
		}
		return (double)value / 100.0;
	}

	public override object ProvideValue(IServiceProvider serviceProvider)
	{
		return this;
	}
}
