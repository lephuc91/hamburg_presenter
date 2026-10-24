using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Playlists;

namespace ProPresenter.UI.ViewModels.Import;

public interface IImportSelectionVM : INotifyPropertyChanged
{
	bool AllowPlaylistSelection { get; }

	ILibrary? Library { get; }

	IPlaylist<ProPresenterCue>? Playlist { get; }

	ILibraryCollection Libraries { get; }

	LibraryPlaylistCollection Playlists { get; }

	IRelayCommand<ILibrary> SelectLibraryCommand { get; }

	IRelayCommand<IPlaylist<ProPresenterCue>?> SelectPlaylistCommand { get; }
}
