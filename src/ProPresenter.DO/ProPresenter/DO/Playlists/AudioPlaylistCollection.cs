using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Google.Protobuf;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.FeatureFlag;
using Pro.Common.ObjectBinding;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Utility;
using Pro.CoreApplication.Document;
using Pro.CoreApplication.Document.Intrinsic;
using Pro.DO;
using Pro.DO.Application;
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
using ProPresenter.DO.Import;
using ProPresenter.DO.Media;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Workspaces;

namespace ProPresenter.DO.Playlists;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_syncedData", "_syncer" })]
public class AudioPlaylistCollection : PlaylistCollectionBase<MediaCue>, IDocumentProvider, IDisposable
{
	private IProtoSyncedData<PlaylistDocument>? _syncedData;

	private readonly IApp _app;

	private readonly IAsyncFileImporter _importer;

	private readonly IMediaFactory _mediaFactory;

	private readonly ITransitionDescriptionCollection _transitionDescriptions;

	private readonly ISyncDataFactory _syncDataFactory;

	private readonly IProPresenterDOFactoryProvider _factoryProvider;

	private readonly IUiScheduler _scheduler;

	private readonly IActionBinderFactory _actionBinderFactory;

	private IEntityDocumentSyncer<IPlaylistDocumentDoc>? _syncer;

	private readonly IFlagService _flagService;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public Guid DocumentId => _syncer?.Id ?? Guid.Empty;

	private ObjectBinder<AudioPlaylistCollection, IComplexCollection<IPlaylist>> Bind(IUiScheduler scheduler, IEntityFactory entityFactory, IActionBinderFactory actionBinderFactory, IPlaylistDocument entityDocument)
	{
		entityDocument.Type.Set(IPlaylistDocument.Types.Type.Audio);
		IPlaylist.Types.IChildrenType.IPlaylists playlists = entityDocument.RootNode.Value.ChildrenType.Value as IPlaylist.Types.IChildrenType.IPlaylists;
		if (playlists == null)
		{
			playlists = entityFactory.Create<IPlaylist.Types.IChildrenType.IPlaylists>();
			entityDocument.RootNode.Value.ChildrenType.Set(playlists);
		}
		ObjectBinder<AudioPlaylistCollection, IComplexCollection<IPlaylist>> objectBinder = new ObjectBinder<AudioPlaylistCollection, IComplexCollection<IPlaylist>>(this, playlists.Value.Playlists);
		objectBinder.Bind((AudioPlaylistCollection l) => l.WhenCollectionChanges(), (IComplexCollection<IPlaylist> r) => r.WhenCollectionChanges, delegate(AudioPlaylistCollection l, IComplexCollection<IPlaylist> r)
		{
			r.SynchronizeFrom(l.Items, (IPlaylist<MediaCue> m, IPlaylist e) => m.ID == e.Uuid.Value, delegate(IPlaylist<MediaCue> m)
			{
				IPlaylist playlist = entityFactory.Create<IPlaylist>();
				IReadOnlyObjectBinder<IPlaylist<MediaCue>, IPlaylist> readOnlyObjectBinder = m.Bind(scheduler, entityFactory, actionBinderFactory, playlist);
				readOnlyObjectBinder.InitializeRightFromLeft();
				playlist.RegisterLinkedDisposable(readOnlyObjectBinder);
				return playlist;
			});
		}, delegate(IComplexCollection<IPlaylist> r, AudioPlaylistCollection l)
		{
			r.Items.SynchronizeTo(l, (IPlaylist e, IPlaylist<MediaCue> m) => m.ID == e.Uuid.Value, delegate(IPlaylist e, int i)
			{
				IPlaylist<MediaCue> playlist2 = ConstructPlaylist(e);
				IReadOnlyObjectBinder<IPlaylist<MediaCue>, IPlaylist> readOnlyObjectBinder2 = playlist2.Bind(scheduler, entityFactory, actionBinderFactory, e);
				readOnlyObjectBinder2.InitializeLeftFromRight();
				e.RegisterLinkedDisposable(readOnlyObjectBinder2);
				l.AddPlaylist(playlist2, null, i);
			}, l.Collection.Move, delegate(int i)
			{
				IPlaylist<MediaCue> playlist3 = l.ElementAtOrDefault(i);
				if (playlist3 != null)
				{
					l.RemovePlaylists(new global::_003C_003Ez__ReadOnlySingleElementList<IPlaylist<MediaCue>>(playlist3));
				}
			});
		}, null, scheduler.Scheduler);
		return objectBinder;
	}

	private IPlaylist<MediaCue> ConstructPlaylist(IPlaylist entityPlaylist)
	{
		if (entityPlaylist.ChildrenType.Value is IPlaylist.Types.IChildrenType.IPlaylists)
		{
			return new AudioGroupPlaylist(base.UndoStack, _app, _importer, _mediaFactory, _transitionDescriptions, _flagService);
		}
		return new AudioPlaylist(_app, _importer, _mediaFactory, _transitionDescriptions, _flagService, base.UndoStack);
	}

	public AudioPlaylistCollection(IApp app, IAsyncFileImporter importer, IMediaFactory mediaFactory, ITransitionDescriptionCollection transitionDescriptions, ISyncDataFactory syncDataFactory, IFlagService flagService, IProPresenterDOFactoryProvider factoryProvider, IUiScheduler scheduler, IActionBinderFactory actionBinderFactory, bool loadLegacy)
		: base((UndoStack?)null)
	{
		_app = app;
		_importer = importer;
		_mediaFactory = mediaFactory;
		_transitionDescriptions = transitionDescriptions;
		_syncDataFactory = syncDataFactory;
		_factoryProvider = factoryProvider;
		_scheduler = scheduler;
		_actionBinderFactory = actionBinderFactory;
		_flagService = flagService;
		SetupDocumentSyncer(loadLegacy);
		ChangeDirectoryPrompt.RegisterDelegate(new ChangeDirectoryListener(TeardownDocumentSyncer, SetupDocumentSyncer));
	}

	private void TeardownDocumentSyncer()
	{
		_syncer?.Dispose();
		_syncedData?.Dispose();
		_syncer = null;
		_syncedData = null;
	}

	private void SetupDocumentSyncer(bool loadLegacy)
	{
		if (_flagService.IsFlagEnabled(Flag.Cloud))
		{
			_syncer = _factoryProvider.EntityDocumentSyncerFactory.CreateFileSyncer(CommonPaths.Playlists, "Audio", (IPlaylistDocumentDoc doc) => Bind(_scheduler, _factoryProvider.EntityFactory, _actionBinderFactory, doc), () => Serialize().ToByteArray(), delegate(byte[] d)
			{
				Deserialize(PlaylistDocument.Parser.ParseFrom(d));
			}, LoadDefaults, loadLegacy);
		}
		else
		{
			_syncedData = _syncDataFactory.GetSyncedData(CommonPaths.Playlists, "Audio", delegate(PlaylistDocument d)
			{
				Deserialize(d);
			}, SyncedDataCleared);
		}
		OnLocationChanged(CommonPaths.Playlists);
	}

	private void LoadDefaults()
	{
		SyncedDataCleared(DataClearSource.FileRemoved);
	}

	public AudioPlaylist AddNewPlaylist(string name = "", AudioGroupPlaylist? parent = null, int index = -1)
	{
		AudioPlaylist audioPlaylist = new AudioPlaylist(_app, _importer, _mediaFactory, _transitionDescriptions, _flagService, base.UndoStack, name);
		AddPlaylist(audioPlaylist, parent, index);
		return audioPlaylist;
	}

	public AudioGroupPlaylist AddNewGroupPlaylist(AudioGroupPlaylist? parent = null, int index = -1)
	{
		AudioGroupPlaylist audioGroupPlaylist = new AudioGroupPlaylist(base.UndoStack, _app, _importer, _mediaFactory, _transitionDescriptions, _flagService);
		AddPlaylist(audioGroupPlaylist, parent, index);
		return audioGroupPlaylist;
	}

	public void Remove(IPlaylist<MediaCue> playlist)
	{
		RemovePlaylists(new IPlaylist<MediaCue>[1] { playlist });
	}

	private void SyncedDataCleared(DataClearSource dataClearSource)
	{
		if (dataClearSource == DataClearSource.FileRemoved)
		{
			base.UndoStack?.StartIgnoring();
			RemovePlaylists(base.Collection.ToArray());
			AddNewPlaylist(LocalizedStrings.Get("GLOBAL_DEFAULT"), null, 0);
			base.UndoStack?.StopIgnoring();
		}
	}

	public void Deserialize(PlaylistDocument document, bool removeExisting = true)
	{
		ApplicationData applicationData = ApplicationData.Deserialize(document?.ApplicationInfo);
		base.UndoStack?.StartIgnoring();
		ObservableCollection<IPlaylist<MediaCue>> collection = base.Collection;
		IEnumerable<Playlist> enumerable = document?.RootNode?.Playlists?.Playlists;
		AudioBinHelper.DeserializePlaylists(collection, enumerable ?? Enumerable.Empty<Playlist>(), base.OnDataModified, base.UndoStack, null, applicationData, _app, _importer, _mediaFactory, _transitionDescriptions, _flagService, removeExisting);
		base.UndoStack?.StopIgnoring();
	}

	public PlaylistDocument Serialize()
	{
		PlaylistDocument playlistDocument = new PlaylistDocument();
		playlistDocument.ApplicationInfo = new ApplicationData(ApplicationType.ProPresenter).Serialize();
		playlistDocument.Type = PlaylistDocument.Types.Type.Audio;
		playlistDocument.RootNode = new Playlist
		{
			Uuid = Guid.NewGuid().ToUUID()
		};
		playlistDocument.RootNode.Type = Playlist.Types.Type.Root;
		playlistDocument.RootNode.Playlists = new Playlist.Types.PlaylistArray();
		playlistDocument.RootNode.Playlists.Playlists.AddRange(base.Collection.Select((IPlaylist<MediaCue> p) => p.ProtoSerialize()));
		return playlistDocument;
	}

	protected override void DataModifiedHook()
	{
		_syncedData?.UpdateData(Serialize());
		AudioPlaylistCollectionUpdated.Publish(this);
	}

	protected override P? GetNewPlaylist<P>()
	{
		return AddNewPlaylist() as P;
	}

	public Pro.CoreApplication.Document.IDocument? GetDocument()
	{
		if (_syncer == null)
		{
			return null;
		}
		return new PlaylistAudioDocument(_syncer.Document.ExportFullSnapshot(), _syncer.Id);
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
			_syncer?.Dispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		ChangeDirectoryPrompt.UnregisterDelegate(new ChangeDirectoryListener(TeardownDocumentSyncer, SetupDocumentSyncer));
	}
}
