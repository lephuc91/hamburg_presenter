using System;
using System.Windows.Threading;
using Pro.Common.Background;

namespace ProPresenter.DO.Sync.Local;

public class SyncAction : ISyncAction
{
	protected readonly Action _doSync;

	protected readonly Action _completed;

	private readonly Dispatcher _dispatcher;

	public ISyncData Data { get; }

	public SyncAction(ISyncData data, Action doSync, Action completed, Dispatcher dispatcher)
	{
		Data = data;
		_doSync = doSync;
		_completed = completed;
		_dispatcher = dispatcher;
	}

	public void Execute()
	{
		DoExecute();
	}

	protected virtual void DoExecute()
	{
		SharedWorkerPool.Queue.AddJob(delegate
		{
			_doSync?.Invoke();
			_dispatcher.InvokeAsync((Action)delegate
			{
				_completed?.Invoke();
			});
		});
	}
}
