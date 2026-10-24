using System;

namespace Pro.Common.Internet;

public interface IInternetAccessCheck
{
	IObservable<bool> WhenIsAvailableChanged { get; }

	bool Available();
}
