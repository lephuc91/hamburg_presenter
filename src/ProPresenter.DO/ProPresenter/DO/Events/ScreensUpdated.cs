namespace ProPresenter.DO.Events;

public record ScreensUpdated : IApplicationEvent
{
	public static void Publish()
	{
		ApplicationEventPublisher.Publish(new ScreensUpdated());
	}
}
