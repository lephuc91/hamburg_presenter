using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Collections;
using ProPresenter.UI.ViewModels.Navigation;

namespace ProPresenter.ViewModels.Navigation;

public abstract class NavigationVMBase<T> : ObservableObject, INavigationVM<T> where T : class, INavigationItem
{
	private readonly LinkedList<T> _backWardStack = new LinkedList<T>();

	private readonly LinkedList<T> _forwardStack = new LinkedList<T>();

	[ObservableProperty]
	private T? _activeItem;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? goBackCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	private RelayCommand? goForwardCommand;

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public T? ActiveItem
	{
		get
		{
			return _activeItem;
		}
		set
		{
			if (!EqualityComparer<T>.Default.Equals(_activeItem, value))
			{
				OnPropertyChanging(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.ActiveItem);
				_activeItem = value;
				OnPropertyChanged(CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.ActiveItem);
			}
		}
	}

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand GoBackCommand => goBackCommand ?? (goBackCommand = new RelayCommand(GoBack, CanGoBack));

	[GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.4.0.0")]
	[ExcludeFromCodeCoverage]
	public IRelayCommand GoForwardCommand => goForwardCommand ?? (goForwardCommand = new RelayCommand(GoForward, CanGoForward));

	[RelayCommand(CanExecute = "CanGoBack")]
	private void GoBack()
	{
		if (TryFindNext(_backWardStack, out T next))
		{
			PushActiveItem(_forwardStack, ForwardStack_PropertyChanged);
			Navigate(next);
		}
	}

	private bool CanGoBack()
	{
		T? activeItem = ActiveItem;
		if (activeItem == null || activeItem.CanExit)
		{
			return HasNext(_backWardStack);
		}
		return false;
	}

	[RelayCommand(CanExecute = "CanGoForward")]
	private void GoForward()
	{
		if (TryFindNext(_forwardStack, out T next))
		{
			PushActiveItem(_backWardStack, BackwardStack_PropertyChanged);
			Navigate(next);
		}
	}

	private bool CanGoForward()
	{
		T? activeItem = ActiveItem;
		if (activeItem == null || activeItem.CanExit)
		{
			return HasNext(_forwardStack);
		}
		return false;
	}

	public void UpdateActiveItem(T? activeItem)
	{
		PushActiveItem(_backWardStack, BackwardStack_PropertyChanged);
		while (_forwardStack.Count > 0)
		{
			_forwardStack.ForEach(delegate(T item)
			{
				if (item is INotifyPropertyChanged notifyPropertyChanged)
				{
					notifyPropertyChanged.PropertyChanged -= ForwardStack_PropertyChanged;
				}
			});
			_forwardStack.Clear();
		}
		ActiveItem = activeItem;
		NotifyCanExecute();
	}

	public void Navigate(T item)
	{
		ActiveItem = item;
		OnNavigate(item);
		NotifyCanExecute();
	}

	public void RemoveItem(T item)
	{
		if (ActiveItem == item)
		{
			GoBack();
		}
		Cleanup(_backWardStack, item);
		Cleanup(_forwardStack, item);
		if (item is INotifyPropertyChanged notifyPropertyChanged)
		{
			notifyPropertyChanged.PropertyChanged -= BackwardStack_PropertyChanged;
			notifyPropertyChanged.PropertyChanged -= ForwardStack_PropertyChanged;
		}
		NotifyCanExecute();
	}

	protected virtual void OnNavigate(T item)
	{
	}

	protected virtual bool TryFindNext(LinkedList<T> stack, [NotNullWhen(true)] out T? next)
	{
		do
		{
			if (!tryGetNext(stack, out next))
			{
				return false;
			}
			if (next is INotifyPropertyChanged notifyPropertyChanged)
			{
				notifyPropertyChanged.PropertyChanged -= BackwardStack_PropertyChanged;
				notifyPropertyChanged.PropertyChanged -= ForwardStack_PropertyChanged;
			}
			stack.RemoveFirst();
		}
		while (!next.IsNavigable);
		return true;
		static bool tryGetNext(LinkedList<T> stack, [NotNullWhen(true)] out T? next)
		{
			LinkedListNode<T>? first = stack.First;
			next = ((first != null) ? first.Value : null);
			return next != null;
		}
	}

	protected virtual bool HasNext(LinkedList<T> stack)
	{
		return stack.Any((T i) => i.IsNavigable);
	}

	private static void Cleanup(LinkedList<T> stack, T item)
	{
		LinkedListNode<T> linkedListNode = stack.First;
		while (linkedListNode != null)
		{
			LinkedListNode<T>? next = linkedListNode.Next;
			if (linkedListNode.Value == item)
			{
				stack.Remove(linkedListNode);
			}
			linkedListNode = next;
		}
	}

	private void NotifyCanExecute()
	{
		GoBackCommand.NotifyCanExecuteChanged();
		GoForwardCommand.NotifyCanExecuteChanged();
	}

	private void ForwardStack_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "IsNavigable" || e.PropertyName == "CanExit")
		{
			GoForwardCommand.NotifyCanExecuteChanged();
		}
	}

	private void BackwardStack_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "IsNavigable" || e.PropertyName == "CanExit")
		{
			GoBackCommand.NotifyCanExecuteChanged();
		}
	}

	private void PushActiveItem(LinkedList<T> stack, PropertyChangedEventHandler propertyChangedEventHandlerToSubscribeTo)
	{
		if (ActiveItem != null)
		{
			stack.AddFirst(ActiveItem);
			if (ActiveItem is INotifyPropertyChanged notifyPropertyChanged)
			{
				notifyPropertyChanged.PropertyChanged += propertyChangedEventHandlerToSubscribeTo;
			}
		}
	}
}
