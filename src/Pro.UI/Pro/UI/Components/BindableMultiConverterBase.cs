using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Pro.UI.Components;

public abstract class BindableMultiConverterBase : DependencyObject, IMultiValueConverter
{
	public abstract object Convert(object[]? values, Type targetType, object? parameter, CultureInfo culture);

	public abstract object[] ConvertBack(object? value, Type[] targetTypes, object? parameter, CultureInfo culture);
}
