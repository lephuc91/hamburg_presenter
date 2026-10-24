using System.Collections.Generic;
using System.Linq;
using ProPresenter.DO.Cues;
using ProPresenter.DO.MacroGroups;
using ProPresenter.DO.Macros;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Props;
using ProPresenter.DO.Timer;

namespace ProPresenter.DO.Communication.MIDI;

public class MIDIDataProvider : IMIDIDataProvider
{
	private readonly IEnumerable<IPlaylist<ProPresenterCue>> _libraryPlaylistCollection;

	private readonly IEnumerable<IPlaylist<MediaCue>> _visualPlaylistCollection;

	private readonly IEnumerable<IPlaylist<MediaCue>> _audioPlaylistCollection;

	private readonly TimerDocument _timerDocument;

	private readonly IMacroSource _macroSource;

	private readonly IPropSource _propSource;

	public MIDIDataProvider()
		: this(DataVault.LibraryPlaylistCollection, DataVault.VisualPlaylistCollection, DataVault.AudioPlaylistCollection, DataVault.TimerDocument, DataVault.MacroSource, DataVault.PropSource)
	{
	}

	public MIDIDataProvider(IEnumerable<IPlaylist<ProPresenterCue>> libraryPlaylistCollection, IEnumerable<IPlaylist<MediaCue>> visualPlaylistCollection, IEnumerable<IPlaylist<MediaCue>> audioPlaylistCollection, TimerDocument timerDocument, IMacroSource macroSource, IPropSource propSource)
	{
		_libraryPlaylistCollection = libraryPlaylistCollection;
		_visualPlaylistCollection = visualPlaylistCollection;
		_audioPlaylistCollection = audioPlaylistCollection;
		_timerDocument = timerDocument;
		_macroSource = macroSource;
		_propSource = propSource;
	}

	public Playlist<ProPresenterCue>? GetPlaylist(int index)
	{
		return _libraryPlaylistCollection.ElementAtOrDefault(index) as Playlist<ProPresenterCue>;
	}

	public VisualPlaylist? GetVisualPlaylist(int index)
	{
		return _visualPlaylistCollection.ElementAtOrDefault(index) as VisualPlaylist;
	}

	public AudioPlaylist? GetAudioPlaylist(int index)
	{
		return _audioPlaylistCollection.ElementAtOrDefault(index) as AudioPlaylist;
	}

	public IPropCue? GetProp(int index)
	{
		return (_propSource.ActiveCollection ?? _propSource.FlatCollection).ElementAtOrDefault(index);
	}

	public TimerData? GetTimer(int index)
	{
		return _timerDocument.Timers.ElementAtOrDefault(index);
	}

	public ProPresenterMacro? GetMacro(int index)
	{
		return (_macroSource.ActiveCollection ?? _macroSource.FlatCollection)?.ElementAtOrDefault(index);
	}
}
