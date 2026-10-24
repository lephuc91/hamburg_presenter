using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
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
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.Entity.Persistence;
using Pro.Localization;
using Pro.Serialization.DataManagement;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Actions;
using ProPresenter.DO.ChangeDirectory;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Extensions;
using ProPresenter.DO.Workspaces;

namespace ProPresenter.DO.ClearGroups;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_syncedData", "_syncer" })]
public class ClearGroupCollection : ImmutableObservableCollection<ClearGroup>, IDragDropNotifyEnumerableChanged<ClearGroup>, INotifyEnumerableChanged<ClearGroup>, IEnumerable<ClearGroup>, IEnumerable, INotifyCollectionChanged, IDragDropCollection<ClearGroup>, ICutPasteCollection<ClearGroup>, ICutCollection<ClearGroup>, IDocumentProvider, IDisposable
{
	private IProtoSyncedData<Pro.SerializationInterop.RVProtoData.ClearGroupsDocument>? _syncedData;

	private IEntityDocumentSyncer<IClearGroupsDocumentDoc>? _syncer;

	private readonly ISyncDataFactory _syncDataFactory;

	private readonly IProPresenterDOFactoryProvider _factoryProvider;

	private readonly IUiScheduler _uiScheduler;

	private readonly IFlagService _flagService;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public UndoStack? UndoStack { get; } = new UndoStack();

	public Guid DocumentId => _syncer?.Id ?? Guid.Empty;

	public event System.Action? DataModified;

	private IReadOnlyObjectBinder<ClearGroupCollection, IClearGroupsDocument> Bind(IClearGroupsDocument clearGroups, IUiScheduler uiScheduler, IEntityFactory entityFactory)
	{
		ObjectBinder<ClearGroupCollection, IClearGroupsDocument> objectBinder = new ObjectBinder<ClearGroupCollection, IClearGroupsDocument>(this, clearGroups);
		objectBinder.Bind((ClearGroupCollection x) => x.WhenCollectionChanges(), (IClearGroupsDocument x) => x.Groups.WhenCollectionChanges, delegate(ClearGroupCollection model, IClearGroupsDocument entity)
		{
			entity.Groups.SynchronizeFrom(model, Equals, delegate(ClearGroup m)
			{
				IClearGroupsDocument.Types.IClearGroup clearGroup = entityFactory.Create<IClearGroupsDocument.Types.IClearGroup>();
				ObjectBinder<IClearGroupsDocument.Types.IClearGroup, ClearGroup> objectBinder2 = m.Bind(clearGroup, uiScheduler);
				objectBinder2.InitializeLeftFromRight();
				entity.RegisterLinkedDisposable(objectBinder2);
				return clearGroup;
			});
		}, delegate(IClearGroupsDocument entity, ClearGroupCollection model)
		{
			entity.Groups.Items.SynchronizeTo(model, Equals, delegate(IClearGroupsDocument.Types.IClearGroup e, int index)
			{
				ClearGroup clearGroup2 = new ClearGroup();
				ObjectBinder<IClearGroupsDocument.Types.IClearGroup, ClearGroup> objectBinder3 = clearGroup2.Bind(e, uiScheduler);
				objectBinder3.InitializeRightFromLeft();
				entity.RegisterLinkedDisposable(objectBinder3);
				clearGroup2.DataModified += OnDataModified;
				clearGroup2.UndoStack = UndoStack;
				base.Collection.Insert(base.Collection.ClampIndexExclusive(index), clearGroup2);
			}, base.Collection.Move, base.Collection.RemoveAt);
		}, null, uiScheduler.Scheduler);
		return objectBinder;
	}

	private static bool Equals(IClearGroupsDocument.Types.IClearGroup left, ClearGroup right)
	{
		return left.Uuid.Value == right.ID;
	}

	private static bool Equals(ClearGroup left, IClearGroupsDocument.Types.IClearGroup right)
	{
		return right.Uuid.Value == left.ID;
	}

	public ClearGroupCollection(ISyncDataFactory syncDataFactory, IProPresenterDOFactoryProvider factoryProvider, IUiScheduler uiScheduler, IFlagService flagService, bool loadLegacy)
	{
		_syncDataFactory = syncDataFactory;
		_factoryProvider = factoryProvider;
		_uiScheduler = uiScheduler;
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
			_syncer = _factoryProvider.EntityDocumentSyncerFactory.CreateConfigurationSyncer("ClearGroups", (IClearGroupsDocumentDoc doc) => Bind(doc, _uiScheduler, _factoryProvider.EntityFactory), () => Serialize().ToByteArray(), delegate(byte[] d)
			{
				Deserialize(Pro.SerializationInterop.RVProtoData.ClearGroupsDocument.Parser.ParseFrom(d));
			}, LoadDefaults, loadLegacy);
		}
		else
		{
			_syncedData = _syncDataFactory.GetSyncedData<Pro.SerializationInterop.RVProtoData.ClearGroupsDocument>(CommonPaths.Configuration, "ClearGroups", Deserialize, SyncedDataCleared);
		}
	}

	private void LoadDefaults()
	{
		SyncedDataCleared(DataClearSource.FileRemoved);
	}

	private void SyncedDataCleared(DataClearSource dataClearSource)
	{
		if (dataClearSource == DataClearSource.FileRemoved)
		{
			UndoStack?.StartIgnoring();
			RemoveClearGroups(base.Collection.ToArray());
			ClearGroup clearGroup = new ClearGroup
			{
				Name = LocalizedStrings.Get("ACTION_TYPE_CLEAR_ALL_title"),
				ImageType = ImageType.All
			};
			clearGroup.ToggleClearTarget(ClearType.Audio);
			clearGroup.ToggleClearTarget(ClearType.AudioEffects);
			clearGroup.ToggleClearTarget(ClearType.Messages);
			clearGroup.ToggleClearTarget(ClearType.Props);
			clearGroup.ToggleClearTarget(ClearType.Announcement);
			clearGroup.ToggleClearTarget(ClearType.Slide);
			clearGroup.ToggleClearTarget(ClearType.Background);
			clearGroup.ToggleClearTarget(ClearType.LiveVideo);
			OutputDestination[] values = Enum.GetValues<OutputDestination>();
			foreach (OutputDestination contentDestination in values)
			{
				clearGroup.ToggleTimelineTarget(contentDestination);
			}
			AddClearGroup(clearGroup);
			UndoStack?.StopIgnoring();
		}
	}

	public void AddClearGroup()
	{
		ClearGroup clearGroup = new ClearGroup
		{
			ImageType = ImageType.Zero
		};
		string text = LocalizedStrings.Get("CLEAR_GROUPS_DEFAULT_NAME_title").DuplicateName(base.Collection.Select((ClearGroup m) => m.Name), (string n) => n);
		if (int.TryParse(text.LastOrDefault().ToString(), out var result))
		{
			clearGroup.ImageType = (ImageType)result;
		}
		clearGroup.Name = text;
		clearGroup.ToggleTimelineTarget(OutputDestination.Announcement);
		clearGroup.ToggleTimelineTarget(OutputDestination.Presentation);
		clearGroup.ClearNextSlide = true;
		AddClearGroup(clearGroup);
	}

	public void AddClearGroup(ClearGroup clearGroup)
	{
		InsertClearGroup(clearGroup, base.Collection.Count, autoFinalize: true);
	}

	private void InsertClearGroup(ClearGroup clearGroup, int index, bool autoFinalize = false)
	{
		insertAction();
		UndoStack?.Commit(UndoActionTypes.ClearGroupAdd.ToAction(), delegate
		{
			RemoveClearGroup(clearGroup);
		}, insertAction, null, null, autoFinalize);
		void insertAction()
		{
			clearGroup.DataModified += OnDataModified;
			clearGroup.UndoStack = UndoStack;
			clearGroup.Name = clearGroup.Name.DuplicateName(base.Collection.Select((ClearGroup m) => m.Name), (string n) => n);
			base.Collection.Insert(base.Collection.ClampIndexExclusive(index), clearGroup);
		}
	}

	public void InsertClearGroups(IEnumerable<ClearGroup> clearGroups, int index)
	{
		if (clearGroups != null)
		{
			UndoStack?.BeginCommit(UndoActionTypes.ClearGroupAdd.ToAction());
			clearGroups.ForEach(delegate(ClearGroup m)
			{
				InsertClearGroup(m, index++);
			});
			UndoStack?.EndCommit(null, null, autoFinalize: true);
		}
	}

	public void RemoveClearGroup(ClearGroup clearGroup)
	{
		RemoveClearGroups(clearGroup.ToEnumerable());
	}

	public void RemoveClearGroups(IEnumerable<ClearGroup> clearGroups)
	{
		KeyValuePair<int, ClearGroup>[] itemIndices = (from m in clearGroups.ToDictionary((ClearGroup m) => base.Collection.IndexOf(m), (ClearGroup i) => i)
			orderby m.Key
			select m).ToArray();
		System.Action action = delegate
		{
			itemIndices.Reverse().ForEach(delegate(KeyValuePair<int, ClearGroup> m)
			{
				m.Value.DataModified -= OnDataModified;
				ClearGroup clearGroup = base.Collection.ElementAtOrDefault(m.Key);
				if (clearGroup != null)
				{
					base.Collection.Remove(clearGroup);
				}
			});
		};
		action();
		UndoStack?.Commit(UndoActionTypes.ClearGroupRemove.ToAction(), delegate
		{
			itemIndices.ForEach(delegate(KeyValuePair<int, ClearGroup> m)
			{
				m.Value.DataModified += OnDataModified;
				base.Collection.Insert(m.Key, m.Value);
			});
		}, action, null, null, autoFinalize: true);
	}

	public Pro.SerializationInterop.RVProtoData.ClearGroupsDocument Serialize()
	{
		Pro.SerializationInterop.RVProtoData.ClearGroupsDocument clearGroupsDocument = new Pro.SerializationInterop.RVProtoData.ClearGroupsDocument();
		clearGroupsDocument.ApplicationInfo = new ApplicationData(ApplicationType.ProPresenter).Serialize();
		clearGroupsDocument.Groups.AddRange(base.Collection.Select((ClearGroup c) => c.Serialize()));
		return clearGroupsDocument;
	}

	public void Deserialize(Pro.SerializationInterop.RVProtoData.ClearGroupsDocument document)
	{
		UndoStack?.StartIgnoring();
		base.Collection.DeserializeCollection(document.Groups, (ClearGroup c, Pro.SerializationInterop.RVProtoData.ClearGroupsDocument.Types.ClearGroup p) => c.ID == p.Uuid.ToGuid(), (Pro.SerializationInterop.RVProtoData.ClearGroupsDocument.Types.ClearGroup p) => new ClearGroup(UndoStack), AddClearGroup, RemoveClearGroup, delegate(ClearGroup c, Pro.SerializationInterop.RVProtoData.ClearGroupsDocument.Types.ClearGroup p)
		{
			c.DataModified -= OnDataModified;
			c.Deserialize(p);
			c.DataModified += OnDataModified;
		});
		UndoStack?.StopIgnoring();
	}

	protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
	{
		OnDataModified();
	}

	private void OnDataModified()
	{
		_syncedData?.UpdateData(Serialize());
		this.DataModified?.Invoke();
	}

	public void DraggedFrom(IEnumerable<ClearGroup> items)
	{
	}

	public void DroppedInto(IEnumerable<ClearGroup> items, int index, bool isCopy)
	{
		UndoStack?.BeginCommit(UndoActionTypes.ClearGroupMove.ToAction());
		items = (isCopy ? items.CloneItems() : items);
		InsertClearGroups(items, index);
		UndoStack?.EndCommit(null, null, autoFinalize: true);
	}

	public void MoveTo(IEnumerable<ClearGroup> items, int index)
	{
		ClearGroup clearGroup = items.FirstOrDefault();
		int origIndex = ((clearGroup == null) ? (-1) : base.Collection.IndexOf(clearGroup));
		if (origIndex > index)
		{
			origIndex++;
		}
		base.Collection.MoveTo(items, index);
		UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ClearGroupMove), delegate
		{
			MoveTo(items, origIndex);
		}, delegate
		{
			MoveTo(items, index);
		}, null, null, autoFinalize: true);
	}

	public void CutFrom(IEnumerable<ClearGroup> items)
	{
		RemoveClearGroups(items.ToArray());
	}

	public void PasteInto(IEnumerable<ClearGroup> items, int index)
	{
		InsertClearGroups(items, index);
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
		return new Pro.CoreApplication.Document.Intrinsic.ClearGroupsDocument(_syncer.Document.ExportFullSnapshot(), _syncer.Id);
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
