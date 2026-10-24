using System.Windows.Media;
using Pro.Common.Mathematics;
using Pro.UI.Controls;

namespace Pro.Editor.Canvas.Controls.Trackers;

public class MouseTracker : TrackerBase
{
	private Vector2<double> _mousePosition = Vector2<double>.Zero;

	private Color _trackerColor = Colors.Red;

	public Vector2<double> MousePosition
	{
		get
		{
			return _mousePosition;
		}
		set
		{
			if (_mousePosition != value)
			{
				_mousePosition = value;
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
		DrawLine(MousePosition, new SolidColorBrush(TrackerColor));
	}
}
