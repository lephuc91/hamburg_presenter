using System;

namespace ProPresenter.Registration.UserInteraction;

public interface IRegistrationUserDialogService
{
	bool DoesUserReallyWantToSwitchToInactiveSeat();

	IDisposable? ShowActivationInProgress();

	bool DoesUserReallyWantToSignOut(string organizationName);
}
