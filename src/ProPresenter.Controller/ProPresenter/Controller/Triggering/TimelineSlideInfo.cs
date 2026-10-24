using ProPresenter.DO.Arrangements;

namespace ProPresenter.Controller.Triggering;

public class TimelineSlideInfo(int currentSlideNumber, int slidesRemaining, int totalSlidesCount, IArrangedCue? currentSlide, IArrangedCue? nextSlide, CueGroup? nextGroup)
{
	public int CurrentSlideNumber { get; } = currentSlideNumber;

	public int SlidesRemaining { get; } = slidesRemaining;

	public int TotalSlidesCount { get; } = totalSlidesCount;

	public IArrangedCue? CurrentSlide { get; } = currentSlide;

	public IArrangedCue? NextSlide { get; } = nextSlide;

	public CueGroup? NextGroup { get; } = nextGroup;
}
