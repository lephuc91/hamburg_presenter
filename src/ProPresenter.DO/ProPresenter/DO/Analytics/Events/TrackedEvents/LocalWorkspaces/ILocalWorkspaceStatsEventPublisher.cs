namespace ProPresenter.DO.Analytics.Events.TrackedEvents.LocalWorkspaces;

public interface ILocalWorkspaceStatsEventPublisher
{
	void Publish(int totalWorkspaces, int numberOfWorkspaceSwitches);
}
