using System;
using System.Windows.Media.Imaging;
using Pro.Common.Components;
using Pro.Common.Mathematics;

namespace Pro.Common.Utility;

public class NonOwnedBitmapHandle : DisposableBase, IBitmapHandle, IDisposable
{
	public Vector2<double> RenderOffset => Vector2<double>.Zero;

	public Vector2<double> RenderSize { get; }

	public BitmapSource? BitmapSource { get; private set; }

	public NonOwnedBitmapHandle(BitmapSource bitmapSource)
	{
		if (bitmapSource == null)
		{
			throw new ArgumentNullException();
		}
		RenderSize = new Vector2<double>(bitmapSource.Width, bitmapSource.Height);
		BitmapSource = bitmapSource;
	}

	protected override void OnDispose(bool disposeObjects)
	{
		BitmapSource = null;
	}
}
