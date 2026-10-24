using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using Google.Protobuf;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.FeatureFlag;
using Pro.Common.FileSystem;
using Pro.Common.Logging;
using Pro.Common.ObjectBinding;
using Pro.Common.Security;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Strings;
using Pro.Common.Utility;
using Pro.CoreApplication.Document;
using Pro.CoreApplication.Document.Intrinsic;
using Pro.DO.Storage;
using Pro.DO.Triggering;
using Pro.Entity;
using Pro.Entity.Collections;
using Pro.Entity.Extensions;
using Pro.Entity.Persistence;
using Pro.Search;
using Pro.Serialization.DataManagement;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using Pro.UI.DialogService;
using ProPresenter.DO.Analytics.Events.TrackedEvents.DataIdDuplicated;
using ProPresenter.DO.ChangeDirectory;
using ProPresenter.DO.CommonPathsWrapper;
using ProPresenter.DO.Cues;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Extensions;
using ProPresenter.DO.Indexing;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Searching;
using ProPresenter.DO.Workspaces;

namespace ProPresenter.DO.Librarian;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_librariesDirWatcher", "_syncedData", "_metadataCache", "_syncer" })]
public class LibraryCollection : ImmutableObservableCollection<ILibrary>, IDragDropCollection<ProPresenterCue>, IDragDropCollection<ILibrary>, ILibraryCollection, IReadOnlyCollection<ILibrary>, IEnumerable<ILibrary>, IEnumerable, INotifyEnumerableChanged<ILibrary>, INotifyCollectionChanged, INotifyPropertyChanged, IDocumentProvider, IDisposable
{
	private readonly PresentationSearchEngine _searchEngine;

	private readonly IPresentationFactory _presentationFactory;

	private readonly IPresentationCapableSyncDataFactory _syncDataFactory;

	private readonly IDataIdDuplicatedEventPublisher _dataIdDuplicatedEvent;

	private readonly IFileWatcherFactory _watcherFactory;

	private readonly IFileSystem _fileSystem;

	private readonly IMessageDialogService _messageDialogService;

	private readonly IFlagService _flagService;

	private readonly IProPresenterDOFactoryProvider _factoryProvider;

	private readonly IUiScheduler _scheduler;

	private readonly ICommonPathsWrapper _commonPathsWrapper;

	private readonly ICollectionStorage _collectionStorage;

	private readonly IActionBinderFactory _actionBinderFactory;

	private readonly bool _loadLegacy;

	private IFileWatcher? _librariesDirWatcher;

	private IProtoSyncedData<Pro.SerializationInterop.RVProtoData.Library>? _syncedData;

	private IPresentationMetadataCache _metadataCache;

	private IEntityDocumentSyncer<ILibraryDoc>? _syncer;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public bool IsLibraryOperationInProgress { get; private set; }

	public UndoStack UndoStack { get; } = new UndoStack();

	public Guid DocumentId => _syncer?.Id ?? Guid.Empty;

	public event Action<ILibrary>? LibraryNameChanged;

	public event Action<ILibrary, NotifyCollectionChangedEventArgs>? LibraryCollectionChanged;

	public event Action<ProPresenter.DO.Presentation.IPresentation>? PresentationNameChanged;

	public event Action<string>? LocationChanged;

	public ObjectBinder<LibraryCollection, IComplexCollection<Pro.Entity.ILibrary>> Bind(Pro.Entity.ILibrary entity)
	{
		Pro.Entity.ILibrary.Types.IChildType.ILibraryChildren libraryChildren = entity.ChildType.Value as Pro.Entity.ILibrary.Types.IChildType.ILibraryChildren;
		if (libraryChildren == null)
		{
			libraryChildren = _factoryProvider.EntityFactory.Create<Pro.Entity.ILibrary.Types.IChildType.ILibraryChildren>();
			entity.ChildType.Set(libraryChildren);
		}
		ObjectBinder<LibraryCollection, IComplexCollection<Pro.Entity.ILibrary>> objectBinder = new ObjectBinder<LibraryCollection, IComplexCollection<Pro.Entity.ILibrary>>(this, libraryChildren.Value.Libraries);
		objectBinder.Bind((LibraryCollection l) => l.Collection.WhenCollectionChanges(), (IComplexCollection<Pro.Entity.ILibrary> r) => r.WhenCollectionChanges, delegate(LibraryCollection l, IComplexCollection<Pro.Entity.ILibrary> r)
		{
			r.SynchronizeFrom(l.Collection, (ILibrary m, Pro.Entity.ILibrary e) => m.Name == RelativePath.Create(e.Url.Value, out URL _).Filename, delegate(ILibrary m)
			{
				Pro.Entity.ILibrary library = _factoryProvider.EntityFactory.Create<Pro.Entity.ILibrary>();
				ObjectBinder<Library, Pro.Entity.ILibrary> objectBinder2 = m.Bind(library);
				objectBinder2.InitializeRightFromLeft();
				library.RegisterLinkedDisposable(objectBinder2);
				return library;
			});
		}, delegate(IComplexCollection<Pro.Entity.ILibrary> r, LibraryCollection l)
		{
			r.Items.SynchronizeTo(l.Collection, (Pro.Entity.ILibrary e, ILibrary m) => RelativePath.Create(e.Url.Value, out URL _).Filename == m?.Name, delegate(Pro.Entity.ILibrary e, int i)
			{
				URL protoUrl3;
				RelativePath relativePath = RelativePath.Create(e.Url.Value, out protoUrl3);
				string text = _fileSystem.Path.Combine(_commonPathsWrapper.Libraries, relativePath.Filename);
				if (!_fileSystem.Directory.Exists(text))
				{
					try
					{
						_fileSystem.Directory.CreateDirectory(text);
					}
					catch
					{
						Log.Error("Failed to create directory at path: " + text);
						return;
					}
				}
				Library library2 = CreateLibrary(text);
				ObjectBinder<Library, Pro.Entity.ILibrary> objectBinder3 = library2.Bind(e);
				objectBinder3.InitializeLeftFromRight();
				e.RegisterLinkedDisposable(objectBinder3);
				l.Insert(library2, i);
			}, l.Collection.Move, delegate(int i)
			{
				ILibrary library3 = l.Collection[i];
				l.Remove(library3);
			});
		}, null, _scheduler.Scheduler);
		return objectBinder;
	}

	public LibraryCollection(IPresentationFactory presentationFactory, IIndexingService indexingService, IPresentationCapableSyncDataFactory syncDataFactory, IDataIdDuplicatedEventPublisher dataIdDuplicatedEvent, IFileWatcherFactory watcherFactory, IFileSystem fileSystem, IUiDispatcher uiDispatcher, IMessageDialogService messageDialogService, IFlagService flagService, IProPresenterDOFactoryProvider factoryProvider, IUiScheduler scheduler, ICommonPathsWrapper commonPathsWrapper, ICollectionStorage collectionStorage, IActionBinderFactory actionBinderFactory, bool loadLegacy, string? searchEngineStoragePath = null)
	{
		_presentationFactory = presentationFactory;
		_syncDataFactory = syncDataFactory;
		_dataIdDuplicatedEvent = dataIdDuplicatedEvent;
		_watcherFactory = watcherFactory;
		_fileSystem = fileSystem;
		_messageDialogService = messageDialogService;
		_flagService = flagService;
		_factoryProvider = factoryProvider;
		_scheduler = scheduler;
		_commonPathsWrapper = commonPathsWrapper;
		_collectionStorage = collectionStorage;
		_actionBinderFactory = actionBinderFactory;
		_loadLegacy = loadLegacy;
		_searchEngine = new PresentationSearchEngine(indexingService, uiDispatcher, searchEngineStoragePath);
		SetupDocumentSyncer(loadLegacy);
		ChangeDirectoryPrompt.RegisterDelegate(new ChangeDirectoryListener(TeardownDocumentSyncer, SetupDocumentSyncer));
		base.CollectionChanged += delegate
		{
			UpdateSyncedData();
		};
	}

	private void TeardownDocumentSyncer()
	{
		IsLibraryOperationInProgress = true;
		_metadataCache.Dispose();
		_librariesDirWatcher?.Dispose();
		_syncedData?.Dispose();
		_syncer?.Dispose();
		_librariesDirWatcher = null;
		_syncedData = null;
		_syncer = null;
		base.Collection.ToArray().ForEach(delegate(ILibrary l)
		{
			Remove(l, moveToRecycleBin: false);
		});
	}

	[MemberNotNull("_metadataCache")]
	private void SetupDocumentSyncer(bool loadLegacy)
	{
		IsLibraryOperationInProgress = true;
		_metadataCache = new PresentationMetadataCache(new PresentationMetadataRepository(GetPresentationMetadataCacheFolder()));
		if (_flagService.IsFlagEnabled(Flag.Cloud))
		{
			_syncer = _factoryProvider.EntityDocumentSyncerFactory.CreateFileSyncer<ILibraryDoc>(CommonPaths.Libraries, "LibraryData", Bind, () => Serialize().ToByteArray(), delegate(byte[] d)
			{
				OnSyncedDataUpdated(Pro.SerializationInterop.RVProtoData.Library.Parser.ParseFrom(d));
			}, LoadDefaults, loadLegacy);
		}
		else
		{
			_librariesDirWatcher = _watcherFactory.Create(CommonPaths.Base);
			_librariesDirWatcher.NotifyFilter = NotifyFilters.DirectoryName;
			_librariesDirWatcher.Deleted += delegate(object _, FileSystemEventArgs args)
			{
				if (args.FullPath == CommonPaths.Libraries)
				{
					OnSyncedDataCleared(DataClearSource.FileRemoved);
					_fileSystem.Directory.CreateDirectory(CommonPaths.Libraries);
					Add("Default");
				}
			};
			_librariesDirWatcher.EnableRaisingEvents = true;
			_syncedData = _syncDataFactory.GetSyncedData<Pro.SerializationInterop.RVProtoData.Library>(CommonPaths.Libraries, "LibraryData", OnSyncedDataUpdated, OnSyncedDataCleared);
			InitializeDirectories();
		}
		IPresentationLoadData[] presentationData = this.SelectMany((ILibrary library) => from c in library
			where c.DocumentAction.Presentation != null
			select c into cue
			select library.GetPresentationLoadData(cue.DocumentAction.Presentation)).ToArray();
		_searchEngine.RemoveOrphanedIndices(presentationData);
		_searchEngine.IndexNonIndexedItems(presentationData);
		IsLibraryOperationInProgress = false;
		this.LocationChanged?.Invoke(CommonPaths.Libraries);
	}

	private void LoadDefaults()
	{
		OnSyncedDataCleared(DataClearSource.FileRemoved);
		InitializeDirectories();
	}

	private static string GetPresentationMetadataCacheFolder()
	{
		return Path.Combine(CommonPaths.Temp, "Metadata", CommonPaths.Libraries.Hash());
	}

	private void InitializeDirectories()
	{
		_fileSystem.Directory.CreateDirectory(CommonPaths.Libraries);
		ResolveDirectories();
		if (this.Empty())
		{
			Add("Default");
		}
	}

	public ILibrary Add(string name)
	{
		name = name.DuplicateName(_fileSystem.Directory.GetFileSystemEntries(CommonPaths.Libraries), Path.GetFileNameWithoutExtension);
		Library library = CreateLibrary(Path.Combine(CommonPaths.Libraries, name).NormalizePath());
		Add(library);
		return library;
	}

	private void Add(ILibrary library)
	{
		Insert(library, base.Collection.Count);
	}

	public void Insert(ILibrary library, int index)
	{
		if (library is Library library2)
		{
			Log.Info("Adding library [{0}] to collection...", library.Name);
			library.UndoStack = UndoStack;
			library2.CollectionChanged += Library_CollectionChanged;
			library2.NameChanged += RenameLibrary;
			library2.PresentationNameChanged += Presentation_NameChanged;
			library2.PresentationDataChanged += Presentation_DataChanged;
			base.Collection.Insert(index, library2);
		}
	}

	private void Presentation_NameChanged(ProPresenter.DO.Presentation.IPresentation presentation)
	{
		this.PresentationNameChanged?.Invoke(presentation);
	}

	private void Presentation_DataChanged(IPresentationLoadData? presentationData)
	{
		if (presentationData != null)
		{
			_searchEngine.IndexPresentation(presentationData);
		}
	}

	public void ResolveDirectories()
	{
		Log.Info("Building library collection...");
		string[] directories;
		try
		{
			directories = _fileSystem.Directory.GetDirectories(CommonPaths.Libraries, "*.*", SearchOption.TopDirectoryOnly);
		}
		catch (Exception value)
		{
			Log.Info($"Unable to enumerate folders in {CommonPaths.Libraries} with error: {value}");
			return;
		}
		DirectoryInfo[] directories2 = directories.Select((string d) => new DirectoryInfo(d)).ToArray();
		DirectoryInfo[] array = directories2.Where((DirectoryInfo d) => !this.Select((ILibrary l) => l.Name).Contains(d.Name)).ToArray();
		foreach (DirectoryInfo directoryInfo in array)
		{
			Add(CreateLibrary(directoryInfo.FullName.NormalizePath()));
		}
		ILibrary[] array2 = this.Where((ILibrary l) => !directories2.Select((DirectoryInfo d) => d.Name).Contains(l.Name)).ToArray();
		foreach (ILibrary library in array2)
		{
			Remove(library);
		}
	}

	private void RenameLibrary(Library library, string name)
	{
		if (library.TryRename(name))
		{
			UpdateSyncedData();
			this.LibraryNameChanged?.Invoke(library);
		}
	}

	private bool ValidateLibraryName(string name)
	{
		return LibraryHelper.ValidateName(CommonPaths.Libraries, _messageDialogService.ShowAlert, name);
	}

	private bool ValidatePresentationID(Guid id)
	{
		return !this.SelectMany((ILibrary l) => l.Select((DocumentCue p) => p.ID)).Contains(id);
	}

	private void UpdateSyncedData()
	{
		Pro.SerializationInterop.RVProtoData.Library data = Serialize();
		_syncedData?.UpdateData(data);
	}

	private void Library_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.Cast<DocumentCue>().ForEach(_searchEngine.RemoveIndex);
		(from DocumentCue c in e.NewItems?
			where c.DocumentAction.Presentation != null
			select c).ForEach(delegate(DocumentCue item)
		{
			IPresentationLoadData presentationLoadData = this.Select((ILibrary lib) => lib.GetPresentationLoadData(item.DocumentAction.Presentation)).FirstOrDefault((IPresentationLoadData d) => d != null);
			if (presentationLoadData != null)
			{
				_searchEngine.IndexPresentation(presentationLoadData);
			}
		});
		if (sender is Library arg)
		{
			this.LibraryCollectionChanged?.Invoke(arg, e);
		}
	}

	public void Remove(ILibrary library, bool moveToRecycleBin = true)
	{
		if (!(library is Library library2))
		{
			return;
		}
		library2.CollectionChanged -= Library_CollectionChanged;
		library2.NameChanged -= RenameLibrary;
		library2.PresentationNameChanged -= Presentation_NameChanged;
		library2.PresentationDataChanged -= Presentation_DataChanged;
		foreach (DocumentCue item in library)
		{
			_searchEngine.RemoveIndex(item);
		}
		library2.Dispose();
		base.Collection.Remove(library);
		if (moveToRecycleBin)
		{
			FileHelper.MoveToRecycleBin(library.Location);
		}
	}

	private Pro.SerializationInterop.RVProtoData.Library Serialize()
	{
		Pro.SerializationInterop.RVProtoData.Library library = new Pro.SerializationInterop.RVProtoData.Library
		{
			LibraryChildren = new Pro.SerializationInterop.RVProtoData.Library.Types.LibraryArray()
		};
		foreach (ILibrary item in base.Collection)
		{
			library.LibraryChildren.Libraries.Add(new Pro.SerializationInterop.RVProtoData.Library
			{
				Url = item.Location.Serialize()
			});
		}
		return library;
	}

	private void OnSyncedDataUpdated(Pro.SerializationInterop.RVProtoData.Library protoLibrary)
	{
		Log.Info("Deserializing proto library data...");
		base.Collection.DeserializeCollection(protoLibrary.LibraryChildren.Libraries.Where((Pro.SerializationInterop.RVProtoData.Library l) => new RelativePath(l.Url).IsValid), (ILibrary l, Pro.SerializationInterop.RVProtoData.Library p) => l.Name == new RelativePath(p.Url).Filename, (Pro.SerializationInterop.RVProtoData.Library p) => CreateLibrary(new RelativePath(p.Url)), Add, delegate(ILibrary l)
		{
			Remove(l);
		}, delegate
		{
		});
	}

	private void OnSyncedDataCleared(DataClearSource dataClearSource)
	{
		base.Collection.ToArray().ForEach(delegate(ILibrary l)
		{
			Remove(l, dataClearSource == DataClearSource.FileRemoved);
		});
	}

	public void CommitAllInWriteQueue()
	{
		foreach (ILibrary item in base.Collection)
		{
			item.CommitAllInWriteQueue();
		}
	}

	public void MoveTo(ILibrary targetLibrary, IEnumerable<DocumentCue> cues, ref bool overwrite, ref bool isCopying)
	{
		MoveTo(null, targetLibrary, cues, ref overwrite, ref isCopying);
	}

	public void MoveTo(ILibrary? sourceLibrary, ILibrary targetLibrary, IEnumerable<DocumentCue> cues, ref bool overwrite, ref bool isCopying)
	{
		IsLibraryOperationInProgress = true;
		UndoStack.BeginCommit(UndoActionTypes.MovePresentation.ToAction());
		foreach (DocumentCue cue in cues.Where((DocumentCue c) => c.DocumentAction.Presentation != null))
		{
			ProPresenter.DO.Presentation.IPresentation presentation = cue.DocumentAction.Presentation;
			if (overwrite)
			{
				targetLibrary.Remove(targetLibrary.FirstOrDefault((DocumentCue d) => d.DocumentAction.Presentation != null && d.DocumentAction.Presentation.Name == presentation.Name));
			}
			if (isCopying)
			{
				targetLibrary.Add(presentation.Clone(), userInitiated: true);
				continue;
			}
			(sourceLibrary ?? base.Collection.First((ILibrary l) => l.Name == cue.LibraryName)).Remove(cue);
			targetLibrary.Add(cue, userInitiated: true);
		}
		UndoStack.EndCommit(null, null, autoFinalize: true);
		IsLibraryOperationInProgress = false;
	}

	public int IndexOf(IDocumentCue item)
	{
		if ((object)item.Path == null)
		{
			return -1;
		}
		DocumentCue libraryToFind = FindDocument(new RelativePath(item.Path));
		foreach (ILibrary item2 in base.Collection)
		{
			int num = item2.FindIndex((DocumentCue x) => x == libraryToFind);
			if (num >= 0)
			{
				return num;
			}
		}
		return -1;
	}

	public IEnumerable<DocumentCue> Search(string term, IEnumerable<DocumentCue> libraries)
	{
		return (from r in _searchEngine.Search(term, libraries)
			select r.Item).NotNull() ?? Array.Empty<DocumentCue>();
	}

	public DocumentCue? FindDocument(RelativePath? path)
	{
		ILibrary library;
		return FindDocument(path, out library);
	}

	public DocumentCue? FindDocument(RelativePath? path, out ILibrary? library)
	{
		try
		{
			if ((object)path != null && path.FullPath != null)
			{
				return FindDocument(path.FullPath.GetDirectoryNameWithoutPath() ?? string.Empty, path.Name, out library);
			}
		}
		catch (Exception exception)
		{
			Log.Error(exception);
		}
		Log.Error("Error finding a document with path \"" + (((object)path != null) ? ((string)path) : string.Empty) + "\"");
		library = null;
		return null;
	}

	public DocumentCue? FindDocument(string libraryName, string cueName, out ILibrary? library)
	{
		library = FindLibrary(libraryName);
		return FindDocument(library, cueName);
	}

	public ILibrary? FindLibrary(string libraryName)
	{
		return this.FirstOrDefault((ILibrary l) => l.Name == libraryName);
	}

	public static DocumentCue? FindDocument(ILibrary? library, string cueName)
	{
		return library?.FirstOrDefault((DocumentCue l) => l.Name == cueName);
	}

	void IDragDropCollection<ILibrary>.DraggedFrom(IEnumerable<ILibrary> items)
	{
		throw new NotSupportedException();
	}

	void IDragDropCollection<ILibrary>.DroppedInto(IEnumerable<ILibrary> items, int index, bool isCopy)
	{
		throw new NotSupportedException();
	}

	void IDragDropCollection<ILibrary>.MoveTo(IEnumerable<ILibrary> items, int index)
	{
		IsLibraryOperationInProgress = true;
		base.Collection.MoveTo(items, index);
		IsLibraryOperationInProgress = false;
	}

	void IDragDropCollection<ProPresenterCue>.DraggedFrom(IEnumerable<ProPresenterCue> items)
	{
		throw new NotSupportedException();
	}

	public void DroppedInto(IEnumerable<ProPresenterCue> items, int index, bool isCopy)
	{
		base.Collection.ElementAtOrDefault(index)?.DroppedInto(items, index, isCopy);
	}

	void IDragDropCollection<ProPresenterCue>.MoveTo(IEnumerable<ProPresenterCue> items, int index)
	{
		throw new NotSupportedException();
	}

	int IDragDropCollection<ProPresenterCue>.IndexOf(ProPresenterCue item)
	{
		throw new NotImplementedException();
	}

	private Library CreateLibrary(string path)
	{
		return new Library(_metadataCache, path, _commonPathsWrapper, _collectionStorage, _fileSystem, _presentationFactory, _syncDataFactory, _dataIdDuplicatedEvent, _flagService, _factoryProvider, _scheduler, _actionBinderFactory, _loadLegacy, ValidateLibraryName, ValidatePresentationID);
	}

	public Pro.CoreApplication.Document.IDocument? GetDocument()
	{
		if (_syncer == null)
		{
			return null;
		}
		return new LibraryDataDocument(_syncer.Document.ExportFullSnapshot(), _syncer.Id);
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
			_librariesDirWatcher?.Dispose();
			_syncedData?.Dispose();
			_metadataCache.Dispose();
			_syncer?.Dispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		ChangeDirectoryPrompt.UnregisterDelegate(new ChangeDirectoryListener(TeardownDocumentSyncer, SetupDocumentSyncer));
	}
}
