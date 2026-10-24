using System;
using Pro.Common.Utility;

namespace ProPresenter.DO.Registration.State.ProPresenter;

public record CodeState(string UserName, string DeviceName, string ActivationKey, LicenseType LicenseType, SeatInformation SeatInfo, string RegistrationKey, DateTime ExpirationDate, DateTime MaintenanceExpirationDate, bool IsExpired, bool IsCurrentBuildCoveredByLicense, bool IsAutoRenewalActive, string LatestAvailableVersion) : IRegisteredState, IRegistrationState, IEquatable<IRegistrationState>
{
	public bool IsRegistered => true;

	public bool Equals(IRegistrationState? other)
	{
		if (other is CodeState other2)
		{
			return Equals(other2);
		}
		return false;
	}

	public virtual bool Equals(CodeState? other)
	{
		if ((object)other != null && UserName == other.UserName && DeviceName == other.DeviceName && ActivationKey == other.ActivationKey && LicenseType == other.LicenseType && SeatInfo.Equals(other.SeatInfo) && RegistrationKey == other.RegistrationKey && ExpirationDate == other.ExpirationDate && MaintenanceExpirationDate == other.MaintenanceExpirationDate && IsExpired == other.IsExpired && IsCurrentBuildCoveredByLicense == other.IsCurrentBuildCoveredByLicense && IsAutoRenewalActive == other.IsAutoRenewalActive)
		{
			return LatestAvailableVersion == other.LatestAvailableVersion;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return HashCodeHelper.GenerateHashCode(UserName, DeviceName, ActivationKey, LicenseType, SeatInfo, RegistrationKey, ExpirationDate, MaintenanceExpirationDate, IsExpired, IsCurrentBuildCoveredByLicense, LatestAvailableVersion);
	}
}
