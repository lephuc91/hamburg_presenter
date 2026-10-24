using System.Windows.Media;
using CommunityToolkit.Mvvm.Input;
using Reactive.Bindings;

namespace ProPresenter.UI.ViewModels.AccountCenter;

public interface IAccountCenterVM
{
	bool IsPopUpOpen { get; set; }

	IReadOnlyReactiveProperty<ImageSource?> Icon { get; }

	IReadOnlyReactiveProperty<bool> IsRegistered { get; }

	IReadOnlyReactiveProperty<string> ListItemTitle { get; }

	IReadOnlyReactiveProperty<string> ListItemSubscript { get; }

	IReadOnlyReactiveProperty<string> MediaManagementProgressStatus { get; }

	IReadOnlyReactiveProperty<SyncStatus> CloudSyncStatus { get; }

	IReadOnlyReactiveProperty<bool> IsMediaManagementPaused { get; }

	IReadOnlyReactiveProperty<bool> IsCloudSyncPaused { get; }

	IReadOnlyReactiveProperty<string> PausedSyncCountdown { get; }

	IReadOnlyReactiveProperty<string> LastActiveSync { get; }

	IRelayCommand CloudTroubleShootingLinkCommand { get; }

	IRelayCommand CloudTeaseSignUpForEarlyAccessCommand { get; }

	IRelayCommand CloudTeaseLearnMoreCommand { get; }
}
