using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Concurrency;
using System.Runtime.CompilerServices;
using Google.Protobuf;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.FeatureFlag;
using Pro.Common.Logging;
using Pro.Common.ObjectBinding;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Utility;
using Pro.CoreApplication.Document;
using Pro.CoreApplication.Document.Intrinsic;
using Pro.DO;
using Pro.DO.Application;
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
using ProPresenter.DO.Librarian;
using ProPresenter.DO.Media;
using ProPresenter.DO.PCO;
using ProPresenter.DO.Workspaces;

namespace ProPresenter.DO.Playlists;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_syncedData", "_syncer" })]
public class LibraryPlaylistCollection : PlaylistCollectionBase<ProPresenterCue>, IDocumentProvider, IDisposable
{
	public interface IChangeTransaction
	{
		void OnChange();
	}

	private sealed class LibraryChangeTransaction(System.Action _whenChangesHappened, System.Action _onEnd) : IDisposable, IChangeTransaction
	{
		private bool _hadChanges;

		public void OnChange()
		{
			_hadChanges = true;
		}

		public void Dispose()
		{
			if (_hadChanges)
			{
				_whenChangesHappened();
			}
			_onEnd();
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass28_0
	{
		public PCOPlaylist pcoPlaylist;

		public GeneralGroupPlaylist parent;

		public GeneralPlaylist playlist;

		public LibraryPlaylistCollection _003C_003E4__this;

		internal void _003CConvertToStandardPlaylist_003Eb__0()
		{
			parent.ReplaceChildPlaylist(playlist, pcoPlaylist);
		}

		internal void _003CConvertToStandardPlaylist_003Eb__1()
		{
			parent.ReplaceChildPlaylist(pcoPlaylist, playlist);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass28_1
	{
		public int index;

		public _003C_003Ec__DisplayClass28_0 CS_0024_003C_003E8__locals1;

		internal void _003CConvertToStandardPlaylist_003Eb__2()
		{
			CS_0024_003C_003E8__locals1._003C_003E4__this.Collection[index] = CS_0024_003C_003E8__locals1.pcoPlaylist;
		}

		internal void _003CConvertToStandardPlaylist_003Eb__3()
		{
			CS_0024_003C_003E8__locals1._003C_003E4__this.Collection[index] = CS_0024_003C_003E8__locals1.playlist;
		}
	}

	[CompilerGenerated]
	private sealed class _003CConvertToStandardPlaylist_003Ed__28 : IEnumerable<GeneralPlaylist>, IEnumerable, IEnumerator<GeneralPlaylist>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private GeneralPlaylist _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public LibraryPlaylistCollection _003C_003E4__this;

		private IEnumerable<PCOPlaylist> pcoPlaylists;

		public IEnumerable<PCOPlaylist> _003C_003E3__pcoPlaylists;

		private IEnumerator<PCOPlaylist> _003C_003E7__wrap1;

		GeneralPlaylist IEnumerator<GeneralPlaylist>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CConvertToStandardPlaylist_003Ed__28(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			int num = _003C_003E1__state;
			if (num == -3 || num == 1)
			{
				try
				{
				}
				finally
				{
					_003C_003Em__Finally1();
				}
			}
			_003C_003E7__wrap1 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			try
			{
				int num = _003C_003E1__state;
				LibraryPlaylistCollection libraryPlaylistCollection = _003C_003E4__this;
				switch (num)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					libraryPlaylistCollection.UndoStack?.BeginCommit(UndoActionTypes.ConvertPCOPlaylist.ToAction());
					_003C_003E7__wrap1 = pcoPlaylists.GetEnumerator();
					_003C_003E1__state = -3;
					break;
				case 1:
					_003C_003E1__state = -3;
					break;
				}
				while (_003C_003E7__wrap1.MoveNext())
				{
					_003C_003Ec__DisplayClass28_0 CS_0024_003C_003E8__locals33 = new _003C_003Ec__DisplayClass28_0();
					CS_0024_003C_003E8__locals33._003C_003E4__this = libraryPlaylistCollection;
					CS_0024_003C_003E8__locals33.pcoPlaylist = _003C_003E7__wrap1.Current;
					CS_0024_003C_003E8__locals33.playlist = CS_0024_003C_003E8__locals33.pcoPlaylist.ConvertToStandardPlaylist(libraryPlaylistCollection.UndoStack, libraryPlaylistCollection._entityFactory, libraryPlaylistCollection._logger, libraryPlaylistCollection._cueFactory);
					if (CS_0024_003C_003E8__locals33.playlist == null)
					{
						continue;
					}
					IPlaylist<ProPresenterCue> playlistParent = CS_0024_003C_003E8__locals33.pcoPlaylist.PlaylistParent;
					CS_0024_003C_003E8__locals33.parent = playlistParent as GeneralGroupPlaylist;
					if (CS_0024_003C_003E8__locals33.parent != null)
					{
						CS_0024_003C_003E8__locals33.parent.ReplaceChildPlaylist(CS_0024_003C_003E8__locals33.pcoPlaylist, CS_0024_003C_003E8__locals33.playlist);
						libraryPlaylistCollection.UndoStack?.Commit(delegate
						{
							CS_0024_003C_003E8__locals33.parent.ReplaceChildPlaylist(CS_0024_003C_003E8__locals33.playlist, CS_0024_003C_003E8__locals33.pcoPlaylist);
						}, delegate
						{
							CS_0024_003C_003E8__locals33.parent.ReplaceChildPlaylist(CS_0024_003C_003E8__locals33.pcoPlaylist, CS_0024_003C_003E8__locals33.playlist);
						});
					}
					else
					{
						_003C_003Ec__DisplayClass28_1 CS_0024_003C_003E8__locals32 = new _003C_003Ec__DisplayClass28_1();
						CS_0024_003C_003E8__locals32.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals33;
						CS_0024_003C_003E8__locals32.index = libraryPlaylistCollection.Collection.IndexOf(CS_0024_003C_003E8__locals32.CS_0024_003C_003E8__locals1.pcoPlaylist);
						if (CS_0024_003C_003E8__locals32.index >= 0 && CS_0024_003C_003E8__locals32.index < libraryPlaylistCollection.Collection.Count)
						{
							libraryPlaylistCollection.Collection[CS_0024_003C_003E8__locals32.index] = CS_0024_003C_003E8__locals32.CS_0024_003C_003E8__locals1.playlist;
							libraryPlaylistCollection.UndoStack?.Commit(delegate
							{
								CS_0024_003C_003E8__locals32.CS_0024_003C_003E8__locals1._003C_003E4__this.Collection[CS_0024_003C_003E8__locals32.index] = CS_0024_003C_003E8__locals32.CS_0024_003C_003E8__locals1.pcoPlaylist;
							}, delegate
							{
								CS_0024_003C_003E8__locals32.CS_0024_003C_003E8__locals1._003C_003E4__this.Collection[CS_0024_003C_003E8__locals32.index] = CS_0024_003C_003E8__locals32.CS_0024_003C_003E8__locals1.playlist;
							});
						}
					}
					_003C_003E2__current = CS_0024_003C_003E8__locals33.playlist;
					_003C_003E1__state = 1;
					return true;
				}
				_003C_003Em__Finally1();
				_003C_003E7__wrap1 = null;
				libraryPlaylistCollection.UndoStack?.EndCommit(null, libraryPlaylistCollection.OnDataModified, autoFinalize: true);
				libraryPlaylistCollection.OnDataModified();
				return false;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void _003C_003Em__Finally1()
		{
			_003C_003E1__state = -1;
			if (_003C_003E7__wrap1 != null)
			{
				_003C_003E7__wrap1.Dispose();
			}
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<GeneralPlaylist> IEnumerable<GeneralPlaylist>.GetEnumerator()
		{
			_003CConvertToStandardPlaylist_003Ed__28 _003CConvertToStandardPlaylist_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CConvertToStandardPlaylist_003Ed__ = this;
			}
			else
			{
				_003CConvertToStandardPlaylist_003Ed__ = new _003CConvertToStandardPlaylist_003Ed__28(0)
				{
					_003C_003E4__this = _003C_003E4__this
				};
			}
			_003CConvertToStandardPlaylist_003Ed__.pcoPlaylists = _003C_003E3__pcoPlaylists;
			return _003CConvertToStandardPlaylist_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<GeneralPlaylist>)this).GetEnumerator();
		}
	}

	private IProtoSyncedData<PlaylistDocument>? _syncedData;

	private readonly IProPresenterResourceService _resourceService;

	private readonly ISyncDataFactory _syncDataFactory;

	private readonly IImportProcessFactory _importProcessFactory;

	private readonly IEntityFactory _entityFactory;

	private readonly ILogger _logger;

	private readonly IProPresenterCueFactory _cueFactory;

	private readonly IMediaFactory _mediaFactory;

	private readonly IUiScheduler _scheduler;

	private readonly IFlagService _flagService;

	private readonly IProPresenterDOFactoryProvider _factoryProvider;

	private readonly IActionBinderFactory _actionBinderFactory;

	private readonly ILibraryCollection _libraryCollection;

	private IChangeTransaction? _dataModificationTransaction;

	private IEntityDocumentSyncer<IPlaylistDocumentDoc>? _syncer;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public Guid DocumentId => _syncer?.Id ?? Guid.Empty;

	private ObjectBinder<LibraryPlaylistCollection, IComplexCollection<IPlaylist>> Bind(IUiScheduler scheduler, IEntityFactory entityFactory, IActionBinderFactory actionBinderFactory, IPlaylistDocument entityDocument)
	{
		entityDocument.Type.Set(IPlaylistDocument.Types.Type.Media);
		IPlaylist.Types.IChildrenType.IPlaylists playlists = entityDocument.RootNode.Value.ChildrenType.Value as IPlaylist.Types.IChildrenType.IPlaylists;
		if (playlists == null)
		{
			playlists = entityFactory.Create<IPlaylist.Types.IChildrenType.IPlaylists>();
			entityDocument.RootNode.Value.ChildrenType.Set(playlists);
		}
		ObjectBinder<LibraryPlaylistCollection, IComplexCollection<IPlaylist>> objectBinder = new ObjectBinder<LibraryPlaylistCollection, IComplexCollection<IPlaylist>>(this, playlists.Value.Playlists);
		objectBinder.Bind((LibraryPlaylistCollection l) => l.WhenCollectionChanges(), (IComplexCollection<IPlaylist> r) => r.WhenCollectionChanges, delegate(LibraryPlaylistCollection l, IComplexCollection<IPlaylist> r)
		{
			r.SynchronizeFrom(l.Items, (IPlaylist<ProPresenterCue> m, IPlaylist e) => m.ID == e.Uuid.Value, delegate(IPlaylist<ProPresenterCue> m)
			{
				IPlaylist playlist = entityFactory.Create<IPlaylist>();
				IReadOnlyObjectBinder<IPlaylist<ProPresenterCue>, IPlaylist> readOnlyObjectBinder = m.Bind(scheduler, entityFactory, actionBinderFactory, playlist);
				readOnlyObjectBinder.InitializeRightFromLeft();
				playlist.RegisterLinkedDisposable(readOnlyObjectBinder);
				return playlist;
			});
		}, delegate(IComplexCollection<IPlaylist> r, LibraryPlaylistCollection l)
		{
			r.Items.SynchronizeTo(l, (IPlaylist e, IPlaylist<ProPresenterCue> m) => m.ID == e.Uuid.Value, delegate(IPlaylist e, int i)
			{
				IPlaylist<ProPresenterCue> playlist2 = ConstructPlaylist(e);
				IReadOnlyObjectBinder<IPlaylist<ProPresenterCue>, IPlaylist> readOnlyObjectBinder2 = playlist2.Bind(scheduler, entityFactory, actionBinderFactory, e);
				readOnlyObjectBinder2.InitializeLeftFromRight();
				e.RegisterLinkedDisposable(readOnlyObjectBinder2);
				l.AddPlaylist(playlist2, null, i);
			}, l.Collection.Move, delegate(int i)
			{
				IPlaylist<ProPresenterCue> playlist3 = l.ElementAtOrDefault(i);
				if (playlist3 != null)
				{
					l.RemovePlaylist(playlist3);
				}
			});
		}, null, scheduler.Scheduler);
		return objectBinder;
	}

	private IPlaylist<ProPresenterCue> ConstructPlaylist(IPlaylist entityPlaylist)
	{
		if (entityPlaylist.ChildrenType.Value is IPlaylist.Types.IChildrenType.IPlaylists)
		{
			return new GeneralGroupPlaylist(_resourceService, _importProcessFactory, _logger, _cueFactory, _mediaFactory, base.UndoStack);
		}
		if (entityPlaylist.LinkData.Value is IPlaylist.Types.ILinkData.IPcoPlan { Value: var value })
		{
			PCOPlan pcoPlan2 = new PCOPlan(string.IsNullOrEmpty(value.ParentIdStr.Value) ? (value.ParentIdNum.Value.ToString() ?? string.Empty) : value.ParentIdStr.Value, string.IsNullOrEmpty(value.PlanIdStr.Value) ? value.PlanIdNum.Value.ToString() : value.PlanIdStr.Value.ToLower(), value.PlanTitle.Value, value.UpdateDate.Value.Seconds.FromUnixTimestamp(), value.DateList.Value, value.SeriesTitle.Value, value.CreatedDate.Value.Seconds.FromUnixTimestamp());
			return new PCOPlaylist(_resourceService, _importProcessFactory, pcoPlan2, base.UndoStack, _cueFactory, _mediaFactory);
		}
		return new GeneralPlaylist(_logger, _cueFactory, base.UndoStack);
	}

	public LibraryPlaylistCollection(IProPresenterResourceService resourceService, ISyncDataFactory syncDataFactory, IImportProcessFactory importProcessFactory, IEntityFactory entityFactory, ILogger logger, IProPresenterCueFactory cueFactory, IMediaFactory mediaFactory, IUiScheduler scheduler, IFlagService flagService, IProPresenterDOFactoryProvider factoryProvider, IActionBinderFactory actionBinderFactory, bool loadLegacy)
		: base((UndoStack?)null)
	{
		_resourceService = resourceService;
		_syncDataFactory = syncDataFactory;
		_importProcessFactory = importProcessFactory;
		_entityFactory = entityFactory;
		_logger = logger;
		_cueFactory = cueFactory;
		_mediaFactory = mediaFactory;
		_scheduler = scheduler;
		_flagService = flagService;
		_factoryProvider = factoryProvider;
		_actionBinderFactory = actionBinderFactory;
		_libraryCollection = resourceService.LibraryCollection;
		SetupDocumentSyncer(loadLegacy);
		ChangeDirectoryPrompt.RegisterDelegate(new ChangeDirectoryListener(TeardownDocumentSyncer, SetupDocumentSyncer));
		_libraryCollection.CollectionChanged += LibraryCollection_CollectionChanged;
		_libraryCollection.ForEach(delegate(ProPresenter.DO.Librarian.ILibrary l)
		{
			l.CollectionChanged += Library_CollectionChanged;
		});
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
			_syncer = _factoryProvider.EntityDocumentSyncerFactory.CreateFileSyncer(CommonPaths.Playlists, "Library", (IPlaylistDocumentDoc doc) => Bind(_scheduler, _factoryProvider.EntityFactory, _actionBinderFactory, doc), () => Serialize().ToByteArray(), delegate(byte[] d)
			{
				Deserialize(PlaylistDocument.Parser.ParseFrom(d));
			}, LoadDefaults, loadLegacy);
		}
		else
		{
			_syncedData = _syncDataFactory.GetSyncedData(CommonPaths.Playlists, "Library", delegate(PlaylistDocument d)
			{
				Deserialize(d);
			}, SyncedDataCleared);
		}
		OnLocationChanged(CommonPaths.Playlists);
		ResolveLibraryChanges(null);
	}

	private void LoadDefaults()
	{
		SyncedDataCleared(DataClearSource.FileRemoved);
	}

	private void LibraryCollection_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.OfType<ProPresenter.DO.Librarian.ILibrary>().ForEach(delegate(ProPresenter.DO.Librarian.ILibrary l)
		{
			l.CollectionChanged -= Library_CollectionChanged;
		});
		e.NewItems?.OfType<ProPresenter.DO.Librarian.ILibrary>().ForEach(delegate(ProPresenter.DO.Librarian.ILibrary l)
		{
			l.CollectionChanged += Library_CollectionChanged;
		});
		if (!_libraryCollection.IsLibraryOperationInProgress)
		{
			DocumentCue[] oldCues = e.OldItems?.OfType<ProPresenter.DO.Librarian.ILibrary>().SelectMany((ProPresenter.DO.Librarian.ILibrary l) => l).ToArray();
			_scheduler.Scheduler.Schedule((System.Action)delegate
			{
				ResolveLibraryChanges(oldCues);
			});
		}
	}

	private void Library_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		if (!_libraryCollection.IsLibraryOperationInProgress)
		{
			ResolveLibraryChanges(e.OldItems?.Cast<DocumentCue>());
		}
	}

	private void ResolveLibraryChanges(IEnumerable<DocumentCue>? oldCues)
	{
		foreach (GeneralPlaylist item in this.GetPlaylists((IPlaylist<ProPresenterCue> p) => p is GeneralPlaylist).Cast<GeneralPlaylist>())
		{
			item.ResolveDeletedDocuments(oldCues);
			item.ResolveMissingDocuments(_libraryCollection);
		}
	}

	public Playlist<ProPresenterCue> AddNewPlaylist(string name = "", GeneralGroupPlaylist? parent = null, int index = -1)
	{
		GeneralPlaylist generalPlaylist = new GeneralPlaylist(_logger, _cueFactory, base.UndoStack, name);
		AddPlaylist(generalPlaylist, parent, index);
		return generalPlaylist;
	}

	public PCOPlaylist AddNewPCOPlaylist(PCOPlan pcoPlan, GeneralGroupPlaylist? parent = null, int index = -1)
	{
		PCOPlaylist pCOPlaylist = new PCOPlaylist(_resourceService, _importProcessFactory, pcoPlan, base.UndoStack, _cueFactory, _mediaFactory);
		AddPlaylist(pCOPlaylist, parent, index);
		return pCOPlaylist;
	}

	public GeneralGroupPlaylist AddNewGroupPlaylist(GeneralGroupPlaylist? parent = null, int index = -1)
	{
		GeneralGroupPlaylist generalGroupPlaylist = new GeneralGroupPlaylist(_resourceService, _importProcessFactory, _logger, _cueFactory, _mediaFactory, base.UndoStack);
		AddPlaylist(generalGroupPlaylist, parent, index);
		return generalGroupPlaylist;
	}

	public void RemovePlaylist(IPlaylist<ProPresenterCue> playlist)
	{
		RemovePlaylists(new global::_003C_003Ez__ReadOnlySingleElementList<IPlaylist<ProPresenterCue>>(playlist));
	}

	[IteratorStateMachine(typeof(_003CConvertToStandardPlaylist_003Ed__28))]
	public IEnumerable<GeneralPlaylist> ConvertToStandardPlaylist(IEnumerable<PCOPlaylist> pcoPlaylists)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CConvertToStandardPlaylist_003Ed__28(-2)
		{
			_003C_003E4__this = this,
			_003C_003E3__pcoPlaylists = pcoPlaylists
		};
	}

	private void SyncedDataCleared(DataClearSource dataClearSource)
	{
		if (dataClearSource == DataClearSource.FileRemoved)
		{
			base.UndoStack?.StartIgnoring();
			RemovePlaylists(base.Collection.ToArray());
			AddNewPlaylist(LocalizedStrings.Get("GLOBAL_DEFAULT"));
			base.UndoStack?.StopIgnoring();
		}
	}

	public void Deserialize(PlaylistDocument? document, bool removeExisting = true)
	{
		if (document?.RootNode?.Playlists?.Playlists == null)
		{
			return;
		}
		ApplicationData applicationData = ApplicationData.Deserialize(document.ApplicationInfo);
		using LibraryChangeTransaction dataModificationTransaction = new LibraryChangeTransaction(delegate
		{
			LibraryPlaylistCollectionUpdated.Publish(this);
		}, delegate
		{
			_dataModificationTransaction = null;
		});
		_dataModificationTransaction = dataModificationTransaction;
		base.UndoStack?.StartIgnoring();
		PlaylistLibraryHelper.DeserializePlaylists(base.Collection, document.RootNode.Playlists.Playlists, base.OnDataModified, base.UndoStack, null, applicationData, _resourceService, _importProcessFactory, _logger, _cueFactory, _mediaFactory, removeExisting);
		base.UndoStack?.StopIgnoring();
	}

	public PlaylistDocument Serialize()
	{
		using LibraryChangeTransaction dataModificationTransaction = new LibraryChangeTransaction(delegate
		{
		}, delegate
		{
			_dataModificationTransaction = null;
		});
		_dataModificationTransaction = dataModificationTransaction;
		PlaylistDocument playlistDocument = new PlaylistDocument();
		playlistDocument.ApplicationInfo = new ApplicationData(ApplicationType.ProPresenter).Serialize();
		playlistDocument.Type = PlaylistDocument.Types.Type.Presentation;
		playlistDocument.RootNode = new Playlist
		{
			Uuid = Guid.NewGuid().ToUUID()
		};
		playlistDocument.RootNode.Type = Playlist.Types.Type.Root;
		playlistDocument.RootNode.Playlists = new Playlist.Types.PlaylistArray();
		playlistDocument.RootNode.Playlists.Playlists.AddRange(base.Collection.Select((IPlaylist<ProPresenterCue> p) => p.ProtoSerialize()));
		return playlistDocument;
	}

	protected override void DataModifiedHook()
	{
		if (_dataModificationTransaction == null)
		{
			_syncedData?.UpdateData(Serialize());
			LibraryPlaylistCollectionUpdated.Publish(this);
		}
		else
		{
			_dataModificationTransaction.OnChange();
		}
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
		return new PlaylistLibraryDocument(_syncer.Document.ExportFullSnapshot(), _syncer.Id);
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
		_libraryCollection.ForEach(delegate(ProPresenter.DO.Librarian.ILibrary l)
		{
			l.CollectionChanged -= Library_CollectionChanged;
		});
		_libraryCollection.CollectionChanged -= LibraryCollection_CollectionChanged;
	}
}
