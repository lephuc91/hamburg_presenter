using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;

namespace ProPresenter.UI.ViewModels.Welcome;

public interface IAdditionalResourcesVM
{
	bool IsDownloadingWorkspace { get; }

	IRelayCommand TutorialsCommand { get; }

	IRelayCommand UserGroupCommand { get; }

	IRelayCommand KnowledgeBaseCommand { get; }

	IRelayCommand BlogCommand { get; }

	Task DownloadWorkspaceAsync(IWorkspaceInfo workspaceInfo);
}
