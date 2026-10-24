using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Pro.Common.Animation;
using Pro.Common.Nullability;
using Pro.Imaging;

namespace ProPresenter.DO.Cache;

public class BitmapImageDecoder : IBitmapImageDecoder
{
	private sealed record AnimationFrame(BitmapSource Image, TimeSpan Duration) : IAnimationFrame;

	private const int DPI = 96;

	private readonly IImageDecoder _imageDecoder;

	public BitmapImageDecoder(IImageDecoder imageDecoder)
	{
		_imageDecoder = imageDecoder;
	}

	public BitmapSource DecodeImage(byte[] data)
	{
		BitmapSource image = null;
		_imageDecoder.DecodeImage(data, delegate(nint data, int width, int height, Pro.Imaging.PixelFormat pixelFormat)
		{
			image = Decode(data, width, height, pixelFormat);
		});
		image.ThrowWhenNull("image");
		return image;
	}

	public IReadOnlyList<IAnimationFrame> DecodeAnimation(byte[] data)
	{
		List<IAnimationFrame> frames = new List<IAnimationFrame>();
		_imageDecoder.DecodeAnimation(data, delegate(nint data, int width, int height, Pro.Imaging.PixelFormat pixelFormat, int duration)
		{
			frames.Add(new AnimationFrame(Decode(data, width, height, pixelFormat), TimeSpan.FromMilliseconds(duration, 0L)));
		});
		return frames;
	}

	private static BitmapSource Decode(nint data, int width, int height, Pro.Imaging.PixelFormat pixelFormat)
	{
		BitmapSource bitmapSource = BitmapSource.Create(width, height, 96.0, 96.0, Convert(pixelFormat), null, data, GetDataLength(pixelFormat, width, height), width * 4);
		((Freezable)bitmapSource).Freeze();
		return bitmapSource;
	}

	private static System.Windows.Media.PixelFormat Convert(Pro.Imaging.PixelFormat format)
	{
		if (format == Pro.Imaging.PixelFormat.Bgra32)
		{
			return PixelFormats.Bgra32;
		}
		throw new ArgumentOutOfRangeException("format", format, $"{format} is not a supported pixel format");
	}

	private static int GetDataLength(Pro.Imaging.PixelFormat format, int width, int height)
	{
		if (format == Pro.Imaging.PixelFormat.Bgra32)
		{
			return width * height * 4;
		}
		throw new ArgumentOutOfRangeException("format", format, $"{format} is not a supported pixel format");
	}
}
