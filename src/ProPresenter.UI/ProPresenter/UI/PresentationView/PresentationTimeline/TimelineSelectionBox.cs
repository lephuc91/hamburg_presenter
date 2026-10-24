using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using Pro.Common.Mathematics;

namespace ProPresenter.UI.PresentationView.PresentationTimeline;

public class TimelineSelectionBox : Adorner
{
	private Rect<double> _bounds = Rect<double>.Empty;

	public TimelineSelectionBox(ItemsControl timelineControl)
		: base(timelineControl)
	{
	}

	public void UpdateBounds(Rect<double> bounds)
	{
		_bounds = bounds;
		InvalidateVisual();
	}

	protected override void OnRender(DrawingContext drawingContext)
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		drawingContext.DrawRectangle(new SolidColorBrush(Colors.AliceBlue)
		{
			Opacity = 0.25
		}, new Pen(new SolidColorBrush(Colors.LightBlue)
		{
			Opacity = 0.5
		}, 0.5), _bounds);
		base.OnRender(drawingContext);
	}
}
