using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace Pro.UI.Commands;

public sealed class ParameterAugmentingCommand<T> : IRelayCommand, ICommand
{
	private readonly IRelayCommand<T> _baseCommand;

	private readonly T _parameter;

	public event EventHandler? CanExecuteChanged
	{
		add
		{
			_baseCommand.CanExecuteChanged += value;
		}
		remove
		{
			_baseCommand.CanExecuteChanged -= value;
		}
	}

	public ParameterAugmentingCommand(IRelayCommand<T> baseCommand, T parameter)
	{
		_baseCommand = baseCommand;
		_parameter = parameter;
	}

	public bool CanExecute(object? parameter)
	{
		return _baseCommand.CanExecute(_parameter);
	}

	public void Execute(object? parameter)
	{
		_baseCommand.Execute(_parameter);
	}

	public void NotifyCanExecuteChanged()
	{
		_baseCommand.NotifyCanExecuteChanged();
	}
}
