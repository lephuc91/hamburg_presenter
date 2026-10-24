using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using Pro.UI.Components;

namespace Pro.UI.Utility;

public static class ICommandExtensions
{
	public static bool Invoke(this ICommand? command)
	{
		if (command != null && command.CanExecute(null))
		{
			command.Execute(null);
			return true;
		}
		return false;
	}

	[Obsolete]
	public static bool Invoke(this ICommand command, object parameter)
	{
		if (command != null && command.CanExecute(parameter))
		{
			command.Execute(parameter);
			return true;
		}
		return false;
	}

	public static bool Invoke<T>(this ICommand<T> command, T parameter)
	{
		return command.Invoke(parameter, parameter);
	}

	public static bool Invoke<T>(this ICommand<T> command, T executeParameter, T canExecuteParameter)
	{
		return ((ICommand<T, T>?)command).Invoke(executeParameter, canExecuteParameter);
	}

	public static bool Invoke<T, V>(this ICommand<T, V>? command, T executeParameter, V canExecuteParameter)
	{
		if (command != null && command.CanExecute(canExecuteParameter))
		{
			command.Execute(executeParameter);
			return true;
		}
		return false;
	}

	public static bool Invoke<T>(this IRelayCommand<T>? command, T parameter)
	{
		if (command != null && command.CanExecute(parameter))
		{
			command.Execute(parameter);
			return true;
		}
		return false;
	}
}
