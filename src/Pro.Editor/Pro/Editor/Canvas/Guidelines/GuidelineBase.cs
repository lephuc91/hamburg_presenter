using System.Windows.Media;
using Pro.Common.Mathematics;

namespace Pro.Editor.Canvas.Guidelines;

public abstract class GuidelineBase : DrawingVisual
{
	protected double ZoomFactor { get; private set; } = 1.0;

	protected Vector2<double> Origin { get; private set; } = Vector2<double>.Zero;

	protected Vector2<double> RenderOffset { get; private set; } = Vector2<double>.Zero;

	public bool IsParent { get; set; }

	public abstract void OnRenderGuideline(DrawingContext dc, Pen pen);

	public void RenderGuideline(Vector2<double> origin, Vector2<double> renderOffset, double zoomFactor, Color color)
	{
		Origin = origin;
		RenderOffset = renderOffset;
		ZoomFactor = zoomFactor;
		Pen pen = new Pen(new SolidColorBrush(color), 1.0);
		using DrawingContext dc = RenderOpen();
		OnRenderGuideline(dc, pen);
	}
}
