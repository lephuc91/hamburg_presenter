using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.Nullability;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.DO.Triggering;
using Pro.DO.Triggering.CompletionTargets;
using Pro.UI.Components;
using Pro.ssAPI;
using ProPresenter.Controller;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.LiveVideo;
using ProPresenter.DO.Media;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Repositories;
using ProPresenter.DO.Settings;
using ProPresenter.UI.MediaLibrary;
using ProPresenter.UI.ViewModels.MediaLibrary;

namespace ProPresenter.ViewModels.MediaLibrary;

public class MediaPlaylistVM : LinkedNotifyPropertyChangedBase, IMediaPlaylistVM, INotifyPropertyChanged
{
	private readonly ICoreManager _manager;

	private readonly IMediaCueThumbnailVMFactory _thumbnailVMFactory;

	private readonly IOutputRepository _outputRepository;

	private IPlaylist<MediaCue>? _activePlaylist;

	private IMediaCueThumbnailVM? _selectedPlaylistItem;

	private string _searchText = string.Empty;

	private readonly IMediaActionService _mediaActionService;

	private readonly IApp _app;

	private readonly IMediaFactory _mediaFactory;

	private bool _shouldSetNewPlaylistActive;

	private IPlaylist<MediaCue>? _selectedPlaylist;

	private readonly PairedCollection<MediaCue, IMediaCueThumbnailVM> _mediaCues;

	private readonly FilteredObservableCollection<IMediaCueThumbnailVM> _filteredMediaCues;

	public IEnumerable<IMediaCueThumbnailVM> ActiveMediaItems => _mediaCues.Where((IMediaCueThumbnailVM m) => m.MediaCue == _manager.ActiveMediaBinBackground || m.MediaCue == _manager.ActiveLiveVideo);

	public IMediaCueThumbnailVM? ActiveMediaItem => _mediaCues.FirstOrDefault((IMediaCueThumbnailVM m) => m.MediaCue == _manager.MostRecentActiveMedia);

	public IVisualPlaylistCollection Playlists { get; }

	public IPlaylist<MediaCue>? ActivePlaylist
	{
		get
		{
			return _activePlaylist;
		}
		set
		{
			SetValue<IPlaylist<MediaCue>>("ActivePlaylist", ref _activePlaylist, value, delegate(IPlaylist<MediaCue> o, IPlaylist<MediaCue> n)
			{
				if (n is VisualPlaylist visualPlaylist)
				{
					_app.SelectedMediaPlaylist = visualPlaylist.ID;
					if (_manager != null)
					{
						_manager.ActiveVisualPlaylist = visualPlaylist;
					}
					SearchText = string.Empty;
					OnPropertyChanged("HotFolderBehavior");
				}
				ResetMediaCues(n as VisualPlaylist);
			}, (IPlaylist<MediaCue> n) => n == null || n is VisualPlaylist);
		}
	}

	public IPlaylist<MediaCue>? SelectedPlaylist
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

	public ObservableCollection<IPlaylist<MediaCue>> SelectedPlaylists { get; } = new ObservableCollection<IPlaylist<MediaCue>>();

	public ILiveVideoInputCollection AvailableVideoInputs => _outputRepository.AvailableLiveVideoInputs;

	public bool HasAvailableVideoInputs => _outputRepository.AvailableLiveVideoInputs.Any();

	public IMediaCueThumbnailVM? SelectedPlaylistItem
	{
		get
		{
			return _selectedPlaylistItem;
		}
		set
		{
			SetValue<IMediaCueThumbnailVM>("SelectedPlaylistItem", ref _selectedPlaylistItem, value, delegate(IMediaCueThumbnailVM oldItem, IMediaCueThumbnailVM newItem)
			{
				if (oldItem?.MediaCue.MediaAction?.VideoMedia != null)
				{
					VideoMedia? videoMedia = oldItem.MediaCue.MediaAction.VideoMedia;
					videoMedia.Video.PropertyChanged -= base.RaiseLinkedValues;
					videoMedia.Transport.PropertyChanged -= base.RaiseLinkedValues;
				}
				if (newItem?.MediaCue.MediaAction?.VideoMedia != null)
				{
					VideoMedia? videoMedia2 = newItem.MediaCue.MediaAction.VideoMedia;
					videoMedia2.Video.PropertyChanged += base.RaiseLinkedValues;
					videoMedia2.Transport.PropertyChanged += base.RaiseLinkedValues;
				}
				OnPropertyChanged("AvailableCompletionCues");
				OnPropertyChanged("CueCompletionTargetType");
				OnPropertyChanged("CueCompletionTargetCueID");
				OnPropertyChanged("CuePlaybackBehavior");
				OnPropertyChanged("SoftLoopTargetTime");
			});
		}
	}

	public ObservableCollection<IMediaCueThumbnailVM> SelectedPlaylistItems { get; } = new ObservableCollection<IMediaCueThumbnailVM>();

	public IEnumerable<MediaCue> SelectedMediaCues => SelectedPlaylistItems.Select((IMediaCueThumbnailVM m) => m.MediaCue);

	public string SearchText
	{
		get
		{
			return _searchText;
		}
		set
		{
			SetValue("SearchText", ref _searchText, value, (Action)delegate
			{
				_filteredMediaCues?.Refresh();
			}, (Predicate<string>?)null, referenceComparison: false);
		}
	}

	public IEnumerable<MediaCue> AvailableCompletionCues => (from m in _mediaCues.Except<IMediaCueThumbnailVM>(SelectedPlaylistItem)
		select m?.MediaCue).NotNull();

	public ImportLayer HotFolderBehavior => SelectedPlaylists.OfType<SmartPlaylist>().LastOrDefault()?.Behavior ?? ImportLayer.Background;

	public CompletionTargetType CueCompletionTargetType => SelectedPlaylistItem?.MediaCue.CompletionTarget.Type ?? CompletionTargetType.None;

	public Guid CueCompletionTargetCueID => (SelectedPlaylistItem?.MediaCue.CompletionTarget as CueTarget)?.ID ?? Guid.Empty;

	public PlaybackBehaviorType CuePlaybackBehavior => (SelectedPlaylistItem?.MediaCue.MediaAction?.Media as ITransportMedia)?.Transport.PlaybackBehaviorType ?? PlaybackBehaviorType.Stop;

	public TimeSlice SoftLoopTargetTime => (SelectedPlaylistItem?.MediaCue.MediaAction?.Media as IVideoMedia)?.Video.SoftLoopDuration ?? TimeSlice.Zero;

	public bool ShouldSetNewPlaylistActive
	{
		get
		{
			return _shouldSetNewPlaylistActive;
		}
		set
		{
			SetValue("ShouldSetNewPlaylistActive", ref _shouldSetNewPlaylistActive, value);
		}
	}

	public INotifyEnumerableChanged<IMediaCueThumbnailVM> MediaCues => _filteredMediaCues;

	public ICommand DeletePlaylistCommand => new RelayCommand(OnDeletePlaylistCommand);

	public ICommand DuplicatePlaylistCommand => new RelayCommand(OnDuplicatePlaylistCommand, () => SelectedPlaylists.Any());

	public ICommand ShowInFileExplorerCommand => new RelayCommand(OnShowInFileExplorerCommand);

	public ICommand<TriggerLayer> SetMediaTargetLayerCommand => new RelayCommand<TriggerLayer>(OnSetMediaTargetLayerCommand);

	public ICommand<ScaleBehavior> SetMediaScaleBehaviorCommand => new RelayCommand<ScaleBehavior>(OnSetMediaScaleBehaviorCommand);

	public ICommand<PlaybackBehaviorType> SetPlaybackCommand => new RelayCommand<PlaybackBehaviorType>(OnSetPlaybackCommand, (PlaybackBehaviorType p) => SelectedPlaylistItems.Any());

	public ICommand<TimeSlice?> SetSoftLoopDurationCommand => new RelayCommand<TimeSlice?>(OnSetSoftLoopDurationCommand, (TimeSlice? t) => SelectedPlaylistItems.Any());

	public ICommand<EndBehaviorType> SetEndBehaviorTypeCommand => new RelayCommand<EndBehaviorType>(OnSetEndBehaviorTypeCommand, (EndBehaviorType t) => SelectedPlaylistItems.Any());

	public ICommand<ImportLayer> SetHotFolderBehaviorCommand => new RelayCommand<ImportLayer>(OnSetHotFolderBehaviorCommand);

	public ICommand<CompletionTargetType> SetCompletionTargetCommand => new RelayCommand<CompletionTargetType>(OnSetCompletionTargetCommand, (CompletionTargetType c) => SelectedPlaylistItems.Any());

	public ICommand<MediaCue> SetCompletionCueCommand => new RelayCommand<MediaCue>(OnSetCompletionCue, (MediaCue c) => SelectedPlaylistItems.Any());

	public ICommand<LiveVideoInput> AddLiveVideoMediaCommand => new RelayCommand<LiveVideoInput>(OnAddLiveVideoMediaCommand, (LiveVideoInput i) => ActivePlaylist is VisualPlaylist);

	public ICommand<AlphaType> SetAlphaTypeCommand => new RelayCommand<AlphaType>(SetAlphaTypeCommandExecuted, (AlphaType i) => SelectedPlaylistItems.Any());

	public ICommand OpenFileLocationCommand => new RelayCommand(OnOpenFileLocationCommandExecute, () => SelectedPlaylists.OfType<SmartPlaylist>().Count() == 1);

	public MediaPlaylistVM(ICoreManager manager, IMediaCueThumbnailVMFactory thumbnailVMFactory, IVisualPlaylistCollection playlists, IOutputRepository outputRepository, IMediaActionService mediaActionService, IApp app, IProPresenterDOFactoryProvider factoryProvider, IUiDispatcher uiDispatcher)
	{
		_manager = manager;
		_thumbnailVMFactory = thumbnailVMFactory;
		Playlists = playlists;
		_outputRepository = outputRepository;
		_mediaActionService = mediaActionService;
		_app = app;
		_mediaFactory = factoryProvider.MediaFactory;
		_mediaCues = new PairedCollection<MediaCue, IMediaCueThumbnailVM>(ActivePlaylist as VisualPlaylist, (MediaCue c) => _thumbnailVMFactory.Create(c));
		_filteredMediaCues = new UpdatingFilteredObservableCollection<IMediaCueThumbnailVM>(_mediaCues, FilterCues, uiDispatcher, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Name"));
		SetDefaultSelection();
		HookupLinkedProperties();
		Playlists.LocationChanged += delegate
		{
			ActivePlaylist = Playlists.FirstOrDefault();
			SelectedPlaylistItem = _mediaCues.FirstOrDefault();
		};
		_manager.ActiveVisualPlaylistChanged += delegate(Playlist<MediaCue> p)
		{
			ActivePlaylist = p;
		};
		SelectedPlaylistItems.CollectionChanged += delegate
		{
			OnPropertyChanged("SelectedMediaCues");
		};
		_filteredMediaCues.CollectionChanged += FilteredMediaCues_CollectionChanged;
		UpdateItemsIndices();
	}

	private void SetDefaultSelection()
	{
		SetSelectedPlaylist(_app.SelectedMediaPlaylist);
		if (_manager != null)
		{
			_manager.ActiveVisualPlaylist = ActivePlaylist as VisualPlaylist;
		}
		SelectedPlaylists.CollectionChanged += delegate
		{
			OnPropertyChanged("HotFolderBehavior");
		};
	}

	private void HookupLinkedProperties()
	{
		LinkProperties("MostRecentActiveMedia", "ActiveMediaItem");
		LinkProperties(new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "ActiveMediaBinBackground", "ActiveLiveVideo" }), "ActiveMediaItems");
		LinkProperties(new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "SoftLoop", "PlaybackBehaviorType" }), "CuePlaybackBehavior");
		LinkAction("ActiveVisualPlaylist", delegate
		{
			SetSelectedPlaylist(_manager.ActiveVisualPlaylist?.ID);
		});
		if (_manager != null)
		{
			_manager.PropertyChanged += base.RaiseLinkedValues;
		}
		_app.PropertyChanged += base.RaiseLinkedValues;
		_outputRepository.AvailableLiveVideoInputs.CollectionChanged += delegate
		{
			OnPropertyChanged("HasAvailableVideoInputs");
		};
	}

	private void SetSelectedPlaylist(Guid? playlistID)
	{
		if (Playlists == null)
		{
			return;
		}
		if (!playlistID.HasValue || playlistID.Value == Guid.Empty)
		{
			ActivePlaylist = Playlists.FirstOrDefault();
			return;
		}
		ActivePlaylist = Playlists.GetPlaylists(delegate(IPlaylist<MediaCue> p)
		{
			Guid iD = p.ID;
			Guid? guid = playlistID;
			return iD == guid;
		}).FirstOrDefault() ?? Playlists.FirstOrDefault();
	}

	private void OnDeletePlaylistCommand()
	{
		if (Playlists == null)
		{
			return;
		}
		IPlaylist<MediaCue>[] array = SelectedPlaylists.NonNull().ToArray();
		if (!array.Any())
		{
			return;
		}
		Playlists.UndoStack?.BeginCommit(UndoActionTypes.RemovePlaylist.ToAction());
		IReadOnlyList<ITrackedMedia> mediaToRemove = PlaylistHelper.GetTrackedMediaFromPlaylists(array);
		mediaToRemove.ForEach(delegate(ITrackedMedia x)
		{
			x.RemoveFromMediaService(deleteAssets: false);
		});
		Playlists.UndoStack?.Commit(delegate
		{
			mediaToRemove.ForEach(delegate(ITrackedMedia x)
			{
				x.AddToMediaServiceAndApplyTransform(userInitiated: true);
			});
		}, delegate
		{
			mediaToRemove.ForEach(delegate(ITrackedMedia x)
			{
				x.RemoveFromMediaService(deleteAssets: false);
			});
		});
		IPlaylist<MediaCue>[] array2 = array;
		foreach (IPlaylist<MediaCue> playlist in array2)
		{
			if (playlist.Parent == null)
			{
				Playlists.RemovePlaylist(playlist);
			}
			else if (playlist.Parent is VisualGroupPlaylist visualGroupPlaylist)
			{
				visualGroupPlaylist.RemoveChild(playlist);
			}
		}
		Playlists.UndoStack?.EndCommit(null, null, autoFinalize: true);
	}

	private void OnDuplicatePlaylistCommand()
	{
		Playlists.Duplicate(SelectedPlaylists);
	}

	private void OnShowInFileExplorerCommand()
	{
		ProcessHelper.ShowFileInExplorer(SelectedPlaylistItem?.MediaCue.MediaAction?.VisualMedia?.SourceFile?.FullPath);
	}

	private void OnSetMediaTargetLayerCommand(TriggerLayer triggerLayer)
	{
		foreach (MediaAction item in SelectedPlaylistItems.Select((IMediaCueThumbnailVM m) => m.MediaCue.MediaAction).NonNull())
		{
			if (triggerLayer != TriggerLayer.Input || (item.Media.MediaType != 0 && item.Media.MediaType != MediaType.Video))
			{
				item.TriggerLayer = triggerLayer;
			}
		}
	}

	private void OnSetMediaScaleBehaviorCommand(ScaleBehavior scaleBehavior)
	{
		_mediaActionService.SetMediaScaleBehavior(SelectedPlaylistItems.Select((IMediaCueThumbnailVM i) => i.MediaCue.MediaAction).NotNull(), scaleBehavior);
	}

	private void OnSetPlaybackCommand(PlaybackBehaviorType playback)
	{
		if (SelectedPlaylistItem?.MediaCue.MediaAction != null)
		{
			_mediaActionService.SetPlayback(SelectedPlaylistItem.MediaCue.MediaAction, SelectedPlaylistItems.Select((IMediaCueThumbnailVM c) => c.MediaCue.MediaAction).NotNull(), playback);
		}
		OnPropertyChanged("CuePlaybackBehavior");
		OnPropertyChanged("SoftLoopTargetTime");
		OnPropertyChanged("CueCompletionTargetType");
		OnPropertyChanged("CueCompletionTargetCueID");
	}

	private void OnSetSoftLoopDurationCommand(TimeSlice? time)
	{
		_mediaActionService.SetSoftLoopDuration(SelectedPlaylistItems.Select((IMediaCueThumbnailVM i) => i.MediaCue.MediaAction).NotNull(), time);
		OnPropertyChanged("CuePlaybackBehavior");
		OnPropertyChanged("SoftLoopTargetTime");
		OnPropertyChanged("CueCompletionTargetType");
		OnPropertyChanged("CueCompletionTargetCueID");
	}

	private void SetAlphaTypeCommandExecuted(AlphaType type)
	{
		_mediaActionService.SetAlphaType(SelectedPlaylistItems.Select((IMediaCueThumbnailVM i) => i.MediaCue.MediaAction).NotNull(), type);
	}

	private void OnSetEndBehaviorTypeCommand(EndBehaviorType endBehavior)
	{
		_mediaActionService.SetEndBehaviorType(SelectedPlaylistItems.Select((IMediaCueThumbnailVM i) => i.MediaCue.MediaAction).NotNull(), endBehavior);
	}

	private void OnSetCompletionTargetCommand(CompletionTargetType completionTargetType)
	{
		foreach (MediaCue item in SelectedPlaylistItems.Select((IMediaCueThumbnailVM m) => m.MediaCue))
		{
			switch (completionTargetType)
			{
			case CompletionTargetType.None:
				item.CompletionTarget = new NoTarget();
				break;
			case CompletionTargetType.Next:
				item.CompletionTarget = new NextTarget();
				break;
			case CompletionTargetType.Random:
				item.CompletionTarget = new RandomTarget();
				break;
			case CompletionTargetType.First:
				item.CompletionTarget = new FirstTarget();
				break;
			default:
				throw new NotSupportedException();
			case CompletionTargetType.Cue:
				break;
			}
		}
		OnPropertyChanged("CueCompletionTargetType");
		OnPropertyChanged("CueCompletionTargetCueID");
		OnPropertyChanged("CuePlaybackBehavior");
		OnPropertyChanged("SoftLoopTargetTime");
	}

	private void OnSetHotFolderBehaviorCommand(ImportLayer behavior)
	{
		SelectedPlaylists.OfType<SmartPlaylist>().ForEach(delegate(SmartPlaylist p)
		{
			p.Behavior = behavior;
		});
		OnPropertyChanged("HotFolderBehavior");
	}

	private void OnOpenFileLocationCommandExecute()
	{
		SmartPlaylist smartPlaylist = SelectedPlaylists.OfType<SmartPlaylist>().FirstOrDefault();
		if (smartPlaylist != null)
		{
			ProcessHelper.ShowFileInExplorer(smartPlaylist.TargetPath);
		}
	}

	private void OnSetCompletionCue(MediaCue targetCue)
	{
		foreach (IMediaCueThumbnailVM selectedPlaylistItem in SelectedPlaylistItems)
		{
			selectedPlaylistItem.MediaCue.CompletionTarget = new CueTarget(targetCue);
		}
		OnPropertyChanged("CueCompletionTargetType");
		OnPropertyChanged("CueCompletionTargetCueID");
	}

	private void OnAddLiveVideoMediaCommand(LiveVideoInput input)
	{
		LiveVideoMedia liveVideoMedia = _mediaFactory.CreateLiveVideoMedia();
		liveVideoMedia.LiveVideo.Input = input;
		MediaCue mediaCue = new MediaCue(_app, liveVideoMedia, _outputRepository.AvailableTransitions);
		mediaCue.MediaAction.Name = input.LongName;
		VisualPlaylist obj = ActivePlaylist as VisualPlaylist;
		obj.ThrowWhenNull("activeVisualPlaylist");
		obj.AddItem(mediaCue);
	}

	private void ResetMediaCues(VisualPlaylist? playlist)
	{
		_mediaCues?.ChangeSource(playlist);
		OnPropertyChanged("MediaCues");
		OnPropertyChanged("ActiveMediaItem");
		OnPropertyChanged("ActiveMediaItems");
		UpdateItemsIndices();
	}

	private void FilteredMediaCues_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		UpdateItemsIndices();
	}

	private void UpdateItemsIndices()
	{
		int index = 1;
		_filteredMediaCues.ForEach(delegate(IMediaCueThumbnailVM m)
		{
			m.UpdateIndex(index++);
		});
	}

	private bool FilterCues(IMediaCueThumbnailVM cueVM)
	{
		if (!string.IsNullOrWhiteSpace(SearchText))
		{
			return cueVM.Name.ToLowerInvariant().Contains(SearchText.ToLowerInvariant());
		}
		return true;
	}

	public void ResetSelectedItems(IEnumerable<MediaCue> pastedItems)
	{
		SelectedPlaylistItems.Clear();
		IEnumerable<IMediaCueThumbnailVM> items = _mediaCues.Where((IMediaCueThumbnailVM i) => pastedItems.Contains(i.MediaCue));
		SelectedPlaylistItems.AddRange(items);
	}
}
