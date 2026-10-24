using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows.Media;
using Google.Protobuf.Collections;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Strings;
using Pro.Common.Utility;
using Pro.DO.Application;
using Pro.DO.Triggering;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.Localization;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Events;
using ProPresenter.DO.Macros;
using ProPresenter.DO.Settings;

namespace ProPresenter.DO.MacroGroups;

public class MacroGroup : ImmutableObservableCollection<ProPresenterMacro>, IMacroGroup, IDragDropNotifyEnumerableChanged<ProPresenterMacro>, INotifyEnumerableChanged<ProPresenterMacro>, IEnumerable<ProPresenterMacro>, IEnumerable, INotifyCollectionChanged, IDragDropCollection<ProPresenterMacro>, ICutPasteCollection<IMacro>, ICutCollection<IMacro>, IActionRepoContainer, ICloneable<MacroGroup>, INotifyPropertyChanged, IIdentifiable
{
	private readonly IApp _app;

	private Guid _id = Guid.NewGuid();

	private string? _name;

	public UndoStack? UndoStack { get; set; }

	public Guid ID
	{
		get
		{
			return _id;
		}
		private set
		{
			SetValue("ID", ref _id, value, OnDataModified);
		}
	}

	public string Name
	{
		get
		{
			return _name ?? string.Empty;
		}
		set
		{
			SetValue<string>("Name", ref _name, value, delegate(string o, string n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.RenameMacroGroup), this, "Name", o, n, null, null, autoFinalize: true);
				OnDataModified();
			});
		}
	}

	public event System.Action? DataModified;

	public event PropertyChangedEventHandler? MacroPropertyChanged;

	public static ObjectBinder<MacroGroup, IMacrosDocument.Types.IMacroCollection> CreateBinder(IUiScheduler scheduler, IActionBinderFactory actionBinderFactory, IEntityFactory entityFactory, MacroGroup left, IMacrosDocument.Types.IMacroCollection right)
	{
		ObjectBinder<MacroGroup, IMacrosDocument.Types.IMacroCollection> objectBinder = new ObjectBinder<MacroGroup, IMacrosDocument.Types.IMacroCollection>(left, right);
		objectBinder.Bind((MacroGroup l) => l.WhenPropertyChanges("ID"), (IMacrosDocument.Types.IMacroCollection r) => r.Uuid.WhenValueChanges, delegate(MacroGroup l, IMacrosDocument.Types.IMacroCollection r)
		{
			r.Uuid.Set(l.ID);
		}, delegate(IMacrosDocument.Types.IMacroCollection r, MacroGroup l)
		{
			l.ID = r.Uuid.Value;
		}).Bind((MacroGroup l) => l.WhenPropertyChanges("Name"), (IMacrosDocument.Types.IMacroCollection r) => r.Name.WhenValueChanges, delegate(MacroGroup l, IMacrosDocument.Types.IMacroCollection r)
		{
			r.Name.Set(l.Name);
		}, delegate(IMacrosDocument.Types.IMacroCollection r, MacroGroup l)
		{
			l.Name = r.Name.Value;
		}).Bind((MacroGroup l) => l.Collection.WhenCollectionChanges(), (IMacrosDocument.Types.IMacroCollection r) => r.Macros.WhenCollectionChanges, delegate(MacroGroup l, IMacrosDocument.Types.IMacroCollection r)
		{
			r.Macros.SynchronizeFrom(l, (ProPresenterMacro model, IMacrosDocument.Types.IMacro entity) => entity.Uuid.Value == model.ID, delegate(ProPresenterMacro model)
			{
				IMacrosDocument.Types.IMacro macro = entityFactory.Create<IMacrosDocument.Types.IMacro>();
				ObjectBinder<Macro, IMacrosDocument.Types.IMacro> objectBinder2 = Macro.CreateBinder(scheduler, actionBinderFactory, entityFactory, model, macro);
				macro.RegisterLinkedDisposable(objectBinder2);
				objectBinder2.InitializeRightFromLeft();
				return macro;
			});
		}, delegate(IMacrosDocument.Types.IMacroCollection r, MacroGroup l)
		{
			r.Macros.Items.SynchronizeTo(l, (IMacrosDocument.Types.IMacro entity, ProPresenterMacro model) => model.ID == entity.Uuid.Value, delegate(IMacrosDocument.Types.IMacro entity, int i)
			{
				ProPresenterMacro proPresenterMacro = new ProPresenterMacro();
				ObjectBinder<Macro, IMacrosDocument.Types.IMacro> objectBinder3 = Macro.CreateBinder(scheduler, actionBinderFactory, entityFactory, proPresenterMacro, entity);
				entity.RegisterLinkedDisposable(objectBinder3);
				objectBinder3.InitializeLeftFromRight();
				l.InsertMacro(proPresenterMacro, i);
			}, l.Collection.Move, delegate(int i)
			{
				ProPresenterMacro proPresenterMacro2 = l.Collection.ElementAtOrDefault(i);
				if (proPresenterMacro2 != null)
				{
					l.RemoveMacro(proPresenterMacro2);
				}
			});
		}, null, scheduler.Scheduler);
		return objectBinder;
	}

	public MacroGroup(IApp app)
	{
		_app = app;
	}

	public void AddMacro()
	{
		AddMacro(new ProPresenterMacro
		{
			Name = LocalizedStrings.Get("MACROS_WINDOW_NEW_MACRO_name")
		});
	}

	public void AddMacro(ProPresenterMacro macro)
	{
		InsertMacro(macro, base.Collection.Count);
	}

	public void InsertMacro(ProPresenterMacro macro, int index)
	{
		if (macro.Color == default(System.Windows.Media.Color))
		{
			macro.Color = _app.GetNextMacroColor();
		}
		insertAction();
		UndoStack?.Commit(UndoActionTypes.AddMacro.ToAction(), delegate
		{
			RemoveMacro(macro);
		}, insertAction);
		void insertAction()
		{
			macro.DataModified += OnDataModified;
			macro.PropertyChanged += OnMacroPropertyChanged;
			macro.UndoStack = UndoStack;
			macro.Name = macro.Name.DuplicateName(base.Collection.Select((ProPresenterMacro m) => m.Name), (string n) => n);
			macro.ParentCollectionID = ID;
			macro.ParentCollectionName = Name;
			base.Collection.Insert(base.Collection.ClampIndexExclusive(index), macro);
		}
	}

	public void InsertMacros(IEnumerable<ProPresenterMacro> macros, int index)
	{
		if (macros != null)
		{
			UndoStack?.BeginCommit(UndoActionTypes.AddMacro.ToAction());
			macros.ForEach(delegate(ProPresenterMacro m)
			{
				InsertMacro(m, index++);
			});
			UndoStack?.EndCommit(null, null, autoFinalize: true);
		}
	}

	public void RemoveMacro(ProPresenterMacro macro)
	{
		RemoveMacros(macro.ToEnumerable());
	}

	public void RemoveMacros(IEnumerable<ProPresenterMacro> macros)
	{
		KeyValuePair<int, ProPresenterMacro>[] itemIndices = (from m in macros.ToDictionary((ProPresenterMacro m) => base.Collection.IndexOf(m), (ProPresenterMacro i) => i)
			orderby m.Key
			select m).ToArray();
		System.Action action = delegate
		{
			itemIndices.Reverse().ForEach(delegate(KeyValuePair<int, ProPresenterMacro> m)
			{
				m.Value.DataModified -= OnDataModified;
				m.Value.PropertyChanged -= OnMacroPropertyChanged;
				ProPresenterMacro proPresenterMacro = base.Collection.ElementAtOrDefault(m.Key);
				if (proPresenterMacro != null)
				{
					base.Collection.Remove(proPresenterMacro);
				}
			});
		};
		action();
		UndoStack?.Commit(UndoActionTypes.RemoveMacro.ToAction(), delegate
		{
			itemIndices.ForEach(delegate(KeyValuePair<int, ProPresenterMacro> m)
			{
				m.Value.DataModified += OnDataModified;
				base.Collection.Insert(m.Key, m.Value);
			});
		}, action, null, null, autoFinalize: true);
	}

	public MacrosDocument.Types.MacroCollection Serialize(MacrosDocument document)
	{
		RepeatedField<MacrosDocument.Types.Macro> macros = document.Macros;
		List<MacrosDocument.Types.Macro> obj = new List<MacrosDocument.Types.Macro>();
		obj.AddRange(base.Collection.Select((ProPresenterMacro m) => m.Serialize()));
		macros.AddRange(new _003C_003Ez__ReadOnlyList<MacrosDocument.Types.Macro>(obj));
		MacrosDocument.Types.MacroCollection macroCollection = new MacrosDocument.Types.MacroCollection();
		macroCollection.Uuid = ID.ToUUID();
		macroCollection.Name = Name;
		macroCollection.Items.AddRange(base.Collection.Select((ProPresenterMacro m) => new MacrosDocument.Types.MacroCollection.Types.Item
		{
			MacroId = m.ID.ToUUID()
		}));
		return macroCollection;
	}

	public void Deserialize(MacrosDocument document, MacrosDocument.Types.MacroCollection collection, ApplicationData? applicationData)
	{
		Guid[] collectionIDs = (from i in collection.Items
			where i.ItemTypeCase == MacrosDocument.Types.MacroCollection.Types.Item.ItemTypeOneofCase.MacroId
			select i.MacroId.ToGuid()).ToArray();
		UndoStack?.StartIgnoring();
		ID = collection.Uuid.ToGuid();
		Name = collection.Name;
		base.Collection.DeserializeCollection(document.Macros.Where((MacrosDocument.Types.Macro m) => collectionIDs.Contains(m.Uuid.ToGuid())), (ProPresenterMacro m, MacrosDocument.Types.Macro p) => m.ID == p.Uuid.ToGuid(), (MacrosDocument.Types.Macro p) => new ProPresenterMacro(UndoStack), AddMacro, RemoveMacro, delegate(ProPresenterMacro m, MacrosDocument.Types.Macro p)
		{
			m.DataModified -= OnDataModified;
			m.ParentCollectionID = ID;
			m.Deserialize(p, applicationData);
			m.DataModified += OnDataModified;
		});
		UndoStack?.StopIgnoring();
	}

	protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
	{
		OnDataModified();
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke();
		MacrosUpdated.Publish(base.Collection);
	}

	private void OnMacroPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		this.MacroPropertyChanged?.Invoke(sender, e);
	}

	public void DraggedFrom(IEnumerable<ProPresenterMacro> items)
	{
	}

	public void DroppedInto(IEnumerable<ProPresenterMacro> items, int index, bool isCopy)
	{
		UndoStack?.BeginCommit(UndoActionTypes.MoveMacro.ToAction());
		object enumerable;
		if (!isCopy)
		{
			enumerable = items;
		}
		else
		{
			enumerable = items.OfType<IMacro>().CloneItems();
		}
		IEnumerable<IMacro> source = (IEnumerable<IMacro>)enumerable;
		InsertMacros(source.OfType<ProPresenterMacro>(), index);
		UndoStack?.EndCommit(null, null, autoFinalize: true);
	}

	public void MoveTo(IEnumerable<ProPresenterMacro> items, int index)
	{
		ProPresenterMacro proPresenterMacro = items.FirstOrDefault();
		int origIndex = ((proPresenterMacro == null) ? (-1) : base.Collection.IndexOf(proPresenterMacro));
		if (origIndex > index)
		{
			origIndex++;
		}
		base.Collection.MoveTo(items, index);
		UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.MoveMacro), delegate
		{
			MoveTo(items, origIndex);
		}, delegate
		{
			MoveTo(items, index);
		}, null, null, autoFinalize: true);
	}

	public void CutFrom(IEnumerable<IMacro> items)
	{
		RemoveMacros(items.OfType<ProPresenterMacro>().AsEnumerable());
	}

	public void PasteInto(IEnumerable<IMacro> items, int index)
	{
		InsertMacros(items.OfType<ProPresenterMacro>(), index);
	}

	public void Insert(IEnumerable<IActionRepository> newRepos, IActionRepository? repo, bool insertBefore)
	{
		if (newRepos != null)
		{
			int num = ((!insertBefore) ? 1 : 0);
			int index = ((!(repo is ProPresenterMacro value)) ? base.Count : (IndexOf(value) + num));
			InsertMacros(newRepos.OfType<ProPresenterMacro>(), index);
		}
	}

	internal void Save()
	{
		OnDataModified();
	}

	public MacroGroup Clone()
	{
		MacroGroup macroGroup = new MacroGroup(_app)
		{
			Name = Name
		};
		foreach (IMacro item in base.Collection.Select((ProPresenterMacro m) => m.Clone()).ToList())
		{
			if (item is ProPresenterMacro macro)
			{
				macroGroup.AddMacro(macro);
			}
		}
		return macroGroup;
	}
}
