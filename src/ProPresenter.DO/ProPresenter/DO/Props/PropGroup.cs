using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Strings;
using Pro.Common.Utility;
using Pro.DO;
using Pro.DO.Application;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.Localization.Services;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Events;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Themes;

namespace ProPresenter.DO.Props;

public class PropGroup : ImmutableObservableCollection<IPropCue>, IPropGroup, IImmutableObservableCollection<IPropCue>, IReadOnlyList<IPropCue>, IEnumerable<IPropCue>, IEnumerable, IReadOnlyCollection<IPropCue>, INotifyEnumerableChanged<IPropCue>, INotifyCollectionChanged, IDragDropNotifyEnumerableChanged<IPropCue>, IDragDropCollection<IPropCue>, ICutPasteCollection<IPropCue>, ICutCollection<IPropCue>, INotifyPropertyChanged, ICloneable<IPropGroup>, IIdentifiable
{
	private readonly ILocalization _localization;

	private UndoStack? _undoStack;

	private bool _singleMode;

	private string _name = string.Empty;

	protected IApp App { get; }

	protected IProPresenterDOFactoryProvider FactoryProvider { get; }

	protected ITransitionDescriptionCollection TransitionDescriptions { get; }

	public UndoStack? UndoStack
	{
		get
		{
			return _undoStack;
		}
		set
		{
			_undoStack = value;
			this.ForEach(delegate(IPropCue x)
			{
				x.UndoStack = value;
			});
		}
	}

	public Guid ID { get; private set; } = Guid.NewGuid();

	public string Name
	{
		get
		{
			return _name;
		}
		set
		{
			SetValue("Name", ref _name, value, delegate(string o, string n)
			{
				UndoStack?.Commit(UndoActionTypes.RenamePropGroup.ToAction(), this, "Name", o, n);
				OnDataModified();
			});
		}
	}

	public bool SingleMode
	{
		get
		{
			return _singleMode;
		}
		set
		{
			SetValue("SingleMode", ref _singleMode, value, delegate(bool o, bool n)
			{
				UndoStack?.Commit(UndoActionTypes.PropGroupSingleMode.ToAction(), this, "SingleMode", o, n);
				OnDataModified();
			});
		}
	}

	public event System.Action? DataModified;

	public IReadOnlyObjectBinder<IPropGroup, IPropDocument.Types.IPropCollection> Bind(IUiScheduler scheduler, IApp app, IProPresenterDOFactoryProvider factoryProvider, IPropDocument.Types.IPropCollection entity)
	{
		IEntityFactory entityFactory = factoryProvider.EntityFactory;
		ObjectBinder<PropGroup, IPropDocument.Types.IPropCollection> objectBinder = new ObjectBinder<PropGroup, IPropDocument.Types.IPropCollection>(this, entity);
		objectBinder.Bind((PropGroup l) => l.WhenPropertyChanges("ID"), (IPropDocument.Types.IPropCollection r) => r.Uuid.WhenValueChanges, delegate(PropGroup l, IPropDocument.Types.IPropCollection r)
		{
			r.Uuid.Set(l.ID);
		}, delegate(IPropDocument.Types.IPropCollection r, PropGroup l)
		{
			l.ID = r.Uuid.Value;
		}).Bind((PropGroup l) => l.WhenPropertyChanges("Name"), (IPropDocument.Types.IPropCollection r) => r.Name.WhenValueChanges, delegate(PropGroup l, IPropDocument.Types.IPropCollection r)
		{
			r.Name.Set(l.Name);
		}, delegate(IPropDocument.Types.IPropCollection r, PropGroup l)
		{
			l.Name = r.Name.Value;
		}).Bind((PropGroup l) => l.WhenPropertyChanges("SingleMode"), (IPropDocument.Types.IPropCollection r) => r.SinglePropEnabled.WhenValueChanges, delegate(PropGroup l, IPropDocument.Types.IPropCollection r)
		{
			r.SinglePropEnabled.Set(l.SingleMode);
		}, delegate(IPropDocument.Types.IPropCollection r, PropGroup l)
		{
			l.SingleMode = r.SinglePropEnabled.Value;
		})
			.Bind((PropGroup l) => l.Collection.WhenCollectionChanges(), (IPropDocument.Types.IPropCollection r) => r.Cues.WhenCollectionChanges, delegate(PropGroup l, IPropDocument.Types.IPropCollection r)
			{
				r.Cues.SynchronizeFrom(l, (IPropCue model, ICue entity) => entity.Uuid.Value == model.ID, delegate(IPropCue model)
				{
					ICue cue = entityFactory.Create<ICue>();
					IReadOnlyObjectBinder<IPropCue, ICue> readOnlyObjectBinder = model.Bind(scheduler, factoryProvider, cue);
					cue.RegisterLinkedDisposable(readOnlyObjectBinder);
					readOnlyObjectBinder.InitializeRightFromLeft();
					return cue;
				});
			}, delegate(IPropDocument.Types.IPropCollection r, PropGroup l)
			{
				r.Cues.Items.SynchronizeTo(l, (ICue e, IPropCue m) => m.ID == e.Uuid.Value, delegate(ICue e, int i)
				{
					PropCue propCue = new PropCue(app, factoryProvider, l.TransitionDescriptions);
					IReadOnlyObjectBinder<IPropCue, ICue> readOnlyObjectBinder2 = propCue.Bind(scheduler, factoryProvider, e);
					readOnlyObjectBinder2.InitializeLeftFromRight();
					e.RegisterLinkedDisposable(readOnlyObjectBinder2);
					l.InsertProp(propCue, i);
				}, l.Collection.Move, delegate(int i)
				{
					IPropCue propCue2 = l.ElementAtOrDefault(i);
					if (propCue2 != null)
					{
						l.RemoveProp(propCue2);
					}
				});
			}, null, scheduler.Scheduler);
		return objectBinder;
	}

	public PropGroup(IApp app, ILocalization localization, IProPresenterDOFactoryProvider factoryProvider, ITransitionDescriptionCollection transitionDescriptions)
	{
		App = app;
		_localization = localization;
		FactoryProvider = factoryProvider;
		TransitionDescriptions = transitionDescriptions;
	}

	public IPropCue AddProp(TemplateSlide? template = null)
	{
		PropCue propCue = new PropCue(App, FactoryProvider, TransitionDescriptions, template)
		{
			Name = _localization.Get("PROPS_WINDOW_NEW_PROP_name").DuplicateName(base.Collection.Select((IPropCue g) => g.Name), (string n) => n)
		};
		AddProp(propCue);
		return propCue;
	}

	public void AddProp(IPropCue cue)
	{
		InsertProps(cue.ToEnumerable(), base.Collection.Count);
	}

	public void AddProps(IEnumerable<IPropCue> cues)
	{
		cues.ForEach(AddProp);
	}

	public IPropGroup Clone()
	{
		PropGroup clone = new PropGroup(App, _localization, FactoryProvider, TransitionDescriptions)
		{
			Name = Name,
			SingleMode = SingleMode
		};
		base.Collection.CloneItems().ForEach(delegate(IPropCue prop)
		{
			clone.AddProp(prop);
			prop.ParentCollectionID = ID;
			prop.ParentCollectionName = Name;
		});
		return clone;
	}

	public void CutFrom(IEnumerable<IPropCue> items)
	{
		RemoveProps(items.OfType<IPropCue>().AsEnumerable());
	}

	public void DraggedFrom(IEnumerable<IPropCue> items)
	{
		RemoveProps(items.OfType<IPropCue>().AsEnumerable());
	}

	public void DroppedInto(IEnumerable<IPropCue> items, int index, bool isCopy)
	{
		UndoStack?.BeginCommit(UndoActionTypes.MovePropGroup.ToAction());
		items = (isCopy ? items.CloneItems() : items);
		InsertProps(items, index);
		UndoStack?.EndCommit(null, null, autoFinalize: true);
	}

	public void InsertProp(IPropCue cue, int index)
	{
		insertAction();
		UndoStack?.Commit(UndoActionTypes.AddProp.ToAction(), delegate
		{
			RemoveProp(cue);
		}, insertAction);
		void insertAction()
		{
			cue.DataModified += OnDataModified;
			cue.UndoStack = UndoStack;
			cue.ParentCollectionID = ID;
			cue.ParentCollectionName = Name;
			base.Collection.Insert(base.Collection.ClampIndexExclusive(index), cue);
		}
	}

	public IPropCue InsertProp(TemplateSlide? template, int index)
	{
		PropCue propCue = new PropCue(App, FactoryProvider, TransitionDescriptions, template)
		{
			Name = _localization.Get("PROPS_WINDOW_NEW_PROP_name").DuplicateName(base.Collection.Select((IPropCue g) => g.Name), (string n) => n)
		};
		InsertProp(propCue, index);
		return propCue;
	}

	public void InsertProps(IEnumerable<IPropCue> cues, int index)
	{
		if (cues != null)
		{
			UndoStack?.BeginCommit(UndoActionTypes.AddProp.ToAction());
			cues.ForEach(delegate(IPropCue m)
			{
				InsertProp(m, index++);
			});
			UndoStack?.EndCommit(null, null, autoFinalize: true);
		}
	}

	public void MoveTo(IEnumerable<IPropCue> items, int index)
	{
		IPropCue propCue = items.FirstOrDefault();
		int origIndex = ((propCue == null) ? (-1) : base.Collection.IndexOf(propCue));
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

	public void PasteInto(IEnumerable<IPropCue> items, int index)
	{
		InsertProps(items, index);
	}

	public void RemoveProp(IPropCue cue)
	{
		RemoveProps(cue.ToEnumerable());
	}

	public void RemoveProps(IEnumerable<IPropCue> cues)
	{
		KeyValuePair<int, IPropCue>[] itemIndices = (from m in cues.Distinct().ToDictionary(base.Collection.IndexOf, (IPropCue i) => i)
			orderby m.Key
			select m).ToArray();
		System.Action action = delegate
		{
			itemIndices.Reverse().ForEach(delegate(KeyValuePair<int, IPropCue> m)
			{
				m.Value.DataModified -= OnDataModified;
				IPropCue propCue = base.Collection.ElementAtOrDefault(m.Key);
				if (propCue != null)
				{
					base.Collection.Remove(propCue);
				}
			});
		};
		action();
		UndoStack?.Commit(UndoActionTypes.RemovePropGroup.ToAction(), delegate
		{
			itemIndices.ForEach(delegate(KeyValuePair<int, IPropCue> m)
			{
				m.Value.DataModified += OnDataModified;
				base.Collection.Insert(m.Key, m.Value);
			});
		}, action, null, null, autoFinalize: true);
	}

	public PropDocument.Types.PropCollection Serialize()
	{
		PropDocument.Types.PropCollection propCollection = new PropDocument.Types.PropCollection
		{
			Uuid = ID.ToUUID(),
			Name = (Name ?? string.Empty),
			SinglePropEnabled = SingleMode
		};
		foreach (IPropCue item in base.Collection)
		{
			propCollection.Items.Add(new PropDocument.Types.PropCollection.Types.Item
			{
				PropCueUuid = item.ID.ToUUID()
			});
		}
		return propCollection;
	}

	public void Deserialize(PropDocument document, PropDocument.Types.PropCollection collection, ApplicationData? applicationData)
	{
		Guid[] collectionIDs = (from i in collection.Items
			where i.ItemTypeCase == PropDocument.Types.PropCollection.Types.Item.ItemTypeOneofCase.PropCueUuid
			select i.PropCueUuid.ToGuid()).ToArray();
		UndoStack?.StartIgnoring();
		ID = collection.Uuid.ToGuid();
		Name = collection.Name;
		SingleMode = collection.SinglePropEnabled;
		base.Collection.DeserializeCollection(document.Cues.Where((Pro.SerializationInterop.RVProtoData.Cue m) => collectionIDs.Contains(m.Uuid.ToGuid())), (IPropCue m, Pro.SerializationInterop.RVProtoData.Cue p) => m.ID == p.Uuid.ToGuid(), (Pro.SerializationInterop.RVProtoData.Cue p) => new PropCue(App, FactoryProvider, TransitionDescriptions), AddProp, RemoveProp, delegate(IPropCue m, Pro.SerializationInterop.RVProtoData.Cue p)
		{
			m.DataModified -= OnDataModified;
			m.Deserialize(p, applicationData, MediaContainerIds.Prop(ID));
			m.ParentCollectionID = ID;
			m.ParentCollectionName = Name;
			m.DataModified += OnDataModified;
		});
		UndoStack?.StopIgnoring();
	}

	private void OnDataModified(Pro.DO.Triggering.Cue cue)
	{
		OnDataModified();
	}

	protected void OnDataModified()
	{
		this.DataModified?.Invoke();
		PropsUpdated.Publish();
	}

	protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
	{
		base.OnCollectionChanged(e);
		OnDataModified();
	}
}
