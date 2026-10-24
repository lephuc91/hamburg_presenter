using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Pro.Common.Background;
using Pro.Common.Cache;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Logging;
using Pro.Common.Mathematics;

namespace Pro.Common.Utility;

public static class ImageHelper
{
	private sealed class ImageFileIdentifier : IEquatable<ImageFileIdentifier>
	{
		public readonly string _fileName;

		public DateTime _modificationDate { get; }

		private ImageFileIdentifier(string fileName)
		{
			_fileName = fileName;
			if (File.Exists(_fileName))
			{
				_modificationDate = File.GetLastWriteTime(_fileName);
			}
			else
			{
				_modificationDate = DateTime.MinValue;
			}
		}

		public override bool Equals(object? obj)
		{
			if (obj is ImageFileIdentifier other)
			{
				return Equals(other);
			}
			return false;
		}

		public bool Equals(ImageFileIdentifier? other)
		{
			if (other != null && _fileName == other._fileName)
			{
				return _modificationDate == other._modificationDate;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(_fileName, _modificationDate);
		}

		public static implicit operator string(ImageFileIdentifier i)
		{
			return i._fileName;
		}

		public static implicit operator ImageFileIdentifier(string path)
		{
			return new ImageFileIdentifier(path);
		}
	}

	private sealed class ImageCache : WeakValueCache<ImageFileIdentifier, BitmapSource>
	{
		protected override BitmapSource? GenerateValue(ImageFileIdentifier target)
		{
			if (!File.Exists(target))
			{
				return null;
			}
			try
			{
				BitmapImage bitmapImage = new BitmapImage();
				using (FileStream streamSource = File.OpenRead(target))
				{
					bitmapImage.BeginInit();
					bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
					bitmapImage.StreamSource = streamSource;
					bitmapImage.EndInit();
					((Freezable)bitmapImage).Freeze();
				}
				return bitmapImage;
			}
			catch (Exception arg)
			{
				Log.Error($"Failed to load image: {Path.GetFileName(target)} {arg}");
				return null;
			}
		}
	}

	private static readonly ImageCache _imageCache = new ImageCache();

	public static BitmapSource? LoadImage(string filename)
	{
		return _imageCache.Get(filename);
	}

	public static BitmapSource? LoadImageFromURL(string url)
	{
		try
		{
			using WebResponse webResponse = WebRequest.CreateDefault(new Uri(url, UriKind.Absolute)).GetResponse();
			using Stream stream = webResponse.GetResponseStream();
			using MemoryStream memoryStream = new MemoryStream();
			stream.CopyTo(memoryStream);
			memoryStream.Position = 0L;
			BitmapImage bitmapImage = new BitmapImage();
			bitmapImage.BeginInit();
			bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
			bitmapImage.StreamSource = memoryStream;
			bitmapImage.EndInit();
			((Freezable)bitmapImage).Freeze();
			return bitmapImage;
		}
		catch (Exception value)
		{
			Log.Error($"Failed to load image from {url} - {value}");
			return null;
		}
	}

	public static void LoadImageFromURLAsync(string url, Action<BitmapSource?> completedCallback, Dispatcher? dispatcher = null)
	{
		if (dispatcher == null)
		{
			dispatcher = Dispatcher.CurrentDispatcher;
		}
		SharedWorkerPool.Queue.AddJob(delegate
		{
			BitmapSource image = LoadImageFromURL(url);
			dispatcher.InvokeAsync((Action)delegate
			{
				completedCallback(image);
			});
		});
	}

	public static BitmapSource RenderVisual(this Visual visual, Size size, bool needsLayout = false)
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		if (needsLayout && visual is UIElement uIElement)
		{
			uIElement.Measure(size);
			uIElement.Arrange(new Rect(size));
		}
		DrawingVisual drawingVisual = new DrawingVisual();
		using (DrawingContext drawingContext = drawingVisual.RenderOpen())
		{
			drawingContext.DrawRectangle(new VisualBrush(visual), null, new Rect(size));
		}
		DisposableRenderTargetBitmap disposableRenderTargetBitmap = new DisposableRenderTargetBitmap((int)Math.Ceiling(((Size)(ref size)).Width), (int)Math.Ceiling(((Size)(ref size)).Height), 96.0, 96.0, PixelFormats.Pbgra32);
		disposableRenderTargetBitmap.Render(drawingVisual);
		disposableRenderTargetBitmap.Freeze();
		return disposableRenderTargetBitmap.DisposeAndExtractBitmap();
	}

	public static bool TryWriteImage(this BitmapSource source, string targetFilename)
	{
		try
		{
			EnsureFolderExists(targetFilename);
			using (FileStream stream = new FileStream(targetFilename, FileMode.Create))
			{
				PngBitmapEncoder pngBitmapEncoder = new PngBitmapEncoder();
				pngBitmapEncoder.Frames.Add(BitmapFrame.Create(source));
				pngBitmapEncoder.Save(stream);
			}
			return true;
		}
		catch (Exception exception)
		{
			Log.Error(exception);
			return false;
		}
	}

	public static byte[]? ToByteArray(this BitmapSource source)
	{
		try
		{
			using MemoryStream memoryStream = new MemoryStream();
			PngBitmapEncoder pngBitmapEncoder = new PngBitmapEncoder();
			pngBitmapEncoder.Frames.Add(BitmapFrame.Create(source));
			pngBitmapEncoder.Save(memoryStream);
			return memoryStream.ToArray();
		}
		catch (Exception exception)
		{
			Log.Error(exception);
			return null;
		}
	}

	public static BitmapSource? ToBitmapSource(this ImageSource? source)
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		if (source == null)
		{
			return null;
		}
		if (source is BitmapSource result)
		{
			return result;
		}
		Vector2<double> size = new Vector2<double>(source.Width, source.Height);
		DrawingVisual drawingVisual = new DrawingVisual();
		using (DrawingContext drawingContext = drawingVisual.RenderOpen())
		{
			drawingContext.DrawImage(source, new Rect<double>(size));
		}
		DisposableRenderTargetBitmap disposableRenderTargetBitmap = new DisposableRenderTargetBitmap((int)Math.Ceiling(size.X), (int)Math.Ceiling(size.Y), 96.0, 96.0, PixelFormats.Pbgra32);
		disposableRenderTargetBitmap.Render(drawingVisual);
		disposableRenderTargetBitmap.Freeze();
		return disposableRenderTargetBitmap.DisposeAndExtractBitmap();
	}

	public static BitmapSource? ToBitmapSource(this byte[] byteArr)
	{
		if (byteArr.Length == 0)
		{
			return null;
		}
		BitmapImage bitmapImage = new BitmapImage();
		using MemoryStream streamSource = new MemoryStream(byteArr);
		bitmapImage.BeginInit();
		bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
		bitmapImage.StreamSource = streamSource;
		bitmapImage.EndInit();
		((Freezable)bitmapImage).Freeze();
		return bitmapImage;
	}

	public static bool HasTransparency(this PixelFormat format)
	{
		return format.IsAnyOf(PixelFormats.Bgra32, PixelFormats.Pbgra32, PixelFormats.Prgba128Float, PixelFormats.Prgba64, PixelFormats.Rgba64);
	}

	public static IBitmapHandle? ToBitmapHandle(this BitmapSource bitmapSource)
	{
		if (bitmapSource != null)
		{
			return new NonOwnedBitmapHandle(bitmapSource);
		}
		return null;
	}

	private static void EnsureFolderExists(string path)
	{
		string directoryName = Path.GetDirectoryName(path);
		if (!string.IsNullOrEmpty(directoryName))
		{
			Directory.CreateDirectory(directoryName);
		}
	}
}
