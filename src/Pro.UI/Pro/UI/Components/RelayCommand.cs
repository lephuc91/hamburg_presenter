using System;
using System.Windows.Input;
using Pro.Common.Logging;
using Pro.Reporting;

namespace Pro.UI.Components;

public class RelayCommand<T, V> : ICommand<T, V>, ICommand
{
	private readonly Predicate<V> _canExecute;

	private readonly Action<T> _execute;

	private EventHandler? _canExecuteChanged;

	public event EventHandler? CanExecuteChanged
	{
		add
		{
			lock (_canExecute)
			{
				_canExecuteChanged = (EventHandler)Delegate.Combine(_canExecuteChanged, value);
				CommandManager.RequerySuggested += value;
			}
		}
		remove
		{
			lock (_canExecute)
			{
				_canExecuteChanged = (EventHandler)Delegate.Remove(_canExecuteChanged, value);
				CommandManager.RequerySuggested -= value;
			}
		}
	}

	public RelayCommand(Action<T>? execute)
		: this(execute, (Predicate<V>?)((V x) => true))
	{
	}

	public RelayCommand(Action<T>? execute, Predicate<V>? canExecute)
	{
		_canExecute = canExecute ?? ((Predicate<V>)((V x) => true));
		_execute = execute ?? ((Action<T>)delegate
		{
		});
	}

	public bool CanExecute(object? parameter)
	{
		if (parameter is V obj)
		{
			return _canExecute(obj);
		}
		return false;
	}

	public bool CanExecute(V parameter)
	{
		return _canExecute(parameter);
	}

	public void Execute(object? parameter)
	{
		try
		{
			if (parameter is T obj)
			{
				_execute(obj);
			}
		}
		catch (Exception ex)
		{
			Log.Error(ex);
			Stargazer.ReportError(ex);
		}
	}

	public void Execute(T parameter)
	{
		try
		{
			_execute(parameter);
		}
		catch (Exception ex)
		{
			Log.Error(ex);
			Stargazer.ReportError(ex);
		}
	}

	public void NotifyCanExecuteChanged()
	{
		_canExecuteChanged?.Invoke(this, new EventArgs());
	}
}
public class RelayCommand<T> : ICommand<T>, ICommand<T, T>, ICommand
{
	private readonly Predicate<T> _canExecute;

	private readonly Action<T> _execute;

	private EventHandler? _canExecuteChanged;

	public event EventHandler? CanExecuteChanged
	{
		add
		{
			lock (_canExecute)
			{
				_canExecuteChanged = (EventHandler)Delegate.Combine(_canExecuteChanged, value);
				CommandManager.RequerySuggested += value;
			}
		}
		remove
		{
			lock (_canExecute)
			{
				_canExecuteChanged = (EventHandler)Delegate.Remove(_canExecuteChanged, value);
				CommandManager.RequerySuggested -= value;
			}
		}
	}

	public RelayCommand(Action<T>? execute)
		: this(execute, (Predicate<T>?)((T x) => true))
	{
	}

	public RelayCommand(Action<T>? execute, Predicate<T>? canExecute)
	{
		_canExecute = canExecute ?? ((Predicate<T>)((T x) => true));
		_execute = execute ?? ((Action<T>)delegate
		{
		});
	}

	public bool CanExecute(object? parameter)
	{
		if (!(parameter is T))
		{
			return _canExecute(default(T));
		}
		return _canExecute((T)parameter);
	}

	public bool CanExecute(T parameter)
	{
		return _canExecute(parameter);
	}

	public void Execute(object? parameter)
	{
		try
		{
			if (parameter is T)
			{
				_execute((T)parameter);
			}
			else
			{
				_execute(default(T));
			}
		}
		catch (Exception ex)
		{
			Log.Error(ex);
			Stargazer.ReportError(ex);
		}
	}

	public void Execute(T parameter)
	{
		try
		{
			_execute(parameter);
		}
		catch (Exception ex)
		{
			Log.Error(ex);
			Stargazer.ReportError(ex);
		}
	}

	public void NotifyCanExecuteChanged()
	{
		_canExecuteChanged?.Invoke(this, new EventArgs());
	}
}
public class RelayCommand : RelayCommand<object>
{
	public RelayCommand(Action execute)
		: base((Action<object>?)delegate
		{
			execute();
		}, (Predicate<object>?)((object x) => true))
	{
	}

	public RelayCommand(Action execute, Func<bool> canExecute)
		: base((Action<object>?)delegate
		{
			execute();
		}, (Predicate<object>?)((object x) => canExecute()))
	{
	}
}
