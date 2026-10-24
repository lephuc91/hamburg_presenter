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

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_syncedData", "_syncer" })]
public class SlideLabelCollection : ImmutableObservableCollection<ActionLabel>, ISlideLabelCollection, INotifyEnumerableChanged<ActionLabel>, IEnumerable<ActionLabel>, IEnumerable, INotifyCollectionChanged, IDragDropCollection<ActionLabel>, IDocumentProvider, IDisposable
{
	private IProtoSyncedData<ProLabelsDocument>? _syncedData;

	private IEntityDocumentSyncer<IProLabelsDocumentDoc>? _syncer;

	private readonly ISyncDataFactory _syncDataFactory;

	private readonly IProPresenterDOFactoryProvider _factoryProvider;

	private readonly IUiScheduler _scheduler;

	private readonly IFlagService _flagService;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public UndoStack UndoStack { get; } = new UndoStack();

	public Guid DocumentId => _syncer?.Id ?? Guid.Empty;

	public event System.Action? ContentsModified;

	public static ObjectBinder<SlideLabelCollection, IProLabelsDocument> CreateBinder(IEntityFactory entityFactory, IUiScheduler uiScheduler, SlideLabelCollection left, IProLabelsDocument right)
	{
		return new ObjectBinder<SlideLabelCollection, IProLabelsDocument>(left, right).Bind((SlideLabelCollection l) => l.Collection.WhenCollectionChanges(), (IProLabelsDocument r) => r.Labels.WhenCollectionChanges, delegate(SlideLabelCollection l, IProLabelsDocument r)
		{
			r.Labels.SynchronizeFrom(l.Collection, (ActionLabel model, IAction.Types.ILabel entity) => model.Text == entity.Text.Value, delegate(ActionLabel model)
			{
				IAction.Types.ILabel label = entityFactory.Create<IAction.Types.ILabel>();
				ObjectBinder<ActionLabel, IAction.Types.ILabel> objectBinder = ActionLabel.CreateBinder(model, label);
				objectBinder.InitializeRightFromLeft();
				label.RegisterLinkedDisposable(objectBinder);
				return label;
			});
		}, delegate(IProLabelsDocument r, SlideLabelCollection l)
		{
			r.Labels.Items.SynchronizeTo(l.Collection, (IAction.Types.ILabel entity, ActionLabel model) => model.Text == entity.Text.Value, delegate(IAction.Types.ILabel entity, int i)
			{
				ActionLabel actionLabel = new ActionLabel(entity.Text.Value ?? string.Empty);
				ObjectBinder<ActionLabel, IAction.Types.ILabel> objectBinder2 = ActionLabel.CreateBinder(actionLabel, entity);
				objectBinder2.InitializeLeftFromRight();
				entity.RegisterLinkedDisposable(objectBinder2);
				l.OnInsert(i, actionLabel);
			}, l.Collection.Move, delegate(int i)
			{
				ActionLabel actionLabel2 = l.Collection.ElementAtOrDefault(i);
				if (actionLabel2 != null)
				{
					l.Remove(actionLabel2);
				}
			});
		}, null, uiScheduler.Scheduler);
	}

	public SlideLabelCollection(ISyncDataFactory syncDataFactory, IProPresenterDOFactoryProvider factoryProvider, IUiScheduler scheduler, IFlagService flagService, bool loadLegacy)
	{
		_syncDataFactory = syncDataFactory;
		_factoryProvider = factoryProvider;
		_scheduler = scheduler;
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
			_syncer = _factoryProvider.EntityDocumentSyncerFactory.CreateConfigurationSyncer("Labels", (IProLabelsDocumentDoc doc) => CreateBinder(_factoryProvider.EntityFactory, _scheduler, this, doc), () => Serialize().ToByteArray(), delegate(byte[] d)
			{
				SyncDataUpdated(ProLabelsDocument.Parser.ParseFrom(d));
			}, LoadDefaults, loadLegacy);
		}
		else
		{
			_syncedData = _syncDataFactory.GetSyncedData<ProLabelsDocument>(CommonPaths.Configuration, "Labels", SyncDataUpdated, SyncDataCleared);
		}
	}

	private void LoadDefaults()
	{
		SyncDataCleared(DataClearSource.FileRemoved);
	}

	protected virtual void OnConfigPathChanged(string configPath)
	{
		_syncedData?.ChangeTargetDirectoryFilename(configPath, "Labels");
	}

	public void Add(string text, System.Windows.Media.Color color)
	{
		Add(new ActionLabel(text, color));
	}

	public void Add(ActionLabel actionLabel)
	{
		OnInsert(base.Collection.Count, actionLabel);
	}

	public void Add(IEnumerable<ActionLabel> actionLabels)
	{
		actionLabels.ForEach(Add);
	}

	public void Insert(int index, ActionLabel actionLabel, bool autoFinalize = true)
	{
		OnInsert(index, actionLabel, autoFinalize);
	}

	private void OnInsert(int index, ActionLabel actionLabel, bool autoFinalize = true)
	{
		insertLabel();
		UndoStack.Commit(UndoActionTypes.AddSlideLabel.ToAction(), delegate
		{
			Remove(actionLabel);
		}, insertLabel, null, null, autoFinalize);
		void insertLabel()
		{
			actionLabel.UndoStack = UndoStack;
			actionLabel.DataModified += OnContentsModified;
			base.Collection.Insert(index, actionLabel);
		}
	}

	public void OnInsert(IEnumerable<ActionLabel> actionLabels, int index)
	{
		if (actionLabels != null)
		{
			UndoStack?.BeginCommit(UndoActionTypes.AddSlideLabel.ToAction());
			actionLabels.ForEach(delegate(ActionLabel m)
			{
				OnInsert(index++, m);
			});
			UndoStack?.EndCommit(null, null, autoFinalize: true);
		}
	}

	public void Remove(ActionLabel actionLabel, bool autoFinalize = true)
	{
		int index = base.Collection.IndexOf(actionLabel);
		removeLabel();
		UndoStack.Commit(UndoActionTypes.RemoveSlideLabel.ToAction(), delegate
		{
			OnInsert(index, actionLabel);
		}, removeLabel, null, null, autoFinalize);
		void removeLabel()
		{
			actionLabel.DataModified -= OnContentsModified;
			base.Collection.Remove(actionLabel);
		}
	}

	public void RemoveRange(IEnumerable<ActionLabel> slideLables)
	{
		slideLables.ForEach(delegate(ActionLabel r)
		{
			Remove(r);
		});
	}

	public void Clear()
	{
		UndoStack.BeginCommit(UndoActionTypes.RemoveSlideLabel.ToAction());
		foreach (ActionLabel item in base.Collection.ToList())
		{
			Remove(item, autoFinalize: false);
		}
		UndoStack.EndCommit(null, null, autoFinalize: true);
	}

	public void Reset()
	{
		UndoStack.StartIgnoring();
		Clear();
		Add(DefaultLabels.Slide);
		UndoStack.StopIgnoring();
	}

	public void Replace(ActionLabel existingLabel, ActionLabel newLabel)
	{
		if (existingLabel == null)
		{
			Add(newLabel);
			return;
		}
		int index = base.Collection.IndexOf(existingLabel);
		Remove(existingLabel);
		OnInsert(index, newLabel);
	}

	public void DraggedFrom(IEnumerable<ActionLabel> items)
	{
	}

	public void DroppedInto(IEnumerable<ActionLabel> items, int index, bool isCopy)
	{
		UndoStack?.BeginCommit(UndoActionTypes.MoveSlideLabel.ToAction());
		items = (isCopy ? items.CloneItems() : items);
		OnInsert(items, index);
		UndoStack?.EndCommit(null, null, autoFinalize: true);
	}

	public void MoveTo(IEnumerable<ActionLabel> items, int index)
	{
		ActionLabel actionLabel = items.FirstOrDefault();
		int origIndex = ((actionLabel == null) ? (-1) : base.Collection.IndexOf(actionLabel));
		if (origIndex > index)
		{
			origIndex++;
		}
		base.Collection.MoveTo(items, index);
		UndoStack.Commit(UndoActionTypes.MoveSlideLabel.ToAction(), delegate
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

	private void SyncDataUpdated(ProLabelsDocument labelsDocument)
	{
		Deserialize(labelsDocument.Labels);
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

	public ProLabelsDocument Serialize()
	{
		ProLabelsDocument proLabelsDocument = new ProLabelsDocument();
		proLabelsDocument.Labels.AddRange(base.Collection.Select((ActionLabel m) => m.Serialize()));
		return proLabelsDocument;
	}

	public void Deserialize(IEnumerable<Pro.SerializationInterop.RVProtoData.Action.Types.Label> labels, bool removeExisting = true)
	{
		UndoStack.StartIgnoring();
		base.Collection.DeserializeCollection(labels, (ActionLabel l, Pro.SerializationInterop.RVProtoData.Action.Types.Label d) => l.Text == d.Text, (Pro.SerializationInterop.RVProtoData.Action.Types.Label d) => new ActionLabel(string.Empty), Add, delegate(ActionLabel l)
		{
			if (removeExisting)
			{
				Remove(l);
			}
		}, delegate(ActionLabel l, Pro.SerializationInterop.RVProtoData.Action.Types.Label d)
		{
			l.Deserialize(d);
		});
		UndoStack.StopIgnoring();
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
		return new LabelsDocument(_syncer.Document.ExportFullSnapshot(), _syncer.Id);
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
