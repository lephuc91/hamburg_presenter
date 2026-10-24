using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Pro.DO.Triggering;
using Pro.UI.Converters;
using Pro.UI.Themes;
using ProPresenter.UI.Macros;

namespace ProPresenter.UI.Converters;

public class MacroCustomIconToImageSourceConverter : MultiValueConverterBase<ImageSource?>
{
	protected override ImageSource? ConvertValues(object?[] values, Type targetType, object? parameter, CultureInfo culture)
	{
		if (values[0] is ImageType imageType)
		{
			if (imageType == ImageType.Custom && values[1] is BitmapSource result)
			{
				return result;
			}
			return MacroIconHelper.GetIconFromEnum(imageType);
		}
		return Application.Current?.TryFindResource(Icons.MacroDefault) as ImageSource;
	}
}
