using ProPresenter.DO.Looks;

namespace ProPresenter.DO.Events;

public record CurrentLookUpdated(LiveAudienceLook LiveLook) : IApplicationEvent
{
	public static void Publish(LiveAudienceLook liveLook)
	{
		ApplicationEventPublisher.Publish(new CurrentLookUpdated(liveLook));
	}
}
