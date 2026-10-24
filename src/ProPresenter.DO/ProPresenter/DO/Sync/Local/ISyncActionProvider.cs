using System;

namespace ProPresenter.DO.Sync.Local;

public interface ISyncActionProvider
{
	ISyncAction CreateAction(ISyncData data, Action doSync, Action completed);
}
