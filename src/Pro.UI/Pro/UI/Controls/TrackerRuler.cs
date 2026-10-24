using System.Linq;
using System.Windows.Media;
using Pro.Common.Mathematics;

namespace Pro.UI.Controls;

public class TrackerRuler : Ruler
{
	private VisualCollection _trackers;

	protected override int VisualChildrenCount => _trackers.Count;

	public TrackerRuler()
	{
		_trackers = new VisualCollection(this);
	}

	protected override Visual GetVisualChild(int index)
	{
		return _trackers[index];
	}

	public void AddTracker(TrackerBase tracker)
	{
		tracker.TrackerInvalidated += OnTrackerInvalidated;
		_trackers.Add(tracker);
	}

	public void RemoveTracker(TrackerBase tracker)
	{
		tracker.TrackerInvalidated -= OnTrackerInvalidated;
		_trackers.Remove(tracker);
	}

	private void OnTrackerInvalidated(TrackerBase tracker)
	{
		tracker.Render(base.IsHorizontal.Orient(0.0, base.Origin - (base.ScrollOffset - base.OriginOffset)), base.ZoomFactor, base.IsHorizontal);
	}

	protected override void OnRender(DrawingContext dc)
	{
		base.OnRender(dc);
		foreach (TrackerBase item in _trackers.OfType<TrackerBase>())
		{
			OnTrackerInvalidated(item);
		}
	}
}
