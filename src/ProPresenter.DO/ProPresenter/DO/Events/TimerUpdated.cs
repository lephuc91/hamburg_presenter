namespace ProPresenter.DO.Events;

public record TimerUpdated : IApplicationEvent
{
	public static void Publish()
	{
		ApplicationEventPublisher.Publish(new TimerUpdated());
	}
}
