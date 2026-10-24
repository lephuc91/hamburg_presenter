using System;
using System.ComponentModel;
using System.Windows.Input;
using Pro.DO.Transitions;
using Pro.UI.Components;
using ProPresenter.Controller.Outputs;
using ProPresenter.DO;
using ProPresenter.DO.Cues;
using ProPresenter.DO.LiveVideo;
using ProPresenter.DO.Playlists;
using ProPresenter.UI.MediaLibrary;
using ProPresenter.UI.ProContent;
using ProPresenter.UI.ViewModels.ProContent;

namespace ProPresenter.UI.ViewModels.MediaLibrary;

public interface IMediaLibraryVM : INotifyPropertyChanged
{
	IMediaPlaylistVM PlaylistVM { get; }

	IProContentVM ProContentVM { get; }

	IMediaBinHeaderNavigatorVM HeaderNavigatorVM { get; }

	ssAPIOutput OutputController { get; }

	MediaCue? SelectedMediaCue { get; }

	TransitionParameters? SelectedMediaCueTransition { get; set; }

	TransitionParameters? SelectedTransition { get; set; }

	TransitionHandler? TransitionHandler { get; }

	int RowCapacity { get; set; }

	PanelViewType ViewType { get; set; }

	bool RenameNextItem { get; set; }

	ICommand CopyCommand { get; }

	ICommand CutCommand { get; }

	ICommand PasteCommand { get; }

	ICommand DuplicateCommand { get; }

	ICommand DeleteCommand { get; }

	ICommand NewGroupFolderCommand { get; }

	ICommand NewHotFolderCommand { get; }

	ICommand NewPlaylistCommand { get; }

	ICommand<ImportMediaCommandParameters> AddFilesCommand { get; }

	ICommand AddNewMediaCommand { get; }

	ICommand ImportMediaCommand { get; }

	ICommand<SortMediaItemsCommandParameter> SortMediaItemsCommand { get; }

	ICommand<IMediaCueThumbnailVM> TriggerMediaItemCommand { get; }

	ICommand GotFocusCommand { get; }

	ICommand<TransitionParameters> SetMediaTransitionCommand { get; }

	ICommand OpenLiveVideoSetupCommand { get; }

	ICommand TriggerPreviousBackgroundCommand { get; }

	ICommand TriggerNextBackgroundCommand { get; }

	ICommand<ProContentDropParameter<VisualPlaylist?>> DropProContentAssetCommand { get; }

	event Action<LiveVideoInput?>? OpenLiveVideoSetup;

	void ActivateProContent();

	void ActivateMediaBin();
}
