using System.Collections.Generic;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Slide.Custom;

namespace ProPresenter.UI.ViewModels;

public interface ISlideSelectorStrategy
{
	IEnumerable<SlideCue> GetSelectedSlideCues();

	IEnumerable<CustomSlide> GetSelectedSlides();
}
