using Pro.Localization;

namespace Pro.DO.Triggering;

public enum AudioBehaviorType
{
	[LocalizedString("PLAYLIST_ITEM_GLOBAL_PLAYBACK_BEHAVIOR_STOP_MENU_ITEM_title")]
	Stop,
	[LocalizedString("PLAYLIST_ITEM_GLOBAL_PLAYBACK_BEHAVIOR_LOOP_MENU_ITEM_title")]
	Loop,
	[LocalizedString("PLAYLIST_ITEM_GLOBAL_CUE_COMPLETION_NEXT_MENU_ITEM_title")]
	Next
}
