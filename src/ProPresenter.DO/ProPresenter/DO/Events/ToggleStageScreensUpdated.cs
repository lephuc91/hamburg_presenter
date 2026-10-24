namespace ProPresenter.DO.Events;

public record ToggleStageScreensUpdated(bool Enabled) : IApplicationEvent
{
	public static void Publish(bool enabled)
	{
		ApplicationEventPublisher.Publish(new ToggleStageScreensUpdated(enabled));
	}
}
