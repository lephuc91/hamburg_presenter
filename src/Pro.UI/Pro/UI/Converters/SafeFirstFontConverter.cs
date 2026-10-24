using System;
using System.Globalization;
using System.Windows.Data;
using Pro.Text;

namespace Pro.UI.Converters;

public class SafeFirstFontConverter : IValueConverter
{
	public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (value is Font[] array && array.Length != 0)
		{
			Font font = array[0];
			if ((object)font != null)
			{
				return font.Info;
			}
		}
		return RunSettings.DefaultFont;
	}

	public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
