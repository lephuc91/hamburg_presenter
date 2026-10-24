using System;

namespace Pro.CoreApplication.CoreInteraction;

public interface ISubscriptionDisposer
{
	void RegisterSubscription(IAsyncDisposable subscription);
}
