using Pro.Common.MessageService;
using ProPresenter.Continuation;
using ProPresenter.DO.Updates;

namespace ProPresenter.Updates;

public class AppInstallerFactory : IAppInstallerFactory
{
	private readonly IMessageService _messageService;

	private readonly IAppContinuationService _appContinuationService;

	public AppInstallerFactory(IMessageService messageService, IAppContinuationService appContinuationService)
	{
		_messageService = messageService;
		_appContinuationService = appContinuationService;
	}

	public IAppInstaller Create(string fileName)
	{
		return new AppInstaller(_messageService, _appContinuationService, fileName);
	}
}
