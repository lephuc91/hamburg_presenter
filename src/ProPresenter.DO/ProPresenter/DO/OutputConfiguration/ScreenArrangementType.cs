using Pro.Localization;

namespace ProPresenter.DO.OutputConfiguration;

public enum ScreenArrangementType
{
	[LocalizedString("SCREEN_CONFIGURATION_SCREEN_ARRANGEMENT_SINGLE_title")]
	Single,
	[LocalizedString("SCREEN_CONFIGURATION_SCREEN_ARRANGEMENT_MIRROR_title")]
	Mirror,
	[LocalizedString("SCREEN_CONFIGURATION_SCREEN_ARRANGEMENT_GROUPED_title")]
	Group,
	[LocalizedString("SCREEN_CONFIGURATION_SCREEN_ARRANGEMENT_EDGE_BLEND_title")]
	EdgeBlend
}
