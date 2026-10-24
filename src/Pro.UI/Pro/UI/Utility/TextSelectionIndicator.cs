using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using Pro.Common.Mathematics;

namespace Pro.UI.Utility;

public class TextSelectionIndicator : Adorner
{
	private readonly Geometry _selectionGeometry;

	public TextSelectionIndicator(UIElement adornedElement, IEnumerable<Rect<double>> rects)
		: base(adornedElement)
	{
		base.IsHitTestVisible = false;
		base.IsClipEnabled = true;
		_selectionGeometry = new GeometryGroup
		{
			FillRule = FillRule.Nonzero,
			Children = new GeometryCollection(rects.Select((Rect<double> r) => new RectangleGeometry(r)))
		};
	}

	protected override void OnRender(DrawingContext drawingContext)
	{
		base.OnRender(drawingContext);
		drawingContext.DrawGeometry(new SolidColorBrush(Colors.CornflowerBlue)
		{
			Opacity = 0.65
		}, new Pen(Brushes.LightBlue, 1.0), _selectionGeometry);
	}
}
