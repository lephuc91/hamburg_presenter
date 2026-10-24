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
using ProPresenter.DO.ProContent.Model.Format;
using ProPresenter.DO.Settings;
using ProPresenter.UI.ViewModels.ProContent.Dialog.Download;

namespace ProPresenter.ViewModels.ProContent.Dialog;

public class ProContentDownloadDialogVMBase : ObservableObject, IProContentDownloadDialogVM
{
	private readonly IProPresenterResourceService _resources;

	private readonly IApp _app;

	[ObservableProperty]
	[NotifyPropertyChangedFor("CanStartDownload")]
	private IPlaylist<MediaCue>? _selectedPlaylist;

	[ObservableProperty]
	[NotifyPropertyChangedFor("CanStartDownload")]
	private IProContentFormat? _selectedFormat;

	[ObservableProperty]
	[NotifyPropertyChangedFor("CanStartDownload")]
	private string _newPlaylistName = string.Empty;

	public INotifyEnumerableChanged<IPlaylist<MediaCue>> Playlists => _resources.VisualPlaylists;

	public IReadOnlyCollection<IProContentFormat> AvailableFormats { get; }

	public virtual bool CanStartDownload
	{
		get
		{
			if (SelectedPlaylist is VisualPlaylist || !string.IsNullOrWhiteSpace(NewPlaylistName))
			{
				return SelectedFormat != null;
			}
			return false;
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IPlaylist<MediaCue>? SelectedPlaylist
	{
		get
		{
			return _selectedPlaylist;
		}
		set
		{
			if (!EqualityComparer<IPlaylist<MediaCue>>.Default.Equals(_selectedPlaylist, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.SelectedPlaylist);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.CanStartDownload);
				_selectedPlaylist = value;
				OnSelectedPlaylistChanged(value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.SelectedPlaylist);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.CanStartDownload);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IProContentFormat? SelectedFormat
	{
		get
		{
			return _selectedFormat;
		}
		set
		{
			if (!EqualityComparer<IProContentFormat>.Default.Equals(_selectedFormat, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.SelectedFormat);
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.CanStartDownload);
				_selectedFormat = value;
				OnSelectedFormatChanged(value);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.SelectedFormat);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.CanStartDownload);
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
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.CanStartDownload);
				_newPlaylistName = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.NewPlaylistName);
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.CanStartDownload);
			}
		}
	}

	protected ProContentDownloadDialogVMBase(IProPresenterResourceService resources, IApp app, IReadOnlyCollection<IProContentFormat>? availableFormats = null)
	{
		_resources = resources;
		_app = app;
		AvailableFormats = (IReadOnlyCollection<IProContentFormat>)(((object)availableFormats) ?? ((object)Array.Empty<IProContentFormat>()));
		SelectedPlaylist = Playlists.GetPlaylists((IPlaylist<MediaCue> p) => p.ID == _app.SelectedMediaDownloadPlaylist)?.FirstOrDefault() as VisualPlaylist;
		SelectedFormat = AvailableFormats.FindFormat((ProContentFormat?)_app.SelectedProContentFormat);
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnSelectedPlaylistChanged(IPlaylist<MediaCue>? value)
	{
		_app.SelectedMediaDownloadPlaylist = value?.ID ?? Guid.Empty;
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	private void OnSelectedFormatChanged(IProContentFormat? value)
	{
		_app.SelectedProContentFormat = value?.ToString() ?? string.Empty;
	}
}
