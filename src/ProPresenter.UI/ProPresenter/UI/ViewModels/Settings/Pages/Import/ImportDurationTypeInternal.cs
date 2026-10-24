using Pro.Localization;

namespace ProPresenter.UI.ViewModels.Settings.Pages.Import;

public enum ImportDurationTypeInternal
{
	[LocalizedString("SETTINGS_IMPORT_DURATION_TYPE_NONE_title")]
	None,
	[LocalizedString("SETTINGS_IMPORT_DURATION_TYPE_TIME_title")]
	Time,
	[LocalizedString("SETTINGS_IMPORT_DURATION_TYPE_RANDOM_title")]
	Random
}
