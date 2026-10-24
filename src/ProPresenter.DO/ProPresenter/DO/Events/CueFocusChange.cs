using ProPresenter.DO.Cues;

namespace ProPresenter.DO.Events;

public record CueFocusChange(ProPresenterCue Slide) : IApplicationEvent
{
	public static void Publish(ProPresenterCue slide)
	{
		ApplicationEventPublisher.Publish(new CueFocusChange(slide));
	}
}
