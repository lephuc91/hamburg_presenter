using System;

namespace Pro.CoreApplication.Media;

public interface IManageMediaAutoMaticallyProvider
{
	bool ManageMediaAutomatically { get; set; }

	IObservable<bool> WhenManageMediaAutomaticallyChanged { get; }
}
