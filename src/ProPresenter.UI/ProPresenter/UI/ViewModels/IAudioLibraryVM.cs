using System.ComponentModel;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Common.Time;
using Pro.DO.Triggering;
using Pro.UI.Components;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Media;
using ProPresenter.UI.AudioLibrary;

namespace ProPresenter.UI.ViewModels;

public interface IAudioLibraryVM : INotifyPropertyChanged
{
	IAudioPlaylistVM PlaylistVM { get; }

	MediaCue? ActiveAudioItem { get; }

	ObservableDictionary<MediaCue, bool> ActiveAudioItems { get; }

	AudioBehaviorType SelectedAudioBehaviorType { get; }

	AudioSortType SortType { get; set; }

	TimeSlice TransitionDuration { get; set; }

	bool IsShuffle { get; set; }

	bool IsPlaying { get; }

	bool RenameNextItem { get; set; }

	ICommand NewPlaylistCommand { get; }

	ICommand NewGroupFolderCommand { get; }

	ICommand AddAudioItemCommand { get; }

	ICommand<AudioType> SetAudioTypeCommand { get; }

	ICommand RemoveSelectedPlaylistItemsCommand { get; }

	ICommand GotFocusCommand { get; }

	ICommand ShowInFileExplorerCommand { get; }

	ICommand<DropAudioFilesCommandParameter> DropAudioFilesCommand { get; }

	ICommand<MediaCue> TriggerMediaItemCommand { get; }

	ICommand<AudioSortType> SortAudioItemsCommand { get; }

	ICommand<AudioBehaviorType> UpdateAudioBehaviorCommand { get; }
}
