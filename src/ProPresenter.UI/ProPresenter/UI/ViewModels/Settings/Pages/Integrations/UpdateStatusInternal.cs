using Pro.Localization;

namespace ProPresenter.UI.ViewModels.Settings.Pages.Integrations;

public enum UpdateStatusInternal
{
	None,
	[LocalizedString("SETTINGS_RESI_ENCODER_DOWNLOADING_label")]
	Downloading,
	[LocalizedString("SETTINGS_RESI_ENCODER_INSTALLING_label")]
	Installing,
	[LocalizedString("SETTINGS_RESI_ENCODER_STARTING_label")]
	Starting
}
