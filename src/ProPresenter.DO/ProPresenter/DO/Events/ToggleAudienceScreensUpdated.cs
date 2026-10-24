namespace ProPresenter.DO.Events;

public record ToggleAudienceScreensUpdated(bool Enabled) : IApplicationEvent
{
	public static void Publish(bool enabled)
	{
		ApplicationEventPublisher.Publish(new ToggleAudienceScreensUpdated(enabled));
	}
}
