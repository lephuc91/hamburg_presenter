using System;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using Pro.DO.Storage;

namespace ProPresenter.UI.LiveVideo;

internal class VideoInputThumbnailConverter : IValueConverter
{
	public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		string text = (value as RelativePath)?.FullPath;
		if (string.IsNullOrWhiteSpace(text))
		{
			return null;
		}
		try
		{
			BitmapImage bitmapImage = new BitmapImage();
			using (FileStream streamSource = new FileStream(text, FileMode.Open, FileAccess.Read))
			{
				bitmapImage.BeginInit();
				bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
				bitmapImage.StreamSource = streamSource;
				bitmapImage.EndInit();
				((Freezable)bitmapImage).Freeze();
			}
			return bitmapImage;
		}
		catch
		{
			return null;
		}
	}

	public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		throw new NotSupportedException();
	}
}
