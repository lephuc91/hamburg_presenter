using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Mathematics;
using Pro.Localization;
using Pro.UI.Components;
using Pro.UI.Utility;
using ProPresenter.DO;
using ProPresenter.DO.Chords;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Import;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.MultiTracks;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Themes;
using ProPresenter.UI.Import;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels;

public class MultiTracksImportDialogVM : LinkedNotifyPropertyChangedBase, IMultiTracksImportDialogVM, ISizeableTarget, INotifyPropertyChanged
{
	private Lazy<MultiTracksImportWindow> _importWindow;

	private ILibrary? _selectedLibrary;

	private IPlaylist<ProPresenterCue>? _selectedPlaylist;

	private string? _presentationName;

	private readonly IApp _app;

	public bool WasImported { get; private set; }

	public IPresentationVM PresentationVM { get; set; }

	public DocumentOptions? SelectedDocument { get; set; }

	public ObservableCollection<DocumentOptions>? Documents { get; set; }

	public ObservableCollection<DocumentOptions>? SelectedDocuments { get; set; }

	public ObservableCollection<int> Notes { get; set; }

	public Note? SelectedNote { get; set; }

	public Scale? SelectedScale { get; set; }

	public bool IsAutomationAndChordsEnabled { get; set; }

	public bool IsAutomationAndChords { get; set; } = true;

	public bool IsMultipleDocuments { get; set; }

	public BreakMode BreakMode { get; set; }

	public string CustomDelimiter { get; set; }

	public int LinesPerSlide { get; set; } = 2;

	public TemplateSlide? SelectedTemplate { get; set; }

	public bool IsPresentationNameValid => !(SelectedLibrary?.DoesPresentationExist(PresentationName) ?? false);

	public string? PresentationName
	{
		get
		{
			return _presentationName;
		}
		set
		{
			SetValue("PresentationName", ref _presentationName, value, null, false, "IsPresentationNameValid");
		}
	}

	public ICommand ImportSingleDocumentCommand { get; set; }

	public ICommand AbortImportCommand { get; set; }

	public ICommand<IPlaylist<ProPresenterCue>> SelectPlaylistCommand => new RelayCommand<IPlaylist<ProPresenterCue>>(delegate(IPlaylist<ProPresenterCue> t)
	{
		SelectedPlaylist = t;
	});

	public ICommand<TemplateSlide> SelectTemplateCommand => new RelayCommand<TemplateSlide>(delegate(TemplateSlide t)
	{
		SelectedTemplate = t;
		OnPropertyChanged("SelectedTemplate");
	});

	public ICommand<ILibrary> SelectLibraryCommand => new RelayCommand<ILibrary>(delegate(ILibrary t)
	{
		SelectedLibrary = t;
	});

	public ThemeCollection Themes => DataVault.Themes;

	public Vector2<double> Size { get; set; } = Vector2<double>.Zero;

	public IEnumerable<IPlaylist<ProPresenterCue>> Playlists => DataVault.LibraryPlaylistCollection.GetPlaylists((IPlaylist<ProPresenterCue> p) => p.Type.IsAnyOf(PlaylistType.Custom, PlaylistType.Group));

	public ILibrary? SelectedLibrary
	{
		get
		{
			return _selectedLibrary;
		}
		set
		{
			SetValue("SelectedLibrary", ref _selectedLibrary, value, null, false, "IsPresentationNameValid");
		}
	}

	public IPlaylist<ProPresenterCue>? SelectedPlaylist
	{
		get
		{
			return _selectedPlaylist;
		}
		set
		{
			SetValue("SelectedPlaylist", ref _selectedPlaylist, value);
		}
	}

	private static LibraryCollection Libraries => DataVault.LibraryCollection;

	public MultiTracksImportDialogVM(IPresentationVM presentationVM, IApp app)
	{
		_app = app;
		HydrateProperties(presentationVM);
		LoadSettings();
		SetupCommands();
	}

	[MemberNotNull("PresentationVM")]
	[MemberNotNull("Notes")]
	[MemberNotNull("_importWindow")]
	private void HydrateProperties(IPresentationVM presentationVM)
	{
		PresentationVM = presentationVM;
		Notes = new ObservableCollection<int>();
		_importWindow = new Lazy<MultiTracksImportWindow>(() => new MultiTracksImportWindow().WithDataContext(this));
	}

	[MemberNotNull("ImportSingleDocumentCommand")]
	[MemberNotNull("AbortImportCommand")]
	private void SetupCommands()
	{
		ImportSingleDocumentCommand = new RelayCommand(ImportSingleDocumentsExecuted, CanExecuteSingleImportDocuments);
		AbortImportCommand = new RelayCommand(AbortImportExecuted);
	}

	[MemberNotNull("CustomDelimiter")]
	private void LoadSettings()
	{
		SelectedLibrary = Libraries.FirstOrDefault();
		BreakMode = _app.BreakMode;
		CustomDelimiter = ((!string.IsNullOrEmpty(_app.CustomDelimiter)) ? _app.CustomDelimiter : LocalizedStrings.Get(BreakMode));
		SelectedTemplate = Themes.FindTemplate(_app.SelectedImportTemplateID);
		Libraries.CollectionChanged += delegate
		{
			if (Libraries.Any() && (SelectedLibrary == null || !Libraries.Contains(SelectedLibrary)))
			{
				SelectedLibrary = Libraries.First();
			}
		};
	}

	private void AbortImportExecuted()
	{
		_importWindow?.Value.Close();
	}

	private bool CanExecuteSingleImportDocuments()
	{
		if (SelectedTemplate != null)
		{
			return Size != Vector2<double>.Zero;
		}
		return false;
	}

	private void ImportSingleDocumentsExecuted()
	{
		WasImported = true;
		_importWindow?.Value.Close();
	}

	public bool Import(MultiTracksSearchResult searchResult)
	{
		OnPropertyChanged("Playlists");
		OnPropertyChanged("Themes");
		WasImported = false;
		PresentationName = searchResult.Title;
		OnPropertyChanged("IsPresentationNameValid");
		IsAutomationAndChordsEnabled = searchResult.HasAutomation && searchResult.HasChords;
		OnPropertyChanged("IsAutomationAndChordsEnabled");
		IsAutomationAndChords = IsAutomationAndChordsEnabled;
		OnPropertyChanged("IsAutomationAndChords");
		SelectedNote = searchResult.OriginalKey?.Note;
		SelectedScale = searchResult.OriginalKey?.Scale;
		OnPropertyChanged("SelectedNote");
		OnPropertyChanged("SelectedScale");
		_importWindow?.Value.ShowDialog();
		return WasImported;
	}

	public void ChangeSize(Vector2<double> size)
	{
		SelectedDocuments?.ForEach(delegate(DocumentOptions d)
		{
			d.DocumentSize = size;
		});
		Size = size;
		OnPropertyChanged("Size");
	}
}
