using Pro.Localization;

namespace ProPresenter.DO.Resi;

public enum UpdateStatus
{
	None,
	[LocalizedString("RESI_PREFERENCES_SETTINGS_DOWNLOADING_label")]
	Downloading,
	[LocalizedString("RESI_PREFERENCES_SETTINGS_INSTALLING_label")]
	Installing,
	[LocalizedString("RESI_PREFERENCES_SETTINGS_STARTING_label")]
	Starting
}
