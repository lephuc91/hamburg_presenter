using ProPresenter.DO.Messages;

namespace ProPresenter.DO.Events;

public record MessageUpdated(Message Message) : IApplicationEvent
{
	public static void Publish(Message message)
	{
		ApplicationEventPublisher.Publish(new MessageUpdated(message));
	}
}
