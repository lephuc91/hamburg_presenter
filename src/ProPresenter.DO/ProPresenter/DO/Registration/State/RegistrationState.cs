using Pro.Common.Utility;
using ProPresenter.DO.Registration.State.ProPresenter;
using ProPresenter.DO.Registration.State.Subscription;

namespace ProPresenter.DO.Registration.State;

public record RegistrationState(ISubscriptionState SubscriptionState, IRegistrationState ProPresenter, ProContentRegistrationState ProContent)
{
	public virtual bool Equals(RegistrationState? other)
	{
		if ((object)other != null && SubscriptionState.Equals(other.SubscriptionState) && ProPresenter.Equals(other.ProPresenter))
		{
			return ProContent == other.ProContent;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return HashCodeHelper.GenerateHashCode(SubscriptionState, ProPresenter, ProContent);
	}
}
