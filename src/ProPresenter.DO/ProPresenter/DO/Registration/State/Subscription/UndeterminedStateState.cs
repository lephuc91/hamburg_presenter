using System;

namespace ProPresenter.DO.Registration.State.Subscription;

public sealed class UndeterminedStateState : ISubscriptionState, IEquatable<ISubscriptionState>
{
	public bool Equals(ISubscriptionState? other)
	{
		return other is UndeterminedStateState;
	}
}
