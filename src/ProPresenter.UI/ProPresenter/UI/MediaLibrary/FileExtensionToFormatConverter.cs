using System;
using System.Globalization;
using System.Windows.Data;

namespace ProPresenter.UI.MediaLibrary;

public class FileExtensionToFormatConverter : IValueConverter
{
	public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (value is string { Length: >1 } text)
		{
			string arg = text.Substring(1).ToUpper();
			return $"{arg} File";
		}
		return Binding.DoNothing;
	}

	public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}
