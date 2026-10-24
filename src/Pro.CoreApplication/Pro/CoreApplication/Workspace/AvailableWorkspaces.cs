using System.Collections.Generic;
using System.Linq;
using Pro.SerializationInterop.RVProtoData.Service.Workspace;

namespace Pro.CoreApplication.Workspace;

public record AvailableWorkspaces(IReadOnlyList<RemoteWorkspace> Workspaces) : IAvailableWorkspaces
{
	public static AvailableWorkspaces FromProto(Notification.Types.Workspaces.Types.WorkspaceList proto)
	{
		return new AvailableWorkspaces(proto.Workspaces.Select(RemoteWorkspace.FromProto).ToList());
	}
}
