using Pro.Localization;

namespace Pro.ssAPI;

public enum PlaybackBehaviorType
{
	[LocalizedString("CUE_INSPECTOR_PROPERTIES_TAB_PLAYBACK_BEHAVIOR_STOP_label")]
	Stop,
	[LocalizedString("CUE_INSPECTOR_PROPERTIES_TAB_PLAYBACK_BEHAVIOR_LOOP_label")]
	Loop,
	[LocalizedString("CUE_INSPECTOR_PROPERTIES_TAB_PLAYBACK_BEHAVIOR_LOOP_FOR_PLAY_COUNT_label")]
	LoopForCount,
	[LocalizedString("CUE_INSPECTOR_PROPERTIES_TAB_PLAYBACK_BEHAVIOR_LOOP_FOR_TIME_label")]
	LoopForTime
}
