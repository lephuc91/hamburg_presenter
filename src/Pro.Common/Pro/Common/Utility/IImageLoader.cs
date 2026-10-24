using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Pro.Common.Components;

namespace Pro.Common.Utility;

public interface IImageLoader
{
	BitmapSource? LoadImage(string filename);

	BitmapSource? LoadImageFromURL(string url);

	void LoadImageFromURLAsync(string url, Action<BitmapSource?> completedCallback, Dispatcher? dispatcher = null);

	BitmapSource RenderVisual(Visual visual, Size size, bool needsLayout = false);

	bool TryWriteImage(BitmapSource source, string targetFilename);

	byte[]? ToByteArray(BitmapSource source);

	BitmapSource? ToBitmapSource(ImageSource? source);

	BitmapSource? ToBitmapSource(byte[] byteArr);

	bool HasTransparency(PixelFormat format);

	IBitmapHandle? ToBitmapHandle(BitmapSource bitmapSource);
}
