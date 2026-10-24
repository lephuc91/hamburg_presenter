using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Mathematics;
using ProPresenter.DO;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Themes;
using ProPresenter.UI.ViewModels;
using ProPresenter.UI.ViewModels.Library;

namespace ProPresenter.ViewModels;

public class NewPresentationVM : ObservableObject, INewPresentationVM, INotifyPropertyChanged
{
	private readonly Func<bool> _trySubmit;

	private readonly ILibraryVM _libraryVM;

	private readonly IApp _app;

	[ObservableProperty]
	[NotifyCanExecuteChangedFor("SubmitCommand")]
	private string? _name;

	[ObservableProperty]
	private Vector2<double> _size = Vector2<double>.Zero;

	[ObservableProperty]
	[NotifyCanExecuteChangedFor("SubmitCommand")]
	private ILibrary? _selectedLibrary;

	[ObservableProperty]
	private TemplateSlide? _selectedTemplate;

	[ObservableProperty]
	private IPlaylist<ProPresenterCue>? _selectedPlaylist;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<ILibrary>? selectLibraryCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? submitCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<IPlaylist<ProPresenterCue>>? selectPlaylistCommand;

	public bool CanSelectPlaylist { get; set; } = true;

	public LibraryPlaylistCollection Playlists => _libraryVM.Playlists;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string? Name
	{
		get
		{
			return _name;
		}
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_name, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Name);
				_name = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Name);
				SubmitCommand.NotifyCanExecuteChanged();
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public Vector2<double> Size
	{
		get
		{
			return _size;
		}
		set
		{
			if (!EqualityComparer<Vector2<double>>.Default.Equals(_size, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Size);
				_size = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Size);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ILibrary? SelectedLibrary
	{
		get
		{
			return _selectedLibrary;
		}
		set
		{
			if (!EqualityComparer<ILibrary>.Default.Equals(_selectedLibrary, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.SelectedLibrary);
				_selectedLibrary = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.SelectedLibrary);
				SubmitCommand.NotifyCanExecuteChanged();
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public TemplateSlide? SelectedTemplate
	{
		get
		{
			return _selectedTemplate;
		}
		set
		{
			if (!EqualityComparer<TemplateSlide>.Default.Equals(_selectedTemplate, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.SelectedTemplate);
				_selectedTemplate = value;
				OnSelectedTemplateChanged(value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.SelectedTemplate);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IPlaylist<ProPresenterCue>? SelectedPlaylist
	{
		get
		{
			return _selectedPlaylist;
		}
		set
		{
			if (!EqualityComparer<IPlaylist<ProPresenterCue>>.Default.Equals(_selectedPlaylist, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.SelectedPlaylist);
				_selectedPlaylist = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.SelectedPlaylist);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<ILibrary> SelectLibraryCommand => selectLibraryCommand ?? (selectLibraryCommand = new RelayCommand<ILibrary>(SelectLibrary, CanSelectLibrary));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand SubmitCommand => submitCommand ?? (submitCommand = new RelayCommand(Submit, CanSubmit));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<IPlaylist<ProPresenterCue>> SelectPlaylistCommand => selectPlaylistCommand ?? (selectPlaylistCommand = new RelayCommand<IPlaylist<ProPresenterCue>>(SelectPlaylist, CanExecutePlaylistSelection));

	public event Action? CloseDialog;

	[RelayCommand(CanExecute = "CanSelectLibrary")]
	private void SelectLibrary(ILibrary library)
	{
		if (CanSelectLibrary(library))
		{
			SelectedLibrary = library;
		}
	}

	private static bool CanSelectLibrary(ILibrary library)
	{
		return library != null;
	}

	[RelayCommand(CanExecute = "CanSubmit")]
	private void Submit()
	{
		if (_trySubmit())
		{
			Name = string.Empty;
			CanSelectPlaylist = true;
			this.CloseDialog?.Invoke();
		}
	}

	private bool CanSubmit()
	{
		if (!string.IsNullOrWhiteSpace(Name))
		{
			return SelectedLibrary != null;
		}
		return false;
	}

	[RelayCommand(CanExecute = "CanExecutePlaylistSelection")]
	private void SelectPlaylist(IPlaylist<ProPresenterCue> playlist)
	{
		if (CanExecutePlaylistSelection(playlist))
		{
			SelectedPlaylist = playlist;
		}
	}

	private bool CanExecutePlaylistSelection(IPlaylist<ProPresenterCue> playlist)
	{
		if (CanSelectPlaylist)
		{
			if (playlist != null)
			{
				return playlist.Type != PlaylistType.Group;
			}
			return true;
		}
		return false;
	}

	public NewPresentationVM(Func<bool> trySubmit, ILibraryVM libraryVM, IApp app, IThemeService themeService)
	{
		_trySubmit = trySubmit;
		_libraryVM = libraryVM;
		_app = app;
		SelectedTemplate = themeService.Themes.FindTemplate(app.SelectedNewPresentationTemplateID);
		SelectedLibrary = libraryVM.Libraries.FirstOrDefault();
		libraryVM.PropertyChanged += LibraryVmPropertyChanged;
	}

	private void LibraryVmPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "ActiveLibrary" && _libraryVM.ActiveLibrary != null)
		{
			SelectedLibrary = _libraryVM.ActiveLibrary;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnSelectedTemplateChanged(TemplateSlide? value)
	{
		_app.SelectedNewPresentationTemplateID = value?.Slide.ID ?? Guid.Empty;
	}
}
