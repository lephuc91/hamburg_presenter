namespace ProPresenter.DO.Events;

public record MessagesUpdated : IApplicationEvent
{
	public static void Publish()
	{
		ApplicationEventPublisher.Publish(new MessagesUpdated());
	}
}
