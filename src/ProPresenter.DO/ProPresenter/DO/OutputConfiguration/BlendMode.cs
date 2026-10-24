using Pro.Localization;

namespace ProPresenter.DO.OutputConfiguration;

public enum BlendMode
{
	[LocalizedString("SCREEN_CONFIGURATION_EDGE_BLEND_TAB_CURVE_LINEAR_label")]
	Linear,
	[LocalizedString("SCREEN_CONFIGURATION_EDGE_BLEND_TAB_CURVE_CUBIC_label")]
	Cubic,
	[LocalizedString("SCREEN_CONFIGURATION_EDGE_BLEND_TAB_CURVE_QUADRATIC_label")]
	Quadratic
}
