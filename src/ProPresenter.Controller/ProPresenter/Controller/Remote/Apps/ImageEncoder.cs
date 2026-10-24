using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace ProPresenter.Controller.Remote.Apps;

public class ImageEncoder : IImageEncoder
{
	public string Encode(BitmapSource? source)
	{
		if (source == null)
		{
			return string.Empty;
		}
		using MemoryStream memoryStream = new MemoryStream();
		JpegBitmapEncoder jpegBitmapEncoder = new JpegBitmapEncoder();
		jpegBitmapEncoder.Frames.Add(BitmapFrame.Create(source));
		jpegBitmapEncoder.Save(memoryStream);
		return Convert.ToBase64String(memoryStream.GetBuffer());
	}
}
