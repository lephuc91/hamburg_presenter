using Pro.Common.MessageService;
using Pro.Common.MessageService.AppMessages;
using ProPresenter.Continuation;
using ProPresenter.DO.Updates;

namespace ProPresenter.Updates;

public class AppInstaller : IAppInstaller
{
	private readonly IMessageService _messageService;

	private readonly IAppContinuationService _appContinuationService;

	private readonly string _fileName;

	public AppInstaller(IMessageService messageService, IAppContinuationService appContinuationService, string fileName)
	{
		_messageService = messageService;
		_appContinuationService = appContinuationService;
		_fileName = fileName;
	}

	public void Install()
	{
		_appContinuationService.Add(_fileName);
		_messageService.PublishMessage(new RequestApplicationCloseMessage());
	}
}
