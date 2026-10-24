using System;

namespace ProPresenter.DO.Registration.State.ProPresenter;

public interface IRegisteredState : IRegistrationState, IEquatable<IRegistrationState>
{
	string UserName { get; }

	string ActivationKey { get; }

	LicenseType LicenseType { get; }

	SeatInformation SeatInfo { get; }
}
