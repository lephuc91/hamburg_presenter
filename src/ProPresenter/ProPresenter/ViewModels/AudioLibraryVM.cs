using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Win32;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.FileSystem;
using Pro.Common.Logging;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using Pro.DO.Triggering.CompletionTargets;
using Pro.Localization;
using Pro.UI.Components;
using Pro.UI.DialogService;
using Pro.ssAPI;
using ProPresenter.Controller;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Media;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Settings;
using ProPresenter.UI.AudioLibrary;
using ProPresenter.UI.ViewModels;
using ProPresenterCore.ProCore.Interop;
using ProPresenterCore.ProCore.Interop.Triggering.Types;

namespace ProPresenter.ViewModels;

public class AudioLibraryVM : LinkedNotifyPropertyChangedBase, IAudioLibraryVM, INotifyPropertyChanged
{
	private readonly ICoreManager _manager;

	private readonly ITriggering _service;

	private readonly AudioPlaylistCollection _audioPlaylists;

	private readonly IApp _app;

	private bool _isPlaying;

	private bool _renameNextItem;

	public AudioPlaylist? ActiveAudioPlaylist => _manager.ActiveAudioPlaylist;

	public IEnumerable<AudioSortType> SortTypeValues => Enum.GetValues<AudioSortType>();

	public IAudioPlaylistVM PlaylistVM { get; }

	public MediaCue? ActiveAudioItem => _manager.ActiveAudio;

	public ObservableDictionary<MediaCue, bool> ActiveAudioItems { get; } = new ObservableDictionary<MediaCue, bool>();

	public AudioBehaviorType SelectedAudioBehaviorType
	{
		get
		{
			MediaCue selectedPlaylistItem = PlaylistVM.SelectedPlaylistItem;
			return selectedPlaylistItem?.CompletionTarget.Type switch
			{
				CompletionTargetType.Next => AudioBehaviorType.Next, 
				CompletionTargetType.None => selectedPlaylistItem?.MediaAction?.AudioMedia?.Transport.PlaybackBehaviorType switch
				{
					PlaybackBehaviorType.Loop => AudioBehaviorType.Loop, 
					PlaybackBehaviorType.Stop => AudioBehaviorType.Stop, 
					_ => AudioBehaviorType.Stop, 
				}, 
				_ => AudioBehaviorType.Stop, 
			};
		}
	}

	public AudioSortType SortType
	{
		get
		{
			return _app.AudioSortType;
		}
		set
		{
			_app.AudioSortType = value;
			SelectedAudioPlaylist?.SortAudioPlaylistItems(value, isReversible: true);
			ActivateAudioPlaylistUndoStack();
		}
	}

	private AudioPlaylist? SelectedAudioPlaylist => PlaylistVM.SelectedPlaylist as AudioPlaylist;

	public TimeSlice TransitionDuration
	{
		get
		{
			return _app.AudioFadeInOutDuration;
		}
		set
		{
			_app.AudioFadeInOutDuration = value;
			_manager.AudioTransition = new TransitionParameters(_manager.AudioTransition?.Preset)
			{
				Duration = value
			};
		}
	}

	public bool IsShuffle
	{
		get
		{
			return _app.ShuffleEnabled;
		}
		set
		{
			_app.ShuffleEnabled = value;
		}
	}

	public bool IsPlaying
	{
		get
		{
			return _isPlaying;
		}
		private set
		{
			SetValue("IsPlaying", ref _isPlaying, value);
		}
	}

	public bool RenameNextItem
	{
		get
		{
			return _renameNextItem;
		}
		set
		{
			SetValue("RenameNextItem", ref _renameNextItem, value);
		}
	}

	public ICommand AddAudioItemCommand => new AsyncRelayCommand(OnAddAudioItemCommand);

	public ICommand NewGroupFolderCommand => new RelayCommand(OnNewGroupFolderCommand);

	public ICommand NewPlaylistCommand => new RelayCommand(OnNewPlaylistCommand);

	public ICommand<AudioType> SetAudioTypeCommand => new RelayCommand<AudioType>(OnSetAudioTypeCommand);

	public ICommand RemoveSelectedPlaylistItemsCommand => new RelayCommand(OnRemoveAudioItemCommand, () => SelectedAudioPlaylist != null && PlaylistVM.SelectedPlaylistItems.Any());

	public ICommand GotFocusCommand => new RelayCommand(ActivateAudioPlaylistUndoStack);

	public ICommand ShowInFileExplorerCommand => new RelayCommand(OnShowInFileExplorerCommand);

	public ICommand<DropAudioFilesCommandParameter> DropAudioFilesCommand => new AsyncRelayCommand<DropAudioFilesCommandParameter>(OnDropAudioFilesCommand);

	public ICommand<MediaCue> TriggerMediaItemCommand => new RelayCommand<MediaCue>(TriggerAudio, delegate(MediaCue c)
	{
		if (c != null)
		{
			MediaAction? mediaAction = c.MediaAction;
			if (mediaAction == null)
			{
				return false;
			}
			return mediaAction.Media.MediaType == MediaType.Audio;
		}
		return false;
	});

	public ICommand<AudioSortType> SortAudioItemsCommand => new RelayCommand<AudioSortType>(delegate(AudioSortType a)
	{
		SortType = a;
	}, (AudioSortType a) => SelectedAudioPlaylist != null);

	public ICommand<AudioBehaviorType> UpdateAudioBehaviorCommand => new RelayCommand<AudioBehaviorType>(OnUpdateBehaviorCommand, (AudioBehaviorType b) => PlaylistVM.SelectedPlaylistItem != null);

	public event Action<UndoStack?>? StackChanged;

	public AudioLibraryVM(ICoreManager manager, IApp app, ITriggeringFactory triggeringFactory, IProPresenterResourceService resourceService, IUiDispatcher uiDispatcher)
	{
		_manager = manager;
		_app = app;
		_service = triggeringFactory.Create();
		_manager.TransportStatusChanged += Coremanager_TransportStatusChanged;
		_manager.ActiveAudioItems.CollectionChanged += ActiveAudioItems_CollectionChanged;
		_manager.PropertyChanged += base.RaiseLinkedValues;
		_audioPlaylists = DataVault.AudioPlaylistCollection;
		HookupLinkedProperties();
		PlaylistVM = new AudioPlaylistVM(manager, app, resourceService, uiDispatcher);
		_app.PropertyChanged += base.RaiseLinkedValues;
		PlaylistVM.PropertyChanged += base.RaiseLinkedValues;
		PlaylistVM.SelectedPlaylistItems.CollectionChanged += SelectedPlaylistItems_CollectionChanged;
	}

	private void Coremanager_TransportStatusChanged(ResourceAddress address, ProTransportStatus transportStatus)
	{
		IsPlaying = address.Layer == ProLayerIndex.Music && transportStatus.IsPlaying;
		if ((address.Layer != ProLayerIndex.Music && address.Layer != ProLayerIndex.SoundEffects) || !ActiveAudioItems.Any() || ActiveAudioItem == null || SelectedAudioPlaylist == null)
		{
			return;
		}
		KeyValuePair<MediaCue, bool> keyValuePair = ActiveAudioItems.FirstOrDefault<KeyValuePair<MediaCue, bool>>(delegate(KeyValuePair<MediaCue, bool> kvp)
		{
			Guid? guid = kvp.Key.MediaAction?.ID;
			Guid? guid2 = ((address.Layer != ProLayerIndex.Music) ? new Guid?(address.Slot) : ActiveAudioItem.MediaAction?.ID);
			if (guid.HasValue != guid2.HasValue)
			{
				return false;
			}
			return !guid.HasValue || guid.GetValueOrDefault() == guid2.GetValueOrDefault();
		});
		if (keyValuePair.Key != null && SelectedAudioPlaylist.Contains(keyValuePair.Key))
		{
			if (ActiveAudioItems.ContainsKey(keyValuePair.Key))
			{
				ActiveAudioItems[keyValuePair.Key] = transportStatus.IsPlaying;
			}
			else
			{
				ActiveAudioItems.Add(keyValuePair.Key, transportStatus.IsPlaying);
			}
		}
	}

	private void ActiveAudioItems_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.OfType<MediaCue>().Where(ActiveAudioItems.ContainsKey).ForEach(delegate(MediaCue c)
		{
			ActiveAudioItems.Remove(c);
		});
		(from c in e.NewItems?.OfType<MediaCue>()
			where !ActiveAudioItems.ContainsKey(c)
			select c).ForEach(delegate(MediaCue c)
		{
			ActiveAudioItems.Add(c, value: false);
		});
	}

	private void SelectedPlaylistItems_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.OfType<MediaCue>().ForEach(delegate(MediaCue m)
		{
			m.PropertyChanged -= AudioMediaCuePropertyChanged;
		});
		e.NewItems?.OfType<MediaCue>().ForEach(delegate(MediaCue m)
		{
			m.PropertyChanged += AudioMediaCuePropertyChanged;
		});
	}

	private void AudioMediaCuePropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "CompletionTarget")
		{
			OnPropertyChanged("SelectedAudioBehaviorType");
		}
	}

	private void HookupLinkedProperties()
	{
		LinkProperties("AudioSortType", "SortType");
		LinkProperties("AudioFadeInOutDuration", "TransitionDuration");
		LinkProperties("ShuffleEnabled", "IsShuffle");
		LinkProperties("SelectedPlaylistItem", "SelectedAudioBehaviorType");
		LinkProperties("ActiveAudio", "ActiveAudioItem");
		LinkProperties("ActiveAudioPlaylist", "ActiveAudioPlaylist");
	}

	private void OnSetAudioTypeCommand(AudioType type)
	{
		PlaylistVM.SelectedPlaylistItems.ForEach(delegate(MediaCue a)
		{
			if (a.MediaAction?.AudioMedia != null)
			{
				a.MediaAction.AudioMedia.AudioType = type;
			}
		});
	}

	private void OnNewPlaylistCommand()
	{
		RenameNextItem = true;
		_audioPlaylists.AddNewPlaylist("", FindCurrentGroup(), FindInsertIndex());
		ActivateAudioPlaylistUndoStack();
	}

	private void OnNewGroupFolderCommand()
	{
		RenameNextItem = true;
		_audioPlaylists.AddNewGroupPlaylist(FindCurrentGroup(), FindInsertIndex());
		ActivateAudioPlaylistUndoStack();
	}

	private AudioGroupPlaylist? FindCurrentGroup()
	{
		IPlaylist<MediaCue> playlist = PlaylistVM.SelectedPlaylists.FirstOrDefault();
		return (playlist as AudioGroupPlaylist) ?? (playlist?.Parent as AudioGroupPlaylist);
	}

	private int FindInsertIndex()
	{
		IPlaylist<MediaCue> playlist = PlaylistVM.SelectedPlaylists.FirstOrDefault();
		if (playlist == null)
		{
			return _audioPlaylists.Count;
		}
		if (playlist.Type == PlaylistType.Group)
		{
			return -1;
		}
		if (playlist.Parent == null)
		{
			return PlaylistVM.Playlists.IndexOf(playlist) + 1;
		}
		if (playlist.Parent is AudioGroupPlaylist audioGroupPlaylist)
		{
			return audioGroupPlaylist.IndexOf(playlist) + 1;
		}
		return -1;
	}

	private async Task OnAddAudioItemCommand()
	{
		OpenFileDialog openFileDialog = new OpenFileDialog
		{
			Filter = FileFilters.AudioFilter,
			Multiselect = true
		};
		if ((SelectedAudioPlaylist != null && SelectedAudioPlaylist.Type == PlaylistType.Group) || openFileDialog.ShowDialog() != true)
		{
			return;
		}
		AudioPlaylist targetPlaylist = _audioPlaylists.GetTargetPlaylist(SelectedAudioPlaylist);
		try
		{
			if (targetPlaylist != null)
			{
				await targetPlaylist.AddAudioFiles(openFileDialog.FileNames, userInitiated: true);
				ActivateAudioPlaylistUndoStack();
			}
		}
		catch (Exception ex)
		{
			Log.Error("Error Adding Files in Audio Bin :" + ex);
		}
	}

	private void OnRemoveAudioItemCommand()
	{
		DeleteMediaOptionButtons? deleteMediaOptionButtons = MessageDialogService.ShowDialog(LocalizedStrings.Get("MEDIA_BIN_DELETE_MEDIA_ALERT_message"), LocalizedStrings.Get("MEDIA_BIN_DELETE_MEDIA_ALERT_info"), DeleteMediaOptionButtons.Cancel | DeleteMediaOptionButtons.MoveToTrash | DeleteMediaOptionButtons.DeleteCues, DeleteMediaOptionButtons.DeleteCues);
		if (deleteMediaOptionButtons.HasValue && deleteMediaOptionButtons.Value != DeleteMediaOptionButtons.Cancel && SelectedAudioPlaylist != null)
		{
			bool flag = deleteMediaOptionButtons.Value == DeleteMediaOptionButtons.DeleteCues;
			int index = PlaylistVM.SelectedPlaylistItems.Min((MediaCue c) => SelectedAudioPlaylist.IndexOf(c)) - 1;
			SelectedAudioPlaylist.RemoveAudioItems(PlaylistVM.SelectedPlaylistItems.ToArray(), flag);
			MediaCue mediaCue = SelectedAudioPlaylist.ElementAtOrDefault(index) ?? SelectedAudioPlaylist.FirstOrDefault();
			PlaylistVM.SelectedPlaylistItems.Clear();
			if (mediaCue != null)
			{
				PlaylistVM.SelectedPlaylistItems.Add(mediaCue);
				PlaylistVM.SelectedPlaylistItem = mediaCue;
			}
			if (flag)
			{
				ActivateAudioPlaylistUndoStack();
			}
		}
	}

	private void ActivateAudioPlaylistUndoStack()
	{
		this.StackChanged?.Invoke(_audioPlaylists?.UndoStack);
	}

	private void OnShowInFileExplorerCommand()
	{
		if (PlaylistVM.SelectedPlaylistItem?.MediaAction?.AudioMedia?.SourceFile?.IsValid == true)
		{
			ProcessHelper.ShowFileInExplorer(PlaylistVM.SelectedPlaylistItem.MediaAction.AudioMedia.SourceFile.FullPath ?? string.Empty);
		}
	}

	private async Task OnDropAudioFilesCommand(DropAudioFilesCommandParameter? parameter)
	{
		AudioPlaylist targetPlaylist = _audioPlaylists.GetTargetPlaylist(SelectedAudioPlaylist);
		if (targetPlaylist == null)
		{
			return;
		}
		if (parameter.RemoteFile != null)
		{
			parameter.RemoteFile.DownloadFile(delegate(FileInfo f)
			{
				targetPlaylist.InsertAudioFiles(new string[1] { f.FullName }, userInitiated: true, parameter.DropIndex);
			});
		}
		else
		{
			await targetPlaylist.InsertAudioFiles(parameter.Filenames.ToArray(), userInitiated: true, parameter.DropIndex);
		}
	}

	private void TriggerAudio(MediaCue mediaCue)
	{
		mediaCue.MediaAction?.Media?.UpdateValidity();
		if (mediaCue.MediaAction?.Media?.IsValid == true && PlaylistVM.SelectedPlaylist is AudioPlaylist playlist)
		{
			_service.TriggerAudio(mediaCue, playlist);
		}
	}

	private void OnUpdateBehaviorCommand(AudioBehaviorType behavior)
	{
		switch (behavior)
		{
		case AudioBehaviorType.Stop:
			PlaylistVM.SelectedPlaylistItems.ForEach(delegate(MediaCue p)
			{
				if (p.MediaAction?.AudioMedia != null)
				{
					p.MediaAction.AudioMedia.Transport.PlaybackBehaviorType = PlaybackBehaviorType.Stop;
				}
			});
			PlaylistVM.SelectedPlaylistItems.ForEach(delegate(MediaCue p)
			{
				p.CompletionTarget = new NoTarget();
			});
			break;
		case AudioBehaviorType.Loop:
			PlaylistVM.SelectedPlaylistItems.ForEach(delegate(MediaCue p)
			{
				if (p.MediaAction?.AudioMedia != null)
				{
					p.MediaAction.AudioMedia.Transport.PlaybackBehaviorType = PlaybackBehaviorType.Loop;
				}
			});
			PlaylistVM.SelectedPlaylistItems.ForEach(delegate(MediaCue p)
			{
				p.CompletionTarget = new NoTarget();
			});
			break;
		case AudioBehaviorType.Next:
			PlaylistVM.SelectedPlaylistItems.ForEach(delegate(MediaCue p)
			{
				if (p.MediaAction?.AudioMedia != null)
				{
					p.MediaAction.AudioMedia.Transport.PlaybackBehaviorType = PlaybackBehaviorType.Stop;
				}
			});
			PlaylistVM.SelectedPlaylistItems.ForEach(delegate(MediaCue p)
			{
				p.CompletionTarget = new NextTarget();
			});
			break;
		default:
			throw new NotSupportedException("This behavior type can't be set");
		}
		OnPropertyChanged("SelectedAudioBehaviorType");
	}
}
