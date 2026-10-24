using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ProPresenter.UI.ViewModels.Welcome;

public interface IWelcomeJoinWorkspaceVM : INotifyPropertyChanged
{
	ObservableCollection<IWorkspaceInfo> Workspaces { get; }

	bool IsLoadingWorkspaces { get; }

	bool HasWorkspaces { get; }

	IWorkspaceInfo? SelectedWorkspace { get; set; }

	IRelayCommand CreateNewWorkspaceCommand { get; }

	IAsyncRelayCommand<IWorkspaceInfo> JoinSelectedWorkspaceCommand { get; }

	void Initialize();
}
