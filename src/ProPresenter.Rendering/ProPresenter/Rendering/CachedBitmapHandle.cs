using System;
using System.Windows.Media.Imaging;
using Pro.Common.Components;
using Pro.Common.Mathematics;

namespace ProPresenter.Rendering;

public class CachedBitmapHandle : DisposableBase, IBitmapHandle, IDisposable
{
	private readonly CachedBitmap _cachedBitmap;

	private readonly RenderedBitmapHandle _renderedBitmap;

	public Vector2<double> RenderOffset
	{
		get
		{
			EnsureValid();
			return _renderedBitmap.RenderOffset;
		}
	}

	public Vector2<double> RenderSize
	{
		get
		{
			EnsureValid();
			return _renderedBitmap.RenderSize;
		}
	}

	public BitmapSource BitmapSource
	{
		get
		{
			EnsureValid();
			return _renderedBitmap.BitmapSource;
		}
	}

	internal CachedBitmapHandle(CachedBitmap cachedBitmap, RenderedBitmapHandle renderedBitmap)
	{
		_cachedBitmap = cachedBitmap;
		_renderedBitmap = renderedBitmap;
	}

	protected override void OnDispose(bool disposeObjects)
	{
		_cachedBitmap?.ReleaseHandle(this, _renderedBitmap);
	}
}
