using System;
using Pro.Interprocess;
using ProPresenter.DO;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.Data.StartupArguments;

public abstract class LegacyUriSchemeStartupArgumentExecutor : RegitrationUiActivator, IStartupArgumentsExecutor
{
	private readonly ISharedData<AppData> _sharedData;

	private readonly IMessages<AppMessages> _messages;

	private readonly Action<bool> _registrationArgumentProcessingComplete;

	protected Uri? Uri { get; private set; }

	protected LegacyUriSchemeStartupArgumentExecutor(Func<IMainLayoutVM> getMainLayoutVM, ISharedData<AppData> sharedData, IMessages<AppMessages> messages, Action<bool> registrationArgumentProcessingComplete)
		: base(getMainLayoutVM)
	{
		_sharedData = sharedData;
		_messages = messages;
		_registrationArgumentProcessingComplete = registrationArgumentProcessingComplete;
	}

	public bool ProcessArgument(string argument)
	{
		if (System.Uri.TryCreate(argument, UriKind.Absolute, out Uri result))
		{
			Uri = result;
			return true;
		}
		return false;
	}

	public void Send()
	{
		if ((object)Uri != null)
		{
			_sharedData.SendData(AppData.Uri, Uri.ToString());
			_messages.SendMessage(AppMessages.HandleUri);
		}
	}

	protected bool TryUseUrlWithLegacyScheme()
	{
		if ((object)Uri != null && UriParser.TryParseUnlockCode(Uri, out string registrationName, out string unlockCode))
		{
			ShowRegistration(registrationName, unlockCode);
			return true;
		}
		return false;
	}

	public void UseLocally()
	{
		_registrationArgumentProcessingComplete(UseUrlSchemeLocally());
	}

	public virtual bool UseUrlSchemeLocally()
	{
		return TryUseUrlWithLegacyScheme();
	}
}
