namespace ProPresenter.DO.Analytics;

public class TimelineAnalyticsEvents : ITimelineAnalyticsEvents
{
	public void Action(TimelineActionType action)
	{
		TimelineActionEvent.Publish(action);
	}

	public void RecordCue()
	{
		TimelineRecordCueEvent.Publish();
	}

	public void TriggerCue(TimelineTriggerCueType type)
	{
		TimelineTriggerCueEvent.Publish(type);
	}
}
