using Pro.Localization;

namespace ProPresenter.DO.Slide.Links;

public enum SlideCountType
{
	[LocalizedString("TEXT_LINK_SLIDE_COUNT_CURRENT_title")]
	Current,
	[LocalizedString("TEXT_LINK_SLIDE_COUNT_REMAINING_title")]
	Remaining,
	[LocalizedString("TEXT_LINK_SLIDE_COUNT_TOTAL_title")]
	Total
}
