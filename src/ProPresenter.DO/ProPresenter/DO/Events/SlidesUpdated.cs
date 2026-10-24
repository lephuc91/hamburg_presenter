using ProPresenter.DO.Cues;

namespace ProPresenter.DO.Events;

public record SlidesUpdated(SlideCue? CurrentSlide, SlideCue? NextSlide) : IApplicationEvent
{
	public static void Publish(SlideCue? currentSlide, SlideCue? nextSlide)
	{
		ApplicationEventPublisher.Publish(new SlidesUpdated(currentSlide, nextSlide));
	}
}
