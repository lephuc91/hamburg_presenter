using System;
using System.Collections.Specialized;
using System.Linq;
using Pro.Common.Collections;
using Pro.UI.InputActions;
using ProPresenter.DO.Props;

namespace ProPresenter.DO.InputActionMap;

public class PropGroupInputActionCollection : InputActionGroupCollectionBase
{
	private readonly Func<IPropGroup, PropGroup> _setup;

	private readonly Action<PropGroup> _tearDown;

	protected internal IPropGroupCollection? Source { get; private set; }

	public PropGroupInputActionCollection(Func<IPropGroup, PropGroup> setup, Action<PropGroup> tearDown)
	{
		_setup = setup;
		_tearDown = tearDown;
	}

	public void ChangeSource(IPropGroupCollection collection)
	{
		if (Source != null)
		{
			Source.CollectionChanged -= OnSourceCollectionChanged;
			if (_tearDown != null)
			{
				base.Collection.OfType<PropGroup>().ForEach(delegate(PropGroup t)
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
			(from s in e.NewItems?.Cast<IPropGroup>().Reverse()
				select _setup(s)).ForEach(delegate(PropGroup t)
			{
				base.Collection.Insert(e.NewStartingIndex, t);
			});
			break;
		case NotifyCollectionChangedAction.Remove:
			if (_tearDown != null)
			{
				base.Collection.OfType<PropGroup>().Skip(e.OldStartingIndex).Take(e.OldItems?.Count ?? 0)
					.ForEach(delegate(PropGroup t)
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
		}
		OnCollectionChanged(e);
	}

	private void Refresh()
	{
		if (_tearDown != null)
		{
			base.Collection.OfType<PropGroup>().ForEach(delegate(PropGroup t)
			{
				_tearDown(t);
			});
		}
		base.Collection.Clear();
		GenerateGroups();
	}
}
