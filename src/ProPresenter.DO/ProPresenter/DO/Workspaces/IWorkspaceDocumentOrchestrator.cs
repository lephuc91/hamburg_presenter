using System.Threading.Tasks;
using Pro.CoreApplication.Workspace;

namespace ProPresenter.DO.Workspaces;

public interface IWorkspaceDocumentOrchestrator
{
	Task SendWorkspaceDocumentsToCoreAsync(IWorkspace workspace);

	Task CreateRemoteWorkspaceAsync(RemoteWorkspaceDocuments remoteWorkspaceDocuments, string path);
}
