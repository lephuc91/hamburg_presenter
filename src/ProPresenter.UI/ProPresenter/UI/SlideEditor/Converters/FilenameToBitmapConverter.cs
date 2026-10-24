using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace ProPresenter.UI.SlideEditor.Converters;

public class FilenameToBitmapConverter : IValueConverter
{
	public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (value is string uriString)
		{
			return BitmapFrame.Create(new Uri(uriString, UriKind.RelativeOrAbsolute));
		}
		return Binding.DoNothing;
	}

	public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}
