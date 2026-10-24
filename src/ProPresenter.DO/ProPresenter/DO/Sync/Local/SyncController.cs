using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Pro.Common.Components;
using ProPresenter.DO.Analytics.Events.Sync;
using ProPresenter.DO.Settings;

namespace ProPresenter.DO.Sync.Local;

public class SyncController : NotifyPropertyChangedBase, ISyncController, INotifyPropertyChanged
{
	private readonly ISyncRepository<ISyncData> _remoteRepo;

	private readonly ISyncRepository<ISyncData> _localRepo;

	private readonly ISyncActionProvider _syncActionProvider;

	private readonly ISync _sync;

	private readonly Func<bool, bool> _shouldPotentiallyRemoveData;

	private ISyncData? _current;

	private double _percentComplete;

	private readonly Queue<ISyncAction> _syncQueue = new Queue<ISyncAction>();

	private bool _isSyncing;

	public ISyncData? Current
	{
		get
		{
			return _current;
		}
		set
		{
			SetValue("Current", ref _current, value);
		}
	}

	public double PercentComplete
	{
		get
		{
			return _percentComplete;
		}
		set
		{
			SetValue("PercentComplete", ref _percentComplete, value);
		}
	}

	public bool IsSyncing
	{
		get
		{
			return _isSyncing;
		}
		set
		{
			SetValue("IsSyncing", ref _isSyncing, value);
		}
	}

	public event Action? Completed;

	public SyncController(ISyncRepository<ISyncData> remoteRepo, ISyncRepository<ISyncData> localRepo, ISyncActionProvider syncActionProvider, ISync sync, Func<bool, bool> shouldPotentiallyRemoveData)
	{
		_remoteRepo = remoteRepo;
		_localRepo = localRepo;
		_syncActionProvider = syncActionProvider;
		_sync = sync;
		_shouldPotentiallyRemoveData = shouldPotentiallyRemoveData;
	}

	public void Sync(bool syncUp, bool replaceData)
	{
		if (!replaceData || _shouldPotentiallyRemoveData(syncUp))
		{
			ISyncRepository<ISyncData> repo = (syncUp ? _remoteRepo : _localRepo);
			IReadOnlyCollection<ISyncData> all = _remoteRepo.GetAll((!syncUp) ? FileAccess.Read : FileAccess.ReadWrite);
			IReadOnlyCollection<ISyncData> all2 = _localRepo.GetAll(syncUp ? FileAccess.Read : FileAccess.ReadWrite);
			SyncLocalEvent.Publish((!syncUp) ? ProPresenter.DO.Analytics.Events.Sync.SyncType.Down : ProPresenter.DO.Analytics.Events.Sync.SyncType.Up, _sync.LocalSyncIncludeLibraryDoc, _sync.LocalSyncIncludeMedia, _sync.LocalSyncIncludePlaylists, _sync.LocalSyncIncludeTemplates, _sync.LocalSyncIncludeUserData, _sync.ReplaceFiles);
			Sync(repo, all, all2, replaceData, syncUp);
		}
	}

	private void Sync(ISyncRepository<ISyncData> repo, IReadOnlyCollection<ISyncData> remoteSyncDataCollection, IReadOnlyCollection<ISyncData> localSyncDataCollection, bool replaceData, bool syncUp)
	{
		IsSyncing = true;
		if (syncUp)
		{
			if (replaceData)
			{
				DeleteData(repo, localSyncDataCollection, remoteSyncDataCollection);
			}
			SyncData(repo, localSyncDataCollection, replaceData);
		}
		else
		{
			if (replaceData)
			{
				DeleteData(repo, remoteSyncDataCollection, localSyncDataCollection);
			}
			SyncData(repo, remoteSyncDataCollection, replaceData);
		}
		if (!DoNext())
		{
			IsSyncing = false;
		}
	}

	private void DeleteData(ISyncRepository<ISyncData> repo, IReadOnlyCollection<ISyncData> source, IReadOnlyCollection<ISyncData> destination)
	{
		destination.Where((ISyncData file) => !source.Any((ISyncData f) => f.Name == file.Name)).ToList().ForEach(delegate(ISyncData d)
		{
			repo.Delete(d, OnProgressChanged);
		});
	}

	private void SyncData(ISyncRepository<ISyncData> repo, IEnumerable<ISyncData> syncDataCollection, bool replaceData)
	{
		foreach (ISyncData fromData in syncDataCollection)
		{
			ISyncAction item = _syncActionProvider.CreateAction(fromData, delegate
			{
				if (replaceData)
				{
					repo.Write(fromData, OnProgressChanged);
				}
				else
				{
					ISyncData syncData = repo.Read(fromData);
					if (syncData == null)
					{
						repo.Write(fromData, OnProgressChanged);
					}
					else if (syncData.CanModify && (syncData.SkipFileCheck || fromData.DateModified > syncData.DateModified))
					{
						repo.Modify(fromData, OnProgressChanged);
					}
				}
			}, OnCompleted);
			_syncQueue.Enqueue(item);
		}
	}

	private void OnProgressChanged(double progress)
	{
		PercentComplete = progress;
	}

	private void OnCompleted()
	{
		PercentComplete = 0.0;
		if (!DoNext())
		{
			IsSyncing = false;
			Current = null;
			this.Completed?.Invoke();
		}
	}

	private bool DoNext()
	{
		if (_syncQueue.Any())
		{
			ISyncAction syncAction = _syncQueue.Dequeue();
			Current = syncAction.Data;
			syncAction.Execute();
			return true;
		}
		return false;
	}
}
