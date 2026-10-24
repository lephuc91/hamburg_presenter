using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Pro.Common.Collections;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;

namespace ProPresenter.UI.ViewModels;

public interface IPlaylistVM<T, C> : INotifyPropertyChanged where T : ProPresenterCue where C : ImmutableObservableCollection<IPlaylist<T>>
{
	C Playlists { get; }

	IPlaylist<T>? SelectedPlaylist { get; set; }

	ObservableCollection<IPlaylist<T>> SelectedPlaylists { get; }

	T? SelectedPlaylistItem { get; set; }

	ObservableCollection<T> SelectedPlaylistItems { get; }

	ICommand DeletePlaylistCommand { get; }

	ICommand DuplicatePlaylistCommand { get; }
}
