using System.Windows.Media;
using Pro.Common.Mathematics;

namespace Pro.Editor.Canvas.TabStop;

public abstract class TabStopControlBase : DrawingVisual
{
	private const string DefaultMarker = "M -6 0 L 0 6 L 6 0 Z";

	protected ICanvasElement? _element;

	private Vector2<double> _parentSize;

	private double _xOrigin;

	private readonly Geometry _marker;

	public ICanvasElement? Element => _element;

	public abstract double Position { get; }

	public Vector2<double> ParentSize => _parentSize;

	public double XOrigin => _xOrigin;

	public virtual double YOrigin => 8.0;

	public virtual bool CanRemove => false;

	protected TabStopControlBase(ICanvasElement? element)
	{
		_element = element;
		_marker = Geometry.Parse("M -6 0 L 0 6 L 6 0 Z");
	}

	public virtual void OnRenderTabStop(DrawingContext context, Pen pen)
	{
		context.DrawGeometry(pen.Brush, pen, _marker);
	}

	public void RenderTabStop(Vector2<double> origin, double zoomFactor, double scrollOfset, double originOffset, Vector2<double> parentSize, Pen pen)
	{
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		_parentSize = parentSize;
		double num = CalculatePosition() * zoomFactor;
		_xOrigin = origin.X - (scrollOfset - num - originOffset);
		using DrawingContext drawingContext = RenderOpen();
		drawingContext.PushTransform(new TranslateTransform(_xOrigin, YOrigin));
		drawingContext.PushClip(new RectangleGeometry(new Rect<double>(new Vector2<double>(0.0 - _xOrigin, 0.0), ParentSize)));
		OnRenderTabStop(drawingContext, pen);
	}

	public abstract void Drag(double startPosition, double dragPosition);

	public double CalculatePosition()
	{
		return (Element?.Position.X ?? 0.0) + OnCalculatePosition();
	}

	protected virtual double OnCalculatePosition()
	{
		return Position;
	}
}
