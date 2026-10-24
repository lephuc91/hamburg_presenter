using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Pro.Common.Collections;
using Pro.UI.Utility;

namespace Pro.UI.Commands;

public static class CommandBindingCollectionExtensions
{
	public static void Add(this CommandBindingCollection collection, ICommand? targetCommand, ICommand? handlerCommand)
	{
		if (targetCommand != null)
		{
			collection.Add(new CommandBinding(targetCommand, delegate(object s, ExecutedRoutedEventArgs e)
			{
				handlerCommand?.Execute(e.Parameter);
			}, delegate(object s, CanExecuteRoutedEventArgs e)
			{
				e.CanExecute = handlerCommand?.CanExecute(e.Parameter) ?? false;
			}));
		}
	}

	public static void Add(this CommandBindingCollection collection, ICommand? targetCommand, Action execute)
	{
		if (targetCommand != null)
		{
			collection.Add(new CommandBinding(targetCommand, delegate
			{
				execute();
			}));
		}
	}

	public static void Add<T>(this CommandBindingCollection collection, ICommand? targetCommand, Action<object, T?> execute, Predicate<object>? canExecute = null)
	{
		if (targetCommand != null)
		{
			collection.Add(new CommandBinding(targetCommand, delegate(object s, ExecutedRoutedEventArgs e)
			{
				execute(e.Source, (T)e.Parameter);
			}, delegate(object s, CanExecuteRoutedEventArgs e)
			{
				e.CanExecute = canExecute?.Invoke(e.Parameter) ?? (e.Parameter is T);
			}));
		}
	}

	public static void Add(this CommandBindingCollection collection, ICommand? targetCommand, Action execute, Func<bool> canExecute)
	{
		if (targetCommand != null)
		{
			collection.Add(new CommandBinding(targetCommand, delegate
			{
				execute();
			}, delegate(object s, CanExecuteRoutedEventArgs e)
			{
				e.CanExecute = canExecute();
			}));
		}
	}

	public static void Add(this CommandBindingCollection collection, ICommand? targetCommand, Action execute, Func<bool> canExecute, Func<bool> continueRouting)
	{
		if (targetCommand != null)
		{
			collection.Add(new CommandBinding(targetCommand, delegate
			{
				execute();
			}, delegate(object s, CanExecuteRoutedEventArgs e)
			{
				e.CanExecute = canExecute();
				e.ContinueRouting = continueRouting();
			}));
		}
	}

	public static void Add<T>(this CommandBindingCollection collection, ICommand? targetCommand, Action<T?> execute)
	{
		if (targetCommand != null)
		{
			collection.Add(new CommandBinding(targetCommand, delegate(object s, ExecutedRoutedEventArgs e)
			{
				execute?.Invoke((T)e.Parameter);
			}));
		}
	}

	public static void Add<T>(this CommandBindingCollection collection, ICommand? targetCommand, Action<T?> execute, Predicate<T?> canExecute)
	{
		if (targetCommand != null)
		{
			collection.Add(new CommandBinding(targetCommand, delegate(object s, ExecutedRoutedEventArgs e)
			{
				execute((T)e.Parameter);
			}, delegate(object s, CanExecuteRoutedEventArgs e)
			{
				e.CanExecute = canExecute((T)e.Parameter);
			}));
		}
	}

	public static void Add<T>(this CommandBindingCollection collection, ICommand? targetCommand, Action<T?> execute, Func<bool> canExecute, Func<bool> continueRouting)
	{
		if (targetCommand != null)
		{
			collection.Add(new CommandBinding(targetCommand, delegate(object s, ExecutedRoutedEventArgs e)
			{
				execute((T)e.Parameter);
			}, delegate(object s, CanExecuteRoutedEventArgs e)
			{
				e.CanExecute = canExecute();
				e.ContinueRouting = continueRouting();
			}));
		}
	}

	public static void Remove(this CommandBindingCollection collection, ICommand? targetCommand)
	{
		if (targetCommand != null)
		{
			CommandBinding commandBinding = collection.FirstOrDefaultOf((CommandBinding b) => b.Command == targetCommand);
			collection.Remove(commandBinding);
		}
	}

	public static void AddTunnelingCommand(this UIElement element, ICommand? targetCommand, ICommand? handlerCommand)
	{
		element.PreviewKeyDown += OnPreviewKeyDown;
		element.CommandBindings.Add(targetCommand, handlerCommand);
	}

	public static void AddTunnelingCommand(this UIElement element, ICommand? targetCommand, Action execute)
	{
		element.PreviewKeyDown += OnPreviewKeyDown;
		element.CommandBindings.Add(targetCommand, execute);
	}

	private static void OnPreviewKeyDown(object? sender, KeyEventArgs e)
	{
		e.Handled = sender is UIElement uIElement && ((from c in uIElement.CommandBindings.OfType<CommandBinding>()
			select c.Command).OfType<RoutedCommand>().FirstOrDefault((RoutedCommand f) => f.InputGestures.OfType<KeyGesture>().Any((KeyGesture k) => k.Matches(null, e)))?.Invoke() ?? false);
	}
}
