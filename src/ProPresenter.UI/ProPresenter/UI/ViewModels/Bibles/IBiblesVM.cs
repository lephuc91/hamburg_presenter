using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Collections;
using Pro.DO.Transitions;
using Pro.UI.Components;
using ProPresenter.Controller.Triggering;
using ProPresenter.DO;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Bibles;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Themes;
using ProPresenter.UI.Bibles;

namespace ProPresenter.UI.ViewModels.Bibles;

public interface IBiblesVM : INotifyPropertyChanged
{
	LoadedBibleCollection LoadedBibles { get; }

	INotifyEnumerableChanged<IGrouping<string, AvailableBibleBase>> AvailablePurchasedBibles { get; }

	INotifyEnumerableChanged<IGrouping<string, AvailableBibleBase>> AvailableFreeBibles { get; }

	bool IsRegistered { get; }

	bool AnyBibleLoaded { get; }

	ILibrary? SelectedImportLibrary { get; set; }

	TransitionParameters? SelectedTransition { get; set; }

	TransitionHandler TransitionHandler { get; }

	BibleTranslationCollection? Translations { get; }

	BibleBase? ActiveBible { get; }

	BibleTranslation[] SearchableBibles { get; }

	BibleTranslation? SearchTargetBible { get; set; }

	ObservableCollection<ArrangedCue> SelectedItems { get; }

	BiblePresentation WorkingPresentation { get; }

	string ReferenceText { get; set; }

	bool SearchInProgress { get; }

	ObservableCollection<SearchResult> SearchResults { get; }

	bool AnySearchResults { get; }

	int PanelRowCapacity { get; set; }

	bool ShowVerseNumbers { get; set; }

	bool BreakOnNewVerse { get; set; }

	bool DisplayTranslation { get; set; }

	bool PreserveFontColor { get; set; }

	ReferenceType ReferenceType { get; set; }

	IPanelViewSettings BiblePresentationViewSettings { get; set; }

	INotifyEnumerableChanged<ProPresenterCue> Items { get; }

	DocumentCue BibleDocumentCue { get; }

	ArrangedCue? ActiveSlide { get; }

	bool ScrollToSlide { get; }

	ActiveCueCollection ActiveSlides { get; }

	IEnumerable<IPlaylist<ProPresenterCue>> Playlists { get; }

	bool IsGeneratingSlides { get; }

	bool IsSlidesCancelled { get; }

	double SlidesProgress { get; }

	bool IsRefreshingBibles { get; }

	bool ScrollToTop { get; }

	ICommand CancelGenerateSlidesCommand { get; }

	ICommand<TemplateSlide> SelectTemplateCommand { get; }

	ICommand SaveAsDocumentCommand { get; }

	ICommand CopyToCurrentDocumentCommand { get; }

	ICommand<Playlist<ProPresenterCue>> SaveToSelectedPlaylistCommand { get; }

	ICommand GoToNextVerseCommand { get; }

	ICommand GoToPreviousVerseCommand { get; }

	ICommand CopyCommand { get; }

	IAsyncRelayCommand<string> SearchKeywordCommand { get; }

	ICommand<SelectBibleReferenceCommandParameter> SelectBookCommand { get; }

	ICommand<SelectBibleReferenceCommandParameter> SelectChapterCommand { get; }

	ICommand<SelectBibleReferenceCommandParameter> SelectVerseCommand { get; }

	ICommand<string> UpdateReferenceTextCommand { get; }

	ICommand<SearchResult> SelectSearchChapterCommand { get; }

	ICommand<SearchResult> SelectSearchVerseCommand { get; }

	ICommand AddBibleTranslationCommand { get; }

	ICommand<BibleTranslation> RemoveBibleTranslationCommand { get; }

	ICommand<BibleTranslation> SetTargetSearchBibleCommand { get; }

	ICommand<ArrangedCue> TriggerSlideCommand { get; }

	ICommand TriggerPreviousSlideCommand { get; }

	ICommand TriggerNextSlideCommand { get; }

	ICommand<ILibrary> SelectLibraryCommand { get; }

	ICommand<AvailablePurchasedBible> InstallPurchasedBibleCommand { get; }

	ICommand<AvailablePurchasedBible> UninstallPurchasedBibleCommand { get; }

	ICommand<AvailableFreeBible> InstallFreeBibleCommand { get; }

	ICommand<AvailableFreeBible> UninstallFreeBibleCommand { get; }

	ICommand ShowRegistrationCommand { get; }

	ICommand GetBiblesCommand { get; }

	ICommand<(SlideElementBase, BibleTranslation)> SelectVerseElementCommand { get; }

	ICommand<(SlideElementBase, BibleTranslation)> SelectReferenceElementCommand { get; }

	ICommand<BibleTranslation> SelectIncludeReferenceWithVerseCommand { get; }

	ICommand RefreshBiblesCommand { get; }

	event Action ShowRegistration;
}
