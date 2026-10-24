using ProPresenter.DO.Props;

namespace ProPresenter.DO.Events;

public record PropCleared(IPropCue Prop) : IApplicationEvent
{
	public static void Publish(IPropCue prop)
	{
		ApplicationEventPublisher.Publish(new PropCleared(prop));
	}
}
