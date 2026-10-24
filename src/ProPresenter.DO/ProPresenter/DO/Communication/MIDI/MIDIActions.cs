namespace ProPresenter.DO.Communication.MIDI;

public static class MIDIActions
{
	public static MIDIAction[] BlockHeaders { get; } = new MIDIAction[4]
	{
		MIDIAction.ClearAll,
		MIDIAction.GoToVideoBeginning,
		MIDIAction.NextPlaylistItem,
		MIDIAction.SelectPlaylist
	};

	public static MIDIAction[] DefaultOrder { get; } = new MIDIAction[33]
	{
		MIDIAction.ClearAll,
		MIDIAction.ClearSlide,
		MIDIAction.ClearBackground,
		MIDIAction.ClearProps,
		MIDIAction.ClearAudio,
		MIDIAction.ShowLogo,
		MIDIAction.GoToVideoBeginning,
		MIDIAction.PlayPauseVideo,
		MIDIAction.PlayVideo,
		MIDIAction.PauseVideo,
		MIDIAction.NextPlaylistItem,
		MIDIAction.PreviousPlaylistItem,
		MIDIAction.NextSlide,
		MIDIAction.PreviousSlide,
		MIDIAction.StartTimeline,
		MIDIAction.StopTimeline,
		MIDIAction.RewindTimeline,
		MIDIAction.SelectPlaylist,
		MIDIAction.SelectPlaylistItem,
		MIDIAction.TriggerSlideCue,
		MIDIAction.SelectVisualPlaylist,
		MIDIAction.TriggerVisualCue,
		MIDIAction.SelectAudioPlaylist,
		MIDIAction.TriggerAudioCue,
		MIDIAction.ToggleProps,
		MIDIAction.StartTimer,
		MIDIAction.StopTimer,
		MIDIAction.ResetTimer,
		MIDIAction.ClearMessages,
		MIDIAction.TriggerMacro,
		MIDIAction.ClearAnnouncements,
		MIDIAction.SelectMacroCollection,
		MIDIAction.SelectPropCollection
	};

	public static MIDIAction[] BlockOrder { get; } = new MIDIAction[33]
	{
		MIDIAction.ClearAll,
		MIDIAction.ClearSlide,
		MIDIAction.ClearBackground,
		MIDIAction.ClearAnnouncements,
		MIDIAction.ClearProps,
		MIDIAction.ClearMessages,
		MIDIAction.ClearAudio,
		MIDIAction.ShowLogo,
		MIDIAction.GoToVideoBeginning,
		MIDIAction.PlayPauseVideo,
		MIDIAction.PlayVideo,
		MIDIAction.PauseVideo,
		MIDIAction.NextPlaylistItem,
		MIDIAction.PreviousPlaylistItem,
		MIDIAction.NextSlide,
		MIDIAction.PreviousSlide,
		MIDIAction.StartTimeline,
		MIDIAction.StopTimeline,
		MIDIAction.RewindTimeline,
		MIDIAction.SelectPlaylist,
		MIDIAction.SelectPlaylistItem,
		MIDIAction.TriggerSlideCue,
		MIDIAction.SelectVisualPlaylist,
		MIDIAction.TriggerVisualCue,
		MIDIAction.SelectAudioPlaylist,
		MIDIAction.TriggerAudioCue,
		MIDIAction.SelectPropCollection,
		MIDIAction.ToggleProps,
		MIDIAction.SelectMacroCollection,
		MIDIAction.TriggerMacro,
		MIDIAction.StartTimer,
		MIDIAction.StopTimer,
		MIDIAction.ResetTimer
	};
}
