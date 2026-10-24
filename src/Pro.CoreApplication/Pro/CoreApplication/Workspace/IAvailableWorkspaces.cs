using System.Collections.Generic;

namespace Pro.CoreApplication.Workspace;

public interface IAvailableWorkspaces
{
	IReadOnlyList<RemoteWorkspace> Workspaces { get; }
}
