using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.UI.Utility;
using ProPresenter.DO;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Custom.Elements.Shapes;
using ProPresenter.DO.Themes;
using ProPresenter.UI;
using ProPresenter.UI.ViewModels;
using ProPresenter.UI.ViewModels.Editor;
using ProPresenter.UI.ViewModels.Library.Cue;

namespace ProPresenter.ViewModels.TextStyle;

public class TextStyleFacade : LinkedNotifyPropertyChangedBase, ITextStyleFacade, INotifyPropertyChanged
{
	private readonly IMainLayoutVM _mainLayoutVM;

	private readonly IThemeAnalyiticEvents _themeAnalytics;

	public bool CanShowTextStylePopover
	{
		get
		{
			if (!_mainLayoutVM.ActiveInlineView.IsAnyOf(InlineType.Presentation, InlineType.Reflow))
			{
				return IsPresentationEditMode;
			}
			return true;
		}
	}

	private bool IsPresentationEditMode
	{
		get
		{
			if (_mainLayoutVM.ActiveInlineView == InlineType.SlideEditor)
			{
				return _mainLayoutVM.PresentationEditorVM.EditMode == EditMode.Presentation;
			}
			return false;
		}
	}

	internal TextStyleFacade(IMainLayoutVM mainLayoutVM, IThemeAnalyiticEvents themeAnalyiticEvents)
	{
		_mainLayoutVM = mainLayoutVM;
		_themeAnalytics = themeAnalyiticEvents;
		LinkProperties(new string[2] { "ActiveInlineView", "EditMode" }, "CanShowTextStylePopover");
		_mainLayoutVM.PropertyChanged += base.RaiseLinkedValues;
		_mainLayoutVM.PresentationEditorVM.PropertyChanged += base.RaiseLinkedValues;
	}

	public ProPresenter.DO.TextStyle? GetCurrentTextStyle(TargetStrategy strategy)
	{
		return GetElement(strategy)?.GetTextStyle();
	}

	public bool CanCopyTextStyle(TargetStrategy strategy)
	{
		ClosedBezierPath element = GetElement(strategy);
		if (!(element is TextShape))
		{
			return !string.IsNullOrEmpty(element?.Text?.AllText ?? string.Empty);
		}
		return true;
	}

	private ClosedBezierPath? GetElement(TargetStrategy strategy)
	{
		switch (_mainLayoutVM.ActiveInlineView)
		{
		case InlineType.Presentation:
		case InlineType.Reflow:
			return GetTextElement(_mainLayoutVM.PresentationVM.SelectedSlide?.Source.SlideAction?.Slide as CustomSlide);
		case InlineType.SlideEditor:
		case InlineType.StageEditor:
		case InlineType.PropsEditor:
			return GetTextElement(_mainLayoutVM.PresentationEditorVM, strategy);
		case InlineType.TemplateEditor:
			return GetTextElement(_mainLayoutVM.TemplateEditorVM, strategy);
		default:
			return null;
		}
	}

	private static ClosedBezierPath? GetTextElement(CustomSlide? slide)
	{
		return slide?.GetLargestTextElementInBounds(useDisplayText: true);
	}

	private static ClosedBezierPath? GetTextElement(ISlideEditorVM editorVM, TargetStrategy strategy)
	{
		return strategy switch
		{
			TargetStrategy.Default => editorVM.SelectedCanvasElements.FirstOrDefaultOf<ClosedBezierPath>() ?? GetTextElement(editorVM.SelectedSlides.FirstOrDefault()), 
			TargetStrategy.SelectedSlides => GetTextElement(editorVM.SelectedSlides.FirstOrDefault()), 
			TargetStrategy.SelectedElements => editorVM.SelectedCanvasElements.FirstOrDefaultOf<ClosedBezierPath>(), 
			_ => null, 
		};
	}

	public IEnumerable<ClosedBezierPath> GetTargetElements(TargetStrategy targetStrategy)
	{
		return targetStrategy switch
		{
			TargetStrategy.Default => GetTargetElements().Any() ? GetTargetElements() : GetTargetSlideElements(), 
			TargetStrategy.SelectedSlides => GetTargetSlideElements(), 
			TargetStrategy.SelectedElements => GetTargetElements(), 
			TargetStrategy.AllSlides => GetAllElements(), 
			_ => throw new NotSupportedException(), 
		};
	}

	private IEnumerable<ClosedBezierPath> GetTargetElements()
	{
		switch (_mainLayoutVM.ActiveInlineView)
		{
		case InlineType.Presentation:
		case InlineType.Reflow:
		{
			IEnumerable<ClosedBezierPath> enumerable = _mainLayoutVM.PresentationVM.SelectedSlides.Select((ArrangedCue s) => s.Source).Distinct().SelectMany(getElements);
			if (!enumerable.Any())
			{
				return GetCues(_mainLayoutVM.PresentationVM.ActivePresentation).SelectMany(getElements);
			}
			return enumerable;
		}
		case InlineType.SlideEditor:
		case InlineType.StageEditor:
		case InlineType.PropsEditor:
			return _mainLayoutVM.PresentationEditorVM.SelectedSlideElements.OfType<ClosedBezierPath>();
		case InlineType.TemplateEditor:
		case InlineType.CCLITemplateEditor:
			return _mainLayoutVM.TemplateEditorVM.SelectedSlideElements.OfType<ClosedBezierPath>();
		case InlineType.MaskEditor:
			return _mainLayoutVM.MaskEditorVM.SelectedSlideElements.OfType<ClosedBezierPath>();
		default:
			return Array.Empty<ClosedBezierPath>();
		}
		static IEnumerable<ClosedBezierPath> getElements(SlideCue cue)
		{
			return (cue?.SlideAction?.Slide as CustomSlide)?.Elements.OfType<ClosedBezierPath>() ?? Enumerable.Empty<ClosedBezierPath>();
		}
	}

	private IEnumerable<ClosedBezierPath> GetAllElements()
	{
		switch (_mainLayoutVM.ActiveInlineView)
		{
		case InlineType.SlideEditor:
		case InlineType.StageEditor:
		case InlineType.PropsEditor:
			return _mainLayoutVM.PresentationEditorVM.Slides.SelectMany(getElements);
		case InlineType.TemplateEditor:
		case InlineType.CCLITemplateEditor:
			return _mainLayoutVM.TemplateEditorVM.Slides.SelectMany(getElements);
		case InlineType.MaskEditor:
			return _mainLayoutVM.MaskEditorVM.Slides.SelectMany(getElements);
		default:
			return Array.Empty<ClosedBezierPath>();
		}
		static IEnumerable<ClosedBezierPath> getElements(CustomSlide slide)
		{
			return slide.Elements.OfType<ClosedBezierPath>();
		}
	}

	private IEnumerable<ClosedBezierPath> GetTargetSlideElements()
	{
		return getSlides().SelectMany((CustomSlide s) => s.Elements.OfType<ClosedBezierPath>());
		IEnumerable<CustomSlide> getSlides()
		{
			switch (_mainLayoutVM.ActiveInlineView)
			{
			case InlineType.SlideEditor:
			case InlineType.StageEditor:
			case InlineType.PropsEditor:
				return _mainLayoutVM.PresentationEditorVM.SelectedSlides;
			case InlineType.TemplateEditor:
				return _mainLayoutVM.TemplateEditorVM.SelectedSlides;
			case InlineType.MaskEditor:
			case InlineType.CCLITemplateEditor:
				return Array.Empty<CustomSlide>();
			default:
			{
				ObservableCollection<ArrangedCue> selectedSlides = _mainLayoutVM.PresentationVM.SelectedSlides;
				if (selectedSlides.Any())
				{
					return selectedSlides.Select((ArrangedCue s) => s.Source.SlideAction?.Slide as CustomSlide).NotNull();
				}
				IEnumerable<IDocumentCue> source = from c in _mainLayoutVM.LibraryVM.SelectedCues.OfType<IDocumentCueVM>()
					select c.Document;
				if (source.Any())
				{
					return (from c in source.SelectMany((IDocumentCue c) => GetCues(c.DocumentAction?.Presentation))
						select c.SlideAction?.Slide as CustomSlide).NotNull();
				}
				if (!(_mainLayoutVM.LibraryVM.ActiveCue is IDocumentCueVM documentCueVM))
				{
					return Array.Empty<CustomSlide>();
				}
				return (from c in GetCues(documentCueVM.Document.DocumentAction?.Presentation)
					select c.SlideAction?.Slide as CustomSlide).NotNull();
			}
			}
		}
	}

	private static IEnumerable<SlideCue> GetCues(IPresentation? presentation)
	{
		return presentation?.ArrangementGroups.SelectMany((CueGroup g) => g.Cues) ?? Enumerable.Empty<SlideCue>();
	}

	public void ApplyTemplate(TemplateSlide template)
	{
		if (IsPresentationEditMode)
		{
			_mainLayoutVM.PresentationEditorVM.ApplyTemplateToSelectedSlidesCommand?.Invoke(template);
			_themeAnalytics?.Applied(ThemeAppliedTargetEnum.SlideSelection);
		}
		else if (_mainLayoutVM.PresentationVM.SelectedSlides.Empty())
		{
			_mainLayoutVM.LibraryVM.SelectTemplateCommand?.Invoke(template);
			_themeAnalytics?.Applied(ThemeAppliedTargetEnum.PresentationSelection);
		}
		else
		{
			_mainLayoutVM.PresentationVM.SelectTemplateCommand?.Invoke(template);
			_themeAnalytics?.Applied(ThemeAppliedTargetEnum.SlideSelection);
		}
	}
}
