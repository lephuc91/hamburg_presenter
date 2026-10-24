using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using Pro.DO.Storage;

namespace ProPresenter.UI.Capture;

public class DirectoryToNameConverter : IValueConverter
{
	public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (value is RelativePath relativePath)
		{
			string fileName = Path.GetFileName(relativePath.FullPath?.TrimEnd('\\', '/'));
			if (!string.IsNullOrEmpty(fileName))
			{
				return fileName;
			}
			return (string)relativePath;
		}
		return value;
	}

	public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}
