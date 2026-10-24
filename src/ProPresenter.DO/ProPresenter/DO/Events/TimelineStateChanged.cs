using ProPresenter.DO.Presentation;

namespace ProPresenter.DO.Events;

public record TimelineStateChanged(Timeline Timeline, bool IsPlaying, double PlayingOffset) : IApplicationEvent
{
	public static void Publish(Timeline timeline, bool isPlaying, double playingOffset)
	{
		ApplicationEventPublisher.Publish(new TimelineStateChanged(timeline, isPlaying, playingOffset));
	}
}
