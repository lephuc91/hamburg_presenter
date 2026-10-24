using System;
using Pro.Common.Utility;

namespace ProPresenter.DO.Registration.State.ProPresenter;

public record SubscribedState(string UserName, string DeviceName, string ActivationKey, LicenseType LicenseType, SeatInformation SeatInfo, string LatestAvailableVersion, bool IsTryoutLicense, DateTime ExpirationDate) : IRegisteredState, IRegistrationState, IEquatable<IRegistrationState>
{
	public bool IsRegistered => true;

	public bool Equals(IRegistrationState? other)
	{
		if (other is SubscribedState other2)
		{
			return Equals(other2);
		}
		return false;
	}

	public virtual bool Equals(SubscribedState? other)
	{
		if ((object)other != null && UserName == other.UserName && DeviceName == other.DeviceName && ActivationKey == other.ActivationKey && LicenseType == other.LicenseType && SeatInfo.Equals(other.SeatInfo) && LatestAvailableVersion == other.LatestAvailableVersion && IsTryoutLicense == other.IsTryoutLicense)
		{
			return ExpirationDate == other.ExpirationDate;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return HashCodeHelper.GenerateHashCode(UserName, DeviceName, ActivationKey, LicenseType, SeatInfo, LatestAvailableVersion, IsTryoutLicense, ExpirationDate);
	}
}
