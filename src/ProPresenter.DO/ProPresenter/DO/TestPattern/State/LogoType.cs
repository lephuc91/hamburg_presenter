using Pro.Localization;

namespace ProPresenter.DO.TestPattern.State;

public enum LogoType
{
	[LocalizedString("TEST_PATTERN_LOGO_NONE_title")]
	None,
	[LocalizedString("TEST_PATTERN_LOGO_PROPRESENTER_title")]
	Propresenter,
	[LocalizedString("TEST_PATTERN_LOGO_USER_title")]
	User
}
