using System;
using System.Windows.Media.Imaging;
using Pro.Common.Mathematics;

namespace Pro.Common.Components;

public interface IBitmapHandle : IDisposable
{
	Vector2<double> RenderOffset { get; }

	Vector2<double> RenderSize { get; }

	BitmapSource? BitmapSource { get; }
}
