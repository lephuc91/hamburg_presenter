using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.UI.Commands;
using Pro.UI.Controls;
using Pro.UI.InputActions;

namespace ProPresenter.UI.KeyMapping;

public static class InputActionGroupExtensions
{
	private sealed record CommandBindingData(Action<InputAction> Handler, CommandBindingCollection CommandBindings, Predicate<InputActionGroupBase> CanContinueRouting);

	private static readonly Dictionary<InputActionGroupBase, CommandBindingData> _inputActionGroupMap = new Dictionary<InputActionGroupBase, CommandBindingData>();

	public static void SetupCollection<T>(this InputActionGroupBase? group, Action<InputAction> handler, CommandBindingCollection commandBindings, Predicate<InputActionGroupBase?>? canContinueRouting = null) where T : InputAction
	{
		if (group != null)
		{
			_inputActionGroupMap[group] = new CommandBindingData(handler, commandBindings, canContinueRouting ?? ((Predicate<InputActionGroupBase>)((InputActionGroupBase g) => false)));
			group.CollectionChanged += Group_CollectionChanged;
			group.OfType<T>().ForEach(delegate(T i)
			{
				SetupInputActionCommandBinding(group, i);
			});
		}
	}

	public static void SetupCollection<TGroup, TAction>(this InputActionGroupCollectionBase groupCollection, Action<InputAction> handler, CommandBindingCollection commandBindings) where TGroup : InputActionGroupBase where TAction : InputAction
	{
		if (groupCollection == null)
		{
			return;
		}
		groupCollection.CollectionChanged += delegate(object? s, NotifyCollectionChangedEventArgs e)
		{
			e.NewItems?.OfType<TGroup>().ForEach(delegate(TGroup g)
			{
				g.SetupCollection<TAction>(handler, commandBindings);
			});
			e.OldItems?.OfType<TGroup>().ForEach(delegate(TGroup g)
			{
				g.TeardownCollection<TAction>();
			});
		};
		foreach (TGroup item in groupCollection.OfType<TGroup>())
		{
			item.SetupCollection<TAction>(handler, commandBindings);
		}
	}

	public static void TeardownCollection<T>(this InputActionGroupBase group) where T : InputAction
	{
		group.CollectionChanged -= Group_CollectionChanged;
		group.OfType<T>().ForEach(delegate(T i)
		{
			TeardownInputActionCommandBinding(group, i);
		});
	}

	private static void Group_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.OfType<InputAction>().ForEach(delegate(InputAction i)
		{
			TeardownInputActionCommandBinding(sender as InputActionGroupBase, i);
		});
		e.NewItems?.OfType<InputAction>().ForEach(delegate(InputAction i)
		{
			SetupInputActionCommandBinding(sender as InputActionGroupBase, i);
		});
	}

	private static void SetupInputActionCommandBinding(InputActionGroupBase? group, InputAction action)
	{
		if (group != null && _inputActionGroupMap.TryGetValue(group, out CommandBindingData commandBindingData))
		{
			Action<InputAction> handler = commandBindingData.Handler;
			commandBindingData.CommandBindings.Add(action.BindCommand, delegate
			{
				handler(action);
			}, canExecute, () => !canExecute());
		}
		bool canExecute()
		{
			if (CanExecute())
			{
				return !commandBindingData.CanContinueRouting(group);
			}
			return false;
		}
	}

	private static bool CanExecute()
	{
		if (!(Keyboard.FocusedElement is FormattedTextBox))
		{
			return !(Keyboard.FocusedElement is TextBoxBase);
		}
		return false;
	}

	private static void TeardownInputActionCommandBinding(InputActionGroupBase? group, InputAction action)
	{
		if (group != null && _inputActionGroupMap.TryGetValue(group, out CommandBindingData value))
		{
			value.CommandBindings.Remove(action.BindCommand);
		}
	}
}
