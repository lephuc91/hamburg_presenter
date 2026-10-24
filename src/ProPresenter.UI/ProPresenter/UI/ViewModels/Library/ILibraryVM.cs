using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Pro.Common.Components;
using Pro.Common.Utility;
using Pro.UI.Components;
using ProPresenter.DO;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.PCO;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Themes;
using ProPresenter.UI.LibraryView;
using ProPresenter.UI.PresentationLibrary;
using ProPresenter.UI.ProContent;
using ProPresenter.UI.ViewModels.Library.Cue;

namespace ProPresenter.UI.ViewModels.Library;

public interface ILibraryVM : ISizeableTarget, INotifyPropertyChanged
{
	ILibraryCollection Libraries { get; }

	LibraryPlaylistCollection Playlists { get; }

	ILibrary? ActiveLibrary { get; set; }

	ObservableCollection<ILibrary> SelectedLibraries { get; }

	IPlaylist<ProPresenterCue>? ActivePlaylist { get; set; }

	ObservableCollection<IPlaylist<ProPresenterCue>> SelectedPlaylists { get; }

	bool MultiplePlaylistsSelected { get; }

	bool OnlyPCOPlaylistSelected { get; }

	bool ShowPCOPlaylistAddMenu { get; }

	bool ShowAddToPlaylistsOnly { get; }

	bool ShowMoveTo { get; }

	string ActiveItemName { get; set; }

	ICollectionView CueCollectionView { get; }

	ICollectionView HiddenCueCollectionView { get; }

	string ItemsCountText { get; }

	string FilterText { get; set; }

	IProPresenterCueVM? ActiveCue { get; set; }

	IProPresenterCueVM? SelectedCue { get; set; }

	bool UseContextMenuReflowTarget { get; set; }

	IProPresenterCueVM? ReflowTargetCue { get; set; }

	ObservableCollection<IProPresenterCueVM> SelectedCues { get; }

	IEnumerable<MediaCue> SelectedMedia { get; }

	IPCOConsumer PCOConsumer { get; }

	bool RenameNextItem { get; set; }

	INewPresentationVM NewPresentationVM { get; }

	IPlaylistTemplateCollectionVM PlaylistTemplatesVM { get; }

	ICommand<DropFilesCommandParameters> DropFilesCommand { get; }

	ICommand<DropFilesCommandParameters> DropPlaylistFilesCommand { get; }

	ICommand<(IEnumerable<IDocumentCueVM>, int, bool)> DropPresentationsCommand { get; }

	ICommand NewLibraryCommand { get; }

	ICommand DeleteLibraryCommand { get; }

	ICommand DeletePlaylistCommand { get; }

	ICommand DuplicatePlaylistCommand { get; }

	ICommand NewGroupFolderCommand { get; }

	ICommand NewHeaderCommand { get; }

	ICommand NewPlaceholderCommand { get; }

	ICommand NewPlaylistCommand { get; }

	ICommand<GeneralPlaylist> AddPlaylistFromTemplateCommand { get; }

	ICommand<IPlaylist<ProPresenterCue>> ExportPlaylistCommand { get; }

	ICommand ExportToTextCommand { get; }

	ICommand ExportToPro7Command { get; }

	ICommand ExportToBundleCommand { get; }

	ICommand CopyCuesCommand { get; }

	ICommand PasteCuesCommand { get; }

	ICommand DuplicateCuesCommand { get; }

	ICommand DeleteCuesCommand { get; }

	ICommand DuplicateActivePlaylistCommand { get; }

	ICommand DeleteActivePlaylistCommand { get; }

	ICommand DeleteActiveLibraryCommand { get; }

	ICommand<ILibrary> SelectLibraryCommand { get; }

	ICommand<IProPresenterCueVM> ShowInLibraryCommand { get; }

	ICommand<IPlaylist<ProPresenterCue>> SelectPlaylistCommand { get; }

	ICommand<ILibrary> AddToLibraryCommand { get; }

	ICommand<Playlist<ProPresenterCue>?> AddToPlaylistCommand { get; }

	ICommand<TemplateSlide> SelectTemplateCommand { get; }

	ICommand<Arrangement> SelectArrangementCommand { get; }

	ICommand<MediaCue> TriggerMediaItemCommand { get; }

	ICommand ConvertPCOPlaylistCommand { get; }

	ICommand RefreshPCOPlaylistCommand { get; }

	ICommand<IProPresenterCueVM> PCOUploadCommand { get; }

	ICommand ShowTriggeredPresentationCommand { get; }

	ICommand ShowTriggeredAnnouncementCommand { get; }

	ICommand RevealInLibraryCommand { get; }

	ICommand<DependencyObject> GotFocusCommand { get; }

	ICommand<bool> LibraryNavigationCrestedCommand { get; }

	ICommand<bool> PlaylistNavigationCrestedCommand { get; }

	ICommand<ColorPair> ColorChangeFinishedCommand { get; }

	ICommand<IProPresenterCueVM> UnlinkItemCommand { get; }

	ICommand<IProPresenterCueVM> HideItemCommand { get; }

	ICommand<IProPresenterCueVM> ShowItemCommand { get; }

	ICommand UnhideAllItemsCommand { get; }

	ICommand<OutputDestination> ChangeOutputDestinationCommand { get; }

	ICommand<ProContentDropParameter<GeneralPlaylist?>> DropProContentAssetCommand { get; }

	ICommand RelinkCommand { get; }

	IDragDropCollection<IProPresenterCueVM>? DropTarget { get; }

	event Action<NewPresentationEventArgs> NewPresentationCreated;

	void AddToActivePlaylist(IEnumerable<ProPresenterCue> cues);
}
