using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Strings;
using Pro.DO.Application;
using Pro.DO.Triggering;
using Pro.DO.Utility;
using Pro.Serialization.Utility;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Events;
using ProPresenter.DO.Settings;

namespace ProPresenter.DO.Macros;

public class MacroCollection : ImmutableObservableCollection<ProPresenterMacro>, IDragDropNotifyEnumerableChanged<ProPresenterMacro>, INotifyEnumerableChanged<ProPresenterMacro>, IEnumerable<ProPresenterMacro>, IEnumerable, INotifyCollectionChanged, IDragDropCollection<ProPresenterMacro>, ICutPasteCollection<IMacro>, ICutCollection<IMacro>, IActionRepoContainer
{
	private readonly IApp _app;

	public UndoStack UndoStack { get; } = new UndoStack();

	public event System.Action? DataModified;

	public event PropertyChangedEventHandler? MacroPropertyChanged;

	public MacroCollection(IApp app)
	{
		_app = app;
	}

	public void AddMacro()
	{
		AddMacro(new ProPresenterMacro());
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
		KeyValuePair<int, ProPresenterMacro>[] itemIndices = (from m in macros.ToDictionary(base.Collection.IndexOf, (ProPresenterMacro i) => i)
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

	public MacrosDocument Serialize()
	{
		MacrosDocument macrosDocument = new MacrosDocument();
		macrosDocument.ApplicationInfo = new ApplicationData(ApplicationType.ProPresenter).Serialize();
		macrosDocument.Macros.AddRange(base.Collection.Select((ProPresenterMacro m) => m.Serialize()));
		return macrosDocument;
	}

	public void Deserialize(MacrosDocument document)
	{
		ApplicationData applicationData = ApplicationData.Deserialize(document.ApplicationInfo);
		UndoStack?.StartIgnoring();
		base.Collection.DeserializeCollection(document.Macros, (ProPresenterMacro m, MacrosDocument.Types.Macro p) => m.ID == p.Uuid.ToGuid(), (MacrosDocument.Types.Macro p) => new ProPresenterMacro(UndoStack), delegate(ProPresenterMacro m)
		{
			AddMacro(m);
		}, RemoveMacro, delegate(ProPresenterMacro m, MacrosDocument.Types.Macro p)
		{
			m.DataModified -= OnDataModified;
			m.Deserialize(p, applicationData);
			m.DataModified += OnDataModified;
		});
		UndoStack?.StopIgnoring();
		MacroCollectionSource macroSource = new MacroCollectionSource(this);
		base.Collection.ForEach(delegate(ProPresenterMacro m)
		{
			m.Actions.OfType<MacroAction>().ForEach(delegate(MacroAction m)
			{
				m.AssignMacroSource(macroSource);
			});
		});
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

	public void SetTriggerOnStartup(ProPresenterMacro? macro, bool triggerOnStartUp)
	{
		if (macro != null && !base.Collection.Contains(macro))
		{
			return;
		}
		UndoStack?.BeginCommit(UndoActionTypes.TriggerOnStartup.ToAction());
		ProPresenterMacro existing = base.Collection.FirstOrDefault((ProPresenterMacro m) => m.TriggerOnStartup);
		if (macro == null)
		{
			base.Collection.ForEach(delegate(ProPresenterMacro m)
			{
				m.SetTriggerOnstartup(triggerOnStartup: false);
			});
		}
		else
		{
			macro.SetTriggerOnstartup(triggerOnStartUp);
			base.Collection.Except<ProPresenterMacro>(macro).ForEach(delegate(ProPresenterMacro m)
			{
				m.SetTriggerOnstartup(triggerOnStartup: false);
			});
		}
		UndoStack?.Commit(delegate
		{
			SetTriggerOnStartup(existing, triggerOnStartUp);
		}, delegate
		{
			SetTriggerOnStartup(macro, triggerOnStartUp);
		});
		UndoStack?.EndCommit(null, null, autoFinalize: true);
	}

	public void CutFrom(IEnumerable<IMacro> items)
	{
		RemoveMacros(items.OfType<ProPresenterMacro>().ToArray());
	}

	public void PasteInto(IEnumerable<IMacro> items, int index)
	{
		InsertMacros(items.OfType<ProPresenterMacro>(), index);
	}

	public void Insert(IEnumerable<IActionRepository> newRepos, IActionRepository? repo, bool insertBefore)
	{
		if (newRepos != null)
		{
			int index = ((!(repo is ProPresenterMacro value)) ? base.Count : (IndexOf(value) + ((!insertBefore) ? 1 : 0)));
			InsertMacros(newRepos.OfType<ProPresenterMacro>(), index);
		}
	}

	internal void Save()
	{
		OnDataModified();
	}
}
