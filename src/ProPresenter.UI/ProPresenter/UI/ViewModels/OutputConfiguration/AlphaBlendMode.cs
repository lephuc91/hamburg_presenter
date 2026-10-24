using Pro.Localization;

namespace ProPresenter.UI.ViewModels.OutputConfiguration;

public enum AlphaBlendMode
{
	[LocalizedString("SCREEN_CONFIGURATION_ALPHA_KEY_TAB_TYPE_NONE_KEY_label")]
	None,
	[LocalizedString("SCREEN_CONFIGURATION_ALPHA_KEY_TAB_TYPE_PREMULTIPLIED_KEY_label")]
	Premultiplied,
	[LocalizedString("SCREEN_CONFIGURATION_ALPHA_KEY_TAB_TYPE_STRAIGHT_KEY_label")]
	Straight
}
