using Pro.DO.Analytics;

namespace ProPresenter.DO.Analytics.Events.ForceQuit;

public class ForceQuitEventPublisher : IForceQuitEventPublisher
{
	public void ForceQuit(ForceQuitReason reason)
	{
		EventPublisher.Publish(new ForceQuitEvent(reason));
	}
}
