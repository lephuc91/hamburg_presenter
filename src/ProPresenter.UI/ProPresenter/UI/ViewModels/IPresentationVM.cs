using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.DO.Label;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using Pro.UI.Components;
using ProPresenter.Controller;
using ProPresenter.Controller.Triggering;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Import;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.QuickSearch;
using ProPresenter.DO.Themes;
using ProPresenter.DO.Timer;
using ProPresenter.UI.ActionPalette;
using ProPresenter.UI.MediaLibrary;
using ProPresenter.UI.PresentationView;
using ProPresenter.UI.ProContent;
using ProPresenter.UI.Thumbnails;
using ProPresenter.UI.ViewModels.MediaLibrary;
using ProPresenter.UI.ViewModels.Props;

namespace ProPresenter.UI.ViewModels;

public interface IPresentationVM : INotifyPropertyChanged, IDisposable
{
	TransitionParameters? SelectedTransition { get; set; }

	TransitionHandler TransitionHandler { get; }

	IMediaLibraryVM MediaLibraryVM { get; }

	IActionsMenuVM TimelineActionsMenuVM { get; }

	int PresentationRowCapacity { get; set; }

	int ReflowRowCapacity { get; set; }

	double ReflowTextZoomLevel { get; set; }

	bool HideBackgroundImage { get; set; }

	IPanelViewSettings? PresentationViewSettings { get; set; }

	bool ScrollToCue { get; }

	bool ScrollToSlide { get; }

	ArrangedCue? ActiveSlide { get; }

	ActiveCueCollection ActiveSlides { get; }

	ArrangedCue? SelectedSlide { get; set; }

	ObservableCollection<ArrangedCue> SelectedSlides { get; }

	IEnumerable<ActionLabel> SlideLabels { get; }

	IEnumerable<GroupLabel> GroupLabels { get; }

	INotifyEnumerableChanged<ProPresenterCue> Items { get; }

	bool IsSecondaryTransitionVisible { get; }

	ProPresenterCue? ActiveSlideParent { get; }

	ProPresenterCue? ActivePlaylistItem { get; set; }

	bool IsContiguousViewFocused { get; }

	IPresentation? ActivePresentation { get; }

	TimerCollection Timers { get; }

	ICustomSlideMenuVM CustomSlideMenuVM { get; }

	bool ForceFlipView { get; set; }

	Action? TogglePresentationView { get; set; }

	Func<ArrangedCue?, Thumbnail?>? FindThumbnailProvider { get; set; }

	ICommand CopyCommand { get; }

	ICommand CutCommand { get; }

	ICommand PasteCommand { get; }

	ICommand DuplicateCommand { get; }

	ICommand DeleteCommand { get; }

	ICommand DeriveAndAddSlideCommand { get; }

	ICommand<TemplateSlide> AddTemplateSlideCommand { get; }

	ICommand<TemplateSlide> SelectTemplateCommand { get; }

	ICommand<ArrangedCue> TriggerSlideCommand { get; }

	ICommand TriggerNextSlideCommand { get; }

	ICommand TriggerPreviousSlideCommand { get; }

	ICommand<int> TriggerNumberCommand { get; }

	ICommand<Key> TriggerHotkeyCommand { get; }

	ICommand GoToPreviousPresentationCommand { get; }

	ICommand GoToNextPresentationCommand { get; }

	ICommand<IDragDropCommandParameters<ArrangedCue, IPresentation>> DroppedIntoCommand { get; }

	ICommand<IDragDropCommandParameters<ArrangedCue, IPresentation>> MoveToCommand { get; }

	ICommand GotFocusCommand { get; }

	ICommand<(IDocumentCue, AddMediaCueParameters)> AddMediaActionCommand { get; }

	ICommand<(IDocumentCue, MediaActionCommandParameters)> AddDroppedMediaActionCommand { get; }

	ICommand<(IDocumentCue, DropMediaFilesCommandParameters)> DropMediaFilesCommand { get; }

	ICommand<(IDocumentCue, AddMediaPlaylistParameters)> AddMediaPlaylistActionCommand { get; }

	ICommand<ProPresenterCue> ItemActivatedCommand { get; }

	ICommand<(IDocumentCue, ActionCommandParameters)> AddDroppedActionCommand { get; }

	ICommand<HeaderAction> TriggerHeaderItemCommand { get; }

	ICommand<TemplateSlide> ApplyTemplateToSelectedSlides { get; }

	ICommand<LinkCommandParameters> LinkNewPresentationCommand { get; }

	ICommand<LinkCommandParameters> LinkImportCommand { get; }

	ICommand<LinkCommandParameters> LinkDocumentCommand { get; }

	ICommand<LinkCommandParameters> LinkMediaCommand { get; }

	ICommand<LinkCommandParameters> LinkDropFilesCommand { get; }

	ICommand<LinkCommandParameters> LinkSongSelectItemCommand { get; }

	ICommand<LinkCommandParameters> LinkMultiTracksItemCommand { get; }

	ICommand<ProPresenterCue> UnlinkItemCommand { get; }

	ICommand<ProPresenterCue> OpenSearchCommand { get; }

	ICommand<IPresentation?> OpenMultiTracksWebsiteCommand { get; }

	ICommand<IPresentation?> RetryMultiTracksAuthorizationCommand { get; }

	ICommand<(IDocumentCue, ProContentDropParameter<ArrangedCue?>)> DropProContentAssetCommand { get; }

	ICommand<DropPropCommandParameter> DropPropCommand { get; }

	bool LibrariesContainPresentations { get; }

	IMultiTracksSearchService? MultiTracksSearchService { get; set; }

	event SlideTriggeredAction? SlideTriggered;

	event SlideClearedAction? SlideCleared;

	event Action<FrameworkElement?, IAction?, IActionRepository?, IEnumerable<IActionRepository>?>? ShowActionDialog;

	event Action<FrameworkElement?>? UpdateDialogPlacementTarget;

	event Action<UndoStack?>? StackChanged;

	void SetMediaBinShowsProContent(bool value);

	void LinkImportedFile(PlaceholderCue? placeholderCue, string? filename, IImportProcess process, PlaceholderLinkSource linkSource);
}
