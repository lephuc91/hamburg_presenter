using System;
using Pro.Common.Logging;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.Data;

public abstract class RegitrationUiActivator
{
	private readonly Func<IMainLayoutVM> _getMainLayoutVM;

	protected RegitrationUiActivator(Func<IMainLayoutVM> getMainLayoutVM)
	{
		_getMainLayoutVM = getMainLayoutVM;
	}

	protected void ShowRegistration(string registrationName, string unlockCode)
	{
		Log.Info("Showing registration dialog...");
		_getMainLayoutVM().ActivateRegistrationUI(new IMainLayoutVM.CodeInfo(registrationName, unlockCode));
	}
}
