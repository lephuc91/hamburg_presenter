using Pro.SerializationInterop.RVProtoData.Registration;
using ProPresenter.DO.Registration.State;

namespace ProPresenter.Registration.CallbackHandlers.State.Extensions;

public static class ProContentRegistrationStateExtensions
{
	public static ProContentRegistrationState ToProContentRegistrationState(this SubscriptionInfo subscriptionInfo)
	{
		if (subscriptionInfo == null)
		{
			return ProContentRegistrationState.NotSignedIn;
		}
		if (subscriptionInfo.ProcontentLicenseType != ProContentLicenseType.Premium)
		{
			return ProContentRegistrationState.Free;
		}
		return ProContentRegistrationState.Premium;
	}
}
