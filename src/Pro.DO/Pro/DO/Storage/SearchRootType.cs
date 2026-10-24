using Pro.Localization;

namespace Pro.DO.Storage;

public enum SearchRootType
{
	[LocalizedString("ADVANCED_PREFERENCES_SEARCH_PATH_OPTION_DOCUMENTS_title")]
	Documents = 0,
	[LocalizedString("ADVANCED_PREFERENCES_SEARCH_PATH_OPTION_DOWNLOADS_title")]
	Downloads = 1,
	[LocalizedString("ADVANCED_PREFERENCES_SEARCH_PATH_OPTION_MUSIC_title")]
	Music = 2,
	[LocalizedString("ADVANCED_PREFERENCES_SEARCH_PATH_OPTION_PICTURES_title")]
	Pictures = 3,
	[LocalizedString("ADVANCED_PREFERENCES_SEARCH_PATH_OPTION_VIDEOS_title")]
	Videos = 4,
	[LocalizedString("ADVANCED_PREFERENCES_SEARCH_PATH_OPTION_DESKTOP_title")]
	Desktop = 11,
	[LocalizedString("ADVANCED_PREFERENCES_SEARCH_PATH_OPTION_HOME_title")]
	Home = 5,
	[LocalizedString("ADVANCED_PREFERENCES_SEARCH_PATH_OPTION_SHOW_title")]
	Show = 6,
	[LocalizedString("ADVANCED_PREFERENCES_SEARCH_PATH_OPTION_PROGRAM_DATA_title")]
	ProgramData = 7,
	[LocalizedString("ADVANCED_PREFERENCES_SEARCH_PATH_OPTION_BOOT_VOLUME_title")]
	BootVolume = 8,
	[LocalizedString("ADVANCED_PREFERENCES_SEARCH_PATH_OPTION_APP_DATA_title")]
	AppData = 9,
	[LocalizedString("ADVANCED_PREFERENCES_SEARCH_PATH_OPTION_OTHER_VOLUMES_title")]
	OtherVolumes = 10
}
