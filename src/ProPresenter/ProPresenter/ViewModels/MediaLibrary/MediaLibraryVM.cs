using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Input;
using Microsoft.Win32;
using Pro.Common.Background;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.Downloads.CompletedMessages;
using Pro.Common.FileSystem;
using Pro.Common.Logging;
using Pro.Common.MessageService;
using Pro.Common.Nullability;
using Pro.DO.Storage;
using Pro.DO.Transitions;
using Pro.Localization;
using Pro.UI.Components;
using Pro.UI.DialogService;
using Pro.UI.Utility;
using ProPresenter.Controller;
using ProPresenter.Controller.Outputs;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.LiveVideo;
using ProPresenter.DO.Media;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.ProContent;
using ProPresenter.DO.ProContent.Model.Asset;
using ProPresenter.DO.Repositories;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Transitions;
using ProPresenter.DO.Workspaces;
using ProPresenter.UI;
using ProPresenter.UI.MediaLibrary;
using ProPresenter.UI.PresentationView;
using ProPresenter.UI.ProContent;
using ProPresenter.UI.ViewModels.MediaLibrary;
using ProPresenter.UI.ViewModels.ProContent;
using ProPresenter.UI.ViewModels.ProContent.Group;
using ProPresenter.ViewModels.ProContent;
using ProPresenter.ViewModels.ProContent.Asset;

namespace ProPresenter.ViewModels.MediaLibrary;

public class MediaLibraryVM : LinkedNotifyPropertyChangedBase, IMediaLibraryVM, INotifyPropertyChanged, ITransitionControl
{
	private readonly ICoreManager _manager;

	private readonly ITriggering _service;

	private readonly IVisualPlaylistCollection _playlists;

	private readonly IProContentDownloader _downloader;

	private readonly IFileSelectorService _fileSelectorService;

	private readonly IApp _app;

	private readonly IMessageDialogService _messageDialogService;

	private readonly IInternalProContentVM _proContentVM;

	private IWorkspace? _activeWorkspace;

	private RelayCommand? _newHotFolderCommand;

	private int _rowCapacity;

	private PanelViewType _viewType;

	private bool _renameNextItem;

	public IMediaPlaylistVM PlaylistVM { get; }

	public IProContentVM ProContentVM => _proContentVM;

	public IMediaBinHeaderNavigatorVM HeaderNavigatorVM { get; }

	public MediaCue? SelectedMediaCue => PlaylistVM.SelectedPlaylistItem?.MediaCue;

	public TransitionParameters? SelectedMediaCueTransition
	{
		get
		{
			return SelectedMediaCue?.MediaAction?.SelectedTransition;
		}
		set
		{
			if (!(SelectedMediaCueTransition != value))
			{
				return;
			}
			SelectedMediaCue?.UndoStack?.BeginCommit(UndoActionTypes.MediaTransition.ToAction());
			foreach (MediaAction item in PlaylistVM.SelectedPlaylistItems.Select((IMediaCueThumbnailVM m) => m.MediaCue?.MediaAction).NotNull())
			{
				item.SelectedTransition = value;
			}
			OnPropertyChanged("SelectedMediaCueTransition");
			SelectedMediaCue?.UndoStack?.EndCommit(null, delegate
			{
				OnPropertyChanged("SelectedMediaCueTransition");
			}, autoFinalize: true);
		}
	}

	public int RowCapacity
	{
		get
		{
			return _rowCapacity;
		}
		set
		{
			SetValue("RowCapacity", ref _rowCapacity, value, delegate(int o, int n)
			{
				_app.MediaBinRowCapacity = n;
			});
		}
	}

	public TransitionHandler TransitionHandler { get; }

	public TransitionParameters? SelectedTransition
	{
		get
		{
			return _manager.BackgroundTransition;
		}
		set
		{
			if (_manager.BackgroundTransition != null)
			{
				_manager.BackgroundTransition.PropertyChanged -= OnSelectedTransitionPropertyChanged;
			}
			_manager.BackgroundTransition = value;
			if (_manager.BackgroundTransition != null)
			{
				_manager.BackgroundTransition.PropertyChanged += OnSelectedTransitionPropertyChanged;
			}
		}
	}

	public ssAPIOutput OutputController { get; }

	public PanelViewType ViewType
	{
		get
		{
			return _viewType;
		}
		set
		{
			SetValue("ViewType", ref _viewType, value, delegate(PanelViewType o, PanelViewType n)
			{
				_app.MediaBinViewType = n;
			});
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

	public ICommand NewGroupFolderCommand => new RelayCommand(OnNewGroupFolderCommand);

	public ICommand NewHotFolderCommand => _newHotFolderCommand ?? (_newHotFolderCommand = new RelayCommand(OnNewHotFolderCommand, CanAddSmartPlaylist));

	public ICommand NewPlaylistCommand => new RelayCommand(OnNewPlaylistCommand);

	public ICommand<ImportMediaCommandParameters> AddFilesCommand => new RelayCommand<ImportMediaCommandParameters>(OnImportMediaCommand);

	public ICommand AddNewMediaCommand => new RelayCommand(OnAddNewMediaCommand, () => IsPlaylistEditable(PlaylistVM.ActivePlaylist));

	public ICommand ImportMediaCommand => new RelayCommand<ImportMediaCommandParameters>(OnImportMediaCommand);

	public ICommand<SortMediaItemsCommandParameter> SortMediaItemsCommand => new RelayCommand<SortMediaItemsCommandParameter>(OnSortMediaItems);

	public ICommand<IMediaCueThumbnailVM> TriggerMediaItemCommand => new RelayCommand<IMediaCueThumbnailVM>(OnTriggerMediaItemCommand, (IMediaCueThumbnailVM m) => m?.MediaCue?.MediaAction?.Media != null);

	public ICommand GotFocusCommand => new RelayCommand(ActivateMediaLibraryUndoStack);

	public ICommand<TransitionParameters> SetMediaTransitionCommand => new RelayCommand<TransitionParameters>(OnSetMediaTransitionCommand);

	public ICommand CopyCommand => new RelayCommand(OnCopyCommand, CanCutCopy);

	public ICommand CutCommand => new RelayCommand(OnCutCommand, () => CanCutCopy() && IsPlaylistEditable(PlaylistVM.ActivePlaylist));

	public ICommand PasteCommand => new RelayCommand(OnPasteCommand, () => ClipboardManagerHelper.CanPasteIntoCollection<MediaCue>() && IsPlaylistEditable(PlaylistVM.ActivePlaylist));

	public ICommand DuplicateCommand => new RelayCommand(OnDuplicateCommand, CanCutCopy);

	public ICommand DeleteCommand => new RelayCommand(OnDeleteCommandAsync, () => IsPlaylistEditable(PlaylistVM.ActivePlaylist) && PlaylistVM.SelectedPlaylistItems.Any());

	public ICommand OpenLiveVideoSetupCommand => new RelayCommand(delegate
	{
		this.OpenLiveVideoSetup?.Invoke(SelectedMediaCue?.LiveVideoInput);
	});

	public ICommand TriggerPreviousBackgroundCommand => new RelayCommand(delegate
	{
		_service.TriggerPreviousBackground(GetActiveVisualPlaylist());
	}, CanTriggerBackground);

	public ICommand TriggerNextBackgroundCommand => new RelayCommand(delegate
	{
		_service.TriggerNextBackground(GetActiveVisualPlaylist());
	}, CanTriggerBackground);

	public ICommand<ProContentDropParameter<VisualPlaylist?>> DropProContentAssetCommand => new RelayCommand<ProContentDropParameter<VisualPlaylist>>(DropProContentAssetCommandExecuted, CanDropAsset);

	public event Action<UndoStack?>? StackChanged;

	public event Action<LiveVideoInput?>? OpenLiveVideoSetup;

	public MediaLibraryVM(ICoreManager manager, ssAPIOutput outputController, IProContentDownloader proContentDownloader, IInternalProContentVM proContentVM, IMessageService messageService, IApp app, IFileSelectorService fileSelectorService, IVisualPlaylistCollection playlists, IOutputRepository outputRepository, IMediaActionService mediaActionService, IMediaCueThumbnailOverlayVMFactory overlayVMFactory, ITriggeringFactory tirggeringFactory, ITransitionSet transitions, IProPresenterDOFactoryProvider factoryProvider, IMessageDialogService messageDialogService, IUiDispatcher uiDispatcher)
	{
		_manager = manager;
		_service = tirggeringFactory.Create();
		_downloader = proContentDownloader;
		_fileSelectorService = fileSelectorService;
		_playlists = playlists;
		_app = app;
		_messageDialogService = messageDialogService;
		_rowCapacity = _app.MediaBinRowCapacity;
		_viewType = _app.MediaBinViewType;
		GlobalTransitionProvider transitionProvider = new GlobalTransitionProvider(transitions, _app.GlobalBackgroundTransitionType, _app.GlobalBackgroundAutoTransitionDuration, _app.GlobalBackgroundAdvancedTransition?.ToTransition(outputController.AvailableTransitions));
		transitionProvider.PropertyChanged += delegate(object? s, PropertyChangedEventArgs e)
		{
			switch (e.PropertyName)
			{
			case "StoredAutoParameters":
				_app.GlobalBackgroundAutoTransitionDuration = transitionProvider.StoredAutoParameters.Duration;
				break;
			case "StoredAdvancedParameters":
				_app.GlobalBackgroundAdvancedTransition = transitionProvider.StoredAdvancedParameters?.Serialize();
				break;
			case "ActiveStoreType":
				_app.GlobalBackgroundTransitionType = transitionProvider.ActiveStoreType.GetValueOrDefault();
				break;
			}
		};
		_activeWorkspace = CommonPaths.Workspaces.FirstOrDefault((IWorkspace w) => w.Active);
		CommonPaths.Workspaces.DataModified += OnWorkspacesDataModified;
		_newHotFolderCommand = new RelayCommand(OnNewHotFolderCommand, CanAddSmartPlaylist);
		SelectedTransition = transitionProvider.GetTransition(transitions);
		TransitionHandler = new TransitionHandler(transitions, transitionProvider);
		TransitionHandler.ActivateTransition(SelectedTransition);
		TransitionHandler.TransitionFinalized += UpdateTransition;
		PlaylistVM = new MediaPlaylistVM(_manager, new MediaCueThumbnailVMFactory(overlayVMFactory, OpenLiveVideoSetupCommand), playlists, outputRepository, mediaActionService, app, factoryProvider, uiDispatcher);
		_proContentVM = proContentVM;
		HeaderNavigatorVM = new MediaBinHeaderNavigatorVM(ProContentVM, PlaylistVM);
		_proContentVM.SetParent(HeaderNavigatorVM);
		OutputController = outputController;
		LinkAction("ActivePlaylist", delegate
		{
			if (PlaylistVM.ActivePlaylist != null)
			{
				ProContentVM.SelectedRootElement = null;
			}
		});
		LinkAction("SelectedRootElement", delegate
		{
			if (ProContentVM.SelectedRootElement != null)
			{
				PlaylistVM.ActivePlaylist = null;
			}
		});
		ProContentVM.PropertyChanged += base.RaiseLinkedValues;
		HookupLinkedProperties();
		messageService?.SubscribeToMessage<MediaDownloadCompletedMessage<VisualPlaylist>>(MediaStoreDownloadCompleted);
	}

	private void OnWorkspacesDataModified(IWorkspaceCollection collection)
	{
		IWorkspace workspace = CommonPaths.Workspaces.FirstOrDefault((IWorkspace w) => w.Active);
		if (workspace != _activeWorkspace)
		{
			_activeWorkspace = workspace;
			_newHotFolderCommand?.NotifyCanExecuteChanged();
		}
	}

	public void ActivateProContent()
	{
		if (ProContentVM.SelectedRootElement == null)
		{
			IProContentGroupVM proContentGroupVM = ProContentVM.Groups.FirstOrDefault((IProContentGroupVM g) => !(g is IProContentSearchGroupVM));
			if (proContentGroupVM != null)
			{
				ProContentVM.SelectedRootElement = proContentGroupVM;
			}
		}
	}

	public void ActivateMediaBin()
	{
		if (PlaylistVM.ActivePlaylist == null)
		{
			PlaylistVM.ActivePlaylist = PlaylistVM.Playlists.Flatten().FirstOrDefault((IPlaylist<MediaCue> p) => p is VisualPlaylist);
		}
	}

	private void DropProContentAssetCommandExecuted(ProContentDropParameter<VisualPlaylist?> parameter)
	{
		IProContentDownloadableAsset asset = (IProContentDownloadableAsset)((IProContentAssetVMInternal)parameter.Asset).Asset;
		_downloader.ImportAssetAsync(asset, parameter.Target).ExecuteAsync();
	}

	private static bool CanDropAsset(ProContentDropParameter<VisualPlaylist?> parameter)
	{
		if (parameter.Asset is IProContentAssetVMInternal proContentAssetVMInternal)
		{
			return proContentAssetVMInternal.Asset is IProContentDownloadableAsset;
		}
		return false;
	}

	private void MediaStoreDownloadCompleted(IMessage fileDownloaded)
	{
		if (fileDownloaded is MediaDownloadCompletedMessage<VisualPlaylist> { TargetType: MediaDownloadTarget.MediaBin, Target: not null } mediaDownloadCompletedMessage)
		{
			mediaDownloadCompletedMessage.Target.InsertPlaylist(_playlists, PlaylistVM.ActivePlaylist?.ID);
			mediaDownloadCompletedMessage.Target.InsertFiles(new RelativePath(mediaDownloadCompletedMessage.FullFilePath).ToEnumerable(), manageMedia: true, userInitiated: true);
			ActivateMediaLibraryUndoStack();
		}
	}

	private void OnSelectedTransitionPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "Duration" && sender is TransitionParameters { Duration: var duration })
		{
			_app.GlobalBackgroundAutoTransitionDuration = duration;
		}
	}

	private void UpdateTransition(TransitionParameters? newTransition)
	{
		SelectedTransition = newTransition;
	}

	private void HookupLinkedProperties()
	{
		LinkProperties("SelectedPlaylistItem", new string[2] { "SelectedMediaCueTransition", "SelectedMediaCue" });
		LinkProperties("BackgroundTransition", "SelectedTransition");
		if (_manager != null)
		{
			_manager.PropertyChanged += base.RaiseLinkedValues;
		}
		PlaylistVM.PropertyChanged += base.RaiseLinkedValues;
	}

	private void OnNewPlaylistCommand()
	{
		PlaylistVM.ShouldSetNewPlaylistActive = true;
		RenameNextItem = true;
		_playlists.AddNewPlaylist(LocalizedStrings.Get("PLAYLIST_GLOBAL_PLAYLIST_title"), FindCurrentGroup(), FindInsertIndex());
		ActivateMediaLibraryUndoStack();
		PlaylistVM.ShouldSetNewPlaylistActive = false;
	}

	private void OnNewHotFolderCommand()
	{
		PlaylistVM.ShouldSetNewPlaylistActive = true;
		if (_fileSelectorService.SelectFolderPath(out string selectedPath))
		{
			_playlists.AddNewHotPlaylist((RelativePath)selectedPath, FindCurrentGroup(), FindInsertIndex());
			ActivateMediaLibraryUndoStack();
		}
		PlaylistVM.ShouldSetNewPlaylistActive = false;
	}

	private void OnNewGroupFolderCommand()
	{
		PlaylistVM.ShouldSetNewPlaylistActive = true;
		RenameNextItem = true;
		_playlists.AddNewVisualGroupPlaylist(FindCurrentGroup(), FindInsertIndex());
		ActivateMediaLibraryUndoStack();
		PlaylistVM.ShouldSetNewPlaylistActive = false;
	}

	private VisualGroupPlaylist? FindCurrentGroup()
	{
		return (PlaylistVM.SelectedPlaylist as VisualGroupPlaylist) ?? (PlaylistVM.SelectedPlaylist?.Parent as VisualGroupPlaylist);
	}

	private int FindInsertIndex()
	{
		IPlaylist<MediaCue> activePlaylist = PlaylistVM.ActivePlaylist;
		if (activePlaylist == null)
		{
			return _playlists?.Count() ?? 0;
		}
		if (activePlaylist.Type != PlaylistType.Group)
		{
			INotifyEnumerableChanged<IPlaylist<MediaCue>> source = (activePlaylist.Parent as INotifyEnumerableChanged<IPlaylist<MediaCue>>) ?? _playlists;
			if (activePlaylist.Type != 0 && activePlaylist.Type != PlaylistType.Smart)
			{
				return source.Count() - 1;
			}
			return source.IndexOf(activePlaylist) + 1;
		}
		return -1;
	}

	private void OnAddNewMediaCommand()
	{
		OpenFileDialog openFileDialog = new OpenFileDialog
		{
			Filter = FileFilters.VisualFilter,
			Multiselect = true
		};
		if ((PlaylistVM.ActivePlaylist != null && PlaylistVM.ActivePlaylist.Type != 0) || openFileDialog.ShowDialog() != true)
		{
			return;
		}
		VisualPlaylist targetPlaylist = _playlists.GetTargetPlaylist(PlaylistVM.ActivePlaylist as VisualPlaylist);
		try
		{
			targetPlaylist?.InsertFiles(openFileDialog.FileNames.Select((string f) => (RelativePath)f), Advanced.Settings.ManageMediaAutomatically, userInitiated: true);
		}
		catch (Exception ex)
		{
			Log.Error("Error Adding Files in Media Bin: {0}", ex);
		}
	}

	private bool CanCutCopy()
	{
		return PlaylistVM.SelectedPlaylistItems.Any();
	}

	private bool CanAddSmartPlaylist()
	{
		IWorkspace workspace = CommonPaths.Workspaces.FirstOrDefault((IWorkspace w) => w.Active);
		if (workspace == null)
		{
			return false;
		}
		return workspace.WorkspaceType == WorkspaceType.Local;
	}

	private static bool IsPlaylistEditable(IPlaylist<MediaCue>? playlist)
	{
		PlaylistType? playlistType = playlist?.Type;
		if (playlistType != PlaylistType.Smart)
		{
			return playlistType != PlaylistType.Group;
		}
		return false;
	}

	private void OnCopyCommand()
	{
		ClipboardManagerHelper.CopyFromCollection(PlaylistVM.SelectedPlaylistItems.Select((IMediaCueThumbnailVM m) => m.MediaCue).ToArray());
		ActivateMediaLibraryUndoStack();
	}

	private void OnCutCommand()
	{
		VisualPlaylist obj = PlaylistVM.ActivePlaylist as VisualPlaylist;
		MediaCue[] items = PlaylistVM.SelectedPlaylistItems.Select((IMediaCueThumbnailVM m) => m.MediaCue).ToArray();
		obj.ThrowWhenNull("selectedPlaylist");
		ClipboardManagerHelper.CutFromCollection(obj, items);
		PlaylistVM.SelectedPlaylistItems.Clear();
		ActivateMediaLibraryUndoStack();
	}

	private void OnPasteCommand()
	{
		VisualPlaylist activeVisualPlaylist = GetActiveVisualPlaylist();
		MediaCue mediaCue = PlaylistVM.SelectedPlaylistItems.Select((IMediaCueThumbnailVM m) => m.MediaCue).LastOrDefault() ?? PlaylistVM.ActiveMediaItem?.MediaCue ?? activeVisualPlaylist.LastOrDefault();
		int index = ((mediaCue == null) ? (-1) : activeVisualPlaylist.IndexOf(mediaCue)) + 1;
		IEnumerable<MediaCue> pastedItems = ClipboardManagerHelper.PasteIntoCollection<VisualPlaylist, MediaCue>(activeVisualPlaylist, index);
		PlaylistVM.ResetSelectedItems(pastedItems);
		ActivateMediaLibraryUndoStack();
	}

	private void OnDuplicateCommand()
	{
		OnCopyCommand();
		OnPasteCommand();
	}

	private void OnDeleteCommandAsync()
	{
		VisualPlaylist activeVisualPlaylist = GetActiveVisualPlaylist();
		MediaCue[] items = PlaylistVM.SelectedPlaylistItems.Select((IMediaCueThumbnailVM m) => m.MediaCue).ToArray();
		DeleteMediaCues(activeVisualPlaylist, items);
	}

	private void DeleteMediaCues(VisualPlaylist playlist, IEnumerable<MediaCue> items)
	{
		if (!items.Any())
		{
			return;
		}
		bool valueOrDefault = items.FirstOrDefault()?.MediaAction?.IsGraphicMedia == true;
		string message = LocalizedStrings.Get("MEDIA_BIN_DELETE_MEDIA_ALERT_NO_FILE_info");
		DeleteMediaOptionButtons deleteMediaOptionButtons = DeleteMediaOptionButtons.Cancel | DeleteMediaOptionButtons.DeleteCues;
		if (valueOrDefault)
		{
			deleteMediaOptionButtons |= DeleteMediaOptionButtons.MoveToTrash;
			message = LocalizedStrings.Get("MEDIA_BIN_DELETE_MEDIA_ALERT_info");
		}
		DeleteMediaOptionButtons? deleteMediaOptionButtons2 = _messageDialogService.ShowDialog(LocalizedStrings.Get("MEDIA_BIN_DELETE_MEDIA_ALERT_message"), message, deleteMediaOptionButtons, DeleteMediaOptionButtons.DeleteCues);
		bool isDeleteAssets = deleteMediaOptionButtons2.HasValue && deleteMediaOptionButtons2.Value == DeleteMediaOptionButtons.MoveToTrash;
		if (!deleteMediaOptionButtons2.HasValue || deleteMediaOptionButtons2.Value == DeleteMediaOptionButtons.Cancel)
		{
			return;
		}
		if (valueOrDefault)
		{
			VisualMedia[] itemsToRemove = items.Select((MediaCue x) => x.MediaAction?.Media).OfType<VisualMedia>().ToArray();
			itemsToRemove.ForEach(delegate(VisualMedia x)
			{
				x.RemoveFromMediaService(isDeleteAssets);
			});
			UndoStack undoStack = ((!isDeleteAssets) ? PlaylistVM.Playlists.UndoStack : null);
			using (undoStack?.Transaction(UndoActionTypes.RemovePlaylistItems.ToAction(), null, null, autoFinalize: true))
			{
				undoStack?.Commit(delegate
				{
					itemsToRemove.ForEach(delegate(VisualMedia x)
					{
						x.AddToMediaServiceAndApplyTransform(userInitiated: true);
					});
				}, delegate
				{
					itemsToRemove.ForEach(delegate(VisualMedia x)
					{
						x.RemoveFromMediaService(isDeleteAssets);
					});
				});
				CompleteRemoval();
				return;
			}
		}
		CompleteRemoval();
		void CompleteRemoval()
		{
			playlist.RemoveCues(items.Reverse(), !isDeleteAssets);
			PlaylistVM.SelectedPlaylistItems.Clear();
			ActivateMediaLibraryUndoStack();
		}
	}

	private void OnImportMediaCommand(ImportMediaCommandParameters parameters)
	{
		VisualPlaylist selectedPlaylist = _playlists.GetTargetPlaylist(parameters.TargetPlaylist as VisualPlaylist);
		if (selectedPlaylist == null)
		{
			return;
		}
		if (parameters.RemoteFile != null)
		{
			parameters.RemoteFile.DownloadFile(delegate(FileInfo f)
			{
				doImport(new FileInfo[1] { f });
			});
		}
		else if (parameters.Files != null)
		{
			doImport(parameters.Files);
		}
		void doImport(IEnumerable<FileInfo> sourceFiles)
		{
			List<RelativePath> list = new List<RelativePath>();
			foreach (FileInfo sourceFile in sourceFiles)
			{
				if (sourceFile.Attributes.HasFlag(FileAttributes.Directory))
				{
					try
					{
						foreach (string item in from f in Directory.EnumerateFiles(sourceFile.FullName, "*.*", SearchOption.AllDirectories)
							where f.IsVisualMediaFile()
							select f)
						{
							list.Add(new RelativePath(item));
						}
					}
					catch (Exception exception)
					{
						Log.Error("Unable to get files in " + sourceFile.FullName);
						Log.Error(exception);
					}
				}
				else
				{
					list.Add(new RelativePath(sourceFile.FullName));
				}
			}
			try
			{
				if (selectedPlaylist is SmartPlaylist smartPlaylist)
				{
					smartPlaylist.ImportFiles(list.Select((RelativePath f) => f.FullPath).NotNull());
				}
				else
				{
					selectedPlaylist.InsertFiles(list, Advanced.Settings.ManageMediaAutomatically, userInitiated: true, parameters.TargetCue, parameters.DroppedBefore);
				}
			}
			catch (Exception ex)
			{
				Log.Error("Error Adding Files in Media Bin:" + ex);
			}
			ActivateMediaLibraryUndoStack();
		}
	}

	private void OnSortMediaItems(SortMediaItemsCommandParameter param)
	{
		if (PlaylistVM.ActivePlaylist is VisualPlaylist visualPlaylist)
		{
			visualPlaylist.SortItems(param.SortType, param.IsAscending);
			ActivateMediaLibraryUndoStack();
		}
	}

	private void ActivateMediaLibraryUndoStack()
	{
		this.StackChanged?.Invoke(PlaylistVM.Playlists.UndoStack);
	}

	private void OnSetMediaTransitionCommand(TransitionParameters newTransition)
	{
		SelectedMediaCueTransition = newTransition;
	}

	private void OnTriggerMediaItemCommand(IMediaCueThumbnailVM mediaCueVM)
	{
		MediaBase mediaBase = mediaCueVM.MediaCue.MediaAction?.Media;
		if (mediaBase != null)
		{
			mediaBase.UpdateValidity();
			if (mediaBase is LiveVideoMedia || mediaBase.IsValid)
			{
				TriggerMediaCue(mediaCueVM.MediaCue, GetActiveVisualPlaylist());
			}
		}
	}

	private bool CanTriggerBackground()
	{
		if (PlaylistVM.ActivePlaylist is VisualPlaylist visualPlaylist)
		{
			return visualPlaylist.Count > 0;
		}
		return false;
	}

	private void TriggerMediaCue(MediaCue cue, VisualPlaylist playlist)
	{
		PlaylistVM.SelectedPlaylistItems.Clear();
		_service.TriggerBackground(cue, playlist);
	}

	private VisualPlaylist GetActiveVisualPlaylist()
	{
		VisualPlaylist obj = PlaylistVM.ActivePlaylist as VisualPlaylist;
		obj.ThrowWhenNull("activeVisualPlaylist");
		return obj;
	}
}
