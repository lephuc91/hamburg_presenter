using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Pro.Common.Components;

namespace Pro.Common.Utility;

public class ImageLoader : IImageLoader
{
	public bool HasTransparency(PixelFormat format)
	{
		return format.HasTransparency();
	}

	public BitmapSource? LoadImage(string filename)
	{
		return ImageHelper.LoadImage(filename);
	}

	public BitmapSource? LoadImageFromURL(string url)
	{
		return ImageHelper.LoadImageFromURL(url);
	}

	public void LoadImageFromURLAsync(string url, Action<BitmapSource?> completedCallback, Dispatcher? dispatcher = null)
	{
		ImageHelper.LoadImageFromURLAsync(url, completedCallback, dispatcher);
	}

	public BitmapSource RenderVisual(Visual visual, Size size, bool needsLayout = false)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		return visual.RenderVisual(size, needsLayout);
	}

	public IBitmapHandle? ToBitmapHandle(BitmapSource bitmapSource)
	{
		return bitmapSource.ToBitmapHandle();
	}

	public BitmapSource? ToBitmapSource(ImageSource? source)
	{
		return source.ToBitmapSource();
	}

	public BitmapSource? ToBitmapSource(byte[] byteArr)
	{
		return byteArr.ToBitmapSource();
	}

	public byte[]? ToByteArray(BitmapSource source)
	{
		return source.ToByteArray();
	}

	public bool TryWriteImage(BitmapSource source, string targetFilename)
	{
		return source.TryWriteImage(targetFilename);
	}
}
