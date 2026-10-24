using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Playlists;
using ProPresenter.UI.ViewModels.Import;

namespace ProPresenter.ViewModels.Import;

public class ImportSelectionVM : ObservableObject, IImportSelectionVM, INotifyPropertyChanged
{
	[ObservableProperty]
	private ILibrary? _library;

	[ObservableProperty]
	private IPlaylist<ProPresenterCue>? _playlist;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<ILibrary>? selectLibraryCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand<IPlaylist<ProPresenterCue>?>? selectPlaylistCommand;

	public required bool AllowPlaylistSelection { get; init; }

	public required LibraryPlaylistCollection Playlists { get; init; }

	public required ILibraryCollection Libraries { get; init; }

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public ILibrary? Library
	{
		get
		{
			return _library;
		}
		set
		{
			if (!EqualityComparer<ILibrary>.Default.Equals(_library, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Library);
				_library = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Library);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IPlaylist<ProPresenterCue>? Playlist
	{
		get
		{
			return _playlist;
		}
		set
		{
			if (!EqualityComparer<IPlaylist<ProPresenterCue>>.Default.Equals(_playlist, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Playlist);
				_playlist = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Playlist);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<ILibrary> SelectLibraryCommand => selectLibraryCommand ?? (selectLibraryCommand = new RelayCommand<ILibrary>(SelectLibrary));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand<IPlaylist<ProPresenterCue>?> SelectPlaylistCommand => selectPlaylistCommand ?? (selectPlaylistCommand = new RelayCommand<IPlaylist<ProPresenterCue>>(SelectPlaylist, CanSelectPlaylist));

	[RelayCommand]
	private void SelectLibrary(ILibrary library)
	{
		Library = library;
	}

	[RelayCommand(CanExecute = "CanSelectPlaylist")]
	private void SelectPlaylist(IPlaylist<ProPresenterCue>? playlist)
	{
		Playlist = playlist;
	}

	private static bool CanSelectPlaylist(IPlaylist<ProPresenterCue>? playlist)
	{
		PlaylistType? playlistType = playlist?.Type;
		return !playlistType.HasValue || playlistType != PlaylistType.Group;
	}
}
