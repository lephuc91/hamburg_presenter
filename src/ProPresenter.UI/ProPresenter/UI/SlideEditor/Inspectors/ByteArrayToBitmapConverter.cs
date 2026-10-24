using System;
using System.Globalization;
using System.Windows.Data;
using Pro.Common.Utility;

namespace ProPresenter.UI.SlideEditor.Inspectors;

public class ByteArrayToBitmapConverter : IValueConverter
{
	public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (!(value is byte[] byteArr))
		{
			return null;
		}
		return byteArr.ToBitmapSource();
	}

	public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}
