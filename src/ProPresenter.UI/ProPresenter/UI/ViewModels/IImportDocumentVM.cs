using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Pro.UI.Components;
using ProPresenter.DO;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Import;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Themes;

namespace ProPresenter.UI.ViewModels;

public interface IImportDocumentVM : INotifyPropertyChanged, ISizeableTarget
{
	IPresentationVM PresentationVM { get; }

	DocumentOptions? SelectedDocument { get; set; }

	ObservableCollection<DocumentOptions> Documents { get; }

	ObservableCollection<DocumentOptions> SelectedDocuments { get; }

	bool IsMultipleDocuments { get; }

	BreakMode BreakMode { get; set; }

	string CustomDelimiter { get; set; }

	int LinesPerSlide { get; set; }

	TemplateSlide? Template { get; set; }

	ICommand EditDocumentCommand { get; }

	ICommand ImportSingleDocumentCommand { get; }

	ICommand ImportAllDocumentCommand { get; }

	ICommand AbortImportCommand { get; }

	ICommand<ILibrary> SelectLibraryCommand { get; }

	ICommand<IPlaylist<ProPresenterCue>> SelectPlaylistCommand { get; }

	ICommand<TemplateSlide> SelectTemplateCommand { get; }
}
