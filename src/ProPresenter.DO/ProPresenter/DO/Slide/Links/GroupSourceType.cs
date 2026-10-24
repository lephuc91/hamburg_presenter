using Pro.Localization;

namespace ProPresenter.DO.Slide.Links;

public enum GroupSourceType
{
	[LocalizedString("TEXT_LINK_GROUP_NAME_CURRENT_SLIDE_title")]
	CurrentSlide,
	[LocalizedString("TEXT_LINK_GROUP_NAME_NEXT_SLIDE_title")]
	NextSlide,
	[LocalizedString("TEXT_LINK_GROUP_NAME_NEXT_GROUP_title")]
	NextGroup
}
