using System.Collections.Generic;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Collections;

namespace ProPresenter.UI.ViewModels.Workspaces;

public interface IWorkspacesVM
{
	IWorkspaceItemVM SelectedWorkspace { get; }

	INotifyEnumerableChanged<IWorkspaceItemVM> Workspaces { get; }

	IReadOnlyList<string> Collaborators { get; }

	IRelayCommand CreateWorkspaceCommand { get; }

	IAsyncRelayCommand DeleteWorkspaceCommand { get; }

	IAsyncRelayCommand RenameWorkspaceCommand { get; }

	IRelayCommand ImportSelectedLegacyFolderToWorkspaceCommand { get; }

	IRelayCommand ManageWorkspacesCommand { get; }

	IRelayCommand ManageCloudWorkspacesCommand { get; }

	IAsyncRelayCommand<IWorkspaceItemVM> DownloadCloudWorkspaceCommand { get; }

	IAsyncRelayCommand ConvertToLocalWorkspaceCommand { get; }

	IAsyncRelayCommand<IWorkspaceItemVM> SelectWorkspaceCommand { get; }

	IAsyncRelayCommand PublishWorkspaceCommand { get; }

	IAsyncRelayCommand PublishWorkspaceWithConfirmCommand { get; }

	IAsyncRelayCommand DuplicateSelectedWorkspaceCommand { get; }

	IRelayCommand ManageCloudWorkspacesLinkCommand { get; }

	bool IsCloudSignedIn { get; }
}
