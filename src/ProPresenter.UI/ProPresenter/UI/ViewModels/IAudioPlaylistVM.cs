using System.ComponentModel;
using Pro.Common.Collections;
using Pro.UI.Components;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;

namespace ProPresenter.UI.ViewModels;

public interface IAudioPlaylistVM : IPlaylistVM<MediaCue, AudioPlaylistCollection>, INotifyPropertyChanged
{
	string ItemCountLabel { get; }

	string TotalPlayLength { get; }

	string SearchText { get; set; }

	ICommand<IPlaylist<MediaCue>> SelectPlaylistCommand { get; }

	IDragDropNotifyEnumerableChanged<MediaCue>? DragDropCueSource { get; }

	INotifyEnumerableChanged<MediaCue> FilteredCues { get; }
}
