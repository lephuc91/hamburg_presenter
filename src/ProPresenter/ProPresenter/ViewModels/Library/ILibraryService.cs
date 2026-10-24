using ProPresenter.DO.Cues;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.PCO;
using ProPresenter.DO.Playlists;
using ProPresenter.UI.Calendar;

namespace ProPresenter.ViewModels.Library;

public interface ILibraryService
{
	LibraryCollection Libraries { get; }

	LibraryPlaylistCollection Playlists { get; }

	ICalendarService Calendar { get; }

	IExportService Export { get; }

	IMatchSongsInteractor MatchSongsInteractor { get; }

	Playlist<ProPresenterCue>? ActivePlaylist { get; set; }

	ILibrary? ActiveLibrary { get; }
}
