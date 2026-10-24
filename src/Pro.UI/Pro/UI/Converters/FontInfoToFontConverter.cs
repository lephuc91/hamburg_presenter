using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using Pro.Text;

namespace Pro.UI.Converters;

public class FontInfoToFontConverter : IValueConverter
{
	private readonly FontGroup[] _fontGroups = SharedTypefaceLibrary.Library.AvailableTypefaces.FontGroups;

	public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		if (value is FontInfo)
		{
			FontInfo fontInfo = (FontInfo)value;
			FontGroup fontGroup = _fontGroups.FirstOrDefault((FontGroup g) => g.SystemName.Equals(fontInfo.SystemFamilyName));
			object obj;
			if (fontGroup != null)
			{
				obj = fontGroup.Fonts.FirstOrDefault((Font f) => f.Info.SystemFaceName?.Equals(fontInfo.SystemFaceName) ?? false);
				if (obj == null)
				{
					return fontGroup.Fonts.FirstOrDefault();
				}
			}
			else
			{
				obj = Binding.DoNothing;
			}
			return obj;
		}
		return Binding.DoNothing;
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		if (!(value is Font font))
		{
			return Binding.DoNothing;
		}
		return font.Info;
	}
}
