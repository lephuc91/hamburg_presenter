using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.IO.Abstractions;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.FeatureFlag;
using Pro.Common.FileSystem;
using Pro.Common.Nullability;
using Pro.Common.ObjectBinding;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Strings;
using Pro.Common.Utility;
using Pro.DO.Storage;
using Pro.DO.Triggering;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Persistence;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Analytics.Events.TrackedEvents.DataIdDuplicated;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.CommonPathsWrapper;
using ProPresenter.DO.Cues;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Events;
using ProPresenter.DO.Media;
using ProPresenter.DO.Presentation;

namespace ProPresenter.DO.Librarian;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_syncer" })]
public class Library : ImmutableObservableCollection<DocumentCue>, ILibrary, IImmutableObservableCollection<DocumentCue>, IReadOnlyList<DocumentCue>, IEnumerable<DocumentCue>, IEnumerable, IReadOnlyCollection<DocumentCue>, INotifyEnumerableChanged<DocumentCue>, INotifyCollectionChanged, IDragDropCollection<ProPresenterCue>, ICutPasteCollection<ProPresenterCue>, ICutCollection<ProPresenterCue>, IIdentifiable, INotifyPropertyChanged, IDisposable
{
	private sealed record IdRewriteData(PresentationAndLoadData PresentationAndLoadData, DataType Type, int DuplicateCount);

	private readonly IPresentationMetadataCache _metadataCache;

	private readonly ICommonPathsWrapper _commonPathsWrapper;

	private readonly ICollectionStorage _collectionStorage;

	private readonly IFileSystem _fileSystem;

	private readonly IPresentationFactory _presentationFactory;

	private readonly IPresentationCapableSyncDataFactory _syncDataFactory;

	private readonly IDataIdDuplicatedEventPublisher _analyticEvent;

	private readonly IProPresenterDOFactoryProvider _factoryProvider;

	private readonly IUiScheduler _scheduler;

	private readonly IActionBinderFactory _actionBinderFactory;

	private readonly Predicate<string> _validateName;

	private readonly Predicate<Guid> _validateID;

	private readonly List<IdRewriteData> _idRewrites = new List<IdRewriteData>();

	private readonly List<PresentationAndLoadData> _needsSanitation = new List<PresentationAndLoadData>();

	private string _name;

	private IPresentationDataSyncer _syncer;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public string Name
	{
		get
		{
			return _name;
		}
		set
		{
			if (_name != value && _validateName(value))
			{
				string oldName = _name;
				string newName = value;
				Action<string> setName = delegate(string s)
				{
					_name = s;
					OnPropertyChanged("Name");
					this.NameChanged?.Invoke(this, _name);
				};
				setName(newName);
				UndoStack?.Commit(UndoActionTypes.RenameLibrary.ToAction(), delegate
				{
					setName(oldName);
				}, delegate
				{
					setName(newName);
				}, null, null, autoFinalize: true);
			}
		}
	}

	public RelativePath Location { get; private set; }

	public UndoStack? UndoStack { get; set; }

	public IList<DocumentCue> SortedItems
	{
		get
		{
			List<DocumentCue> obj = this.ToList();
			obj.Sort(new NaturalStringComparer<DocumentCue>((DocumentCue? d) => d?.Name ?? string.Empty));
			return obj;
		}
	}

	public Guid ID { get; } = Guid.NewGuid();

	internal event Action<Library, string>? NameChanged;

	internal event Action<ProPresenter.DO.Presentation.IPresentation>? PresentationNameChanged;

	internal event Action<IPresentationLoadData?>? PresentationDataChanged;

	public event Action<Pro.DO.Triggering.Cue>? CueUpdated;

	public event Action<ILibrary, DocumentCue>? PresentationRemovedBySync;

	public ObjectBinder<Library, Pro.Entity.ILibrary> Bind(Pro.Entity.ILibrary entity)
	{
		ObjectBinder<Library, Pro.Entity.ILibrary> objectBinder = new ObjectBinder<Library, Pro.Entity.ILibrary>(this, entity);
		objectBinder.Bind((Library l) => l.WhenPropertyChanges("Location"), (Pro.Entity.ILibrary r) => r.Url.WhenValueChanges, delegate(Library l, Pro.Entity.ILibrary r)
		{
			r.Url.Set(RelativePath.Create(l.Location));
		}, delegate(Pro.Entity.ILibrary r, Library l)
		{
			l.Name = RelativePath.Create(r.Url.Value, out URL _).Filename;
		});
		return objectBinder;
	}

	public Library(IPresentationMetadataCache metadataCache, string path, ICommonPathsWrapper commonPathsWrapper, ICollectionStorage collectionStorage, IFileSystem fileSystem, IPresentationFactory presentationFactory, IPresentationCapableSyncDataFactory syncDataFactory, IDataIdDuplicatedEventPublisher analyticEvent, IFlagService flagService, IProPresenterDOFactoryProvider factoryProvider, IUiScheduler scheduler, IActionBinderFactory actionBinderFactory, bool loadLegacy, Predicate<string>? validateName = null, Predicate<Guid>? validateID = null)
	{
		_metadataCache = metadataCache;
		_commonPathsWrapper = commonPathsWrapper;
		_collectionStorage = collectionStorage;
		_fileSystem = fileSystem;
		_presentationFactory = presentationFactory;
		_syncDataFactory = syncDataFactory;
		_analyticEvent = analyticEvent;
		_factoryProvider = factoryProvider;
		_scheduler = scheduler;
		_actionBinderFactory = actionBinderFactory;
		_validateName = validateName ?? ((Predicate<string>)((string n) => true));
		_validateID = validateID ?? ((Predicate<Guid>)((Guid i) => true));
		Location = new RelativePath(path);
		SetupDataSyncer(path, flagService, loadLegacy);
		base.CollectionChanged += delegate(object? s, NotifyCollectionChangedEventArgs e)
		{
			switch (e.Action)
			{
			case NotifyCollectionChangedAction.Add:
				LibraryUpdated.Publish(this, LibraryUpdateType.Add, e.NewItems?.Cast<DocumentCue>().ToArray() ?? Array.Empty<DocumentCue>());
				break;
			case NotifyCollectionChangedAction.Remove:
				LibraryUpdated.Publish(this, LibraryUpdateType.Remove, e.OldItems?.Cast<DocumentCue>().ToArray() ?? Array.Empty<DocumentCue>());
				break;
			}
		};
	}

	public DocumentCue Add(ProPresenter.DO.Presentation.IPresentation presentation, bool userInitiated)
	{
		SanitizePresentationID(new PresentationAndLoadData(presentation, null));
		DocumentCue documentCue = new DocumentCue(presentation, supportsArrangement: false, newID: false);
		Add(documentCue, userInitiated);
		return documentCue;
	}

	public void Add(IReadOnlyList<ProPresenter.DO.Presentation.IPresentation> presentations, bool userInitiated)
	{
		Add(presentations.Select((ProPresenter.DO.Presentation.IPresentation x) => new DocumentCue(x, supportsArrangement: false, newID: false)), userInitiated);
	}

	public void Add(DocumentCue cue, bool userInitiated)
	{
		Add(new global::_003C_003Ez__ReadOnlySingleElementList<DocumentCue>(cue), userInitiated);
	}

	public void Add(IEnumerable<DocumentCue> cues, bool userInitiated)
	{
		GetAllTrackedMedia(cues.Select((DocumentCue x) => x.Actions.FirstOf<DocumentAction>().Presentation).NotNull().ToArray()).ForEach(delegate(ITrackedMedia x)
		{
			x.AddToMediaServiceAndApplyTransform(userInitiated);
		});
		foreach (DocumentCue cue in cues)
		{
			SanitizePresentationName(cue);
			cue.DocumentAction.Presentation.ThrowWhenNull("cue.DocumentAction.Presentation");
			_syncer.Add(cue.DocumentAction.Presentation);
			OnAdd(cue);
		}
		UndoStack? undoStack = UndoStack;
		if (undoStack != null && undoStack.IsRecording)
		{
			UndoStack.Commit(delegate
			{
				Remove(cues);
			}, delegate
			{
				Add(cues, userInitiated);
			}, null, null, autoFinalize: true);
		}
	}

	internal bool TryRename(string newName)
	{
		if (!_syncer.TryRenameLibrary(newName))
		{
			return false;
		}
		Location = new RelativePath(_fileSystem.Path.Combine(CommonPaths.Libraries, newName).NormalizePath());
		foreach (DocumentCue item in base.Collection)
		{
			if (item.DocumentAction.Presentation is PresentationBase presentationBase)
			{
				presentationBase.SourceFile = new RelativePath(GetLibraryPath(item.Name));
			}
		}
		OnPropertyChanged("Location");
		return true;
	}

	private void OnAdd(DocumentCue cue)
	{
		cue.DocumentAction.Presentation.ThrowWhenNull("cue.DocumentAction.Presentation");
		ProPresenter.DO.Presentation.IPresentation? presentation = cue.DocumentAction.Presentation;
		presentation.SourceFile = new RelativePath(GetLibraryPath(cue.Name));
		base.Collection.Add(cue);
		presentation.NameChanging += Presentation_NameChanging;
		presentation.NameChanged += Presentation_NameChanged;
		ProcessIDRewrites();
	}

	private void SanitizePresentationName(DocumentCue cue)
	{
		cue.DocumentAction.Presentation.ThrowWhenNull("cue.DocumentAction.Presentation");
		ProPresenter.DO.Presentation.IPresentation presentation = cue.DocumentAction.Presentation;
		string origin = presentation.Name.SanitizeFilename();
		presentation.Name = origin.DuplicateName(base.Collection, (DocumentCue i) => i.Name);
		if (DoesPresentationExist(presentation.Name))
		{
			List<string> list = base.Collection.Select((DocumentCue i) => i.Name).ToList();
			do
			{
				list.Add(presentation.Name);
				presentation.Name = origin.DuplicateName(list, (string i) => i);
			}
			while (DoesPresentationExist(presentation.Name));
		}
		cue.Name = presentation.Name;
	}

	private void SanitizePresentationID(PresentationAndLoadData presentationAndLoadData)
	{
		if (base.Collection.Select((DocumentCue p) => p.ID).Contains(presentationAndLoadData.Presentation.ID) || !_validateID(presentationAndLoadData.Presentation.ID))
		{
			presentationAndLoadData.Presentation.ResetID(presentationAndLoadData.LoadData == null);
			if (presentationAndLoadData.LoadData != null)
			{
				Pro.SerializationInterop.RVProtoData.Presentation presentation = presentationAndLoadData.LoadData.ProtoData ?? presentationAndLoadData.Presentation.Serialize();
				presentation.Uuid = presentationAndLoadData.Presentation.ID.ToUUID();
				presentationAndLoadData.LoadData.UpdateProtoData(presentation);
				_idRewrites.Add(new IdRewriteData(presentationAndLoadData, DataType.Presentation, 1));
			}
		}
		_needsSanitation.Add(presentationAndLoadData);
	}

	public void SanitizeMediaFillMediaIDs()
	{
		foreach (PresentationAndLoadData item in _needsSanitation)
		{
			int num = item.Presentation.FixDuplicatedFillMediaIds();
			if (num > 0 && item.LoadData != null)
			{
				Pro.SerializationInterop.RVProtoData.Presentation protoData = item.LoadData.ProtoData ?? item.Presentation.Serialize();
				item.LoadData.UpdateProtoData(protoData);
				_idRewrites.Add(new IdRewriteData(item, DataType.Media, num));
			}
		}
		_needsSanitation.Clear();
	}

	private void ProcessIDRewrites()
	{
		if (_syncer != null)
		{
			_idRewrites.ForEach(delegate(IdRewriteData p)
			{
				_syncer?.UpdateFile(p.PresentationAndLoadData.LoadData, p.PresentationAndLoadData.Presentation);
			});
			SendDuplicatePresentationIdsAnalytics();
			_idRewrites.Clear();
		}
	}

	private void SendDuplicatePresentationIdsAnalytics()
	{
		if (!_idRewrites.Any())
		{
			return;
		}
		foreach (IGrouping<DataType, IdRewriteData> item in from r in _idRewrites
			group r by r.Type)
		{
			int num = item.Sum((IdRewriteData i) => i.DuplicateCount);
			if (num > 0)
			{
				_analyticEvent.Publish(item.Key, num);
			}
		}
	}

	public bool DoesPresentationExist(string? name)
	{
		if (name != null)
		{
			return _fileSystem.File.Exists(GetLibraryPath(name));
		}
		return false;
	}

	public void Remove(DocumentCue? cue)
	{
		Remove(new global::_003C_003Ez__ReadOnlySingleElementList<DocumentCue>(cue));
	}

	public void Remove(IEnumerable<DocumentCue?> cues)
	{
		DocumentCue[] validCues = cues.NotNull().ToArray();
		GetAllTrackedMedia(cues.Select((DocumentCue x) => x?.Actions.FirstOf<DocumentAction>().Presentation).NotNull().ToArray()).ForEach(delegate(ITrackedMedia x)
		{
			x.RemoveFromMediaService(deleteAssets: false);
		});
		DocumentCue[] array = validCues;
		foreach (DocumentCue documentCue in array)
		{
			documentCue.DocumentAction.Presentation.ThrowWhenNull("cue.DocumentAction.Presentation");
			_syncer.Remove(documentCue.DocumentAction.Presentation);
			OnRemove(documentCue);
		}
		UndoStack? undoStack = UndoStack;
		if (undoStack != null && undoStack.IsRecording)
		{
			UndoStack.Commit(delegate
			{
				Add(validCues, userInitiated: true);
			}, delegate
			{
				Remove(validCues);
			}, null, null, autoFinalize: true);
		}
	}

	private void OnRemove(DocumentCue cue)
	{
		cue.DocumentAction.Presentation.ThrowWhenNull("cue.DocumentAction.Presentation");
		ProPresenter.DO.Presentation.IPresentation? presentation = cue.DocumentAction.Presentation;
		presentation.NameChanging -= Presentation_NameChanging;
		presentation.NameChanged -= Presentation_NameChanged;
		presentation.SourceFile = null;
		base.Collection.Remove(cue);
	}

	private void OnRemoveBySync(ProPresenter.DO.Presentation.IPresentation presentation)
	{
		DocumentCue documentCue = base.Collection.FirstOrDefault((DocumentCue c) => c.DocumentAction.Presentation == presentation);
		if (documentCue != null)
		{
			this.PresentationRemovedBySync?.Invoke(this, documentCue);
			OnRemove(documentCue);
		}
	}

	private void Presentation_NameChanging(ProPresenter.DO.Presentation.IPresentation presentation)
	{
		LibraryUpdated.Publish(this, LibraryUpdateType.Remove, this.Where((DocumentCue x) => x.ID.Equals(presentation.ID)).ToArray());
	}

	private void Presentation_NameChanged(ProPresenter.DO.Presentation.IPresentation presentation)
	{
		LibraryUpdated.Publish(this, LibraryUpdateType.Add, this.Where((DocumentCue x) => x.ID.Equals(presentation.ID)).ToArray());
	}

	public void CommitAllInWriteQueue()
	{
		_syncer.CommitAllInWriteQueue();
	}

	public IPresentationLoadData? GetPresentationLoadData(ProPresenter.DO.Presentation.IPresentation presentation)
	{
		if (!_syncer.TryGetData(presentation, out IPresentationLoadData data))
		{
			return null;
		}
		return data;
	}

	int IDragDropCollection<ProPresenterCue>.IndexOf(ProPresenterCue item)
	{
		return IndexOf((DocumentCue)item);
	}

	public void DraggedFrom(IEnumerable<ProPresenterCue> items)
	{
		Remove(items.Cast<DocumentCue>());
	}

	public void DroppedInto(IEnumerable<ProPresenterCue> items, int index, bool isCopy)
	{
		items = (isCopy ? items.CloneItems() : items);
		Add(items.OfType<DocumentCue>(), userInitiated: true);
	}

	void IDragDropCollection<ProPresenterCue>.MoveTo(IEnumerable<ProPresenterCue> items, int index)
	{
	}

	public void CutFrom(IEnumerable<ProPresenterCue> items)
	{
		throw new NotSupportedException();
	}

	public void PasteInto(IEnumerable<ProPresenterCue> items, int index)
	{
		ProPresenter.DO.Presentation.IPresentation[] presentations = (from DocumentCue c in items
			select c.DocumentAction.Presentation).NonNull().CloneItems().ToArray();
		Add(presentations, userInitiated: true);
	}

	public static IReadOnlyList<ITrackedMedia> GetAllTrackedMedia(IReadOnlyList<ProPresenter.DO.Presentation.IPresentation> presentations)
	{
		return presentations.SelectMany((ProPresenter.DO.Presentation.IPresentation x) => x.ArrangementGroups.SelectMany((CueGroup cueGroup) => cueGroup.Cues)).DistinctBy((SlideCue x) => x.ID).ToArray()
			.SelectMany((SlideCue x) => x.GetTrackedMedia())
			.ToArray();
	}

	[MemberNotNull(new string[] { "_syncer", "_name" })]
	private void SetupDataSyncer(string path, IFlagService flagService, bool loadLegacy)
	{
		_name = (string.IsNullOrEmpty(path) ? string.Empty : _fileSystem.Directory.CreateDirectory(path).Name);
		IPresentationDataSyncer syncer;
		if (!flagService.IsFlagEnabled(Flag.Cloud))
		{
			IPresentationDataSyncer presentationDataSyncer = new PresentationProtoSyncer(_name, _fileSystem, _commonPathsWrapper, _syncDataFactory, _metadataCache, _presentationFactory, _factoryProvider.ErrorReporter, SanitizePresentationID, delegate(IPresentationLoadData? l)
			{
				this.PresentationDataChanged?.Invoke(l);
			}, delegate(DocumentCue c)
			{
				this.CueUpdated?.Invoke(c);
			}, () => this, OnAdd, OnRemove, OnRename);
			syncer = presentationDataSyncer;
		}
		else
		{
			IPresentationDataSyncer presentationDataSyncer = new PresentationEntitySyncer(_name, _commonPathsWrapper, _collectionStorage, _fileSystem, _presentationFactory, _factoryProvider, _scheduler, _actionBinderFactory, _metadataCache, OnAdd, OnRemoveBySync, OnRename, delegate(IPresentationLoadData? l)
			{
				this.PresentationDataChanged?.Invoke(l);
			}, loadLegacy);
			syncer = presentationDataSyncer;
		}
		_syncer = syncer;
		ProcessIDRewrites();
	}

	private void OnRename(ProPresenter.DO.Presentation.IPresentation model, string newName)
	{
		model.SourceFile = new RelativePath(GetLibraryPath(newName));
		this.PresentationNameChanged?.Invoke(model);
	}

	private string GetLibraryPath(string name)
	{
		return _fileSystem.Path.Combine(Location, name + ".pro");
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
			_syncer.Dispose();
		}
	}
}
