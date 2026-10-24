using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Google.Protobuf;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.FeatureFlag;
using Pro.Common.ObjectBinding;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Strings;
using Pro.Common.Utility;
using Pro.CoreApplication.Document;
using Pro.CoreApplication.Document.Intrinsic;
using Pro.DO;
using Pro.DO.Application;
using Pro.DO.Transitions;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Collections;
using Pro.Entity.Extensions;
using Pro.Entity.Persistence;
using Pro.Localization.Services;
using Pro.Serialization.DataManagement;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.ChangeDirectory;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Events;
using ProPresenter.DO.Extensions;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Transitions;
using ProPresenter.DO.Workspaces;

namespace ProPresenter.DO.Props;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_syncedData", "_syncer" })]
public class PropGroupCollection : ImmutableObservableCollection<IPropGroup>, IPropGroupCollection, IImmutableObservableCollection<IPropGroup>, IReadOnlyList<IPropGroup>, IEnumerable<IPropGroup>, IEnumerable, IReadOnlyCollection<IPropGroup>, INotifyEnumerableChanged<IPropGroup>, INotifyCollectionChanged, IDragDropNotifyEnumerableChanged<IPropGroup>, IDragDropCollection<IPropGroup>, ICutPasteCollection<IPropGroup>, ICutCollection<IPropGroup>, INotifyPropertyChanged, IDocumentProvider, IDisposable
{
	private IProtoSyncedData<PropDocument>? _syncedData;

	private readonly IApp _app;

	private readonly ILocalization _localization;

	private readonly ISyncDataFactory _syncDataFactory;

	private readonly ITransitionDescriptionCollection _transitionDescriptions;

	private readonly IProPresenterDOFactoryProvider _factoryProvider;

	private readonly IFlagService _flagService;

	private readonly IUiScheduler _uiScheduler;

	private TransitionParameters? _selectedTransition;

	private IEntityDocumentSyncer<IPropDocumentDoc>? _syncer;

	private bool _isDeserializing;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public TransitionParameters? SelectedTransition
	{
		get
		{
			return _selectedTransition;
		}
		set
		{
			SetValue("SelectedTransition", ref _selectedTransition, value, OnDataModified);
		}
	}

	public UndoStack UndoStack { get; } = new UndoStack();

	public Guid DocumentId => _syncer?.Id ?? Guid.Empty;

	public event System.Action? DataModified;

	public event System.Action? TargetDirectoryChanged;

	public static ObjectBinder<PropGroupCollection, IPropDocument> Bind(IUiScheduler scheduler, IApp app, IProPresenterDOFactoryProvider factoryProvider, ILocalization localization, PropGroupCollection left, IPropDocument document)
	{
		IEntityFactory entityFactory = factoryProvider.EntityFactory;
		ObjectBinder<PropGroupCollection, IComplexCollection<IPropDocument.Types.IPropCollection>> groupCollectionBinder = new ObjectBinder<PropGroupCollection, IComplexCollection<IPropDocument.Types.IPropCollection>>(left, document.PropCollections);
		groupCollectionBinder.Bind((PropGroupCollection l) => l.WhenCollectionChanges(), (IComplexCollection<IPropDocument.Types.IPropCollection> r) => r.WhenCollectionChanges, delegate(PropGroupCollection l, IComplexCollection<IPropDocument.Types.IPropCollection> r)
		{
			r.SynchronizeFrom(l, (IPropGroup model, IPropDocument.Types.IPropCollection entity) => entity.Uuid.Value == model.ID, delegate(IPropGroup model)
			{
				IPropDocument.Types.IPropCollection propCollection = entityFactory.Create<IPropDocument.Types.IPropCollection>();
				IReadOnlyObjectBinder<IPropGroup, IPropDocument.Types.IPropCollection> readOnlyObjectBinder = model.Bind(scheduler, app, factoryProvider, propCollection);
				readOnlyObjectBinder.InitializeRightFromLeft();
				propCollection.RegisterLinkedDisposable(readOnlyObjectBinder);
				return propCollection;
			});
		}, delegate(IComplexCollection<IPropDocument.Types.IPropCollection> r, PropGroupCollection l)
		{
			r.Items.SynchronizeTo(l, (IPropDocument.Types.IPropCollection e, IPropGroup m) => m.ID == e.Uuid.Value, delegate(IPropDocument.Types.IPropCollection e, int i)
			{
				PropGroup propGroup = new PropGroup(app, localization, factoryProvider, left._transitionDescriptions);
				IReadOnlyObjectBinder<IPropGroup, IPropDocument.Types.IPropCollection> readOnlyObjectBinder2 = propGroup.Bind(scheduler, app, factoryProvider, e);
				readOnlyObjectBinder2.InitializeLeftFromRight();
				e.RegisterLinkedDisposable(readOnlyObjectBinder2);
				l.InsertGroup(propGroup, i);
			}, l.Collection.Move, delegate(int i)
			{
				IPropGroup propGroup2 = l.ElementAtOrDefault(i);
				if (propGroup2 != null)
				{
					l.RemoveGroup(propGroup2);
				}
			});
		}, null, scheduler.Scheduler);
		ObjectBinder<PropGroupCollection, IPropDocument> objectBinder = new ObjectBinder<PropGroupCollection, IPropDocument>(left, document);
		objectBinder.Bind((PropGroupCollection l) => l.WhenPropertyChanges("SelectedTransition"), (IPropDocument r) => r.Transition.WhenValueChanges, delegate(PropGroupCollection l, IPropDocument r)
		{
			if ((object)l.SelectedTransition == null)
			{
				r.Transition.Set(null);
			}
			else
			{
				ITransition transition = entityFactory.Create<ITransition>();
				r.Transition.Set(transition);
				ObjectBinder<TransitionParameters, ITransition> objectBinder2 = TransitionParameters.CreateBinder(entityFactory, l.SelectedTransition, transition);
				objectBinder2.InitializeRightFromLeft();
				transition.RegisterLinkedDisposable(objectBinder2);
			}
		}, delegate(IPropDocument r, PropGroupCollection l)
		{
			if (r.Transition.Value == null)
			{
				l.SelectedTransition = null;
			}
			else
			{
				ObjectBinder<TransitionParameters, ITransition> objectBinder3 = TransitionParameters.CreateBinder(left: l.SelectedTransition = r.Transition.Value?.ToTransition(l._transitionDescriptions), entityFactory: entityFactory, right: r.Transition.Value);
				objectBinder3.InitializeRightFromLeft();
				r.Transition.Value.RegisterLinkedDisposable(objectBinder3);
			}
		}, null, scheduler.Scheduler).DoOnInitializeLeftFromRight(groupCollectionBinder.InitializeLeftFromRight).DoOnInitializeRightFromLeft(groupCollectionBinder.InitializeRightFromLeft)
			.RegisterChildDisposable(() => groupCollectionBinder);
		return objectBinder;
	}

	public PropGroupCollection(IApp app, ILocalization localization, ISyncDataFactory syncDataFactory, ITransitionDescriptionCollection transitionDescriptions, IProPresenterDOFactoryProvider factoryProvider, IFlagService flagService, IUiScheduler uiScheduler, bool loadLegacy)
	{
		_app = app;
		_localization = localization;
		_syncDataFactory = syncDataFactory;
		_transitionDescriptions = transitionDescriptions;
		_factoryProvider = factoryProvider;
		_flagService = flagService;
		_uiScheduler = uiScheduler;
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
			_syncer = _factoryProvider.EntityDocumentSyncerFactory.CreateConfigurationSyncer("Props", (IPropDocumentDoc doc) => Bind(_uiScheduler, _app, _factoryProvider, _localization, this, doc), () => Serialize().ToByteArray(), delegate(byte[] d)
			{
				Deserialize(PropDocument.Parser.ParseFrom(d));
			}, LoadDefaults, loadLegacy);
		}
		else
		{
			_syncedData = _syncDataFactory.GetSyncedData<PropDocument>(CommonPaths.Configuration, "Props", Deserialize, SyncedDataCleared);
		}
		this.TargetDirectoryChanged?.Invoke();
	}

	private void LoadDefaults()
	{
		SyncedDataCleared(DataClearSource.FileRemoved);
	}

	public void AddDefault()
	{
		AddGroup(new PropGroup(_app, _localization, _factoryProvider, _transitionDescriptions)
		{
			Name = _localization.Get("PROP_COLLECTION_DEFAULT_name")
		});
	}

	public PropDocument Serialize()
	{
		PropDocument propDocument = new PropDocument();
		propDocument.ApplicationInfo = new ApplicationData(ApplicationType.ProPresenter).Serialize();
		propDocument.Transition = SelectedTransition?.Serialize();
		propDocument.PropCollections.AddRange(base.Collection.Select((IPropGroup c) => c.Serialize()).NonNull());
		propDocument.Cues.AddRange(from c in base.Collection.SelectMany((IPropGroup g) => g)
			select c.Serialize());
		return propDocument;
	}

	public void Deserialize(PropDocument document)
	{
		ApplicationData applicationData = ApplicationData.Deserialize(document.ApplicationInfo);
		_isDeserializing = true;
		UndoStack?.StartIgnoring();
		SelectedTransition = document.Transition?.ToTransition(_transitionDescriptions);
		base.Collection.DeserializeCollection(document.PropCollections, (IPropGroup m, PropDocument.Types.PropCollection p) => m.ID == p.Uuid.ToGuid(), (PropDocument.Types.PropCollection p) => new PropGroup(_app, _localization, _factoryProvider, _transitionDescriptions), AddGroup, RemoveGroup, delegate(IPropGroup m, PropDocument.Types.PropCollection p)
		{
			m.DataModified -= OnDataModified;
			m.Deserialize(document, p, applicationData);
			m.DataModified += OnDataModified;
		});
		if (base.Collection.Empty())
		{
			AddDefault();
		}
		IPropCue[] allProps = base.Collection.SelectMany((IPropGroup g) => g).ToArray();
		Cue[] array = document.Cues.Where((Cue p) => allProps.None((IPropCue m) => m.ID == p.Uuid.ToGuid())).ToArray();
		if (array.Any())
		{
			IPropGroup propGroup = base.Collection[0];
			Cue[] array2 = array;
			foreach (Cue data in array2)
			{
				PropCue propCue = new PropCue(_app, _factoryProvider, _transitionDescriptions);
				propCue.Deserialize(data, applicationData, MediaContainerIds.Prop(propGroup.ID));
				propGroup.AddProp(propCue);
			}
		}
		UndoStack?.StopIgnoring();
		_isDeserializing = false;
	}

	private void SyncedDataCleared(DataClearSource dataClearSource)
	{
		if (dataClearSource == DataClearSource.FileRemoved)
		{
			UndoStack.StartIgnoring();
			RemoveGroups(base.Collection.ToArray());
			AddDefault();
			UndoStack.StopIgnoring();
		}
	}

	protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
	{
		OnDataModified();
	}

	private void OnDataModified()
	{
		if (!_isDeserializing)
		{
			_syncedData?.UpdateData(Serialize());
			this.DataModified?.Invoke();
			PropsUpdated.Publish();
		}
	}

	public IPropGroup AddGroup()
	{
		PropGroup propGroup = new PropGroup(_app, _localization, _factoryProvider, _transitionDescriptions)
		{
			Name = _localization.Get("PROP_COLLECTION_ADD_name").DuplicateName(base.Collection.Select((IPropGroup g) => g.Name), (string n) => n)
		};
		AddGroup(propGroup);
		return propGroup;
	}

	public void AddGroup(IPropGroup group)
	{
		InsertGroup(group, base.Collection.Count);
	}

	public void InsertGroup(IPropGroup group, int index)
	{
		insertAction();
		UndoStack?.Commit(UndoActionTypes.AddPropGroup.ToAction(), delegate
		{
			RemoveGroup(group);
		}, insertAction);
		void insertAction()
		{
			group.DataModified += OnDataModified;
			group.UndoStack = UndoStack;
			base.Collection.Insert(base.Collection.ClampIndexExclusive(index), group);
		}
	}

	public void InsertGroups(IEnumerable<IPropGroup> groups, int index)
	{
		if (groups != null)
		{
			UndoStack?.BeginCommit(UndoActionTypes.AddPropGroup.ToAction());
			groups.ForEach(delegate(IPropGroup m)
			{
				InsertGroup(m, index++);
			});
			UndoStack?.EndCommit(null, null, autoFinalize: true);
		}
	}

	public void RemoveGroup(IPropGroup group)
	{
		RemoveGroups(group.ToEnumerable());
	}

	public void RemoveGroups(IEnumerable<IPropGroup> groups)
	{
		KeyValuePair<int, IPropGroup>[] itemIndices = (from m in groups.ToDictionary(base.Collection.IndexOf, (IPropGroup i) => i)
			orderby m.Key
			select m).ToArray();
		System.Action action = delegate
		{
			itemIndices.Reverse().ForEach(delegate(KeyValuePair<int, IPropGroup> m)
			{
				m.Value.DataModified -= OnDataModified;
				IPropGroup propGroup = base.Collection.ElementAtOrDefault(m.Key);
				if (propGroup != null)
				{
					base.Collection.Remove(propGroup);
				}
			});
		};
		action();
		UndoStack?.Commit(UndoActionTypes.RemovePropGroup.ToAction(), delegate
		{
			itemIndices.ForEach(delegate(KeyValuePair<int, IPropGroup> m)
			{
				m.Value.DataModified += OnDataModified;
				base.Collection.Insert(m.Key, m.Value);
			});
		}, action, null, null, autoFinalize: true);
	}

	public void DraggedFrom(IEnumerable<IPropGroup> items)
	{
		RemoveGroups(items.AsEnumerable());
	}

	public void DroppedInto(IEnumerable<IPropGroup> items, int index, bool isCopy)
	{
		UndoStack?.BeginCommit(UndoActionTypes.MovePropGroup.ToAction());
		items = (isCopy ? items.CloneItems() : items);
		InsertGroups(items, index);
		UndoStack?.EndCommit(null, null, autoFinalize: true);
	}

	public void MoveTo(IEnumerable<IPropGroup> items, int index)
	{
		int origIndex = base.Collection.IndexOf(items.First());
		if (origIndex > index)
		{
			origIndex++;
		}
		base.Collection.MoveTo(items, index);
		UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.MovePropGroup), delegate
		{
			MoveTo(items, origIndex);
		}, delegate
		{
			MoveTo(items, index);
		}, null, null, autoFinalize: true);
	}

	public void CutFrom(IEnumerable<IPropGroup> items)
	{
		RemoveGroups(items.OfType<IPropGroup>().AsEnumerable());
	}

	public void PasteInto(IEnumerable<IPropGroup> items, int index)
	{
		InsertGroups(items.OfType<IPropGroup>(), index);
	}

	public Pro.CoreApplication.Document.IDocument? GetDocument()
	{
		if (_syncer == null)
		{
			return null;
		}
		return new PropsDocument(_syncer.Document.ExportFullSnapshot(), _syncer.Id);
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
