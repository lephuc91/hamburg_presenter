using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using Pro.DO.Triggering;
using Pro.UI.Themes;
using ProPresenter.UI.Macros;

namespace ProPresenter.UI.Converters;

public class MacroIconToImageSource : IValueConverter
{
	public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (value is ImageType imageType)
		{
			return MacroIconHelper.GetIconFromEnum(imageType);
		}
		return Application.Current?.TryFindResource(Icons.MacroDefault) as ImageSource;
	}

	public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
