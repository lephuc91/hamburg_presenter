using Pro.Localization;

namespace ProPresenter.DO.Actions;

public enum SlideDestinationType
{
	NoChange,
	[LocalizedString("ACTION_PALETTE_STAGE_DESTINATION_STAGE_title")]
	StageOnly,
	[LocalizedString("ACTION_PALETTE_STAGE_DESTINATION_STAGE_AND_AUDIENCE_title")]
	All
}
