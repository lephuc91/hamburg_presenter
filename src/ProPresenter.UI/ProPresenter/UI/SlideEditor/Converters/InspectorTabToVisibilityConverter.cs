using System;
using System.Globalization;
using System.Windows;
using Pro.UI.Components;

namespace ProPresenter.UI.SlideEditor.Converters;

public class InspectorTabToVisibilityConverter : DataConverterBase<InspectorTab>
{
	public override object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		InspectorTab data = base.Data;
		if (parameter is InspectorTab inspectorTab)
		{
			return (!data.HasFlag(inspectorTab)) ? Visibility.Collapsed : Visibility.Visible;
		}
		return Visibility.Collapsed;
	}

	public override object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}
