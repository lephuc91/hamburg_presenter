using Pro.Localization;

namespace ProPresenter.DO.Slide.Links;

public enum ElementVisibilityCriteria
{
	[LocalizedString("VISIBILITY_LINK_CONDITION_HAS_TEXT_title")]
	HasText,
	[LocalizedString("VISIBILITY_LINK_CONDITION_DOES_NOT_HAVE_TEXT_title")]
	HasNoText
}
