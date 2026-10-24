using Pro.Localization;

namespace ProPresenter.DO.Media;

public enum AlphaType
{
	Unknown,
	[LocalizedString("CUE_INSPECTOR_PROPERTIES_TAB_ALPHA_TYPE_STRAIGHT_label")]
	Straight,
	[LocalizedString("CUE_INSPECTOR_PROPERTIES_TAB_ALPHA_TYPE_PREMULTIPLIED_label")]
	Premultiplied
}
