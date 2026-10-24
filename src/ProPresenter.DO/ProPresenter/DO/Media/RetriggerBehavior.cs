using Pro.Localization;

namespace ProPresenter.DO.Media;

public enum RetriggerBehavior
{
	Unset,
	[LocalizedString("CUE_INSPECTOR_PROPERTIES_TAB_RETRIGGER_BEHAVIOR_ALWAYS_label")]
	Always,
	[LocalizedString("CUE_INSPECTOR_PROPERTIES_TAB_RETRIGGER_BEHAVIOR_NEVER_label")]
	Never,
	[LocalizedString("CUE_INSPECTOR_PROPERTIES_TAB_RETRIGGER_BEHAVIOR_AUTOMATIC_label")]
	Automatic
}
