using ProPresenter.DO.Capture;

namespace ProPresenter.DO.Events;

public record CaptureStatusUpdated(State State, string TimeLapse, string StatusText) : IApplicationEvent
{
	public static void Publish(State state, string timeLapse, string statusText)
	{
		ApplicationEventPublisher.Publish(new CaptureStatusUpdated(state, timeLapse, statusText));
	}
}
