using System;
using System.Collections.Generic;
using Pro.SerializationInterop.RVProtoData.Service.Workspace;

namespace Pro.CoreApplication.Workspace;

public record AvailableWorkspacesError : IAvailableWorkspaces
{
	public IReadOnlyList<RemoteWorkspace> Workspaces => Array.Empty<RemoteWorkspace>();

	public static AvailableWorkspacesError FromProto(Notification.Types.Workspaces.Types.Error proto)
	{
		return new AvailableWorkspacesError();
	}
}
