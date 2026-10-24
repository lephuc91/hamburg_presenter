using Pro.Common.MessageService;

namespace ProPresenter.Controller;

public class TriggerServiceFactory : ITriggeringFactory
{
	private readonly IInternalCoreManager _coreManager;

	private readonly IMessageService _messageService;

	public TriggerServiceFactory(IInternalCoreManager coreManager, IMessageService messageService)
	{
		_coreManager = coreManager;
		_messageService = messageService;
	}

	public ITriggering Create(TriggerSource triggerSource = TriggerSource.Internal)
	{
		return new TriggerService(_coreManager, _messageService, triggerSource);
	}
}
