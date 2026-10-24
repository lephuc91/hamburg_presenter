using System;
using System.Globalization;
using System.Windows.Data;
using Pro.Localization;

namespace ProPresenter.UI.SlideEditor.Converters;

public class RoundedDoubleToPercentConverter : IValueConverter
{
	public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		return LocalizedStrings.Get("EDITOR_ZOOM_MENU_ITEM_title", new object[1] { Math.Round((value is double num) ? num : 0.0, 2) * 100.0 });
	}

	public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}
