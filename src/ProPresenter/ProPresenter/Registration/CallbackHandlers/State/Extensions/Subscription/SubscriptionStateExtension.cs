using Pro.SerializationInterop.RVProtoData.Registration;
using ProPresenter.DO.Registration.State.Subscription;

namespace ProPresenter.Registration.CallbackHandlers.State.Extensions.Subscription;

public static class SubscriptionStateExtension
{
	public static ISubscriptionState ToSubscription(this VerificationComplete verificationComplete)
	{
		if (verificationComplete.SubscriptionInfo != null)
		{
			return new SubscribedState(verificationComplete.SubscriptionInfo.OrganizationName);
		}
		return new UnsubscribedState();
	}
}
