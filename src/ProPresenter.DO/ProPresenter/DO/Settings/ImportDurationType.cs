using Pro.Localization;

namespace ProPresenter.DO.Settings;

public enum ImportDurationType
{
	[LocalizedString("IMPORT_PREFERENCES_DURATION_TYPE_NONE_title")]
	None,
	[LocalizedString("IMPORT_PREFERENCES_DURATION_TYPE_TIME_title")]
	Time,
	[LocalizedString("IMPORT_PREFERENCES_DURATION_TYPE_RANDOM_title")]
	Random
}
