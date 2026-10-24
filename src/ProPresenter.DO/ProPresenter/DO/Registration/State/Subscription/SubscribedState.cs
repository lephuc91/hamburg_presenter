using System;

namespace ProPresenter.DO.Registration.State.Subscription;

public record SubscribedState(string OrganizationName) : ISubscriptionState, IEquatable<ISubscriptionState>
{
	public bool Equals(ISubscriptionState? other)
	{
		if (other is SubscribedState other2)
		{
			return Equals(other2);
		}
		return false;
	}
}
