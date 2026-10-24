using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace Pro.UI.Commands;

public sealed class AsyncParameterAugmentingCommand<T> : IAsyncRelayCommand, IRelayCommand, ICommand, INotifyPropertyChanged
{
	private readonly IAsyncRelayCommand<T> _baseCommand;

	private readonly T _parameter;

	public Task? ExecutionTask => _baseCommand.ExecutionTask;

	public bool CanBeCanceled => _baseCommand.CanBeCanceled;

	public bool IsCancellationRequested => _baseCommand.IsCancellationRequested;

	public bool IsRunning => _baseCommand.IsRunning;

	public event PropertyChangedEventHandler? PropertyChanged
	{
		add
		{
			_baseCommand.PropertyChanged += value;
		}
		remove
		{
			_baseCommand.PropertyChanged -= value;
		}
	}

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

	public AsyncParameterAugmentingCommand(IAsyncRelayCommand<T> baseCommand, T parameter)
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

	public Task ExecuteAsync(object? parameter)
	{
		return _baseCommand.ExecuteAsync(_parameter);
	}

	public void NotifyCanExecuteChanged()
	{
		_baseCommand.NotifyCanExecuteChanged();
	}

	public void Cancel()
	{
		_baseCommand.Cancel();
	}
}
