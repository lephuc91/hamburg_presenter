using System;

namespace ProPresenter.DO.Analytics.Events.TrackedEvents.Workspace;

public interface IWorkspaceAnalyticsEventPublisher
{
	void WorkspaceCreation(WorkspaceCreationSource source, TimeSpan creationDuration);
}
