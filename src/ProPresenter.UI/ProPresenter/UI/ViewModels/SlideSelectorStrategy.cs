using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using ProPresenter.DO;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Slide.Custom;

namespace ProPresenter.UI.ViewModels;

public class SlideSelectorStrategy : ISlideSelectorStrategy
{
	private readonly IMainLayoutVM _mainLayoutVM;

	public SlideSelectorStrategy(IMainLayoutVM mainLayoutVM)
	{
		_mainLayoutVM = mainLayoutVM;
	}

	public IEnumerable<CustomSlide> GetSelectedSlides()
	{
		switch (_mainLayoutVM.ActiveInlineView)
		{
		case InlineType.Presentation:
		case InlineType.Reflow:
			return _mainLayoutVM.PresentationVM.CustomSlideMenuVM.SelectedSlides.Select((ArrangedCue s) => s.Source.SlideAction?.Slide).OfType<CustomSlide>().Distinct();
		case InlineType.SlideEditor:
			if (_mainLayoutVM.PresentationEditorVM.EditMode != 0)
			{
				return Array.Empty<CustomSlide>();
			}
			return _mainLayoutVM.PresentationEditorVM.SelectedSlides.ToArray();
		default:
			return Array.Empty<CustomSlide>();
		}
	}

	public IEnumerable<SlideCue> GetSelectedSlideCues()
	{
		switch (_mainLayoutVM.ActiveInlineView)
		{
		case InlineType.Presentation:
		case InlineType.Reflow:
			return _mainLayoutVM.PresentationVM?.CustomSlideMenuVM?.SelectedSlides.Select((ArrangedCue slide) => slide.Source) ?? Enumerable.Empty<SlideCue>();
		case InlineType.SlideEditor:
			if (_mainLayoutVM.PresentationEditorVM.EditMode == EditMode.Presentation)
			{
				return (from source in (_mainLayoutVM.PresentationVM?.ActivePresentation?.DefaultArrangement?.ArrangedCues)?.Select((ArrangedCue cue) => cue.Source).NonNull()
					where _mainLayoutVM.PresentationEditorVM.SelectedSlides.NonNull().Any((CustomSlide slide) => slide == source?.SlideAction?.Slide)
					select source) ?? Enumerable.Empty<SlideCue>();
			}
			return Array.Empty<SlideCue>();
		default:
			return Array.Empty<SlideCue>();
		}
	}
}
