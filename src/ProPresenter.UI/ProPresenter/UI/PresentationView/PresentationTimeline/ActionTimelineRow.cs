namespace ProPresenter.UI.PresentationView.PresentationTimeline;

public class ActionTimelineRow : TimelineRow
{
	public override bool IsSectionVisible(TimelineSection section)
	{
		if (section.StartTime >= base.VisibleDurationStart)
		{
			return section.StartTime <= base.VisibleDurationStart + base.VisibleDuration;
		}
		return false;
	}
}
