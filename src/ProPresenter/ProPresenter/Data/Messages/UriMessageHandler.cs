using System;
using Pro.Interprocess;
using ProPresenter.DO;
using ProPresenter.DO.Registration.Operations;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.Data.Messages;

public class UriMessageHandler : RegitrationUiActivator, IMessageHandler
{
	private readonly ISharedData<AppData> _sharedData;

	private readonly Func<IRegistrationOperationFactory> _getRegistrationOperationFactory;

	private readonly Func<bool> _shouldSuppressVisualIndication;

	public AppMessages HandledMessage => AppMessages.HandleUri;

	public UriMessageHandler(ISharedData<AppData> sharedData, Func<IRegistrationOperationFactory> getRegistrationOperationFactory, Func<bool> shouldSuppressVisualIndication, Func<IMainLayoutVM> getMainLayoutVM)
		: base(getMainLayoutVM)
	{
		_sharedData = sharedData;
		_getRegistrationOperationFactory = getRegistrationOperationFactory;
		_shouldSuppressVisualIndication = shouldSuppressVisualIndication;
	}

	public void Handle()
	{
		if (Uri.TryCreate(_sharedData.ReadData(AppData.Uri), UriKind.Absolute, out Uri result))
		{
			if (UriParser.TryParseUnlockCode(result, out string registrationName, out string unlockCode))
			{
				ShowRegistration(registrationName, unlockCode);
			}
			if (UriParser.TryParseSubscriptionKey(result, out string subscriptionKey))
			{
				bool showVisualIndication = !_shouldSuppressVisualIndication();
				_getRegistrationOperationFactory().Activate(subscriptionKey, showVisualIndication);
			}
		}
	}
}
