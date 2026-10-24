using Pro.Common.MessageService;

namespace ProPresenter.DO.Actions;

public class ClearTypeTriggeredMessage : IMessage
{
	public ClearType TriggeredClearType { get; }

	public ClearTypeTriggeredMessage(ClearType triggeredClearType)
	{
		TriggeredClearType = triggeredClearType;
	}
}
