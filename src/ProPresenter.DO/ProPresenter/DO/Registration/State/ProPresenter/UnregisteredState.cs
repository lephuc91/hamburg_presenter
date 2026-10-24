using System;

namespace ProPresenter.DO.Registration.State.ProPresenter;

public record UnregisteredState(string DeviceName, string LatestAvailableVersion) : IRegistrationState, IEquatable<IRegistrationState>
{
	public bool IsRegistered => false;

	public bool Equals(IRegistrationState? other)
	{
		if (other is UnregisteredState other2)
		{
			return Equals(other2);
		}
		return false;
	}
}
