using System.Threading;
using System.Threading.Tasks;

namespace ProPresenter.DO.Workspaces;

public interface IWorkspaceService
{
	IWorkspaceCollection Workspaces { get; }

	bool DoesWorkspacePathExist(string? path);

	bool DoesWorkspaceNameExist(string? workspaceName);

	void OnWorkspaceSwitch();

	Task<string> ZipWorkspaceAsync(IWorkspace workSpace);

	Task RemoveWorkspaceAsync(IWorkspace workspace);

	Task<long> GetWorkspaceSizeBytesAsync(IWorkspace workspace, CancellationToken ct = default(CancellationToken));
}
