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
using Pro.DO.Triggering;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.Entity.Persistence;
using Pro.Localization.Services;
using Pro.Serialization.DataManagement;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Actions;
using ProPresenter.DO.ChangeDirectory;
using ProPresenter.DO.Extensions;
using ProPresenter.DO.Macros;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Workspaces;

namespace ProPresenter.DO.MacroGroups;

[Pro.Common.SourceGenerator.Attributes.Disposable(new string[] { "_syncer", "_syncedData" })]
public class MacroGroupCollection : ImmutableObservableCollection<MacroGroup>, IMacroGroupCollection, IDragDropNotifyEnumerableChanged<MacroGroup>, INotifyEnumerableChanged<MacroGroup>, IEnumerable<MacroGroup>, IEnumerable, INotifyCollectionChanged, IDragDropCollection<MacroGroup>, IImmutableObservableCollection<MacroGroup>, IReadOnlyList<MacroGroup>, IReadOnlyCollection<MacroGroup>, IDocumentProvider, IDisposable
{
	private IProtoSyncedData<Pro.SerializationInterop.RVProtoData.MacrosDocument>? _syncedData;

	private readonly ISyncDataFactory _syncDataFactory;

	private readonly IApp _app;

	private readonly ILocalization _localization;

	private readonly IUiScheduler _uiScheduler;

	private readonly IFlagService _flagService;

	private readonly IActionBinderFactory _actionBinderFactory;

	private readonly IEntityDocumentSyncerFactory _entitySyncerFactory;

	private readonly IEntityFactory _entityFactory;

	private readonly IDocumentFactory _entityDocumentFactory;

	private bool _isDeserializing;

	private IEntityDocumentSyncer<IMacrosDocumentDoc>? _syncer;

	[GeneratedCode("Pro.Common.SourceGenerator", "1.0.0.0")]
	private bool _disposed;

	public UndoStack UndoStack { get; } = new UndoStack();

	public Guid DocumentId => _syncer?.Id ?? Guid.Empty;

	public event System.Action? DataModified;

	public event System.Action? TargetDirectoryChanged;

	public static ObjectBinder<MacroGroupCollection, IMacrosDocument> CreateBinder(IUiScheduler uiScheduler, IActionBinderFactory actionBinderFactory, IEntityFactory entityFactory, IApp app, MacroGroupCollection left, IMacrosDocument right)
	{
		ObjectBinder<MacroGroupCollection, IMacrosDocument> objectBinder = new ObjectBinder<MacroGroupCollection, IMacrosDocument>(left, right);
		objectBinder.Bind((MacroGroupCollection l) => l.Collection.WhenCollectionChanges(), (IMacrosDocument r) => r.MacroCollections.WhenCollectionChanges, delegate(MacroGroupCollection l, IMacrosDocument r)
		{
			r.MacroCollections.SynchronizeFrom(l, (MacroGroup model, IMacrosDocument.Types.IMacroCollection entity) => entity.Uuid.Value == model.ID, delegate(MacroGroup model)
			{
				IMacrosDocument.Types.IMacroCollection macroCollection = entityFactory.Create<IMacrosDocument.Types.IMacroCollection>();
				ObjectBinder<MacroGroup, IMacrosDocument.Types.IMacroCollection> objectBinder2 = MacroGroup.CreateBinder(uiScheduler, actionBinderFactory, entityFactory, model, macroCollection);
				macroCollection.RegisterLinkedDisposable(objectBinder2);
				objectBinder2.InitializeRightFromLeft();
				return macroCollection;
			});
		}, delegate(IMacrosDocument r, MacroGroupCollection l)
		{
			r.MacroCollections.Items.SynchronizeTo(l, (IMacrosDocument.Types.IMacroCollection e, MacroGroup m) => m.ID == e.Uuid.Value, delegate(IMacrosDocument.Types.IMacroCollection e, int i)
			{
				MacroGroup macroGroup = new MacroGroup(app);
				ObjectBinder<MacroGroup, IMacrosDocument.Types.IMacroCollection> objectBinder3 = MacroGroup.CreateBinder(uiScheduler, actionBinderFactory, entityFactory, macroGroup, e);
				objectBinder3.InitializeLeftFromRight();
				e.RegisterLinkedDisposable(objectBinder3);
				l.InsertMacroGroup(macroGroup, i);
			}, l.Collection.Move, delegate(int i)
			{
				MacroGroup macroGroup2 = l.ElementAtOrDefault(i);
				if (macroGroup2 != null)
				{
					l.RemoveMacroGroup(macroGroup2);
				}
			});
		}, null, uiScheduler.Scheduler);
		return objectBinder;
	}

	public MacroGroupCollection(ISyncDataFactory syncDataFactory, IApp app, ILocalization localization, IUiScheduler uiScheduler, IFlagService flagService, IActionBinderFactory actionBinderFactory, IEntityDocumentSyncerFactory entitySyncerFactory, IEntityFactory entityFactory, IDocumentFactory documentFactory, bool loadLegacy)
	{
		_syncDataFactory = syncDataFactory;
		_app = app;
		_localization = localization;
		_uiScheduler = uiScheduler;
		_flagService = flagService;
		_actionBinderFactory = actionBinderFactory;
		_entitySyncerFactory = entitySyncerFactory;
		_entityFactory = entityFactory;
		_entityDocumentFactory = documentFactory;
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
			_syncer = _entitySyncerFactory.CreateConfigurationSyncer("Macros", (IMacrosDocumentDoc doc) => CreateBinder(_uiScheduler, _actionBinderFactory, _entityFactory, _app, this, doc), () => Serialize().ToByteArray(), delegate(byte[] d)
			{
				Deserialize(Pro.SerializationInterop.RVProtoData.MacrosDocument.Parser.ParseFrom(d));
			}, LoadDefaults, loadLegacy);
		}
		else
		{
			_syncedData = _syncDataFactory.GetSyncedData<Pro.SerializationInterop.RVProtoData.MacrosDocument>(CommonPaths.Configuration, "Macros", Deserialize, SyncedDataCleared);
		}
		this.TargetDirectoryChanged?.Invoke();
	}

	private void LoadDefaults()
	{
		SyncedDataCleared(DataClearSource.FileRemoved);
	}

	public MacroGroup AddMacroGroup()
	{
		MacroGroup macroGroup = new MacroGroup(_app)
		{
			Name = _localization.Get("MACRO_COLLECTION_ADD_name")
		};
		macroGroup.Name = macroGroup.Name.DuplicateName(base.Collection.Select((MacroGroup g) => g.Name), (string n) => n);
		AddMacroGroup(macroGroup);
		return macroGroup;
	}

	public void AddMacroGroup(MacroGroup macroGroup)
	{
		InsertMacroGroup(macroGroup, base.Collection.Count);
	}

	public void InsertMacroGroup(MacroGroup macroGroup, int index)
	{
		insertAction();
		UndoStack?.Commit(UndoActionTypes.AddMacroGroup.ToAction(), delegate
		{
			RemoveMacroGroup(macroGroup);
		}, insertAction);
		void insertAction()
		{
			macroGroup.DataModified += OnDataModified;
			macroGroup.UndoStack = UndoStack;
			base.Collection.Insert(base.Collection.ClampIndexExclusive(index), macroGroup);
		}
	}

	private void OnInsert(IEnumerable<MacroGroup> macroGroups, int index)
	{
		if (macroGroups != null)
		{
			UndoStack?.BeginCommit(UndoActionTypes.AddMacro.ToAction());
			macroGroups.ForEach(delegate(MacroGroup m)
			{
				InsertMacroGroup(m, index++);
			});
			UndoStack?.EndCommit(null, null, autoFinalize: true);
		}
	}

	public void RemoveMacroGroup(MacroGroup macroGroup)
	{
		RemoveMacroGroups(macroGroup.ToEnumerable());
	}

	public void RemoveMacroGroups(IEnumerable<MacroGroup> macroGroups)
	{
		KeyValuePair<int, MacroGroup>[] itemIndices = (from m in macroGroups.ToDictionary((MacroGroup m) => base.Collection.IndexOf(m), (MacroGroup i) => i)
			orderby m.Key
			select m).ToArray();
		System.Action action = delegate
		{
			itemIndices.Reverse().ForEach(delegate(KeyValuePair<int, MacroGroup> m)
			{
				m.Value.DataModified -= OnDataModified;
				MacroGroup macroGroup = base.Collection.ElementAtOrDefault(m.Key);
				if (macroGroup != null)
				{
					base.Collection.Remove(macroGroup);
				}
			});
		};
		action();
		UndoStack?.Commit(UndoActionTypes.RemoveMacroGroup.ToAction(), delegate
		{
			itemIndices.ForEach(delegate(KeyValuePair<int, MacroGroup> m)
			{
				m.Value.DataModified += OnDataModified;
				base.Collection.Insert(m.Key, m.Value);
			});
		}, action, null, null, autoFinalize: true);
	}

	public Pro.SerializationInterop.RVProtoData.MacrosDocument Serialize()
	{
		Pro.SerializationInterop.RVProtoData.MacrosDocument document = new Pro.SerializationInterop.RVProtoData.MacrosDocument
		{
			ApplicationInfo = new ApplicationData(ApplicationType.ProPresenter).Serialize()
		};
		Pro.SerializationInterop.RVProtoData.MacrosDocument.Types.MacroCollection[] values = base.Collection.Select((MacroGroup m) => m.Serialize(document)).ToArray();
		document.MacroCollections.AddRange(values);
		return document;
	}

	public void Deserialize(Pro.SerializationInterop.RVProtoData.MacrosDocument document)
	{
		ApplicationData applicationData = ApplicationData.Deserialize(document.ApplicationInfo);
		_isDeserializing = true;
		UndoStack?.StartIgnoring();
		base.Collection.DeserializeCollection(document.MacroCollections, (MacroGroup g, Pro.SerializationInterop.RVProtoData.MacrosDocument.Types.MacroCollection p) => g.ID == p.Uuid.ToGuid(), (Pro.SerializationInterop.RVProtoData.MacrosDocument.Types.MacroCollection p) => new MacroGroup(_app), AddMacroGroup, RemoveMacroGroup, delegate(MacroGroup g, Pro.SerializationInterop.RVProtoData.MacrosDocument.Types.MacroCollection p)
		{
			g.Deserialize(document, p, applicationData);
		});
		if (base.Collection.Empty())
		{
			AddDefaultMacro();
		}
		ProPresenterMacro[] allMacros = base.Collection.SelectMany((MacroGroup g) => g).ToArray();
		Pro.SerializationInterop.RVProtoData.MacrosDocument.Types.Macro[] array = document.Macros.Where((Pro.SerializationInterop.RVProtoData.MacrosDocument.Types.Macro p) => allMacros.None((ProPresenterMacro m) => m.ID == p.Uuid.ToGuid())).ToArray();
		if (array.Any())
		{
			MacroGroup macroGroup = base.Collection[0];
			Pro.SerializationInterop.RVProtoData.MacrosDocument.Types.Macro[] array2 = array;
			foreach (Pro.SerializationInterop.RVProtoData.MacrosDocument.Types.Macro protoMacro in array2)
			{
				ProPresenterMacro proPresenterMacro = new ProPresenterMacro();
				proPresenterMacro.Deserialize(protoMacro, applicationData);
				macroGroup.AddMacro(proPresenterMacro);
			}
		}
		UndoStack?.StopIgnoring();
		_isDeserializing = false;
		MacroGroupSource macroSource = new MacroGroupSource(this);
		base.Collection.SelectMany((MacroGroup g) => g).ForEach(delegate(ProPresenterMacro m)
		{
			m.Actions.OfType<MacroAction>().ForEach(delegate(MacroAction m)
			{
				m.AssignMacroSource(macroSource);
			});
		});
	}

	public void AddDefaultMacro()
	{
		AddMacroGroup(new MacroGroup(_app)
		{
			Name = _localization.Get("MACRO_COLLECTION_DEFAULT_name")
		});
	}

	private void SyncedDataCleared(DataClearSource dataClearSource)
	{
		if (dataClearSource == DataClearSource.FileRemoved)
		{
			UndoStack.StartIgnoring();
			RemoveMacroGroups(base.Collection.ToArray());
			AddDefaultMacro();
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
		}
	}

	public void DraggedFrom(IEnumerable<MacroGroup> items)
	{
	}

	public void DroppedInto(IEnumerable<MacroGroup> items, int index, bool isCopy)
	{
		UndoStack?.BeginCommit(UndoActionTypes.MoveMacroGroup.ToAction());
		items = (isCopy ? items.CloneItems() : items);
		OnInsert(items, index);
		UndoStack?.EndCommit(null, null, autoFinalize: true);
	}

	public void MoveTo(IEnumerable<MacroGroup> items, int index)
	{
		MacroGroup macroGroup = items.FirstOrDefault();
		int origIndex = ((macroGroup == null) ? (-1) : base.Collection.IndexOf(macroGroup));
		if (origIndex > index)
		{
			origIndex++;
		}
		base.Collection.MoveTo(items, index);
		UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.MoveMacroGroup), delegate
		{
			MoveTo(items, origIndex);
		}, delegate
		{
			MoveTo(items, index);
		}, null, null, autoFinalize: true);
	}

	public void SetTriggerOnStartup(ProPresenterMacro? macro, bool triggerOnStartUp)
	{
		if (macro == null)
		{
			return;
		}
		ProPresenterMacro[] source = base.Collection.SelectMany((MacroGroup g) => g).ToArray();
		if (source.Contains<ProPresenterMacro>(macro))
		{
			UndoStack?.BeginCommit(UndoActionTypes.TriggerOnStartup.ToAction());
			ProPresenterMacro existing = source.FirstOrDefault((ProPresenterMacro m) => m.TriggerOnStartup);
			macro.SetTriggerOnstartup(triggerOnStartUp);
			source.Except<ProPresenterMacro>(macro).ForEach(delegate(ProPresenterMacro m)
			{
				m.SetTriggerOnstartup(triggerOnStartup: false);
			});
			UndoStack?.Commit(delegate
			{
				SetTriggerOnStartup(existing, triggerOnStartUp);
			}, delegate
			{
				SetTriggerOnStartup(macro, triggerOnStartUp);
			});
			UndoStack?.EndCommit(null, null, autoFinalize: true);
		}
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
		return new Pro.CoreApplication.Document.Intrinsic.MacrosDocument(_syncer.Document.ExportFullSnapshot(), _syncer.Id);
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
