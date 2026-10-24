using System;
using System.Globalization;
using System.Windows.Data;
using Pro.Common.FileSystem;
using Pro.Common.Utility;
using Pro.DO.Storage;

namespace ProPresenter.UI.SlideEditor.Inspectors;

public class ChordChartToBitmapConverter : IValueConverter
{
	public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		if (!(value is RelativePath { IsValid: not false, FullPath: not null } relativePath))
		{
			return null;
		}
		if (!relativePath.FullPath.IsImageFile())
		{
			return null;
		}
		return ImageHelper.LoadImage(relativePath.FullPath);
	}

	public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}
