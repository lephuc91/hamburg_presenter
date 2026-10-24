using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Windows.Threading;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.Nullability;
using Pro.Common.ObjectBinding;
using Pro.Common.Time;
using Pro.Common.Time.Timer;
using Pro.Common.Utility;
using Pro.DO.Label;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;
using Pro.UI.DialogService;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Bibles;
using ProPresenter.DO.Cues;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Themes;

namespace ProPresenter.DO.Presentation;

public class BiblePresentation : CustomPresentation
{
	private BibleTranslationCollection? _translations;

	private BibleReference _startReference;

	private BibleReference _endReference;

	private string? PrimaryAbbreviation => _translations?.PrimaryTranslation?.Abbreviation;

	public override PresentationType PresentationType => PresentationType.Bible;

	public BibleReference StartReference
	{
		get
		{
			return _startReference;
		}
		set
		{
			_startReference = value;
			OnPropertyChanged("StartReference");
		}
	}

	public BibleReference EndReference
	{
		get
		{
			return _endReference;
		}
		set
		{
			_endReference = value;
			OnPropertyChanged("EndReference");
		}
	}

	public override ObjectBinder<PresentationBase, Pro.Entity.IPresentation> Bind(IUiScheduler scheduler, IProPresenterDOFactoryProvider factoryProvider, IActionBinderFactory actionBinderFactory, Pro.Entity.IPresentation entityDoc)
	{
		ObjectBinder<PresentationBase, Pro.Entity.IPresentation> objectBinder = base.Bind(scheduler, factoryProvider, actionBinderFactory, entityDoc);
		ObjectBinder<BiblePresentation, Pro.Entity.IPresentation> bibleBinder = new ObjectBinder<BiblePresentation, Pro.Entity.IPresentation>(this, objectBinder.Right);
		bibleBinder.Bind((BiblePresentation l) => l.WhenPropertyChanges("StartReference").ToUnit().Merge(l.WhenPropertyChanges("EndReference").ToUnit()), (Pro.Entity.IPresentation r) => r.BibleReference.WhenAnyValueChanges, delegate(BiblePresentation l, Pro.Entity.IPresentation r)
		{
			if (!StartReference.IsValid || !EndReference.IsValid)
			{
				r.BibleReference.Set(null);
			}
			else
			{
				Pro.Entity.IPresentation.Types.IBibleReference bibleReference = factoryProvider.EntityFactory.Create<Pro.Entity.IPresentation.Types.IBibleReference>();
				r.BibleReference.Set(bibleReference);
				bibleReference.BookIndex.Set((uint)l.StartReference.BookIndex);
				bibleReference.BookName.Set(l.StartReference.BookName ?? string.Empty);
				bibleReference.ChapterRange.Set(new Pro.Entity.IntRange(l.StartReference.ChapterNumber, l.EndReference.ChapterNumber));
				bibleReference.VerseRange.Set(new Pro.Entity.IntRange(l.StartReference.VerseNumber, l.EndReference.VerseNumber));
			}
		}, delegate(Pro.Entity.IPresentation r, BiblePresentation l)
		{
			if (r.BibleReference.Value != null)
			{
				l.StartReference = new BibleReference((int)r.BibleReference.Value.BookIndex.Value, "", r.BibleReference.Value.BookName.Value, r.BibleReference.Value.ChapterRange.Value?.Start ?? 0, r.BibleReference.Value.VerseRange.Value?.Start ?? 0);
				l.EndReference = new BibleReference((int)r.BibleReference.Value.BookIndex.Value, "", r.BibleReference.Value.BookName.Value, r.BibleReference.Value.ChapterRange.Value?.End ?? 0, r.BibleReference.Value.VerseRange.Value?.End ?? 0);
			}
			else
			{
				l.StartReference = BibleReference.Invalid;
				l.EndReference = BibleReference.Invalid;
			}
		}, null, scheduler.Scheduler);
		objectBinder.DoOnInitializeLeftFromRight(bibleBinder.InitializeLeftFromRight).DoOnInitializeRightFromLeft(bibleBinder.InitializeRightFromLeft).RegisterChildDisposable(() => bibleBinder);
		return objectBinder;
	}

	protected BiblePresentation(IApp app, ITimerFactory timerFactory, IProPresenterDOFactoryProvider factoryProvider, TemplateSlide template, BibleReference startReference, BibleReference endReference, BibleTranslationCollection translations, ITransitionDescriptionCollection transitionDescriptions, IMessageDialogService messageDialogService, ICurrentTime currentTime)
		: this(app, timerFactory, factoryProvider, transitionDescriptions, messageDialogService, currentTime, template, translations)
	{
		StartReference = startReference;
		EndReference = endReference;
	}

	public BiblePresentation(IApp app, ITimerFactory timerFactory, IProPresenterDOFactoryProvider mediaFactory, ITransitionDescriptionCollection transitionDescriptions, IMessageDialogService messageDialogService, ICurrentTime currentTime, TemplateSlide? template = null, BibleTranslationCollection? translations = null)
		: base(app, timerFactory, mediaFactory, transitionDescriptions, messageDialogService, currentTime, template ?? DataVault.Themes?.FindTemplate(BibleSettings.Settings.SelectedTemplateID))
	{
		_translations = translations;
	}

	public override PresentationBase Clone()
	{
		BiblePresentation presentation = new BiblePresentation(base.App, base.TimerFactory, base.FactoryProvider, base.TransitionDescriptions, base.MessageDialogService, base.CurrentTime, base.ActiveTemplate, _translations?.Clone())
		{
			StartReference = StartReference,
			EndReference = EndReference
		};
		return CopyProperties(presentation);
	}

	public void NavigateVerse(LoadedBibleCollection loadedBibles, bool isForward, bool applyTemplateMediaAction)
	{
		BibleBase loadedBible = loadedBibles.GetLoadedBible(PrimaryAbbreviation);
		if (loadedBible == null)
		{
			return;
		}
		BibleReference oldNextVerseReference = (isForward ? EndReference : StartReference);
		BibleReference newNextVerseReference = BibleHelper.NavigateBibleVerse(loadedBible, oldNextVerseReference, isForward);
		if (!newNextVerseReference.IsValid)
		{
			return;
		}
		base.UndoStack.BeginCommit(UndoActionTypes.ChangeBibleReference.ToAction());
		if (isForward)
		{
			base.UndoStack.Commit(delegate
			{
				EndReference = oldNextVerseReference;
			}, delegate
			{
				EndReference = newNextVerseReference;
			});
			EndReference = newNextVerseReference;
		}
		else
		{
			base.UndoStack.Commit(delegate
			{
				StartReference = oldNextVerseReference;
			}, delegate
			{
				StartReference = newNextVerseReference;
			});
			StartReference = newNextVerseReference;
		}
		List<SlideCue> generatedSlides = new List<SlideCue>();
		base.ActiveTemplate.ThrowWhenNull("ActiveTemplate");
		BibleTemplateHelper.GenerateSlides(base.ActiveTemplate, newNextVerseReference, newNextVerseReference, _translations, loadedBibles, BibleSlideDisplayOptions.Current, delegate(SlideCue newCue)
		{
			generatedSlides.Add(newCue);
			if (applyTemplateMediaAction)
			{
				newCue.ApplyTemplateMediaAction(base.ActiveTemplate);
			}
		}, null, () => false, base.FactoryProvider, base.TransitionDescriptions);
		OnInsertCues(generatedSlides, (!isForward) ? base.Cues.FirstOrDefault() : null, null, !isForward);
		base.UndoStack.EndCommit(null, null, autoFinalize: true);
	}

	public void UpdateSlides(Dispatcher dispatcher, BibleReference startReference, BibleReference endReference, string referenceText, IEnumerable<BibleBase> loadedBibles, BibleSlideDisplayOptions displayOptions, bool applyTemplateMediaAction, BibleTemplateHelper.GenerateSlideProgressDelegate progressCallback, BibleTemplateHelper.IsGenerateSlideCancelledDelegate isCancelledCallback, BibleTranslationCollection translations)
	{
		StartReference = startReference;
		EndReference = endReference;
		_translations = translations;
		CueGroup group = dispatcher.Invoke<CueGroup>((Func<CueGroup>)delegate
		{
			ClearSlides();
			CueGroup result = base.ArrangementGroups.AddArrangementGroup(new GroupLabel(referenceText));
			if (_translations != null)
			{
				translations = _translations.Clone();
				if (PrimaryAbbreviation != null && translations.PrimaryTranslation != null)
				{
					translations.PrimaryTranslation.Abbreviation = PrimaryAbbreviation;
				}
			}
			return result;
		});
		base.ActiveTemplate.ThrowWhenNull("ActiveTemplate");
		BibleTemplateHelper.GenerateSlides(base.ActiveTemplate, StartReference, EndReference, _translations, loadedBibles, displayOptions, delegate(SlideCue s)
		{
			AddGeneratedSlide(s, group, applyTemplateMediaAction, dispatcher);
		}, progressCallback, isCancelledCallback, base.FactoryProvider, base.TransitionDescriptions);
	}

	private void AddGeneratedSlide(SlideCue slideCue, CueGroup group, bool applyTemplateMediaAction, Dispatcher dispatcher)
	{
		dispatcher.Invoke((System.Action)delegate
		{
			slideCue.SlideAction?.Slide.ChangeSize(base.Size);
			group.Cues.AddCue(slideCue);
			if (applyTemplateMediaAction)
			{
				slideCue.ApplyTemplateMediaAction(base.ActiveTemplate);
			}
		});
	}

	public void ClearSlides()
	{
		RemoveCues(base.Cues.ToArray(), canClearAll: true);
	}

	protected override Pro.SerializationInterop.RVProtoData.Presentation.Types.BibleReference? SerializeBibleReference()
	{
		if (!StartReference.IsValid || !EndReference.IsValid)
		{
			return null;
		}
		return new Pro.SerializationInterop.RVProtoData.Presentation.Types.BibleReference
		{
			BookIndex = (uint)StartReference.BookIndex,
			BookKey = (StartReference.BookKey ?? string.Empty),
			BookName = (StartReference.BookName ?? string.Empty),
			ChapterRange = new Pro.SerializationInterop.RVProtoData.IntRange
			{
				Start = StartReference.ChapterNumber,
				End = EndReference.ChapterNumber
			},
			VerseRange = new Pro.SerializationInterop.RVProtoData.IntRange
			{
				Start = StartReference.VerseNumber,
				End = EndReference.VerseNumber
			},
			TranslationDisplayAbbreviation = PrimaryAbbreviation,
			TranslationInternalAbbreviation = PrimaryAbbreviation
		};
	}

	protected override void DeserializeBibleReference(Pro.SerializationInterop.RVProtoData.Presentation.Types.BibleReference protoBibleReference)
	{
		StartReference = protoBibleReference.ToStartReference();
		EndReference = protoBibleReference.ToEndReference();
		_translations = new BibleTranslationCollection();
		_translations.PrimaryTranslation.Abbreviation = protoBibleReference.TranslationInternalAbbreviation;
	}
}
