using System;
using System.ComponentModel;

namespace ProPresenter.DO.Sync.Local;

public interface ISyncController : INotifyPropertyChanged
{
	ISyncData? Current { get; set; }

	double PercentComplete { get; set; }

	bool IsSyncing { get; set; }

	event Action Completed;

	void Sync(bool syncUp, bool replaceData);
}
