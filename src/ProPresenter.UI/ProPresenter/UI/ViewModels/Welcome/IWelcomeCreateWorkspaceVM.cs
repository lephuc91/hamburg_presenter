using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ProPresenter.UI.ViewModels.Welcome;

public interface IWelcomeCreateWorkspaceVM : INotifyPropertyChanged
{
	string WorkspaceName { get; set; }

	bool IsWorkspaceNameValid { get; }

	bool CanCreateCloudWorkspace { get; }

	bool CanCreateLocalWorkspace { get; }

	bool HasActiveSubscription { get; }

	bool HasNetworkConnection { get; }

	bool IsSignedIn { get; }

	bool IsCreatingWorkspace { get; }

	IRelayCommand OpenLearnMoreCommand { get; }

	IRelayCommand ContinueWithLocalCommand { get; }

	IAsyncRelayCommand ContinueWithCloudCommand { get; }

	void Initialize();
}
