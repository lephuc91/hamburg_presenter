using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using ProPresenter.DO.Slide.Custom.Elements.Scrollers;

namespace ProPresenter.UI.SlideEditor.Converters;

public class ScrollDirectionToLabelConverter : MarkupExtension, IValueConverter
{
	public string? HorizontalLabel { get; set; }

	public string? VerticalLabel { get; set; }

	public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (value == null || value == DependencyProperty.UnsetValue)
		{
			return null;
		}
		if (!((ScrollingType)value).IsVertical())
		{
			return HorizontalLabel;
		}
		return VerticalLabel;
	}

	public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		return Binding.DoNothing;
	}

	public override object ProvideValue(IServiceProvider serviceProvider)
	{
		return this;
	}
}
