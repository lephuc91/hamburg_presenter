using System;

namespace ProPresenter.DO.Registration.State.ProPresenter;

public interface IRegistrationState : IEquatable<IRegistrationState>
{
	string DeviceName { get; }

	string LatestAvailableVersion { get; }

	bool IsRegistered { get; }
}
