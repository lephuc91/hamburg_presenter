using System;
using System.Collections.Specialized;
using System.Linq;
using Pro.Common.Collections;
using Pro.UI.InputActions;
using ProPresenter.DO.MacroGroups;

namespace ProPresenter.DO.InputActionMap;

public class MacroGroupsInputActionCollection : InputActionGroupCollectionBase
{
	private readonly Func<IMacroGroup, MacroGroup> _setup;

	private readonly Action<MacroGroup> _tearDown;

	protected internal IMacroGroupCollection? Source { get; private set; }

	public MacroGroupsInputActionCollection(Func<IMacroGroup, MacroGroup> setup, Action<MacroGroup> tearDown)
	{
		_setup = setup;
		_tearDown = tearDown;
	}

	public void ChangeSource(IMacroGroupCollection collection)
	{
		if (Source != null)
		{
			Source.CollectionChanged -= OnSourceCollectionChanged;
			if (_tearDown != null)
			{
				base.Collection.OfType<MacroGroup>().ForEach(delegate(MacroGroup t)
				{
					_tearDown(t);
				});
			}
			base.Collection.Clear();
		}
		Source = collection;
		GenerateGroups();
		if (Source != null)
		{
			Source.CollectionChanged += OnSourceCollectionChanged;
		}
	}

	private void GenerateGroups()
	{
		Source?.Select(_setup).ForEach(base.AddInputActionGroup);
	}

	private void OnSourceCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		switch (e.Action)
		{
		case NotifyCollectionChangedAction.Add:
			(from s in e.NewItems?.Cast<IMacroGroup>().Reverse()
				select _setup(s)).ForEach(delegate(MacroGroup t)
			{
				base.Collection.Insert(e.NewStartingIndex, t);
			});
			break;
		case NotifyCollectionChangedAction.Remove:
			if (_tearDown != null)
			{
				base.Collection.OfType<MacroGroup>().Skip(e.OldStartingIndex).Take(e.OldItems?.Count ?? 0)
					.ForEach(delegate(MacroGroup t)
					{
						_tearDown(t);
					});
			}
			base.Collection.RemoveAtRange(e.OldStartingIndex, e.OldItems?.Count ?? 0);
			break;
		case NotifyCollectionChangedAction.Move:
			base.Collection.Move(e.OldStartingIndex, e.NewStartingIndex);
			break;
		case NotifyCollectionChangedAction.Reset:
			Refresh();
			break;
		case NotifyCollectionChangedAction.Replace:
			break;
		}
	}

	private void Refresh()
	{
		if (_tearDown != null)
		{
			base.Collection.OfType<MacroGroup>().ForEach(delegate(MacroGroup t)
			{
				_tearDown(t);
			});
		}
		base.Collection.Clear();
		GenerateGroups();
	}
}
