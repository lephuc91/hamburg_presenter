using Pro.Common.Internet;
using Pro.CoreApplication.Registration.Interaction;
using Pro.SerializationInterop.RVProtoData.Registration;
using ProPresenter.DO.Settings;
using ProPresenter.Registration.CallbackHandlers.Dialogs;
using ProPresenter.Registration.Model.Extensions;

namespace ProPresenter.Registration.CallbackHandlers;

public class ExpirationDialogHandler : IRegistrationCallbackHandler
{
	private readonly IRegistrationCallbackDialogProvider _activationDialogProvider;

	private readonly IApp _app;

	private readonly IInternetAccessCheck _internetAccess;

	public ExpirationDialogHandler(IRegistrationCallbackDialogProvider activationDialogProvider, IApp app, IInternetAccessCheck internetAccess)
	{
		_activationDialogProvider = activationDialogProvider;
		_app = app;
		_internetAccess = internetAccess;
	}

	public bool HandleResponse(Callback responseCallback, IRegistrationRequestSender requestSender)
	{
		if (responseCallback.CallbackCase == Callback.CallbackOneofCase.ShowExpirationDialog)
		{
			if (_internetAccess.Available())
			{
				if (_activationDialogProvider.ShowInAppRenewalStore())
				{
					requestSender.Send(new Request
					{
						Refresh = new Refresh
						{
							Channel = _app.UpdateChannel.ToProtoUpdateChannel()
						}
					});
				}
			}
			else
			{
				_activationDialogProvider.ShowExpiration(responseCallback.ShowExpirationDialog.Days);
			}
			return true;
		}
		return false;
	}
}
