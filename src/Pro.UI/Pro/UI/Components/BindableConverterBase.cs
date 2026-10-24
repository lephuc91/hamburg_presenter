using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Pro.UI.Components;

public abstract class BindableConverterBase : DependencyObject, IValueConverter
{
	public abstract object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture);

	public abstract object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture);
}
