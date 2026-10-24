using System;
using System.Windows.Threading;

namespace ProPresenter.DO.Sync.Local;

public class SyncActionProvider : ISyncActionProvider
{
	public ISyncAction CreateAction(ISyncData data, Action doSync, Action completed)
	{
		return new SyncAction(data, doSync, completed, Dispatcher.CurrentDispatcher);
	}
}
