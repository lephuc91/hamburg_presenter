using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Pro.Common.Collections;

namespace Pro.UI.InputActions;

public abstract class InputActionGroupBase : ImmutableObservableCollection<InputAction>, INotifyEnumerableChanged<InputAction>, IEnumerable<InputAction>, IEnumerable, INotifyCollectionChanged
{
	private string _label = string.Empty;

	public string Label
	{
		get
		{
			return _label;
		}
		set
		{
			SetValue("Label", ref _label, value);
		}
	}

	public InputActionGroupCollectionBase Parent { get; }

	public InputActionGroupCollectionBase? Children { get; protected set; }

	public event Action? DataModified;

	protected InputActionGroupBase(string label, InputActionGroupCollectionBase parent)
		: this(label, parent, null)
	{
	}

	protected InputActionGroupBase(string label, InputActionGroupCollectionBase parent, InputActionGroupCollectionBase? children)
	{
		Label = label;
		Parent = parent;
		Children = children;
		base.CollectionChanged += delegate
		{
			OnDataModified();
		};
	}

	protected virtual InputAction CreateInputAction(string identifier, string label, IEnumerable<VirtualKeyGesture?>? defaultGestures = null, IEnumerable<string>? accessPath = null, bool requireModifiers = true)
	{
		return new InputAction(identifier, label, defaultGestures, this, accessPath, requireModifiers);
	}

	protected InputAction Add(string identifier, string label, IEnumerable<VirtualKeyGesture?>? defaultGestures = null, IEnumerable<string>? accessPath = null, bool requireModifiers = true)
	{
		return Insert(base.Collection.Count, identifier, label, defaultGestures, accessPath, requireModifiers);
	}

	protected InputAction Insert(int index, string identifier, string label, IEnumerable<VirtualKeyGesture?>? defaultGestures = null, IEnumerable<string>? accessPath = null, bool requireModifiers = true)
	{
		InputAction inputAction = CreateInputAction(identifier, label, defaultGestures, accessPath, requireModifiers);
		return Insert(index, inputAction);
	}

	protected InputAction Insert(int index, InputAction inputAction)
	{
		inputAction.DataModified += OnDataModified;
		base.Collection.Insert(index, inputAction);
		return base.Collection[index];
	}

	protected void Remove(InputAction? action)
	{
		if (action != null)
		{
			action.DataModified -= OnDataModified;
			base.Collection.Remove(action);
			CheckConflict();
		}
	}

	protected void OnDataModified()
	{
		this.DataModified?.Invoke();
	}

	public void Reset()
	{
		base.Collection.ForEach(delegate(InputAction i)
		{
			i.Reset();
		});
		OnReset();
	}

	protected virtual void OnReset()
	{
	}

	protected internal void CheckConflict()
	{
		InputAction[] array = Parent.SelectMany((InputActionGroupBase g) => g).ToArray();
		array.ForEach(delegate(InputAction g)
		{
			g.ResetConflicts();
		});
		InputAction[] array2 = array;
		foreach (InputAction inputAction in array2)
		{
			foreach (InputAction item in array.Except(inputAction))
			{
				if (inputAction.ParentGroup.CanConflict(item.ParentGroup) && inputAction.IsConflict(item))
				{
					inputAction.AddConflict(item);
				}
			}
		}
	}

	protected virtual bool CanConflict(InputActionGroupBase other)
	{
		return true;
	}
}
