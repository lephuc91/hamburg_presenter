using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using Pro.Text;

namespace Pro.UI.Converters;

public class FontInfoToFontGroupConverter : IValueConverter
{
	private readonly FontGroup[] _fontGroups = SharedTypefaceLibrary.Library.AvailableTypefaces.FontGroups;

	public object? Convert(object? value, Type targetType, object parameter, CultureInfo culture)
	{
		if (value is FontInfo)
		{
			FontInfo fontInfo = (FontInfo)value;
			return _fontGroups.FirstOrDefault((FontGroup f) => f.SystemName == fontInfo.SystemFamilyName);
		}
		return Binding.DoNothing;
	}

	public object? ConvertBack(object? value, Type targetType, object parameter, CultureInfo culture)
	{
		if (!(value is FontGroup fontGroup))
		{
			return Binding.DoNothing;
		}
		return fontGroup.Fonts.FirstOrDefault()?.Info;
	}
}
