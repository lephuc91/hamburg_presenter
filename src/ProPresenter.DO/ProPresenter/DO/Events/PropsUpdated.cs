namespace ProPresenter.DO.Events;

public record PropsUpdated : IApplicationEvent
{
	public static void Publish()
	{
		ApplicationEventPublisher.Publish(new PropsUpdated());
	}
}
