namespace ProPresenter.DO.Events;

public record SlideCleared(OutputDestination Destination) : IApplicationEvent
{
	public static void Publish(OutputDestination destination)
	{
		ApplicationEventPublisher.Publish(new SlideCleared(destination));
	}
}
