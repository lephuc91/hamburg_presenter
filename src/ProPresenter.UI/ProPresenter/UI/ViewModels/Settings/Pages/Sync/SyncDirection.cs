using Pro.Localization;

namespace ProPresenter.UI.ViewModels.Settings.Pages.Sync;

public enum SyncDirection
{
	[LocalizedString("SETTINGS_SYNC_SYNC_DOWN_FROM_REPOSITORY_title")]
	SyncDown,
	[LocalizedString("SETTINGS_SYNC_SYNC_UP_TO_REPOSITORY_title")]
	SyncUp
}
