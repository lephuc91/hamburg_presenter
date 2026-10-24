using ProPresenter.DO.Cues;
using ProPresenter.DO.Macros;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Props;
using ProPresenter.DO.Timer;

namespace ProPresenter.DO.Communication.MIDI;

public interface IMIDIExecutor
{
	void ClearAll();

	void ClearSlide();

	void ClearBackground();

	void ClearAnnouncements();

	void ClearProps();

	void ClearMessages();

	void ClearAudio();

	void TriggerLogo();

	void RestartBackgroundVideo();

	void ToggleVideo();

	void PlayVideo();

	void PauseVideo();

	void GoToNextPlaylistItem();

	void GoToPreviousPlaylistItem();

	void TriggerNextSlide();

	void TriggerPreviousSlide();

	void StartTimeline();

	void PauseTimeline();

	void ResetTimeline();

	void SelectPlaylist(Playlist<ProPresenterCue>? playlist);

	void SelectPlaylistItem(int index);

	void TriggerSlide(int index);

	void SelectVisualPlaylist(VisualPlaylist? visualPlaylist);

	void TriggerVisualCue(int index);

	void SelectAudioPlaylist(AudioPlaylist? audioPlaylist);

	void TriggerAudioCue(int index);

	void ToggleProp(IPropCue prop);

	void StartTimer(TimerData timer);

	void StopTimer(TimerData timer);

	void ResetTimer(TimerData timer);

	void TriggerMacro(ProPresenterMacro macro);

	void SelectMacroGroup(int index);

	void SelectPropGroup(int index);
}
