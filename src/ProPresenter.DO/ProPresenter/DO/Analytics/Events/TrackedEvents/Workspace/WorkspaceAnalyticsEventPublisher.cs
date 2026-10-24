using System;
using Pro.DO.Analytics;

namespace ProPresenter.DO.Analytics.Events.TrackedEvents.Workspace;

public class WorkspaceAnalyticsEventPublisher : IWorkspaceAnalyticsEventPublisher
{
	public void WorkspaceCreation(WorkspaceCreationSource source, TimeSpan creationDuration)
	{
		EventPublisher.Publish(new WorkspaceCreationEvent(source, creationDuration));
	}
}
