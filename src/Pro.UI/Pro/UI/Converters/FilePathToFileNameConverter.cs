using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;

namespace Pro.UI.Converters;

public class FilePathToFileNameConverter : IValueConverter
{
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		try
		{
			return Path.GetFileName((string)value);
		}
		catch
		{
			return string.Empty;
		}
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}
