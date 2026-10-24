using ProPresenter.DO.Cues;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Playlists;

namespace ProPresenter.DO.Import;

public record LibraryAndPlaylist(ILibrary? Library, IPlaylist<ProPresenterCue>? Playlist);
