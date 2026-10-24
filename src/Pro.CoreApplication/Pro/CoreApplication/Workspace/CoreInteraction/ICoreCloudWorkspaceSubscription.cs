using System;
using Pro.SerializationInterop.RVProtoData.Service.Workspace;

namespace Pro.CoreApplication.Workspace.CoreInteraction;

public interface ICoreCloudWorkspaceSubscription
{
	IObservable<Notification.Types.Workspaces> WhenWorkspacesChanged { get; }

	IObservable<Notification.Types.Collaborators> WhenCollaboratorsChanged { get; }

	IObservable<Notification.Types.Syncing> WhenSyncingChanged { get; }
}
