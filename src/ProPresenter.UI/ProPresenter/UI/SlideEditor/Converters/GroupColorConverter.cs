using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using ProPresenter.UI.Theming;

namespace ProPresenter.UI.SlideEditor.Converters;

public class GroupColorConverter : IValueConverter
{
	public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (value is Color color && color != Colors.Transparent)
		{
			return color;
		}
		return (Color)AppTheme.Active.LIST_BACKGROUND_COLOR;
	}

	public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
