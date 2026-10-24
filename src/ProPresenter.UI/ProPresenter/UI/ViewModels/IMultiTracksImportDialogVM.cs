using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Pro.UI.Components;
using ProPresenter.DO;
using ProPresenter.DO.Chords;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Import;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.MultiTracks;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Themes;

namespace ProPresenter.UI.ViewModels;

public interface IMultiTracksImportDialogVM : ISizeableTarget, INotifyPropertyChanged
{
	bool WasImported { get; }

	IPresentationVM PresentationVM { get; }

	DocumentOptions? SelectedDocument { get; set; }

	ILibrary? SelectedLibrary { get; }

	IPlaylist<ProPresenterCue>? SelectedPlaylist { get; }

	ObservableCollection<DocumentOptions>? Documents { get; }

	ObservableCollection<DocumentOptions>? SelectedDocuments { get; }

	string? PresentationName { get; set; }

	bool IsPresentationNameValid { get; }

	bool IsMultipleDocuments { get; }

	bool IsAutomationAndChordsEnabled { get; }

	bool IsAutomationAndChords { get; }

	BreakMode BreakMode { get; set; }

	Note? SelectedNote { get; set; }

	Scale? SelectedScale { get; }

	string CustomDelimiter { get; }

	int LinesPerSlide { get; set; }

	TemplateSlide? SelectedTemplate { get; set; }

	ICommand ImportSingleDocumentCommand { get; }

	ICommand AbortImportCommand { get; }

	ICommand<ILibrary> SelectLibraryCommand { get; }

	ICommand<IPlaylist<ProPresenterCue>> SelectPlaylistCommand { get; }

	ICommand<TemplateSlide> SelectTemplateCommand { get; }

	ThemeCollection Themes { get; }

	IEnumerable<IPlaylist<ProPresenterCue>> Playlists { get; }

	bool Import(MultiTracksSearchResult searchResult);
}
