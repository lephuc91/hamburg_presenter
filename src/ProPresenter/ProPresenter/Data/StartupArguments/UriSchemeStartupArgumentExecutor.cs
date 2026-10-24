using System;
using Pro.Interprocess;
using ProPresenter.DO;
using ProPresenter.DO.Registration.Operations;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.Data.StartupArguments;

public class UriSchemeStartupArgumentExecutor : LegacyUriSchemeStartupArgumentExecutor
{
	private readonly Func<IRegistrationOperationFactory> _getRegistrationOperationFactory;

	public UriSchemeStartupArgumentExecutor(Func<IRegistrationOperationFactory> getRegistrationOperationFactory, ISharedData<AppData> sharedData, IMessages<AppMessages> messages, Func<IMainLayoutVM> getMainLayoutVM, Action<bool> registrationArgumentProcessingComplete)
		: base(getMainLayoutVM, sharedData, messages, registrationArgumentProcessingComplete)
	{
		_getRegistrationOperationFactory = getRegistrationOperationFactory;
	}

	public override bool UseUrlSchemeLocally()
	{
		if (!TryUseUrlWithLegacyScheme())
		{
			return TryUseUrlWithNewScheme();
		}
		return true;
	}

	private bool TryUseUrlWithNewScheme()
	{
		if ((object)base.Uri != null && UriParser.TryParseSubscriptionKey(base.Uri, out string subscriptionKey))
		{
			_getRegistrationOperationFactory().Activate(subscriptionKey);
			return true;
		}
		return false;
	}
}
