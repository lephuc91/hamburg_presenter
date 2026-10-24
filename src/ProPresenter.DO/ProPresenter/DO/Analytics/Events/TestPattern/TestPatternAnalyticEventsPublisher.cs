using Pro.DO.Analytics;

namespace ProPresenter.DO.Analytics.Events.TestPattern;

public class TestPatternAnalyticEventsPublisher : ITestPatternAnalyticEventsPublisher
{
	public void Shown(TestPatternShownSource source)
	{
		EventPublisher.Publish(new TestPatternShownEvent(source));
	}
}
