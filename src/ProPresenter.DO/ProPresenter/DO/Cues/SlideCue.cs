using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.ObjectBinding;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.DO.Reversibility;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using Pro.DO.Triggering.CompletionTargets;
using Pro.Editor;
using Pro.Entity;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Hotkey;
using ProPresenter.DO.Media;
using ProPresenter.DO.Media.Properties.File;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Slide;
using ProPresenter.DO.Slide.Builds;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Custom.Elements.Fills;
using ProPresenter.DO.Slide.Custom.Elements.Shapes;

namespace ProPresenter.DO.Cues;

public class SlideCue : ProPresenterCue, ICloneable<SlideCue>, ITimelineSlideItem, ITimelineItem, ITriggerable, INotifyPropertyChanged, IActionRepository, IHasMediaContainerId
{
	private readonly IProPresenterDOFactoryProvider _factoryProvider;

	private readonly IActionGateway _actionGateway;

	private GotoNext? _gotoNext;

	private bool _slideActionAdded;

	private bool _isValid = true;

	private bool _validityUpdateInProgress;

	public TimelineItemType TimelineItemType => TimelineItemType.Slide;

	string ITimelineItem.Name => SlideAction?.Label?.Text ?? string.Empty;

	public string GroupName => ParentPresentation?.DefaultArrangement?.FirstOrDefault((CueGroup g) => g?.Cues.Any((SlideCue c) => c.ID == base.ID) ?? false)?.Label?.Text ?? string.Empty;

	public System.Windows.Media.Color? GroupColor => ParentPresentation?.DefaultArrangement?.FirstOrDefault((CueGroup g) => g?.Cues.Any((SlideCue c) => c.ID == base.ID) ?? false)?.Label?.Color;

	public override CueType Type => CueType.Slide;

	IEnumerable<Pro.DO.Triggering.IAction> IActionRepository.Actions => base.Actions;

	public SlideAction? SlideAction => base.Actions.FirstOrDefaultOf<SlideAction>();

	public ProPresenter.DO.Presentation.IPresentation? ParentPresentation { get; private set; }

	public GotoNext? GotoNext
	{
		get
		{
			return _gotoNext;
		}
		set
		{
			SetValue<GotoNext>("GotoNext", ref _gotoNext, value, delegate(GotoNext o, GotoNext n)
			{
				UndoStack?.Commit(new TaggedUndoAction<Pro.DO.Reversibility.UndoActionTypes>(Pro.DO.Reversibility.UndoActionTypes.AddAction), this, "GotoNext", o, n);
				if (o != null)
				{
					o.PropertyChanged -= GotoNext_PropertyChanged;
				}
				if (n != null)
				{
					n.PropertyChanged += GotoNext_PropertyChanged;
				}
				UpdateFromGotoNext(n);
			});
		}
	}

	public bool IsValid
	{
		get
		{
			return _isValid;
		}
		private set
		{
			SetValue("IsValid", ref _isValid, value);
		}
	}

	public event System.Action? SlideTimeChanged;

	public event System.Action? MediaActionVisualInvalidated;

	public override IReadOnlyObjectBinder<ProPresenterCue, IPlaylistItem> Bind(IUiScheduler scheduler, IEntityFactory entityFactory, IActionBinderFactory actionBinderFactory, IPlaylistItem right)
	{
		throw new NotSupportedException();
	}

	public ObjectBinder<SlideCue, IStage.Types.ILayout> Bind(IUiScheduler scheduler, IProPresenterDOFactoryProvider factoryProvider, IStage.Types.ILayout entity)
	{
		ObjectBinder<SlideCue, IStage.Types.ILayout> objectBinder = new ObjectBinder<SlideCue, IStage.Types.ILayout>(this, entity);
		objectBinder.Bind((SlideCue l) => l.WhenPropertyChanges("ID"), (IStage.Types.ILayout r) => r.Uuid.WhenValueChanges, delegate(SlideCue l, IStage.Types.ILayout r)
		{
			r.Uuid.Set(l.ID);
		}, delegate(IStage.Types.ILayout r, SlideCue l)
		{
			l.ID = r.Uuid.Value;
		}).Bind((SlideCue l) => l.WhenPropertyChanges("Name"), (IStage.Types.ILayout r) => r.Name.WhenValueChanges, delegate(SlideCue l, IStage.Types.ILayout r)
		{
			r.Name.Set(l.Name);
		}, delegate(IStage.Types.ILayout r, SlideCue l)
		{
			l.Name = r.Name.Value;
		}).Bind((SlideCue l) => l.WhenPropertyChanges("SlideAction"), (IStage.Types.ILayout r) => r.Slide.WhenValueChanges.ToUnit(), delegate(SlideCue l, IStage.Types.ILayout r)
		{
			if (l.SlideAction != null)
			{
				ISlide slide = factoryProvider.EntityFactory.Create<ISlide>();
				r.Slide.Set(slide);
				ObjectBinder<CustomSlide, ISlide> objectBinder2 = CustomSlide.CreateBinder(scheduler, (CustomSlide)SlideAction.Slide, slide);
				objectBinder2.InitializeRightFromLeft();
				slide.RegisterLinkedDisposable(objectBinder2);
			}
		}, delegate(IStage.Types.ILayout r, SlideCue l)
		{
			ObjectBinder<CustomSlide, ISlide> objectBinder3 = CustomSlide.CreateBinder(scheduler, (CustomSlide)SlideAction.Slide, r.Slide.Value);
			objectBinder3.InitializeLeftFromRight();
			r.Slide.Value.RegisterLinkedDisposable(objectBinder3);
		});
		return objectBinder;
	}

	public SlideCue(IProPresenterDOFactoryProvider factoryProvider, SlideAction action)
		: this(factoryProvider)
	{
		base.ContainerId = action.ContainerId;
		base.Actions.UpdateContainerId(base.ContainerId);
		AddAction(action);
	}

	public SlideCue(IProPresenterDOFactoryProvider factoryProvider, SlideBase slide, ITransitionDescriptionCollection transitionDescriptions)
		: this(factoryProvider, new SlideAction(slide, transitionDescriptions, null))
	{
	}

	public SlideCue(IProPresenterDOFactoryProvider factoryProvider, IActionGateway? actionGateway = null)
	{
		_factoryProvider = factoryProvider;
		_actionGateway = actionGateway ?? new ActionGateway(base.Actions);
		base.Actions.CollectionChanged += Actions_CollectionChanged;
		LinkAction(new global::_003C_003Ez__ReadOnlyArray<string>(new string[3] { "Start", "Delay", "SelectedTransition" }), OnSlideTimeChanged);
		LinkAction(new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "IsValid", "IsValid" }), UpdateValidity);
		LinkAction("TriggerLayer", delegate
		{
			SlideAction?.Slide?.InvalidateVisual();
			OnSlideTimeChanged();
		});
		LinkProperties(new global::_003C_003Ez__ReadOnlySingleElementList<string>("Label"), "Name");
		LinkAction("Label", delegate
		{
			OnPropertyChanged("GroupName");
			OnPropertyChanged("GroupColor");
		});
		SetupSlideMediaSampler();
	}

	protected override void OnIsEnabledChanged(bool oldValue, bool newValue)
	{
		OnSlideTimeChanged();
	}

	private void Builds_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.OfType<IBuild>().ForEach(delegate(IBuild b)
		{
			b.PropertyChanged -= base.RaiseLinkedValues;
		});
		e.NewItems?.OfType<IBuild>().ForEach(delegate(IBuild b)
		{
			b.PropertyChanged += base.RaiseLinkedValues;
		});
		OnSlideTimeChanged();
	}

	private void Actions_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.NewItems?.OfType<ICanReceiveMediaContainerIdUpdates>().ForEach(delegate(ICanReceiveMediaContainerIdUpdates a)
		{
			a.UpdateContainerId(base.ContainerId);
		});
		MediaAction mediaAction = e.OldItems?.OfType<MediaAction>().FirstOrDefault((MediaAction a) => a.Media.MediaType.IsAnyOf(MediaType.Image, MediaType.Video, MediaType.LiveVideo));
		if (mediaAction != null)
		{
			mediaAction.PropertyChanged -= base.RaiseLinkedValues;
			mediaAction.VisualInvalidated -= OnMediaActionVisualInvalidated;
		}
		MediaAction mediaAction2 = e.NewItems?.OfType<MediaAction>().FirstOrDefault((MediaAction a) => a.Media.MediaType.IsAnyOf(MediaType.Image, MediaType.Video, MediaType.LiveVideo));
		if (mediaAction2 != null)
		{
			mediaAction2.PropertyChanged += base.RaiseLinkedValues;
			mediaAction2.VisualInvalidated += OnMediaActionVisualInvalidated;
		}
		if (mediaAction != null || mediaAction2 != null)
		{
			OnSlideTimeChanged();
		}
		SlideAction slideAction = e.NewItems?.FirstOrDefaultOf<SlideAction>();
		if (!_slideActionAdded && slideAction?.Slide is CustomSlide customSlide)
		{
			customSlide.Builds.CollectionChanged += Builds_CollectionChanged;
			customSlide.Builds.ForEach(delegate(IBuild b)
			{
				b.PropertyChanged += base.RaiseLinkedValues;
			});
			_slideActionAdded = true;
		}
		if (slideAction != null)
		{
			slideAction.PropertyChanged += base.RaiseLinkedValues;
		}
		if (mediaAction != null || mediaAction2 != null)
		{
			OnMediaActionVisualInvalidated();
		}
		SlideAction?.Slide?.InvalidateVisual();
	}

	private void OnMediaActionVisualInvalidated()
	{
		SetupSlideMediaSampler();
		this.MediaActionVisualInvalidated?.Invoke();
	}

	SlideCue ICloneable<SlideCue>.Clone()
	{
		return (SlideCue)Clone();
	}

	private void SetupSlideMediaSampler()
	{
		if (SlideAction?.Slide is CustomSlide customSlide)
		{
			VisualMedia visualMedia = this.GetPreviewMedia() as VisualMedia;
			customSlide.SetupBackgroundMedia(visualMedia);
			customSlide.InvalidateVisual();
			IDrawMedia drawMedia = visualMedia;
			if (drawMedia != null)
			{
				drawMedia.Drawing.PreviewImageUpdated += Drawing_PreviewImageUpdated;
			}
		}
	}

	protected override void OnDeserialize(Pro.SerializationInterop.RVProtoData.Cue data)
	{
		base.OnDeserialize(data);
		RemoveActions(base.Actions.OfType<StageAction>().Skip(1).ToArray());
		CheckStageActionSlideTarget(data);
		RemoveActions(base.Actions.OfType<AudienceLookAction>().Skip(1).ToArray());
		RemoveActions(base.Actions.OfType<SlideAction>().Skip(1).ToArray());
		VisualMedia visualMedia = base.Actions.FirstOrDefaultOf((MediaAction m) => m.Media is VisualMedia)?.VisualMedia;
		if (visualMedia?.Drawing.PreviewImage != null)
		{
			SetupSlideMediaSampler();
		}
		else if (visualMedia != null)
		{
			visualMedia.MetadataLoadSuccessful += Media_MetadataLoadSuccessful;
		}
		CompletionTargetBase completionTarget = base.CompletionTarget;
		if (completionTarget == null || completionTarget.Type != 0)
		{
			TimeSlice completionTime = base.CompletionTime;
			CompletionTargetBase completionTarget2 = base.CompletionTarget;
			_gotoNext = new GotoNext(completionTime, completionTarget2 != null && completionTarget2.Type == CompletionTargetType.First);
		}
	}

	private void CheckStageActionSlideTarget(Pro.SerializationInterop.RVProtoData.Cue data)
	{
		Pro.SerializationInterop.RVProtoData.Action action = data.Actions.FirstOrDefault((Pro.SerializationInterop.RVProtoData.Action a) => a.ActionTypeDataCase == Pro.SerializationInterop.RVProtoData.Action.ActionTypeDataOneofCase.Stage);
		if (action?.Stage != null && action.Stage.SlideTarget != 0)
		{
			AddAction(action.Stage.SlideTarget.ToAction());
		}
	}

	private void Media_MetadataLoadSuccessful(FileMediaBase media)
	{
		media.MetadataLoadSuccessful -= Media_MetadataLoadSuccessful;
		SetupSlideMediaSampler();
	}

	protected override void DeserializeHotkey(Key? key)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		if (key.HasValue)
		{
			base.Hotkey = new SlideHotkey(key.Value);
		}
	}

	public override Pro.DO.Triggering.Cue Clone()
	{
		Pro.DO.Triggering.Cue cue = CopyProperties(new SlideCue(_factoryProvider));
		if (GotoNext != null && cue is SlideCue slideCue)
		{
			slideCue.GotoNext = GotoNext.Clone();
		}
		return cue;
	}

	protected override void OnInsertAction(bool userInitiated, Pro.DO.Triggering.IAction action, bool addMediaReferences = false)
	{
		if (action is ICanReceiveMediaContainerIdUpdates canReceiveMediaContainerIdUpdates)
		{
			canReceiveMediaContainerIdUpdates.UpdateContainerId(base.ContainerId);
		}
		if (action is MediaAction mediaAction)
		{
			bool flag = mediaAction.Media is IFileMedia fileMedia && fileMedia.File.RemoteProperties is ProContentFileProperties;
			if (mediaAction.Media is ITrackedMedia trackedMedia && (addMediaReferences || flag))
			{
				trackedMedia.AddToMediaServiceAndApplyTransform(userInitiated);
			}
			if (mediaAction.IsAudioMedia && mediaAction.Media is FileMediaBase { MetadataLoaded: false } fileMediaBase)
			{
				fileMediaBase.MetadataLoadSuccessful += media_MetadataLoadSuccessful;
			}
			else
			{
				handleIncoming();
			}
			if (mediaAction.IsGraphicMedia)
			{
				SetupSlideMediaSampler();
			}
		}
		else
		{
			handleIncoming();
		}
		void handleIncoming()
		{
			_actionGateway.HandleIncoming(action, out IEnumerable<Pro.DO.Triggering.IAction> replacements);
			RemoveActions(replacements);
		}
		void media_MetadataLoadSuccessful(FileMediaBase media)
		{
			media.MetadataLoadSuccessful -= media_MetadataLoadSuccessful;
			handleIncoming();
		}
	}

	protected override void OnRemoveAction(Pro.DO.Triggering.IAction action)
	{
		_actionGateway.HandleOutgoing(action);
		((action is MediaAction mediaAction) ? (mediaAction.Media as ITrackedMedia) : null)?.RemoveFromMediaService(deleteAssets: false);
	}

	private void OnDefaultArrangementCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.OfType<CueGroup>().ForEach(delegate(CueGroup g)
		{
			g.PropertyChanged -= base.RaiseLinkedValues;
		});
		e.NewItems?.OfType<CueGroup>().ForEach(delegate(CueGroup g)
		{
			g.PropertyChanged += base.RaiseLinkedValues;
		});
		OnPropertyChanged("GroupName");
		OnPropertyChanged("GroupColor");
	}

	private void SetupTimelineGroup(ProPresenter.DO.Presentation.IPresentation? oldPresentation, ProPresenter.DO.Presentation.IPresentation newPresentation)
	{
		if (oldPresentation != null)
		{
			oldPresentation.DefaultArrangement.CollectionChanged -= OnDefaultArrangementCollectionChanged;
			oldPresentation.DefaultArrangement.ForEach(delegate(CueGroup g)
			{
				g.PropertyChanged -= base.RaiseLinkedValues;
			});
		}
		newPresentation.DefaultArrangement.CollectionChanged += OnDefaultArrangementCollectionChanged;
		newPresentation.DefaultArrangement.ForEach(delegate(CueGroup g)
		{
			g.PropertyChanged += base.RaiseLinkedValues;
		});
		OnPropertyChanged("GroupName");
		OnPropertyChanged("GroupColor");
	}

	public void SetParentPresentation(ProPresenter.DO.Presentation.IPresentation newParent)
	{
		SetupTimelineGroup(ParentPresentation, newParent);
		if (ParentPresentation != null)
		{
			throw new InvalidOperationException("A slide cue may only be part of a single presentation at a time");
		}
		ParentPresentation = newParent;
		if (SlideAction != null && SlideAction.Slide != null)
		{
			SlideAction.Slide.UndoStack = newParent.UndoStack;
			SlideAction.Slide.BacklightSampler = delegate
			{
				ProPresenter.DO.Presentation.IPresentation? parentPresentation = ParentPresentation;
				return (parentPresentation == null || !parentPresentation.UseBackgroundColor) ? Colors.Black : ParentPresentation.BackgroundColor;
			};
		}
		ParentPresentation.PropertyChanged += ParentPresentation_PropertyChanged;
		UpdateContainerId(newParent.ContainerId);
	}

	private void ParentPresentation_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		string propertyName = e.PropertyName;
		if (propertyName == "BackgroundColor" || propertyName == "UseBackgroundColor")
		{
			SlideAction?.Slide?.InvalidateVisual();
		}
	}

	public void ClearParentPresentation()
	{
		if (ParentPresentation != null)
		{
			ParentPresentation.PropertyChanged -= ParentPresentation_PropertyChanged;
			ParentPresentation = null;
		}
	}

	public void ConvertMediaActionToSlideElement()
	{
		UndoStack?.BeginCommit(UndoActionTypes.ConvertMediaToElement.ToAction());
		MediaAction mediaAction = base.Actions.FirstOrDefaultOf(delegate(MediaAction m)
		{
			MediaType mediaType = m.Media.MediaType;
			bool flag = (uint)(mediaType - 2) <= 1u;
			return !flag;
		});
		if (AddMediaElement(mediaAction?.VisualMedia?.Clone(), userInitiated: true))
		{
			RemoveAction(mediaAction);
			SetupSlideMediaSampler();
		}
		UndoStack?.EndCommit(null, null, autoFinalize: true);
	}

	public bool AddMediaElement([NotNullWhen(true)] MediaBase? media, bool userInitiated)
	{
		if (!(media is VisualMedia visualMedia) || !visualMedia.SourceFile.IsValid || !(SlideAction?.Slide is CustomSlide customSlide))
		{
			return false;
		}
		RectangleShape rectangleShape = new RectangleShape(_factoryProvider, base.ContainerId)
		{
			Size = customSlide.Size,
			Fill = new MediaFill(_factoryProvider.MediaFactory, base.ContainerId)
			{
				Media = visualMedia
			}
		};
		customSlide.AddElement(rectangleShape, userInitiated);
		ElementOrdonnance.ChangeElementZOrder(customSlide.Elements, new global::_003C_003Ez__ReadOnlySingleElementList<ICanvasElement>(rectangleShape), ZOrderDirection.Back);
		if (media is IDrawMedia drawMedia)
		{
			drawMedia.Drawing.PreviewImageUpdated -= Drawing_PreviewImageUpdated;
		}
		SetupSlideMediaSampler();
		return true;
	}

	protected override bool CanRemoveAction(Pro.DO.Triggering.IAction action)
	{
		if (action.ActionType == ActionType.Slide)
		{
			if (action.ActionType == ActionType.Slide)
			{
				return base.Actions.OfType<SlideAction>().ToArray().Length > 1;
			}
			return false;
		}
		return true;
	}

	private void GotoNext_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		UpdateFromGotoNext(GotoNext);
	}

	private void UpdateFromGotoNext(GotoNext? gotoNext)
	{
		base.CompletionTime = gotoNext?.Time ?? TimeSlice.Zero;
		if (gotoNext != null)
		{
			base.CompletionAction = CompletionAction.AfterTime;
			base.CompletionTarget = (gotoNext.LoopToBeginning ? ((CompletionTargetBase)new FirstTarget()) : ((CompletionTargetBase)new NextTarget()));
		}
		else
		{
			base.CompletionTarget = new NoTarget();
			base.CompletionAction = CompletionAction.Last;
		}
		OnSlideTimeChanged();
	}

	private void Drawing_PreviewImageUpdated()
	{
		if (SlideAction?.Slide is CustomSlide customSlide)
		{
			customSlide.InvalidateVisual();
		}
	}

	public bool CanAddAction(object data)
	{
		return _actionGateway.CanAddAction(data);
	}

	public bool CanReplace(object data)
	{
		return true;
	}

	private void OnSlideTimeChanged()
	{
		this.SlideTimeChanged?.Invoke();
	}

	public double GetSlideDuration(double fallbackGtnDuration = 0.0)
	{
		double num = GotoNext?.Time.TotalSeconds ?? fallbackGtnDuration;
		double num2 = (base.Actions.OfType<MediaAction>().FirstOrDefault((MediaAction m) => m.TriggerLayer == TriggerLayer.Foreground)?.MediaDuration.TotalSeconds ?? 0.0) + num;
		double num3 = 0.0;
		if (SlideAction?.Slide is CustomSlide customSlide && customSlide.Builds.Any())
		{
			bool flag = true;
			foreach (IBuild build in customSlide.Builds)
			{
				double buildDuration = build.GetBuildDuration();
				switch (build.Start)
				{
				case StartMode.WithPrevious:
				case StartMode.WithSlide:
					if (!flag && buildDuration > num3)
					{
						num2 -= num3;
						num2 += buildDuration;
						num3 = buildDuration;
					}
					break;
				case StartMode.OnClick:
					num3 = buildDuration;
					buildDuration += num;
					num2 += buildDuration;
					flag = false;
					break;
				case StartMode.AfterPrevious:
					if (!flag)
					{
						num2 += buildDuration;
						num3 = buildDuration;
					}
					break;
				}
			}
		}
		return num2;
	}

	public void UpdateValidity()
	{
		if (!_validityUpdateInProgress)
		{
			_validityUpdateInProgress = true;
			SlideAction?.UpdateValidity();
			IsValid = (from a in base.Actions.OfType<MediaAction>()
				select a.Media).All(isValid);
			_validityUpdateInProgress = false;
		}
		static bool isValid(MediaBase media)
		{
			media.UpdateValidity();
			return media.IsValid;
		}
	}

	public bool CanAssign(object data, Pro.DO.Triggering.IAction? action)
	{
		return this.CanAssignData(data, action);
	}

	public IReadOnlyList<ITrackedMedia> GetTrackedMedia()
	{
		return (from x in base.Actions.OfType<MediaAction>()
			select x.Media).OfType<ITrackedMedia>().Concat(GetTrackedMediaFromElements()).ToArray();
	}

	public IReadOnlyList<ITrackedMedia> GetTrackedMediaFromElements()
	{
		if (SlideAction?.Slide is CustomSlide customSlide)
		{
			return CustomSlide.GetTrackedMediaFromElements(customSlide.Elements);
		}
		return Array.Empty<ITrackedMedia>();
	}

	bool ITimelineItem.get_IsEnabled()
	{
		return base.IsEnabled;
	}

	void IActionRepository.AddAction(Pro.DO.Triggering.IAction action, bool addMediaReferences = false)
	{
		AddAction(action, addMediaReferences);
	}

	void IActionRepository.RemoveAction(Pro.DO.Triggering.IAction action)
	{
		RemoveAction(action);
	}

	void IActionRepository.RemoveActions(IEnumerable<Pro.DO.Triggering.IAction> actions)
	{
		RemoveActions(actions);
	}

	void IActionRepository.InsertActions(IEnumerable<Pro.DO.Triggering.IAction> actions, int index, bool addMediaReferences = false)
	{
		InsertActions(actions, index, addMediaReferences);
	}
}
