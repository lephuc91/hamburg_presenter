using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using Pro.Common.Collections;
using ProPresenter.DO;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Settings;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.ViewModels.MediaLibrary;

public class MediaImportDownloadDialogVM : ObservableObject, IMediaImportDownloadDialogVM
{
	private readonly IProPresenterResourceService _resources;

	private readonly IApp _app;

	[ObservableProperty]
	[NotifyPropertyChangedFor("IsValidLibrarySelected")]
	private VisualPlaylist? _selectedPlaylist;

	[ObservableProperty]
	[NotifyPropertyChangedFor("IsValidLibrarySelected")]
	private string _newPlaylistName = string.Empty;

	public INotifyEnumerableChanged<IPlaylist<MediaCue>> Playlists => _resources.VisualPlaylists;

	public bool IsValidLibrarySelected
	{
		get
		{
			if (SelectedPlaylist == null)
			{
				return !string.IsNullOrEmpty(NewPlaylistName);
			}
			return true;
		}
	}

	public bool IsDownload { get; }

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public VisualPlaylist? SelectedPlaylist
	{
		get
		{
			return _selectedPlaylist;
		}
		set
		{
			if (!EqualityComparer<VisualPlaylist>.Default.Equals(_selectedPlaylist, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.SelectedPlaylist);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsValidLibrarySelected);
				_selectedPlaylist = value;
				OnSelectedPlaylistChanged(value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.SelectedPlaylist);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsValidLibrarySelected);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public string NewPlaylistName
	{
		get
		{
			return _newPlaylistName;
		}
		[MemberNotNull("_newPlaylistName")]
		set
		{
			if (!EqualityComparer<string>.Default.Equals(_newPlaylistName, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.NewPlaylistName);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.IsValidLibrarySelected);
				_newPlaylistName = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.NewPlaylistName);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.IsValidLibrarySelected);
			}
		}
	}

	public MediaImportDownloadDialogVM(IProPresenterResourceService resources, IApp app, bool isDownload)
	{
		_resources = resources;
		_app = app;
		IsDownload = isDownload;
		SelectedPlaylist = _resources.VisualPlaylists.GetPlaylists((IPlaylist<MediaCue> p) => p.ID == _app.SelectedMediaPlaylist).FirstOrDefault() as VisualPlaylist;
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnSelectedPlaylistChanged(VisualPlaylist? value)
	{
		if (_app != null)
		{
			_app.SelectedMediaDownloadPlaylist = value?.ID ?? Guid.Empty;
		}
	}
}
