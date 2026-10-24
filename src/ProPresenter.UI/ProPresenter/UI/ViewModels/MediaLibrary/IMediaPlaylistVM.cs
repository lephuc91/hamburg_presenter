using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Common.Time;
using Pro.DO.Triggering;
using Pro.UI.Components;
using Pro.ssAPI;
using ProPresenter.DO.Cues;
using ProPresenter.DO.LiveVideo;
using ProPresenter.DO.Media;
using ProPresenter.DO.Playlists;

namespace ProPresenter.UI.ViewModels.MediaLibrary;

public interface IMediaPlaylistVM : INotifyPropertyChanged
{
	IVisualPlaylistCollection Playlists { get; }

	IPlaylist<MediaCue>? ActivePlaylist { get; set; }

	IPlaylist<MediaCue>? SelectedPlaylist { get; set; }

	ObservableCollection<IPlaylist<MediaCue>> SelectedPlaylists { get; }

	IMediaCueThumbnailVM? SelectedPlaylistItem { get; set; }

	ObservableCollection<IMediaCueThumbnailVM> SelectedPlaylistItems { get; }

	IEnumerable<MediaCue> SelectedMediaCues { get; }

	IMediaCueThumbnailVM? ActiveMediaItem { get; }

	IEnumerable<IMediaCueThumbnailVM> ActiveMediaItems { get; }

	ILiveVideoInputCollection AvailableVideoInputs { get; }

	bool HasAvailableVideoInputs { get; }

	string SearchText { get; set; }

	IEnumerable<MediaCue> AvailableCompletionCues { get; }

	ImportLayer HotFolderBehavior { get; }

	CompletionTargetType CueCompletionTargetType { get; }

	Guid CueCompletionTargetCueID { get; }

	PlaybackBehaviorType CuePlaybackBehavior { get; }

	TimeSlice SoftLoopTargetTime { get; }

	bool ShouldSetNewPlaylistActive { get; set; }

	INotifyEnumerableChanged<IMediaCueThumbnailVM> MediaCues { get; }

	ICommand ShowInFileExplorerCommand { get; }

	ICommand<TriggerLayer> SetMediaTargetLayerCommand { get; }

	ICommand<ScaleBehavior> SetMediaScaleBehaviorCommand { get; }

	ICommand<PlaybackBehaviorType> SetPlaybackCommand { get; }

	ICommand<TimeSlice?> SetSoftLoopDurationCommand { get; }

	ICommand<EndBehaviorType> SetEndBehaviorTypeCommand { get; }

	ICommand<ImportLayer> SetHotFolderBehaviorCommand { get; }

	ICommand<CompletionTargetType> SetCompletionTargetCommand { get; }

	ICommand<MediaCue> SetCompletionCueCommand { get; }

	ICommand<LiveVideoInput> AddLiveVideoMediaCommand { get; }

	ICommand DeletePlaylistCommand { get; }

	ICommand DuplicatePlaylistCommand { get; }

	ICommand<AlphaType> SetAlphaTypeCommand { get; }

	void ResetSelectedItems(IEnumerable<MediaCue> pastedItems);
}
