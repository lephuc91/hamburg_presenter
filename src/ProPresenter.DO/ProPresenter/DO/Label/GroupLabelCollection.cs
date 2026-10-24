using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Media;
using Google.Protobuf;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.FeatureFlag;
using Pro.Common.ObjectBinding;
using Pro.Common.SourceGenerator.Attributes;
using Pro.Common.Utility;
using Pro.CoreApplication.Document;
using Pro.CoreApplication.Document.Intrinsic;
using Pro.DO;
using Pro.DO.Label;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.Entity.Persistence;
using Pro.Serialization.DataManagement;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.ChangeDirectory;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Extensions;
using ProPresenter.DO.Workspaces;

namespace ProPresenter.DO.Label;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_syncer", "_syncedData" })]
public class GroupLabelCollection : ImmutableObservableCollection<GroupLabel>, IGroupLabelCollection, INotifyEnumerableChanged<GroupLabel>, IEnumerable<GroupLabel>, IEnumerable, INotifyCollectionChanged, IDragDropCollection<GroupLabel>, IDocumentProvider, IDisposable
{
	private IProtoSyncedData<ProGroupsDocument>? _syncedData;

	private IEntityDocumentSyncer<IProGroupsDocumentDoc>? _syncer;

	private readonly ISyncDataFactory _syncDataFactory;

	private readonly IProPresenterDOFactoryProvider _factoryProvider;

	private readonly IUiScheduler _uiScheduler;

	private readonly IFlagService _flagService;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public UndoStack UndoStack { get; } = new UndoStack();

	public Guid DocumentId => _syncer?.Id ?? Guid.Empty;

	public event System.Action? ContentsModified;

	public static ObjectBinder<GroupLabelCollection, IProGroupsDocument> CreateBinder(IEntityFactory entityFactory, IUiScheduler uiScheduler, GroupLabelCollection left, IProGroupsDocument right)
	{
		return new ObjectBinder<GroupLabelCollection, IProGroupsDocument>(left, right).Bind((GroupLabelCollection l) => l.Collection.WhenCollectionChanges(), (IProGroupsDocument r) => r.Groups.WhenCollectionChanges, delegate(GroupLabelCollection l, IProGroupsDocument r)
		{
			r.Groups.SynchronizeFrom(l.Collection, (GroupLabel model, IGroup entity) => model.ID == entity.Uuid.Value, delegate(GroupLabel model)
			{
				IGroup group = entityFactory.Create<IGroup>();
				ObjectBinder<GroupLabel, IGroup> objectBinder = GroupLabel.CreateBinder(uiScheduler, model, group, left);
				group.RegisterLinkedDisposable(objectBinder);
				objectBinder.InitializeRightFromLeft();
				return group;
			});
		}, delegate(IProGroupsDocument r, GroupLabelCollection l)
		{
			r.Groups.Items.SynchronizeTo(l.Collection, (IGroup entity, GroupLabel model) => model.ID == entity.Uuid.Value, delegate(IGroup entity, int index)
			{
				GroupLabel groupLabel = new GroupLabel();
				ObjectBinder<GroupLabel, IGroup> objectBinder2 = GroupLabel.CreateBinder(uiScheduler, groupLabel, entity, left);
				entity.RegisterLinkedDisposable(objectBinder2);
				objectBinder2.InitializeLeftFromRight();
				l.Collection.Insert(index, groupLabel);
			}, l.Collection.Move, l.Collection.RemoveAt);
		}, null, uiScheduler.Scheduler);
	}

	public GroupLabelCollection(ISyncDataFactory syncDataFactory, IProPresenterDOFactoryProvider factoryProvider, IUiScheduler uiScheduler, IFlagService flagService, bool loadLegacy)
	{
		_syncDataFactory = syncDataFactory;
		_factoryProvider = factoryProvider;
		_uiScheduler = uiScheduler;
		_flagService = flagService;
		SetupDocumentSyncer(loadLegacy);
		ChangeDirectoryPrompt.RegisterDelegate(new ChangeDirectoryListener(TeardownDocumentSyncer, SetupDocumentSyncer));
		base.CollectionChanged += delegate
		{
			OnDataModified();
		};
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
			_syncer = _factoryProvider.EntityDocumentSyncerFactory.CreateConfigurationSyncer("Groups", (IProGroupsDocumentDoc doc) => CreateBinder(_factoryProvider.EntityFactory, _uiScheduler, this, doc), () => Serialize().ToByteArray(), delegate(byte[] d)
			{
				SyncDataUpdated(ProGroupsDocument.Parser.ParseFrom(d));
			}, LoadDefaults, loadLegacy);
		}
		else
		{
			_syncedData = _syncDataFactory.GetSyncedData<ProGroupsDocument>(CommonPaths.Configuration, "Groups", SyncDataUpdated, SyncDataCleared);
		}
	}

	private void LoadDefaults()
	{
		SyncDataCleared(DataClearSource.FileRemoved);
	}

	public void Add(string text, System.Windows.Media.Color color)
	{
		Add(new GroupLabel(text, color));
	}

	public void Add(GroupLabel groupLabel)
	{
		OnInsert(base.Collection.Count, groupLabel);
	}

	public void Add(IEnumerable<GroupLabel> groupLabels)
	{
		groupLabels.ForEach(Add);
	}

	public void Insert(int index, GroupLabel groupLabel)
	{
		OnInsert(index, groupLabel);
	}

	private void OnInsert(int index, GroupLabel groupLabel, bool autoFinalize = true)
	{
		insertLabel();
		UndoStack.Commit(UndoActionTypes.AddGroupLabel.ToAction(), delegate
		{
			OnRemove(groupLabel);
		}, insertLabel, null, null, autoFinalize);
		void insertLabel()
		{
			groupLabel.UndoStack = UndoStack;
			groupLabel.DataModified += OnContentsModified;
			base.Collection.Insert(index, groupLabel);
		}
	}

	public void OnInsert(IEnumerable<GroupLabel> groupLabels, int index)
	{
		if (groupLabels != null)
		{
			UndoStack?.BeginCommit(UndoActionTypes.MoveGroupLabel.ToAction());
			groupLabels.ForEach(delegate(GroupLabel m)
			{
				OnInsert(index++, m);
			});
			UndoStack?.EndCommit(null, null, autoFinalize: true);
		}
	}

	public void Remove(GroupLabel groupLabel)
	{
		OnRemove(groupLabel);
	}

	public void RemoveRange(IEnumerable<GroupLabel> groupLabels)
	{
		groupLabels.ForEach(Remove);
	}

	private void OnRemove(GroupLabel groupLabel, bool autoFinalize = true)
	{
		int index = base.Collection.IndexOf(groupLabel);
		removeLabel();
		UndoStack.Commit(UndoActionTypes.RemoveGroupLabel.ToAction(), delegate
		{
			OnInsert(index, groupLabel);
		}, removeLabel, null, null, autoFinalize);
		void removeLabel()
		{
			groupLabel.DataModified -= OnContentsModified;
			base.Collection.Remove(groupLabel);
		}
	}

	public void Clear()
	{
		UndoStack.BeginCommit(UndoActionTypes.RemoveGroupLabel.ToAction());
		foreach (GroupLabel item in base.Collection.ToList())
		{
			OnRemove(item, autoFinalize: false);
		}
		UndoStack.EndCommit(null, null, autoFinalize: true);
	}

	public void Reset(bool canUndo = false)
	{
		if (!canUndo)
		{
			UndoStack.StartIgnoring();
		}
		Clear();
		Add(DefaultLabels.Group);
		if (!canUndo)
		{
			UndoStack.StopIgnoring();
		}
	}

	public void Replace(GroupLabel existingLabel, GroupLabel newLabel)
	{
		if (existingLabel == null)
		{
			Add(newLabel);
			return;
		}
		int index = base.Collection.IndexOf(existingLabel);
		Remove(existingLabel);
		Insert(index, newLabel);
	}

	public void DraggedFrom(IEnumerable<GroupLabel> items)
	{
	}

	public void DroppedInto(IEnumerable<GroupLabel> items, int index, bool isCopy)
	{
		UndoStack?.BeginCommit(UndoActionTypes.MoveGroupLabel.ToAction());
		items = (isCopy ? items.CloneItems() : items);
		OnInsert(items, index);
		UndoStack?.EndCommit(null, null, autoFinalize: true);
	}

	public void MoveTo(IEnumerable<GroupLabel> items, int index)
	{
		GroupLabel groupLabel = items.FirstOrDefault();
		int origIndex = ((groupLabel == null) ? (-1) : base.Collection.IndexOf(groupLabel));
		if (origIndex > index)
		{
			origIndex++;
		}
		base.Collection.MoveTo(items, index);
		UndoStack.Commit(UndoActionTypes.MoveGroupLabel.ToAction(), delegate
		{
			MoveTo(items, origIndex);
		}, delegate
		{
			MoveTo(items, index);
		}, null, null, autoFinalize: true);
	}

	private void SyncDataCleared(DataClearSource dataClearSource)
	{
		if (dataClearSource == DataClearSource.FileRemoved)
		{
			Reset();
		}
	}

	private void SyncDataUpdated(ProGroupsDocument document)
	{
		Deserialize(document.Groups);
	}

	public void Deserialize(IEnumerable<Group> groups, bool removeExisting = true)
	{
		UndoStack.StartIgnoring();
		base.Collection.DeserializeCollection(groups, (GroupLabel l, Group d) => l.ID == d.Uuid.ToGuid(), (Group d) => new GroupLabel(), Add, delegate(GroupLabel l)
		{
			if (removeExisting)
			{
				Remove(l);
			}
		}, delegate(GroupLabel l, Group d)
		{
			l.Deserialize(d);
		});
		UndoStack.StopIgnoring();
	}

	public ProGroupsDocument Serialize()
	{
		ProGroupsDocument proGroupsDocument = new ProGroupsDocument();
		proGroupsDocument.Groups.AddRange(base.Collection.Select((GroupLabel m) => m.Serialize()));
		return proGroupsDocument;
	}

	private void OnDataModified()
	{
		_syncedData?.UpdateData(Serialize());
	}

	private void OnContentsModified()
	{
		OnDataModified();
		this.ContentsModified?.Invoke();
	}

	internal void Save()
	{
		OnDataModified();
	}

	public Pro.CoreApplication.Document.IDocument? GetDocument()
	{
		if (_syncer == null)
		{
			return null;
		}
		return new GroupsDocument(_syncer.Document.ExportFullSnapshot(), _syncer.Id);
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
			_syncer?.Dispose();
			_syncedData?.Dispose();
		}
	}

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private void OnDispose()
	{
		ChangeDirectoryPrompt.UnregisterDelegate(new ChangeDirectoryListener(TeardownDocumentSyncer, SetupDocumentSyncer));
	}
}
