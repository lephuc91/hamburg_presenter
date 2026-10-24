using System;

namespace ProPresenter.DO.Registration.State.ProPresenter;

public record InitialState(string DeviceName) : IRegistrationState, IEquatable<IRegistrationState>
{
	public bool IsRegistered => false;

	public string LatestAvailableVersion => string.Empty;

	public bool Equals(IRegistrationState? other)
	{
		if (other is InitialState other2)
		{
			return Equals(other2);
		}
		return false;
	}
}
