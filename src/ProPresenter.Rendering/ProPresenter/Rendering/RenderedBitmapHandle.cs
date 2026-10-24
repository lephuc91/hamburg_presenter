using System;
using System.Windows.Media.Imaging;
using Pro.Common.Components;
using Pro.Common.Mathematics;
using Pro.Common.Utility;

namespace ProPresenter.Rendering;

public class RenderedBitmapHandle : DisposableBase, IBitmapHandle, IDisposable
{
	private readonly DisposableRenderTargetBitmap _renderTargetBitmap;

	public Vector2<double> RenderOffset { get; }

	public Vector2<double> RenderSize { get; }

	public BitmapSource BitmapSource => _renderTargetBitmap;

	internal RenderedBitmapHandle(Vector2<double> renderOffset, Vector2<double> renderSize, DisposableRenderTargetBitmap renderTargetBitmap)
	{
		RenderOffset = renderOffset;
		RenderSize = renderSize;
		_renderTargetBitmap = renderTargetBitmap;
	}

	protected override void OnDispose(bool disposeObjects)
	{
		if (disposeObjects)
		{
			_renderTargetBitmap.Dispose();
		}
	}
}
