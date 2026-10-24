using System;
using System.Diagnostics.CodeAnalysis;
using Pro.Common.Nullability;
using Pro.Common.Utility;
using Pro.SerializationInterop.RVProtoData.Registration;

namespace ProPresenter.Registration.Model.Extensions;

public static class RegistrationInfoExtension
{
	public static bool IsLicensed([NotNullWhen(true)] this RegistrationInfo? registrationInfo)
	{
		return !(registrationInfo?.ActivationKey).NullableIsNullOrEmpty();
	}

	public static bool IsCurrentBuildCoveredByLicense(this RegistrationInfo registrationInfo, DateTime currentBuildDate)
	{
		long num = currentBuildDate.ToUnixTimestamp();
		LicenseType licenseType = registrationInfo.LicenseType;
		bool flag = (uint)(licenseType - 2) <= 1u;
		long num2 = (flag ? registrationInfo.NonExtendedMaintenanceExpirationDate : registrationInfo.ExpirationDate);
		return num <= num2;
	}
}
