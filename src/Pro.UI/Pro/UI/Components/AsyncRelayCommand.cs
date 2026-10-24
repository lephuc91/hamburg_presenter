using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Pro.UI.Components;

public class AsyncRelayCommand<TExecuteParameter, TCanExecuteParameter> : AsyncRelayCommandBase<TExecuteParameter, TCanExecuteParameter>
{
	private readonly Func<TExecuteParameter?, Task> _execute;

	public AsyncRelayCommand(Func<TExecuteParameter?, Task> execute)
		: this(execute, (Predicate<TCanExecuteParameter?>?)null)
	{
	}

	public AsyncRelayCommand(Func<TExecuteParameter?, Task> execute, Predicate<TCanExecuteParameter?>? canExecute)
		: base(canExecute)
	{
		_execute = execute;
	}

	public override async Task ExecuteAsync(TExecuteParameter? parameter)
	{
		await _execute(parameter);
	}

	public override async Task ExecuteAsync(object? parameter)
	{
		await _execute((TExecuteParameter)parameter);
	}
}
public class AsyncRelayCommand<TExecuteParameter> : AsyncRelayCommand<TExecuteParameter, TExecuteParameter>, ICommand<TExecuteParameter>, ICommand<TExecuteParameter, TExecuteParameter>, ICommand
{
	public AsyncRelayCommand(Func<TExecuteParameter?, Task> execute)
		: base(execute)
	{
	}

	public AsyncRelayCommand(Func<TExecuteParameter?, Task> execute, Predicate<TExecuteParameter?>? canExecute)
		: base(execute, canExecute)
	{
	}
}
public class AsyncRelayCommand : AsyncRelayCommand<object>
{
	public AsyncRelayCommand(Func<Task> execute)
		: base((Func<object?, Task>)((object? x) => execute()))
	{
	}

	public AsyncRelayCommand(Func<Task> execute, Func<bool> canExecute)
		: base((Func<object?, Task>)((object? x) => execute()), (Predicate<object?>?)((object? x) => canExecute()))
	{
	}
}
