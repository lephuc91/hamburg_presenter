using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Pro.Common.Logging;
using Pro.Reporting;

namespace Pro.UI.Components;

public abstract class AsyncRelayCommandBase<TExecuteParameter, TCanExecuteParameter> : IAsyncCommand<TExecuteParameter, TCanExecuteParameter>, ICommand<TExecuteParameter, TCanExecuteParameter>, ICommand
{
	private readonly Predicate<TCanExecuteParameter?> _canExecute;

	private EventHandler? _canExecuteChanged;

	private bool _isExecuting;

	public bool IsExecuting
	{
		get
		{
			return _isExecuting;
		}
		private set
		{
			_isExecuting = value;
			NotifyCanExecuteChanged();
		}
	}

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

	protected AsyncRelayCommandBase(Predicate<TCanExecuteParameter?>? canExecute)
	{
		_canExecute = canExecute ?? ((Predicate<TCanExecuteParameter>)((TCanExecuteParameter? x) => true));
	}

	public bool CanExecute(TCanExecuteParameter? parameter)
	{
		if (!IsExecuting)
		{
			return _canExecute(parameter);
		}
		return false;
	}

	public bool CanExecute(object? parameter)
	{
		if (!IsExecuting)
		{
			return _canExecute((TCanExecuteParameter)parameter);
		}
		return false;
	}

	public async void Execute(TExecuteParameter? parameter)
	{
		IsExecuting = true;
		try
		{
			await ExecuteAsync(parameter);
		}
		catch (Exception ex)
		{
			Log.Error(ex);
			Stargazer.ReportError(ex);
		}
		finally
		{
			IsExecuting = false;
		}
	}

	public async void Execute(object? parameter)
	{
		IsExecuting = false;
		try
		{
			await ExecuteAsync(parameter);
		}
		catch (Exception ex)
		{
			Log.Error(ex);
			Stargazer.ReportError(ex);
		}
		finally
		{
			IsExecuting = false;
		}
	}

	public abstract Task ExecuteAsync(TExecuteParameter? parameter);

	public abstract Task ExecuteAsync(object? parameter);

	public void NotifyCanExecuteChanged()
	{
		_canExecuteChanged?.Invoke(this, new EventArgs());
	}
}
