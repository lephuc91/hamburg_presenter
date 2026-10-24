using ProPresenter.DO.Cues;

namespace ProPresenter.Controller;

public class TimelineTriggerOptions
{
	public SlideCue NextSlide { get; }

	public TimelineTriggerOptions(SlideCue nextSlide)
	{
		NextSlide = nextSlide;
	}
}
