using System;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Pro.Common.Components;
using Pro.Common.Reflection;

namespace Pro.Common.Utility;

public class DisposableRenderTargetBitmap : DisposableBase
{
	private static readonly PropertyGetter? MILRenderTargetPropertyGetter = PropertyGetterCache.GetGetter<RenderTargetBitmap>("MILRenderTarget");

	private readonly RenderTargetBitmap _bitmap;

	private int _gdiHandleFreed;

	public double Width
	{
		get
		{
			EnsureValid();
			return _bitmap.Width;
		}
	}

	public double Height
	{
		get
		{
			EnsureValid();
			return _bitmap.Height;
		}
	}

	public DisposableRenderTargetBitmap(int pixelWidth, int pixelHeight, double dpiX, double dpiY, PixelFormat pixelFormat)
	{
		_bitmap = new RenderTargetBitmap(pixelWidth, pixelHeight, dpiX, dpiY, pixelFormat);
	}

	public void Render(Visual visual)
	{
		EnsureValid();
		_bitmap?.Render(visual);
	}

	public void Freeze()
	{
		EnsureValid();
		if (!((Freezable)_bitmap).IsFrozen)
		{
			((Freezable)_bitmap).Freeze();
			FreeGdiHandle();
		}
	}

	public BitmapSource DisposeAndExtractBitmap()
	{
		Freeze();
		Dispose();
		return _bitmap;
	}

	protected override void OnDispose(bool disposeObjects)
	{
		if (disposeObjects)
		{
			FreeGdiHandle();
		}
	}

	private void FreeGdiHandle()
	{
		if (Interlocked.Exchange(ref _gdiHandleFreed, 1) == 0)
		{
			(MILRenderTargetPropertyGetter?.Invoke(_bitmap) as IDisposable)?.Dispose();
		}
	}

	public static implicit operator BitmapSource(DisposableRenderTargetBitmap disposableBitmap)
	{
		disposableBitmap.EnsureValid();
		return disposableBitmap._bitmap;
	}
}
