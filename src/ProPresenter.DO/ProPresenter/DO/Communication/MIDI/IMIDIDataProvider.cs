using ProPresenter.DO.Cues;
using ProPresenter.DO.Macros;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Props;
using ProPresenter.DO.Timer;

namespace ProPresenter.DO.Communication.MIDI;

public interface IMIDIDataProvider
{
	Playlist<ProPresenterCue>? GetPlaylist(int index);

	VisualPlaylist? GetVisualPlaylist(int index);

	AudioPlaylist? GetAudioPlaylist(int index);

	IPropCue? GetProp(int index);

	TimerData? GetTimer(int index);

	ProPresenterMacro? GetMacro(int index);
}
