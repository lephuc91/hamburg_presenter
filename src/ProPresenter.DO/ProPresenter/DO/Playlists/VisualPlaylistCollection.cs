using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Google.Protobuf;
using Pro.Common.Background;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.FeatureFlag;
using Pro.Common.ObjectBinding;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Time;
using Pro.Common.Time.Timer;
using Pro.Common.Utility;
using Pro.CoreApplication.Document;
using Pro.CoreApplication.Document.Intrinsic;
using Pro.CoreApplication.Media;
using Pro.CoreApplication.Media.V2;
using Pro.DO;
using Pro.DO.Application;
using Pro.DO.Storage;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Collections;
using Pro.Entity.Extensions;
using Pro.Entity.Persistence;
using Pro.Localization;
using Pro.Serialization.DataManagement;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.ChangeDirectory;
using ProPresenter.DO.Cues;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Events;
using ProPresenter.DO.Extensions;
using ProPresenter.DO.Media;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Workspaces;

namespace ProPresenter.DO.Playlists;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_syncedData", "_syncedDataUpdateDelayTimer", "_syncer" })]
public class VisualPlaylistCollection : PlaylistCollectionBase<MediaCue>, IVisualPlaylistCollection, INotifyEnumerableChanged<IPlaylist<MediaCue>>, IEnumerable<IPlaylist<MediaCue>>, IEnumerable, INotifyCollectionChanged, IDocumentProvider, IDisposable
{
	private sealed class ReferenceEqualityComparer<T> : IEqualityComparer<T> where T : class
	{
		public bool Equals(T? x, T? y)
		{
			return x == y;
		}

		public int GetHashCode(T obj)
		{
			return RuntimeHelpers.GetHashCode(obj);
		}
	}

	private static readonly TimeSlice SyncedDataUpdateDelayTime = TimeSlice.FromSeconds(2.5);

	private IProtoSyncedData<PlaylistDocument>? _syncedData;

	private IOneShotTimer? _syncedDataUpdateDelayTimer;

	private readonly IApp _app;

	private readonly ITimerFactory _timerFactory;

	private readonly IMediaImportService _mediaImportService;

	private readonly IMediaFactory _mediaFactory;

	private readonly ITransitionDescriptionCollection _transitionDescriptions;

	private readonly ISyncDataFactory _syncDataFactory;

	private readonly IUiScheduler _scheduler;

	private readonly IProPresenterDOFactoryProvider _factoryProvider;

	private readonly IActionBinderFactory _actionBinderFactory;

	private readonly IMediaService _mediaService;

	private readonly IAsyncExecutor _asyncExecutor;

	private readonly IFlagService _flagService;

	private readonly IUiDispatcher _dispatcher;

	private IEntityDocumentSyncer<IPlaylistDocumentDoc>? _syncer;

	private IReadOnlySet<string>? _existingSmartPlaylistPaths;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public LiveVideoPlaylist LiveVideoPlaylist { get; }

	public Guid DocumentId => _syncer?.Id ?? Guid.Empty;

	private ObjectBinder<VisualPlaylistCollection, IComplexCollection<IPlaylist>> Bind(IPlaylistDocument entityDocument)
	{
		entityDocument.Type.Set(IPlaylistDocument.Types.Type.Media);
		IPlaylist.Types.IChildrenType.IPlaylists playlists = entityDocument.RootNode.Value.ChildrenType.Value as IPlaylist.Types.IChildrenType.IPlaylists;
		if (playlists == null)
		{
			playlists = _factoryProvider.EntityFactory.Create<IPlaylist.Types.IChildrenType.IPlaylists>();
			entityDocument.RootNode.Value.ChildrenType.Set(playlists);
		}
		if (entityDocument.LiveVideoPlaylist.Value == null)
		{
			entityDocument.LiveVideoPlaylist.Set(_factoryProvider.EntityFactory.Create<IPlaylist>());
		}
		entityDocument.LiveVideoPlaylist.Value.Name.Set(LiveVideoPlaylist.Name);
		IReadOnlyObjectBinder<IPlaylist<MediaCue>, IPlaylist> liveVideoPlaylistBinder = LiveVideoPlaylist.Bind(_scheduler, _factoryProvider.EntityFactory, _actionBinderFactory, entityDocument.LiveVideoPlaylist.Value);
		ObjectBinder<VisualPlaylistCollection, IComplexCollection<IPlaylist>> objectBinder = new ObjectBinder<VisualPlaylistCollection, IComplexCollection<IPlaylist>>(this, playlists.Value.Playlists);
		objectBinder.Bind((VisualPlaylistCollection l) => l.WhenCollectionChanges(), (IComplexCollection<IPlaylist> r) => r.WhenCollectionChanges, delegate(VisualPlaylistCollection l, IComplexCollection<IPlaylist> r)
		{
			r.SynchronizeFrom(l.Items.Where((IPlaylist<MediaCue> i) => !(i is LiveVideoPlaylist)).ToList(), (IPlaylist<MediaCue> m, IPlaylist e) => m.ID == e.Uuid.Value, delegate(IPlaylist<MediaCue> m)
			{
				IPlaylist playlist = _factoryProvider.EntityFactory.Create<IPlaylist>();
				IReadOnlyObjectBinder<IPlaylist<MediaCue>, IPlaylist> readOnlyObjectBinder = m.Bind(_scheduler, _factoryProvider.EntityFactory, _actionBinderFactory, playlist);
				readOnlyObjectBinder.InitializeRightFromLeft();
				playlist.RegisterLinkedDisposable(readOnlyObjectBinder);
				return playlist;
			});
		}, delegate(IComplexCollection<IPlaylist> r, VisualPlaylistCollection l)
		{
			r.Items.SynchronizeTo(l, (IPlaylist e, IPlaylist<MediaCue> m) => m.ID == e.Uuid.Value, delegate(IPlaylist e, int i)
			{
				IPlaylist<MediaCue> playlist2 = ConstuctPlaylist(e);
				IReadOnlyObjectBinder<IPlaylist<MediaCue>, IPlaylist> readOnlyObjectBinder2 = playlist2.Bind(_scheduler, _factoryProvider.EntityFactory, _actionBinderFactory, e);
				readOnlyObjectBinder2.InitializeLeftFromRight();
				e.RegisterLinkedDisposable(readOnlyObjectBinder2);
				l.AddPlaylist(playlist2, null, i);
			}, l.Collection.Move, delegate(int i)
			{
				IPlaylist<MediaCue> playlist3 = l.ElementAtOrDefault(i);
				if (playlist3 != null)
				{
					l.RemovePlaylist(playlist3);
				}
			});
		}, null, _scheduler.Scheduler).DoOnInitializeLeftFromRight(liveVideoPlaylistBinder.InitializeLeftFromRight).DoOnInitializeRightFromLeft(liveVideoPlaylistBinder.InitializeRightFromLeft)
			.RegisterChildDisposable(() => liveVideoPlaylistBinder);
		return objectBinder;
	}

	private IPlaylist<MediaCue> ConstuctPlaylist(IPlaylist entityPlaylist)
	{
		if (entityPlaylist.ChildrenType.Value is IPlaylist.Types.IChildrenType.IPlaylists)
		{
			return new VisualGroupPlaylist(_app, _mediaImportService, _mediaFactory, base.UndoStack, _transitionDescriptions, _flagService);
		}
		return new VisualPlaylist(_app, _mediaImportService, _mediaFactory, _transitionDescriptions, _flagService, base.UndoStack);
	}

	public VisualPlaylistCollection(IApp app, ITimerFactory timerFactory, IMediaImportService mediaImportService, IMediaFactory mediaFactory, ITransitionDescriptionCollection transitionDescriptions, ISyncDataFactory syncDataFactory, IUiScheduler scheduler, IFlagService flagService, IProPresenterDOFactoryProvider factoryProvider, IActionBinderFactory actionBinderFactory, IMediaService mediaService, IAsyncExecutor asyncExecutor, IUiDispatcher dispatcher, bool loadLegacy)
		: base((UndoStack?)null)
	{
		_app = app;
		_timerFactory = timerFactory;
		_mediaImportService = mediaImportService;
		_mediaFactory = mediaFactory;
		_transitionDescriptions = transitionDescriptions;
		_syncDataFactory = syncDataFactory;
		_scheduler = scheduler;
		_factoryProvider = factoryProvider;
		_actionBinderFactory = actionBinderFactory;
		_mediaService = mediaService;
		_asyncExecutor = asyncExecutor;
		_flagService = flagService;
		_dispatcher = dispatcher;
		LiveVideoPlaylist = new LiveVideoPlaylist(_app, mediaImportService, _mediaFactory, _transitionDescriptions, _flagService, base.UndoStack);
		LiveVideoPlaylist.DataModified += base.OnDataModified;
		SetupDocumentSyncer(loadLegacy);
		ChangeDirectoryPrompt.RegisterDelegate(new ChangeDirectoryListener(TeardownDocumentSyncer, SetupDocumentSyncer));
	}

	private void TeardownDocumentSyncer()
	{
		_syncer?.Dispose();
		_syncedData?.Dispose();
		_syncedDataUpdateDelayTimer?.Dispose();
		_syncer = null;
		_syncedData = null;
		_syncedDataUpdateDelayTimer = null;
	}

	private void SetupDocumentSyncer(bool loadLegacy)
	{
		if (_flagService.IsFlagEnabled(Flag.Cloud))
		{
			_syncer = _factoryProvider.EntityDocumentSyncerFactory.CreateFileSyncer<IPlaylistDocumentDoc>(CommonPaths.Playlists, "Media", Bind, () => Serialize().ToByteArray(), delegate(byte[] d)
			{
				Deserialize(PlaylistDocument.Parser.ParseFrom(d));
			}, LoadDefaults, loadLegacy);
		}
		else
		{
			_syncedDataUpdateDelayTimer = _timerFactory.CreateOneShotDispatched(SyncedDataUpdateDelayTime, delegate
			{
				_syncedDataUpdateDelayTimer?.Stop();
				_syncedData?.UpdateData(Serialize());
			});
			_syncedData = _syncDataFactory.GetSyncedData(CommonPaths.Playlists, "Media", delegate(PlaylistDocument d)
			{
				Deserialize(d);
			}, SyncedDataCleared);
		}
		AppendSpecialPlaylist();
		OnLocationChanged(CommonPaths.Playlists);
	}

	private void LoadDefaults()
	{
		SyncedDataCleared(DataClearSource.FileRemoved);
	}

	public VisualPlaylist AddNewPlaylist(string name = "", VisualGroupPlaylist? parent = null, int index = -1)
	{
		VisualPlaylist visualPlaylist = new VisualPlaylist(_app, _mediaImportService, _mediaFactory, _transitionDescriptions, _flagService, base.UndoStack, name);
		AddPlaylist(visualPlaylist, parent, index);
		return visualPlaylist;
	}

	public VisualPlaylist AddNewHotPlaylist(RelativePath targetFolder, VisualGroupPlaylist? parent = null, int index = -1)
	{
		UpdateCoreOfAvailableSmartPlaylists(targetFolder);
		SmartPlaylist smartPlaylist = new SmartPlaylist(new SmartFolderRepo(targetFolder), base.UndoStack, _app, _mediaImportService, _mediaFactory, _transitionDescriptions, _flagService);
		AddPlaylist(smartPlaylist, parent, index);
		return smartPlaylist;
	}

	public VisualGroupPlaylist AddNewVisualGroupPlaylist(VisualGroupPlaylist? parent = null, int index = -1)
	{
		VisualGroupPlaylist visualGroupPlaylist = new VisualGroupPlaylist(_app, _mediaImportService, _mediaFactory, base.UndoStack, _transitionDescriptions, _flagService)
		{
			Name = LocalizedStrings.Get("PLAYLIST_GLOBAL_NEW_PLAYLIST_FOLDER_name")
		};
		AddPlaylist(visualGroupPlaylist, parent, index);
		return visualGroupPlaylist;
	}

	protected override int SanitizeInsertionIndex(int index)
	{
		index = base.SanitizeInsertionIndex(index);
		if (index == base.Collection.Count && base.Collection.ElementAtOrDefault(base.Collection.Count - 1) == LiveVideoPlaylist)
		{
			index = base.Collection.Count - 1;
		}
		return index;
	}

	public void RemovePlaylist(IPlaylist<MediaCue> playlist)
	{
		if (!(playlist is LiveVideoPlaylist))
		{
			int index = base.Collection.IndexOf(playlist);
			base.Collection.Remove(playlist);
			base.UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.RemovePlaylist), delegate
			{
				base.Collection.Insert(base.Collection.ClampIndex(index), playlist);
			}, delegate
			{
				base.Collection.Remove(playlist);
			}, null, base.OnDataModified, autoFinalize: true);
			OnDataModified();
		}
	}

	private void SyncedDataCleared(DataClearSource dataClearSource)
	{
		if (dataClearSource == DataClearSource.FileRemoved)
		{
			base.UndoStack?.StartIgnoring();
			RemovePlaylists(base.Collection.ToArray());
			LoadDefaultPlaylistCollection();
			base.UndoStack?.StopIgnoring();
		}
	}

	public void Deserialize(PlaylistDocument? document, bool removeExisting = true)
	{
		ApplicationData applicationData = ApplicationData.Deserialize(document?.ApplicationInfo);
		base.UndoStack?.StartIgnoring();
		ObservableCollection<IPlaylist<MediaCue>> collection = base.Collection;
		IEnumerable<Playlist> enumerable = document?.RootNode?.Playlists?.Playlists;
		MediaBinHelper.DeserializePlaylists(collection, enumerable ?? Enumerable.Empty<Playlist>(), base.OnDataModified, base.UndoStack, null, applicationData, _app, _mediaImportService, _mediaFactory, _transitionDescriptions, _flagService, removeExisting);
		UpdateCoreOfAvailableSmartPlaylists();
		if (document?.DownloadsPlaylist?.Items?.Items?.Any() == true)
		{
			VisualPlaylist visualPlaylist = new VisualPlaylist(_app, _mediaImportService, _mediaFactory, _transitionDescriptions, _flagService);
			visualPlaylist.ProtoDeserialize(document.DownloadsPlaylist, applicationData);
			AddPlaylist(visualPlaylist);
		}
		LiveVideoPlaylist.ProtoDeserialize(document?.LiveVideoPlaylist, applicationData);
		base.UndoStack?.StopIgnoring();
	}

	public PlaylistDocument Serialize()
	{
		UpdateCoreOfAvailableSmartPlaylists();
		PlaylistDocument playlistDocument = new PlaylistDocument();
		playlistDocument.ApplicationInfo = new ApplicationData(ApplicationType.ProPresenter).Serialize();
		playlistDocument.Type = PlaylistDocument.Types.Type.Media;
		playlistDocument.RootNode = new Playlist
		{
			Uuid = Guid.NewGuid().ToUUID()
		};
		playlistDocument.RootNode.Type = Playlist.Types.Type.Root;
		playlistDocument.RootNode.Playlists = new Playlist.Types.PlaylistArray();
		playlistDocument.RootNode.Playlists.Playlists.AddRange(from p in base.Collection.Except(LiveVideoPlaylist)
			select p.ProtoSerialize());
		playlistDocument.DownloadsPlaylist = null;
		playlistDocument.LiveVideoPlaylist = LiveVideoPlaylist.ProtoSerialize();
		return playlistDocument;
	}

	protected override void DataModifiedHook()
	{
		_syncedDataUpdateDelayTimer?.Start();
		VisualPlaylistCollectionUpdated.Publish(this);
	}

	private void LoadDefaultPlaylistCollection()
	{
		base.UndoStack?.StartIgnoring();
		AddNewPlaylist(LocalizedStrings.Get("GLOBAL_DEFAULT"));
		AppendSpecialPlaylist();
		base.UndoStack?.StopIgnoring();
	}

	public async Task ConvertAllSmartPlaylistsToVisualPlaylistsAsync()
	{
		SmartPlaylist[] array = base.Collection.OfType<IPlaylist<MediaCue>>().Flatten().OfType<SmartPlaylist>()
			.ToArray();
		if (array.Length == 0)
		{
			return;
		}
		List<System.Action> uiActions = new List<System.Action>();
		HashSet<ITrackedMedia> trackedMediaSet = new HashSet<ITrackedMedia>(new ReferenceEqualityComparer<ITrackedMedia>());
		SmartPlaylist[] array2 = array;
		foreach (SmartPlaylist smartPlaylist in array2)
		{
			VisualPlaylist newPlaylist = new VisualPlaylist(_app, _mediaImportService, _mediaFactory, _transitionDescriptions, _flagService, base.UndoStack, smartPlaylist.Name);
			MediaCue[] clonedCues = smartPlaylist.Select((MediaCue c) => (MediaCue)c.Clone()).ToArray();
			uiActions.Add(delegate
			{
				if (smartPlaylist.PlaylistParent is GroupPlaylist<MediaCue> groupPlaylist)
				{
					AddPlaylist(newPlaylist, groupPlaylist);
					groupPlaylist.RemoveChild(smartPlaylist);
				}
				else
				{
					AddPlaylist(newPlaylist);
					RemovePlaylist(smartPlaylist);
				}
				newPlaylist.AddItems(clonedCues);
			});
			foreach (ITrackedMedia item in (from x in clonedCues
				where (object)x.MediaAction?.FileMedia?.SourceFile != null
				select x.MediaAction.Media).OfType<ITrackedMedia>())
			{
				if (item != null)
				{
					trackedMediaSet.Add(item);
				}
			}
		}
		await _dispatcher.InvokeAsync(delegate
		{
			foreach (System.Action item2 in uiActions)
			{
				item2();
			}
		}).ConfigureAwait(continueOnCapturedContext: false);
		UpdateCoreOfAvailableSmartPlaylists();
		if (trackedMediaSet.Count <= 0)
		{
			return;
		}
		List<Task> list = new List<Task>(trackedMediaSet.Count);
		foreach (ITrackedMedia media in trackedMediaSet)
		{
			try
			{
				list.Add(media.AddToMediaServiceAsync(userInitiated: true));
			}
			catch
			{
				list.Add(Task.Run(delegate
				{
					media.AddToMediaServiceAndApplyTransform(userInitiated: true);
				}));
			}
		}
		await Task.WhenAll(list).ConfigureAwait(continueOnCapturedContext: false);
	}

	private void AppendSpecialPlaylist()
	{
		if (!base.Collection.Contains(LiveVideoPlaylist))
		{
			base.Collection.Add(LiveVideoPlaylist);
		}
	}

	protected override P GetNewPlaylist<P>()
	{
		return AddNewPlaylist() as P;
	}

	public VisualPlaylist? GetTargetPlaylist(VisualPlaylist? playlist)
	{
		return base.GetTargetPlaylist(playlist);
	}

	public void Duplicate(IEnumerable<IPlaylist<MediaCue>> playlists)
	{
		PlaylistHelper.Duplicate(this, playlists);
	}

	private void UpdateCoreOfAvailableSmartPlaylists(string? smartPlaylistPathBeingAdded = null)
	{
		IMediaService mediaService = _mediaService;
		IMediaServiceV2 mediaServiceV2 = mediaService as IMediaServiceV2;
		if (mediaServiceV2 == null)
		{
			return;
		}
		HashSet<string> smartPlaylistPaths = new HashSet<string>();
		if (smartPlaylistPathBeingAdded != null)
		{
			smartPlaylistPaths.Add(smartPlaylistPathBeingAdded);
		}
		foreach (IPlaylist<MediaCue> item in base.Collection)
		{
			ProcessPlaylist(item, smartPlaylistPaths);
		}
		if (_existingSmartPlaylistPaths == null || !smartPlaylistPaths.SetEquals(_existingSmartPlaylistPaths))
		{
			_existingSmartPlaylistPaths = smartPlaylistPaths;
			_asyncExecutor.ExecuteAsync(async delegate
			{
				await mediaServiceV2.UpdateAvailableSmartPlaylists(smartPlaylistPaths).ConfigureAwait(continueOnCapturedContext: false);
			});
		}
	}

	private static void ProcessPlaylist(IPlaylist<MediaCue> playlist, HashSet<string> smartPlaylistPaths)
	{
		if (playlist is SmartPlaylist smartPlaylist)
		{
			smartPlaylistPaths.Add(smartPlaylist.TargetPath);
		}
		else
		{
			if (!(playlist is VisualGroupPlaylist visualGroupPlaylist))
			{
				return;
			}
			foreach (IPlaylist<MediaCue> item in visualGroupPlaylist)
			{
				ProcessPlaylist(item, smartPlaylistPaths);
			}
		}
	}

	public Pro.CoreApplication.Document.IDocument? GetDocument()
	{
		if (_syncer == null)
		{
			return null;
		}
		return new PlaylistMediaDocument(_syncer.Document.ExportFullSnapshot(), _syncer.Id);
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
			_syncedData?.Dispose();
			_syncedDataUpdateDelayTimer?.Dispose();
			_syncer?.Dispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		ChangeDirectoryPrompt.UnregisterDelegate(new ChangeDirectoryListener(TeardownDocumentSyncer, SetupDocumentSyncer));
	}
}
