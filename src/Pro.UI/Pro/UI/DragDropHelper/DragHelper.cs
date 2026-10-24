using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Pro.Common.Mathematics;
using Pro.Common.Utility;
using Pro.UI.Controls;

namespace Pro.UI.DragDropHelper;

public static class DragHelper
{
	private static UIElement ToUIElement(this FrameworkElement container, Vector2<double> size)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		DrawingVisual drawingVisual = new DrawingVisual();
		using (DrawingContext drawingContext = drawingVisual.RenderOpen())
		{
			drawingContext.DrawRectangle(new VisualBrush(container), null, new Rect((Size)size));
		}
		using DisposableRenderTargetBitmap disposableRenderTargetBitmap = new DisposableRenderTargetBitmap((int)Math.Ceiling(size.X), (int)Math.Ceiling(size.Y), 96.0, 96.0, PixelFormats.Pbgra32);
		disposableRenderTargetBitmap.Render(drawingVisual);
		disposableRenderTargetBitmap.Freeze();
		ImageBrush imageBrush = new ImageBrush((BitmapSource)disposableRenderTargetBitmap)
		{
			Viewport = new Rect<double>(Vector2<double>.Zero, new Vector2<double>(disposableRenderTargetBitmap.Width, disposableRenderTargetBitmap.Height)),
			ViewportUnits = BrushMappingMode.Absolute,
			Stretch = Stretch.None
		};
		((Freezable)imageBrush).Freeze();
		return new Rectangle
		{
			Width = size.X,
			Height = size.Y,
			Fill = imageBrush
		};
	}

	public static DragVisual ToDragVisual(this FrameworkElement draggedItem, int count = 1, Vector2<double>? itemSize = null)
	{
		Vector2<double> valueOrDefault = itemSize.GetValueOrDefault();
		if (!itemSize.HasValue)
		{
			valueOrDefault = new Vector2<double>(draggedItem.ActualWidth, draggedItem.ActualHeight);
			itemSize = valueOrDefault;
		}
		return new DragVisual
		{
			Visual = draggedItem.ToUIElement(itemSize.Value),
			Height = itemSize.Value.Y,
			Width = itemSize.Value.X,
			Count = count,
			Opacity = 0.8
		};
	}
}
