using System;
using Pro.SerializationInterop.RVProtoData.Registration;
using ProPresenter.DO.Registration.State;
using ProPresenter.Registration.CallbackHandlers.State.Extensions.ProPresenter;
using ProPresenter.Registration.CallbackHandlers.State.Extensions.Subscription;

namespace ProPresenter.Registration.CallbackHandlers.State.Extensions;

public static class RegistrationStateExtension
{
	public static RegistrationState ToRegistrationState(this VerificationComplete verificationComplete, DateTime currentBuildDate, string deviceName, RegistrationState previousState)
	{
		return new RegistrationState(verificationComplete.ToSubscription(), verificationComplete.ToProPresenter(currentBuildDate, deviceName, previousState.ProPresenter), verificationComplete.SubscriptionInfo.ToProContentRegistrationState());
	}
}
