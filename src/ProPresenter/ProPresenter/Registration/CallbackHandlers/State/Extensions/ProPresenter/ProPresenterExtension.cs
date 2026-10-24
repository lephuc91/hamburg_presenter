using System;
using Pro.Common.Nullability;
using Pro.Common.Utility;
using Pro.SerializationInterop.RVProtoData.Registration;
using ProPresenter.DO.Registration.State.ProPresenter;
using ProPresenter.Registration.Model.Extensions;

namespace ProPresenter.Registration.CallbackHandlers.State.Extensions.ProPresenter;

public static class ProPresenterExtension
{
	public static IRegistrationState ToProPresenter(this VerificationComplete verificationComplete, DateTime currentBuildDate, string deviceName, IRegistrationState previousState)
	{
		LicenseInfo license = verificationComplete.License;
		if (!(license?.RegistrationInfo).IsLicensed())
		{
			return new UnregisteredState(GetDeviceName(license, previousState, deviceName), license?.RegistrationInfo?.LatestAvailableVersion ?? string.Empty);
		}
		RegistrationInfo registrationInfo = license.RegistrationInfo;
		DateTime dateTime = registrationInfo.ExpirationDate.FromUnixTimestamp();
		if (verificationComplete.IsUsingSubscriptionLicense())
		{
			return new SubscribedState(registrationInfo.UserName, registrationInfo.DisplayName, registrationInfo.ActivationKey, registrationInfo.LicenseType.ToLicenseType(), verificationComplete.License.ToSeatInfo((previousState as IRegisteredState)?.SeatInfo), registrationInfo.LatestAvailableVersion, registrationInfo.LicenseType == Pro.SerializationInterop.RVProtoData.Registration.LicenseType.Trial, dateTime);
		}
		DateTime maintenanceExpirationDate = registrationInfo.NonExtendedMaintenanceExpirationDate.FromUnixTimestamp();
		return new CodeState(registrationInfo.UserName, registrationInfo.DisplayName, registrationInfo.ActivationKey, registrationInfo.LicenseType.ToLicenseType(), license.ToSeatInfo((previousState as IRegisteredState)?.SeatInfo), registrationInfo.DisplayKey, dateTime, maintenanceExpirationDate, dateTime < DateTime.Now, registrationInfo.IsCurrentBuildCoveredByLicense(currentBuildDate), registrationInfo.IsAutoRenewalActive, registrationInfo.LatestAvailableVersion);
	}

	private static string GetDeviceName(LicenseInfo? licenseInfo, IRegistrationState previousState, string deviceName)
	{
		if (!(licenseInfo?.RegistrationInfo?.DisplayName).NullableIsNullOrEmpty())
		{
			return licenseInfo.RegistrationInfo.DisplayName;
		}
		if (!previousState.DeviceName.NullableIsNullOrEmpty())
		{
			return previousState.DeviceName;
		}
		return deviceName;
	}
}
