using Pro.DO.Analytics;

namespace ProPresenter.DO.Analytics.Events.TrackedEvents.LocalWorkspaces;

public class LocalWorkspaceStatsEventPublisher : ILocalWorkspaceStatsEventPublisher
{
	public void Publish(int totalWorkspaces, int numberOfWorkspaceSwitches)
	{
		EventPublisher.Publish(new LocalWorkspaceStatsEvent(totalWorkspaces, numberOfWorkspaceSwitches));
	}
}
