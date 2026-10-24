using Pro.Localization;

namespace ProPresenter.UI.ViewModels.AccountCenter;

public enum SyncStatus
{
	[LocalizedString("CLOUDWORKSPACE_SYNC_STATUS_ACTIVE_message")]
	Active,
	[LocalizedString("CLOUDWORKSPACE_SYNC_STATUS_OFFLINE_message")]
	Offline,
	[LocalizedString("CLOUDWORKSPACE_SYNC_STATUS_PAUSED_message")]
	Paused,
	[LocalizedString("CLOUDWORKSPACE_SYNC_STATUS_ERROR_message")]
	Error
}
