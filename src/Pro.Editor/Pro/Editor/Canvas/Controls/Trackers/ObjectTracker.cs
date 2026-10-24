using System.Windows.Media;
using Pro.Common.Mathematics;
using Pro.UI.Controls;

namespace Pro.Editor.Canvas.Controls.Trackers;

public class ObjectTracker : TrackerBase
{
	private Rect<double> _objectBounds = Rect<double>.Empty;

	private Color _trackerColor = Colors.Blue;

	public Rect<double> ObjectBounds
	{
		get
		{
			return _objectBounds;
		}
		set
		{
			if (_objectBounds != value)
			{
				_objectBounds = value;
				OnTrackerInvalidated();
			}
		}
	}

	public Color TrackerColor
	{
		get
		{
			return _trackerColor;
		}
		set
		{
			if (_trackerColor != value)
			{
				_trackerColor = value;
				OnTrackerInvalidated();
			}
		}
	}

	protected override void OnRender()
	{
		if (ObjectBounds != Rect<double>.Empty)
		{
			SolidColorBrush brush = new SolidColorBrush(TrackerColor);
			Rect<double> objectBounds = ObjectBounds;
			DrawLine(objectBounds.TopLeft, brush);
			DrawLine(objectBounds.Center, brush);
			DrawLine(objectBounds.BottomRight, brush);
		}
	}
}
