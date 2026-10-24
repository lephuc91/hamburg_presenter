using ProPresenter.DO.Props;

namespace ProPresenter.DO.Events;

public record PropTriggered(IPropCue Prop) : IApplicationEvent
{
	public static void Publish(IPropCue prop)
	{
		ApplicationEventPublisher.Publish(new PropTriggered(prop));
	}
}
