using Pro.Common.Time;

namespace ProPresenter.DO.Events;

public record VideoCountdownTimeChanged(TimeSlice Time) : IApplicationEvent
{
	public static void Publish(TimeSlice time)
	{
		ApplicationEventPublisher.Publish(new VideoCountdownTimeChanged(time));
	}
}
