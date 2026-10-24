using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Pro.Common.SourceGenerator.Attributes;
using ProPresenter.Controller;
using ProPresenter.DO;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.PCO;
using ProPresenter.DO.Playlists;
using ProPresenter.UI.Calendar;

namespace ProPresenter.ViewModels.Library;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { })]
public class LibraryService : ObservableObject, ILibraryService, IDisposable
{
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("ActiveLibraryPlaylist", "ActivePlaylist")]
	[Pro.Common.SourceGenerator.Attributes.PropertyLink("ActiveLibrary", "ActiveLibrary")]
	private readonly ICoreManager _manager;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public LibraryCollection Libraries => DataVault.LibraryCollection;

	public LibraryPlaylistCollection Playlists => DataVault.LibraryPlaylistCollection;

	public ICalendarService Calendar { get; }

	public IExportService Export { get; }

	public IMatchSongsInteractor MatchSongsInteractor { get; }

	public Playlist<ProPresenterCue>? ActivePlaylist
	{
		get
		{
			return _manager.ActiveLibraryPlaylist;
		}
		set
		{
			_manager.ActiveLibraryPlaylist = value;
		}
	}

	public ILibrary? ActiveLibrary => _manager.ActiveLibrary;

	public LibraryService(ICoreManager manager, ICalendarService calendarService, IExportService exportService, IMatchSongsInteractor matchSongsInteractor)
	{
		Export = exportService;
		_manager = manager;
		Calendar = calendarService;
		MatchSongsInteractor = matchSongsInteractor;
		AddPropertyLinks();
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed && disposing)
		{
			_disposed = true;
			OnDispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		RemovePropertyLinks();
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void _manager_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		string propertyName = e.PropertyName;
		if (!(propertyName == "ActiveLibraryPlaylist"))
		{
			if (propertyName == "ActiveLibrary")
			{
				OnPropertyChanged("ActiveLibrary");
			}
		}
		else
		{
			OnPropertyChanged("ActivePlaylist");
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void AddPropertyLinks()
	{
		_manager.PropertyChanged += _manager_PropertyChanged;
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void RemovePropertyLinks()
	{
		_manager.PropertyChanged -= _manager_PropertyChanged;
	}
}
