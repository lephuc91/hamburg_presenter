using System;

namespace ProPresenter.DO.Registration.State.Subscription;

public sealed class UnsubscribedState : ISubscriptionState, IEquatable<ISubscriptionState>
{
	public bool Equals(ISubscriptionState? other)
	{
		return other is UnsubscribedState;
	}
}
