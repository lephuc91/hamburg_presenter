using System.Collections.Generic;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Slide;

namespace ProPresenter.UI.PresentationView;

public class SlidesCommandParameter
{
	public IEnumerable<SlideBase> Slides { get; }

	public PresentationBase Presentation { get; }

	public SlidesCommandParameter(IEnumerable<SlideBase> slides, PresentationBase presentation)
	{
		Slides = slides;
		Presentation = presentation;
	}
}
