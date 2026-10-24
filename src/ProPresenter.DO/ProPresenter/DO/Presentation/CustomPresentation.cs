using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.Common.Time;
using Pro.Common.Time.Timer;
using Pro.DO.Transitions;
using Pro.Text;
using Pro.UI.DialogService;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Media;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Themes;

namespace ProPresenter.DO.Presentation;

public class CustomPresentation : PresentationBase
{
	public enum SlideMergeResult
	{
		Successful,
		FirstSlide,
		FirstSlideInGroup,
		PreviousSlideHasNoText,
		SlideNotFoundInPresentation
	}

	private TemplateSlide? _activeTemplate;

	public TemplateSlide? ActiveTemplate
	{
		get
		{
			return _activeTemplate ?? (_activeTemplate = DataVault.Themes?.DefaultTheme.FirstOrDefault());
		}
		set
		{
			SetValue<TemplateSlide>("ActiveTemplate", ref _activeTemplate, value, delegate(TemplateSlide o, TemplateSlide n)
			{
				base.UndoStack.Commit(UndoActionTypes.ApplyTemplate.ToAction(), this, "ActiveTemplate", o, n);
			});
		}
	}

	public override ICopyPresentationIdentifier CopyIdentifier => new CustomPresentationCopyIdentifier();

	public CustomPresentation(IApp app, ITimerFactory timerFactory, IProPresenterDOFactoryProvider factoryProvider, ITransitionDescriptionCollection transitionDescriptions, IMessageDialogService messageDialogService, ICurrentTime currentTime, TemplateSlide? template = null)
		: base(app, timerFactory, factoryProvider, transitionDescriptions, messageDialogService, currentTime)
	{
		_activeTemplate = template;
	}

	public virtual SlideCue AddCue(TemplateSlide? targetTemplate, IEnumerable<ArrangedCue> targetCues, IArrangement? activeArrangement = null)
	{
		IArrangement arrangement = activeArrangement ?? base.ActiveArrangement ?? base.DefaultArrangement;
		return AddCue(targetTemplate, targetCues.OrderBy(arrangement.ArrangedCues.IndexOf).LastOrDefault()?.Source);
	}

	public virtual SlideCue AddCue(TemplateSlide? targetTemplate = null, SlideCue? targetCue = null)
	{
		ActiveTemplate = targetTemplate ?? ActiveTemplate;
		SlideCue slideCue = new SlideCue(base.FactoryProvider, new CustomSlide(base.FactoryProvider, base.TransitionDescriptions, ActiveTemplate), base.TransitionDescriptions);
		InsertCue(slideCue, targetCue);
		return slideCue;
	}

	public void AddCues(IEnumerable<SlideCue> cues, TemplateSlide? targetTemplate = null)
	{
		cues.ForEach(delegate(SlideCue s)
		{
			AddCue(targetTemplate, s);
		});
	}

	public void RemoveCue(SlideCue cue)
	{
		RemoveCue(cue, canClearAll: false);
	}

	protected void RemoveCue(SlideCue cue, bool canClearAll)
	{
		RemoveCues(new SlideCue[1] { cue }, canClearAll);
	}

	public virtual void RemoveCues(IEnumerable<SlideCue> targetCues)
	{
		RemoveCues(targetCues, canClearAll: false);
	}

	public void RemoveCues(IEnumerable<SlideCue> targetCues, bool canClearAll)
	{
		base.UndoStack.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.RemoveSlides));
		ITrackedMedia[] itemsToRemove = targetCues.SelectMany((SlideCue x) => x.GetTrackedMedia()).ToArray();
		base.UndoStack.Commit(delegate
		{
			itemsToRemove.ForEach(delegate(ITrackedMedia x)
			{
				x.AddToMediaServiceAndApplyTransform(userInitiated: true);
			});
		}, delegate
		{
			itemsToRemove.ForEach(delegate(ITrackedMedia x)
			{
				x.RemoveFromMediaService(deleteAssets: false);
			});
		});
		itemsToRemove.ForEach(delegate(ITrackedMedia x)
		{
			x.RemoveFromMediaService(deleteAssets: false);
		});
		DoRemoval();
		base.UndoStack.EndCommit(null, null, autoFinalize: true);
		void DoRemoval()
		{
			OnRemoveCues(targetCues);
			if (!canClearAll && base.Cues.Empty())
			{
				AddCue();
			}
		}
	}

	public void InsertCue(SlideCue cue, SlideCue? targetCue = null, IArrangement? arrangement = null, bool insertBefore = false)
	{
		InsertCues(new global::_003C_003Ez__ReadOnlySingleElementList<SlideCue>(cue), targetCue, arrangement, insertBefore);
	}

	public void InsertCues(IEnumerable<SlideCue> cues, SlideCue? targetCue = null, IArrangement? arrangement = null, bool insertBefore = false)
	{
		OnInsertCues(cues, targetCue, arrangement, insertBefore);
	}

	public SlideCue BreakSlideDocument(SlideCue cue, int caretIndex, ClosedBezierPath? targetPath = null, bool breakToNewSlide = true)
	{
		CustomSlide customSlide = (CustomSlide)(cue.SlideAction?.Slide);
		if (caretIndex < 0 || (targetPath == null && caretIndex > customSlide?.Text?.LastCharacterIndex) || (targetPath != null && caretIndex > targetPath.Text?.LastCharacterIndex))
		{
			return cue;
		}
		base.UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.BreakSlides));
		SlideCue slideCue = null;
		if (!breakToNewSlide)
		{
			slideCue = base.Cues.ElementAtOrDefault(base.Cues.IndexOf(cue) + 1);
		}
		if (slideCue == null)
		{
			breakToNewSlide = true;
			slideCue = (SlideCue)cue.Clone();
			slideCue.ClearActions();
		}
		CustomSlide customSlide2 = (CustomSlide)(slideCue.SlideAction?.Slide);
		ClosedBezierPath closedBezierPath = customSlide2?.Elements.OfType<ClosedBezierPath>().FirstOrDefault((ClosedBezierPath e) => e.Text == targetPath?.Text) ?? customSlide2?.GetPrimaryTextElement(useDisplayText: false);
		TextDocument textDocument = (targetPath?.Text ?? customSlide?.Text)?.SplitDocument(caretIndex);
		if (breakToNewSlide)
		{
			if ((object)textDocument != null && closedBezierPath != null)
			{
				closedBezierPath.Text = textDocument;
			}
			InsertCues(new SlideCue[1] { slideCue }, cue);
		}
		else
		{
			if (closedBezierPath == null)
			{
				ClosedBezierPath closedBezierPath2 = (ClosedBezierPath)((targetPath ?? customSlide?.GetPrimaryTextElement(useDisplayText: false))?.Clone());
				if (closedBezierPath2 != null)
				{
					closedBezierPath2.Text.Clear();
					if (customSlide2 != null)
					{
						customSlide2?.AddElement(closedBezierPath2, userInitiated: true);
					}
				}
			}
			if (textDocument != null)
			{
				customSlide2?.Text?.MergeDocument(textDocument, prepend: true);
			}
		}
		base.UndoStack?.EndCommit(null, null, autoFinalize: true);
		return slideCue;
	}

	public override PresentationBase Clone()
	{
		return CopyProperties(new CustomPresentation(base.App, base.TimerFactory, base.FactoryProvider, base.TransitionDescriptions, base.MessageDialogService, base.CurrentTime, ActiveTemplate?.Clone()));
	}

	public SlideMergeResult MergeSlidesDocument(SlideCue cue, out int characterIndex, out SlideCue? previousSlide, Action? onUndo = null)
	{
		characterIndex = -1;
		CueCollection cueCollection = base.ArrangementGroups.FirstOrDefault((CueGroup g) => g.Cues.Contains(cue))?.Cues;
		int num = cueCollection?.IndexOf(cue) ?? (-1);
		if (num < 0)
		{
			previousSlide = null;
			return SlideMergeResult.SlideNotFoundInPresentation;
		}
		if (num == 0)
		{
			previousSlide = null;
			if (cueCollection == base.ArrangementGroups[0].Cues)
			{
				return SlideMergeResult.FirstSlide;
			}
			return SlideMergeResult.FirstSlideInGroup;
		}
		SlideCue slideCue = cueCollection[num - 1];
		TextDocument other = cue.SlideAction?.Slide.Text;
		TextDocument textDocument = slideCue.SlideAction?.Slide.Text;
		if (textDocument == null)
		{
			previousSlide = null;
			return SlideMergeResult.PreviousSlideHasNoText;
		}
		base.UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.MergeSlides));
		characterIndex = textDocument.LastCharacterIndex;
		textDocument.MergeDocument(other);
		RemoveCue(cue);
		if (onUndo != null)
		{
			base.UndoStack?.Commit(onUndo, delegate
			{
			});
		}
		base.UndoStack?.EndCommit(null, null, autoFinalize: true);
		previousSlide = slideCue;
		return SlideMergeResult.Successful;
	}

	public void ApplyTemplateToSlides(TemplateSlide template, bool applyMediaAction)
	{
		ApplyTemplateToSlides(template, base.Cues, applyMediaAction);
	}

	public void ApplyTemplateToSlides(TemplateSlide template, IEnumerable<SlideCue> targetCues, bool applyMediaAction)
	{
		base.UndoStack.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ApplyTemplate));
		ActiveTemplate = template;
		targetCues.ForEach(delegate(SlideCue c)
		{
			c.ApplyTemplate(ActiveTemplate, TemplateOptions.None, applyMediaAction);
		});
		base.UndoStack.EndCommit(null, null, autoFinalize: true);
	}
}
