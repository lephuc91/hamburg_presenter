namespace ProPresenter.DO.Analytics;

public interface ITimelineAnalyticsEvents
{
	void Action(TimelineActionType action);

	void RecordCue();

	void TriggerCue(TimelineTriggerCueType type);
}
