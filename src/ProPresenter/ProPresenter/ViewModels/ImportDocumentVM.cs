using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Mathematics;
using Pro.Common.Nullability;
using Pro.Localization;
using Pro.UI.Components;
using Pro.UI.Utility;
using ProPresenter.DO;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Import;
using ProPresenter.DO.InputActionMap;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Themes;
using ProPresenter.UI.Import;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels;

public class ImportDocumentVM : LinkedNotifyPropertyChangedBase, IImportDocumentVM, INotifyPropertyChanged, ISizeableTarget
{
	private readonly Lazy<ImportFileWindow> _importFileWindow;

	private readonly Lazy<EditImportFileWindow> _editImportWindow;

	private readonly IApp _app;

	private DocumentOptions? _selectedDocument;

	private ImportProcess? _process;

	private Action<DocumentOptions>? _singleImport;

	private bool _abort = true;

	private bool _importRemaining;

	private BreakMode _breakMode;

	private int _linesPerSlide;

	private string _customDelimiter = string.Empty;

	private TemplateSlide? _selectedTemplate;

	private Vector2<double> _documentSize;

	private ILibrary? _selectedLibrary;

	private IPlaylist<ProPresenterCue>? _selectedPlaylist;

	private bool _didOpenEditWindow;

	public IPresentationVM PresentationVM { get; }

	public ObservableCollection<DocumentOptions> Documents { get; } = new ObservableCollection<DocumentOptions>();

	public IEnumerable<IPlaylist<ProPresenterCue>> Playlists => DataVault.LibraryPlaylistCollection.GetPlaylists((IPlaylist<ProPresenterCue> p) => p.Type.IsAnyOf(PlaylistType.Custom, PlaylistType.Group));

	public ThemeCollection Themes => DataVault.Themes;

	public ILibrary? SelectedLibrary
	{
		get
		{
			return _selectedLibrary;
		}
		set
		{
			SetValue("SelectedLibrary", ref _selectedLibrary, value);
		}
	}

	public object? SelectedPlaylist
	{
		get
		{
			return _selectedPlaylist;
		}
		set
		{
			SetValue("SelectedPlaylist", ref _selectedPlaylist, value as IPlaylist<ProPresenterCue>);
		}
	}

	public DocumentOptions? SelectedDocument
	{
		get
		{
			return _selectedDocument;
		}
		set
		{
			SetValue("SelectedDocument", ref _selectedDocument, value);
		}
	}

	public ObservableCollection<DocumentOptions> SelectedDocuments { get; } = new ObservableCollection<DocumentOptions>();

	public bool IsMultipleDocuments => Documents.Count > 1;

	public BreakMode BreakMode
	{
		get
		{
			return _breakMode;
		}
		set
		{
			SetValue("BreakMode", ref _breakMode, value, delegate(BreakMode o, BreakMode n)
			{
				SelectedDocuments.ForEach(delegate(DocumentOptions d)
				{
					d.BreakMode = n;
				});
				_app.BreakMode = n;
			});
		}
	}

	public string CustomDelimiter
	{
		get
		{
			return _customDelimiter;
		}
		set
		{
			if (string.IsNullOrEmpty(value))
			{
				return;
			}
			SetValue("CustomDelimiter", ref _customDelimiter, value, delegate(string o, string n)
			{
				SelectedDocuments.ForEach(delegate(DocumentOptions d)
				{
					d.CustomDelimiter = n;
				});
				_app.CustomDelimiter = n;
			});
		}
	}

	public int LinesPerSlide
	{
		get
		{
			return _linesPerSlide;
		}
		set
		{
			SetValue("LinesPerSlide", ref _linesPerSlide, value, delegate(int o, int n)
			{
				SelectedDocuments.ForEach(delegate(DocumentOptions d)
				{
					d.LinesPerSlide = n;
				});
				_app.LinesPerSlide = n;
			});
		}
	}

	public TemplateSlide? Template
	{
		get
		{
			return _selectedTemplate;
		}
		set
		{
			SetValue<TemplateSlide>("Template", ref _selectedTemplate, value, delegate(TemplateSlide o, TemplateSlide n)
			{
				SelectedDocuments.ForEach(delegate(DocumentOptions d)
				{
					d.Template = n;
				});
				_app.SelectedImportTemplateID = n.Slide.ID;
			});
		}
	}

	public ICommand EditDocumentCommand => new RelayCommand(OnEditDocumentCommand, () => SelectedDocument != null);

	public ICommand ImportSingleDocumentCommand => new RelayCommand(OnImportSingleDocumentCommand);

	public ICommand ImportAllDocumentCommand => new RelayCommand(OnImportAllDocumentCommand);

	public ICommand AbortImportCommand => new RelayCommand(OnAbortImportCommand);

	public ICommand<TemplateSlide> SelectTemplateCommand => new RelayCommand<TemplateSlide>(delegate(TemplateSlide t)
	{
		Template = t;
	});

	public ICommand<ILibrary> SelectLibraryCommand => new RelayCommand<ILibrary>(delegate(ILibrary t)
	{
		SelectedLibrary = t;
	});

	public ICommand<IPlaylist<ProPresenterCue>> SelectPlaylistCommand => new RelayCommand<IPlaylist<ProPresenterCue>>(delegate(IPlaylist<ProPresenterCue> t)
	{
		SelectedPlaylist = t;
	});

	public Vector2<double> Size => _documentSize;

	private ImportFileWindow ImportFileWindow => _importFileWindow.Value;

	private LibraryCollection Libraries => DataVault.LibraryCollection;

	public ImportDocumentVM(IPresentationVM presentationVM, IApp app, IInputActions inputActions)
	{
		ImportDocumentVM importDocumentVM = this;
		PresentationVM = presentationVM;
		_app = app;
		LoadSettings();
		ImportPrompt.SetHandleOptions(OnImportText);
		DataVault.LibraryPlaylistCollection.CollectionModified += delegate
		{
			importDocumentVM.OnPropertyChanged("Playlists");
		};
		_importFileWindow = new Lazy<ImportFileWindow>(() => new ImportFileWindow().WithDataContext(importDocumentVM));
		_editImportWindow = new Lazy<EditImportFileWindow>(() => new EditImportFileWindow(importDocumentVM.PresentationVM, inputActions));
	}

	private void LoadSettings()
	{
		_selectedLibrary = Libraries.FirstOrDefault();
		_breakMode = _app.BreakMode;
		_linesPerSlide = _app.LinesPerSlide;
		_customDelimiter = ((!string.IsNullOrEmpty(_app.CustomDelimiter)) ? _app.CustomDelimiter : LocalizedStrings.Get(_breakMode));
		_selectedTemplate = Themes.FindTemplate(_app.SelectedImportTemplateID);
		Libraries.CollectionChanged += delegate
		{
			if (Libraries.Any() && (SelectedLibrary == null || !Libraries.Contains(SelectedLibrary)))
			{
				SelectedLibrary = Libraries.First();
			}
		};
	}

	private void OnImportText(ImportProcess process, DocumentOptions[] options, Action<DocumentOptions> singleImport, out bool importRemaining, out bool abort)
	{
		_process = process;
		foreach (DocumentOptions obj in options)
		{
			obj.BreakMode = BreakMode;
			obj.CustomDelimiter = CustomDelimiter;
			obj.LinesPerSlide = LinesPerSlide;
			obj.Template = Template;
			obj.DocumentSize = Size;
		}
		importRemaining = false;
		abort = false;
		_singleImport = singleImport;
		Documents.Clear();
		SelectedDocuments.Clear();
		Documents.AddRange(options);
		SelectedDocuments.AddRange(Documents);
		SelectedDocument = Documents.FirstOrDefault();
		OnPropertyChanged("IsMultipleDocuments");
		ImportFileWindow.ShowDialog();
		Documents.ForEach(delegate(DocumentOptions d)
		{
			d.InvalidateDocument();
		});
		importRemaining = _importRemaining;
		abort = _abort;
	}

	private void OnEditDocumentCommand()
	{
		_didOpenEditWindow = true;
		EditImportFileWindow value = _editImportWindow.Value;
		value.DocumentOptions = SelectedDocument;
		value.SetBinding(EditImportFileWindow.SelectedSlidesProperty, new Binding("SelectedSlides")
		{
			Source = PresentationVM
		});
		value.SetBinding(EditImportFileWindow.ReflowRowCapacityProperty, new Binding("ReflowRowCapacity")
		{
			Source = _app
		});
		value.SetBinding(EditImportFileWindow.ReflowTextZoomLevelProperty, new Binding("ReflowTextZoomLevel")
		{
			Source = _app
		});
		value.ImportDocument = false;
		value.ShowDialog();
		if (value.ImportDocument)
		{
			OnImportSingleDocumentCommand();
		}
		value.DocumentOptions = null;
	}

	private void OnImportSingleDocumentCommand()
	{
		FinalizeProcess();
		PublishSongSelectEvents();
		SelectedDocument.ThrowWhenNull("SelectedDocument");
		_singleImport?.Invoke(SelectedDocument);
		Documents.Remove(SelectedDocument);
		if (!Documents.Any())
		{
			_abort = false;
			ImportFileWindow.Close();
		}
	}

	private void OnImportAllDocumentCommand()
	{
		FinalizeProcess();
		PublishSongSelectEvents();
		_importRemaining = true;
		_abort = false;
		_didOpenEditWindow = false;
		ImportFileWindow.Close();
	}

	private void PublishSongSelectEvents()
	{
		_process.ThrowWhenNull("_process");
		foreach (IImportRequest item in _process.Requests.Where((IImportRequest r) => r.Source == ImportSource.SongSelect))
		{
			_ = item;
			SongSelectImportEvent.Publish(_didOpenEditWindow, SelectedPlaylist != null, BreakMode.ToLineDelimiter(), LinesPerSlide, Template?.Slide.Elements.Count((SlideElementBase e) => e.IsTextElement()) ?? 0);
		}
	}

	private void FinalizeProcess()
	{
		_process.ThrowWhenNull("_process");
		_process.SelectedLibrary = SelectedLibrary;
		_process.SelectedPlaylist = _selectedPlaylist;
	}

	private void OnAbortImportCommand()
	{
		_abort = true;
		ImportFileWindow.Close();
	}

	public void ChangeSize(Vector2<double> size)
	{
		SelectedDocuments.ForEach(delegate(DocumentOptions d)
		{
			d.DocumentSize = size;
		});
		_documentSize = size;
		OnPropertyChanged("Size");
	}
}
