using System;

namespace ProPresenter.DO.Slide.Links.Text.Slide;

public static class SlideMenuTestModeExtensions
{
	public static SlideTextSourceMode ToSlideTextSourceMode(this SlideMenuTextMode source)
	{
		switch (source)
		{
		case SlideMenuTextMode.TextOnly:
		case SlideMenuTextMode.TextAndChords:
			return SlideTextSourceMode.TextOnly;
		case SlideMenuTextMode.Notes:
			return SlideTextSourceMode.Notes;
		case SlideMenuTextMode.ElementMatch:
			return SlideTextSourceMode.ElementMatch;
		default:
			throw new NotSupportedException();
		}
	}
}
