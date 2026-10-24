using Pro.Localization;

namespace ProPresenter.DO.Media;

public enum VisualSortType
{
	[LocalizedString("MEDIA_BIN_CONTEXT_MENU_CLEAN_UP_BY_TYPE_title")]
	Type,
	[LocalizedString("MEDIA_BIN_CONTEXT_MENU_CLEAN_UP_BY_NAME_title")]
	Name,
	[LocalizedString("MEDIA_BIN_CONTEXT_MENU_CLEAN_UP_BY_PATH_title")]
	Path,
	[LocalizedString("MEDIA_BIN_CONTEXT_MENU_CLEAN_UP_BY_KIND_title")]
	Kind,
	[LocalizedString("MEDIA_BIN_CONTEXT_MENU_CLEAN_UP_BY_DURATION_title")]
	Duration,
	[LocalizedString("MEDIA_BIN_CONTEXT_MENU_CLEAN_UP_BY_FORMAT_title")]
	Format,
	[LocalizedString("MEDIA_BIN_CONTEXT_MENU_CLEAN_UP_BY_ORIGINAL_LENGTH_title")]
	Length
}
