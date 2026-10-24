using System;
using Pro.SerializationInterop.RVProtoData.Registration;

namespace ProPresenter.Registration.Model.Extensions;

public static class VerificationCompleteExtension
{
	public static bool IsUsingSubscriptionLicense(this VerificationComplete verificationComplete)
	{
		if (verificationComplete.SubscriptionInfo != null)
		{
			return !(verificationComplete.License?.Legacy ?? true);
		}
		return false;
	}

	public static bool IsCurrentBuildCoveredByLicense(this VerificationComplete verificationComplete, DateTime currentBuildDate)
	{
		if (!(verificationComplete.License?.RegistrationInfo).IsLicensed() || verificationComplete.IsUsingSubscriptionLicense())
		{
			return true;
		}
		return verificationComplete.License.RegistrationInfo.IsCurrentBuildCoveredByLicense(currentBuildDate);
	}
}
