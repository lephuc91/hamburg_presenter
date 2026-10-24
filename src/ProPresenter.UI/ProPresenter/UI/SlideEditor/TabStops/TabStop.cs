using System.Windows.Media;
using Pro.Editor.Canvas.TabStop;
using Pro.Text;
using ProPresenter.DO.Slide.Custom.Elements;

namespace ProPresenter.UI.SlideEditor.TabStops;

public class TabStop : TabStopControlBase
{
	public static string LeftAlign = "M -3 0 L -3 12 L 3 6 Z";

	public static string CenterAlign = "M 0 0 L -6 6 L 0 12 L 6 6 Z";

	public static string RightAlign = "M 3 0 L 3 12 L -3 6 Z";

	public static string DecimalAlign = "M6,6C6,9.31370849898476 3.31370849898476,12 0,12 -3.31370849898476,12 -6,9.31370849898476 -6,6 -6,2.68629150101524 -3.31370849898476,0 0,0 3.31370849898476,0 6,2.68629150101524 6,6z";

	private readonly Geometry _leftMarker;

	private readonly Geometry _centerMarker;

	private readonly Geometry _rightMarker;

	private readonly Geometry _decimalMarker;

	public Pro.Text.TabStop TextTabStop { get; }

	public override double Position => TextTabStop?.Position ?? 0.0;

	public override bool CanRemove => true;

	public override double YOrigin => 4.0;

	public TabStop(Pro.Text.TabStop tabStop, ClosedBezierPath textElement)
		: base(textElement)
	{
		TextTabStop = tabStop;
		_leftMarker = Geometry.Parse(LeftAlign);
		_centerMarker = Geometry.Parse(CenterAlign);
		_rightMarker = Geometry.Parse(RightAlign);
		_decimalMarker = Geometry.Parse(DecimalAlign);
	}

	public override void OnRenderTabStop(DrawingContext context, Pen pen)
	{
		Brush brush = pen.Brush;
		context.DrawGeometry(brush, pen, TextTabStop.Type switch
		{
			TabStopType.Center => _centerMarker, 
			TabStopType.Right => _rightMarker, 
			TabStopType.Decimal => _decimalMarker, 
			_ => _leftMarker, 
		});
	}

	public override void Drag(double startPosition, double dragPosition)
	{
		TextTabStop.Position = startPosition + dragPosition;
	}
}
