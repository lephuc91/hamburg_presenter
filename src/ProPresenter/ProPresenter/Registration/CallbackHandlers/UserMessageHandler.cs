using Pro.Common.Startup;
using Pro.CoreApplication.Registration.Interaction;
using Pro.SerializationInterop.RVProtoData.Registration;
using ProPresenter.Registration.CallbackHandlers.PopUpAlert;

namespace ProPresenter.Registration.CallbackHandlers;

public class UserMessageHandler : IRegistrationCallbackHandler, ILaunchPopUpProvider
{
	private sealed record DeferredPopUp(PopupAlertMessage Alert, string OrganizationName);

	private readonly IPopUpAlertFactory _popUpAlertFactory;

	private readonly IAfterStartupCompleteQueue _afterStartupCompleteQueue;

	private DeferredPopUp? _deferredPopUp;

	private bool _popUpsEnabled;

	public UserMessageHandler(IPopUpAlertFactory popUpAlertFactory, IAfterStartupCompleteQueue afterStartupCompleteQueue)
	{
		_popUpAlertFactory = popUpAlertFactory;
		_afterStartupCompleteQueue = afterStartupCompleteQueue;
		afterStartupCompleteQueue.AddStartup();
	}

	public bool HandleResponse(Callback responseCallback, IRegistrationRequestSender requestSender)
	{
		if (responseCallback.CallbackCase == Callback.CallbackOneofCase.VerificationComplete)
		{
			HandleVerificationComplete(responseCallback.VerificationComplete);
			return true;
		}
		return false;
	}

	public void EnablePopUps(EnablePopUpsInstruction showDeferredPopUpInstruction)
	{
		_popUpsEnabled = true;
		if ((object)_deferredPopUp == null)
		{
			return;
		}
		switch (showDeferredPopUpInstruction)
		{
		case EnablePopUpsInstruction.IgnoreStartup:
			if (!IsLaunchPopUp(_deferredPopUp.Alert))
			{
				ShowPopUp(_deferredPopUp.Alert, _deferredPopUp.OrganizationName);
			}
			break;
		case EnablePopUpsInstruction.ShowAll:
			ShowPopUp(_deferredPopUp.Alert, _deferredPopUp.OrganizationName);
			break;
		}
		_deferredPopUp = null;
	}

	private void HandleVerificationComplete(VerificationComplete verificationComplete)
	{
		string organizationName = verificationComplete.SubscriptionInfo?.OrganizationName ?? string.Empty;
		if (DoesRequestPopUpAlert(verificationComplete.Alert))
		{
			if (!_popUpsEnabled)
			{
				_deferredPopUp = new DeferredPopUp(verificationComplete.Alert, organizationName);
			}
			else
			{
				ShowPopUp(verificationComplete.Alert, organizationName);
			}
		}
		if (verificationComplete.FullyLaunched)
		{
			_afterStartupCompleteQueue.CompleteStartup();
		}
	}

	private void ShowPopUp(PopupAlertMessage alert, string organizationName)
	{
		switch (alert)
		{
		case PopupAlertMessage.SeatActivated:
			_popUpAlertFactory.ShowSeatActivated(organizationName);
			break;
		case PopupAlertMessage.NoLicenseActivated:
			_popUpAlertFactory.ShowNoLicenseActivated(organizationName);
			break;
		case PopupAlertMessage.FullySignedOut:
			_popUpAlertFactory.ShowFullySignedOut();
			break;
		case PopupAlertMessage.LegacyLicenseProContentActivated:
			_popUpAlertFactory.ShowLegacyLicenseProContentActivated(organizationName);
			break;
		case PopupAlertMessage.NoSeatActivated:
			_popUpAlertFactory.ShowNoSeatActivated(organizationName);
			break;
		case PopupAlertMessage.FirstLaunchLegacyLicense:
			_popUpAlertFactory.ShowFirstLaunchLegacyLicense();
			break;
		case PopupAlertMessage.FirstLaunchSignedInNoSubscriptionNoLicense:
			_popUpAlertFactory.ShowFirstLaunchSignedInNoSubscriptionNoLicense();
			break;
		case PopupAlertMessage.FirstLaunchSignedInNoSubscriptionLegacyLicense:
			_popUpAlertFactory.ShowFirstLaunchSignedInNoSubscriptionLegacyLicense();
			break;
		}
	}

	private static bool IsLaunchPopUp(PopupAlertMessage alert)
	{
		if ((uint)(alert - 5) <= 3u)
		{
			return true;
		}
		return false;
	}

	private static bool DoesRequestPopUpAlert(PopupAlertMessage alert)
	{
		return alert != PopupAlertMessage.NoPopupAlert;
	}
}
