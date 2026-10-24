using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Dispatcher;
using Pro.Common.FeatureFlag;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Application;
using Pro.DO.Transitions;
using Pro.DO.Triggering;
using Pro.Entity;
using Pro.Entity.Collections;
using Pro.Entity.Extensions;
using Pro.SerializationInterop.RVProtoData;
using Pro.Text;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Cues;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Media;
using ProPresenter.DO.Slide;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Custom.Elements.Shapes;

namespace ProPresenter.DO.Themes;

public class TemplateSlide : NotifyPropertyChangedBase, ICloneable<TemplateSlide>, IIdentifiable, IHasMediaContainerId, ICanReceiveMediaContainerIdUpdates
{
	private readonly IProPresenterDOFactoryProvider _factoryProvider;

	private readonly IFlagService _flagService;

	private string _name = string.Empty;

	private CustomSlide _slide;

	private UndoStack? _undoStack;

	public Guid ID => _slide.ID;

	public string Name
	{
		get
		{
			return _name;
		}
		set
		{
			SetValue("Name", ref _name, value, (System.Action)delegate
			{
				OnDataModified("Name");
			}, (Predicate<string>?)null, referenceComparison: false);
		}
	}

	public CustomSlide Slide
	{
		get
		{
			return _slide;
		}
		[MemberNotNull("_slide")]
		private set
		{
			if (_slide != value)
			{
				if (_slide != null)
				{
					_slide.VisualInvalidated -= OnVisualInvalidated;
					_slide.DataModified -= OnSlideModified;
				}
				_slide = value;
				OnVisualInvalidated();
				OnSlideModified(_slide);
				OnPropertyChanged("Slide");
				_slide.VisualInvalidated += OnVisualInvalidated;
				_slide.DataModified += OnSlideModified;
				_slide.UndoStack = UndoStack;
			}
		}
	}

	public UndoStack? UndoStack
	{
		get
		{
			return _undoStack;
		}
		set
		{
			_undoStack = value;
			Slide.UndoStack = value;
		}
	}

	public Theme? ParentTheme { get; internal set; }

	public ActionCollection Actions { get; }

	public MediaAction? MediaAction => Actions.FirstOrDefaultOf<MediaAction>();

	public bool CopyMediaAssetFilesOnApply => !_flagService.IsFlagEnabled(Flag.Cloud);

	public string ContainerId { get; protected set; } = string.Empty;

	public event Action<string, TemplateSlide>? DataModified;

	public event Action<TemplateSlide>? VisualInvalidated;

	public event System.Action? MediaActionVisualInvalidated;

	public static ObjectBinder<TemplateSlide, ITemplate.Types.ISlide> CreateBinder(IUiScheduler scheduler, IActionBinderFactory actionBinderFactory, TemplateSlide left, ITemplate.Types.ISlide right)
	{
		IEntityFactory entityFactory = left._factoryProvider.EntityFactory;
		ObjectBinder<ActionCollection, IComplexCollection<Pro.Entity.IAction>> actionsBinder = ActionCollection.CreateBinder(scheduler, entityFactory, actionBinderFactory, left.Actions, right.Actions);
		return new ObjectBinder<TemplateSlide, ITemplate.Types.ISlide>(left, right).Bind((TemplateSlide l) => l.WhenPropertyChanges("Name"), (ITemplate.Types.ISlide r) => r.Name.WhenValueChanges, delegate(TemplateSlide l, ITemplate.Types.ISlide r)
		{
			r.Name.Set(l.Name);
		}, delegate(ITemplate.Types.ISlide r, TemplateSlide l)
		{
			l.Name = r.Name.Value;
		}).Bind((TemplateSlide l) => l.WhenPropertyChanges("Slide"), (ITemplate.Types.ISlide r) => r.BaseSlide.WhenValueChanges.ToUnit(), delegate(TemplateSlide l, ITemplate.Types.ISlide r)
		{
			ISlide slide = entityFactory.Create<ISlide>();
			r.BaseSlide.Set(slide);
			ObjectBinder<CustomSlide, ISlide> objectBinder = CustomSlide.CreateBinder(scheduler, l.Slide, slide);
			objectBinder.InitializeRightFromLeft();
			slide.RegisterLinkedDisposable(objectBinder);
		}, delegate(ITemplate.Types.ISlide r, TemplateSlide l)
		{
			ObjectBinder<CustomSlide, ISlide> objectBinder2 = CustomSlide.CreateBinder(scheduler, l.Slide, r.BaseSlide.Value);
			objectBinder2.InitializeLeftFromRight();
			r.BaseSlide.Value.RegisterLinkedDisposable(objectBinder2);
		}, null, scheduler.Scheduler).DoOnInitializeRightFromLeft(actionsBinder.InitializeRightFromLeft)
			.DoOnInitializeLeftFromRight(actionsBinder.InitializeLeftFromRight)
			.RegisterChildDisposable(() => actionsBinder);
	}

	public TemplateSlide(IProPresenterDOFactoryProvider factoryProvider, CustomSlide slide, IFlagService flagService, bool addDefaultShape = false)
		: this(factoryProvider, addDefaultShape, (CustomSlide)slide.Clone(), flagService)
	{
	}

	public TemplateSlide(IProPresenterDOFactoryProvider factoryProvider, ITransitionDescriptionCollection transitionDescriptions, IFlagService flagService, bool addDefaultShape = false)
		: this(factoryProvider, addDefaultShape, new CustomSlide(factoryProvider, transitionDescriptions), flagService)
	{
	}

	private TemplateSlide(IProPresenterDOFactoryProvider factoryProvider, bool addDefaultShape, CustomSlide slide, IFlagService flagService)
	{
		slide.Text?.ForceToDefaultSettings();
		if (addDefaultShape)
		{
			TextShape textShape = new TextShape(factoryProvider, ContainerId);
			textShape.CenterAndScaleIn(slide.Size);
			slide.AddElement(textShape, userInitiated: false);
		}
		_factoryProvider = factoryProvider;
		Slide = slide;
		_flagService = flagService;
		Actions = new ActionCollection();
		Actions.CollectionChanged += Actions_CollectionChanged;
	}

	private void Actions_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		TearDownMediaActions(e.OldItems?.OfType<MediaAction>() ?? Enumerable.Empty<MediaAction>());
		SetupMediaActions(e.NewItems?.OfType<MediaAction>() ?? Enumerable.Empty<MediaAction>());
		SetupSlideBackgroundSampler();
		OnPropertyChanged("MediaAction");
		OnDataModified("Actions");
		Slide.InvalidateVisual();
		OnVisualInvalidated();
		OnMediaActionVisualInvalidated();
	}

	private void TearDownMediaActions(IEnumerable<MediaAction> mediaActions)
	{
		if (mediaActions == null)
		{
			return;
		}
		foreach (MediaAction mediaAction in mediaActions)
		{
			mediaAction.VisualInvalidated -= OnMediaActionVisualInvalidated;
			if (mediaAction.Media is IDrawMedia drawMedia)
			{
				drawMedia.Drawing.PreviewImageUpdated -= Drawing_PreviewImageUpdated;
			}
			mediaAction.DataModified -= Action_DataModified;
		}
	}

	private void SetupMediaActions(IEnumerable<MediaAction> mediaActions)
	{
		if (mediaActions == null)
		{
			return;
		}
		foreach (MediaAction mediaAction in mediaActions)
		{
			mediaAction.VisualInvalidated += OnMediaActionVisualInvalidated;
			if (mediaAction.Media is IDrawMedia drawMedia)
			{
				drawMedia.Drawing.PreviewImageUpdated += Drawing_PreviewImageUpdated;
			}
			mediaAction.DataModified += Action_DataModified;
		}
	}

	private void OnMediaActionVisualInvalidated()
	{
		OnVisualInvalidated();
		this.MediaActionVisualInvalidated?.Invoke();
	}

	private void Action_DataModified()
	{
		OnDataModified("MediaAction");
	}

	private void SetupSlideBackgroundSampler()
	{
		VisualMedia media = Actions.GetPreviewMedia() as VisualMedia;
		Slide.SetupBackgroundMedia(media);
	}

	private void Drawing_PreviewImageUpdated()
	{
		Slide.InvalidateVisual();
		OnVisualInvalidated();
	}

	private void OnVisualInvalidated()
	{
		this.VisualInvalidated?.Invoke(this);
	}

	private void OnSlideModified(SlideBase slide)
	{
		OnDataModified("Slide");
	}

	public TemplateSlide Clone()
	{
		TemplateSlide templateSlide = new TemplateSlide(_factoryProvider, Slide, _flagService)
		{
			_name = _name
		};
		foreach (Pro.DO.Triggering.IAction item in Actions.Select((Pro.DO.Triggering.IAction x) => x.Clone()))
		{
			templateSlide.Actions.Add(item);
		}
		return templateSlide;
	}

	public TemplateSlide CloneWithID()
	{
		TemplateSlide templateSlide = Clone();
		templateSlide.Slide = Slide.Clone(null, preserveID: true);
		return templateSlide;
	}

	public Template.Types.Slide Serialize()
	{
		Template.Types.Slide slide = new Template.Types.Slide();
		slide.BaseSlide = Slide.Serialize().BaseSlide;
		slide.Name = Name;
		slide.Actions.AddRange(Actions.Select((Pro.DO.Triggering.IAction a) => a.Serialize()));
		return slide;
	}

	public void Deserialize(Template.Types.Slide protoTemplateSlide, ApplicationData? applicationData, string containerId)
	{
		if (protoTemplateSlide != null)
		{
			_name = protoTemplateSlide.Name;
			Slide.DeserializeSlide(protoTemplateSlide.BaseSlide, applicationData, containerId, null);
			Actions.Deserialize(protoTemplateSlide.Actions, applicationData, containerId);
			if (applicationData != null && applicationData.ApplicationVersion < new System.Version("7.7"))
			{
				MigrateTextAttributes();
			}
		}
	}

	private void MigrateTextAttributes()
	{
		foreach (TextDocument element in (from p in Slide.Elements.OfType<ClosedBezierPath>()
			select p.Text).NotNull())
		{
			element.IterateParagraphs(Pro.Text.Range.All, delegate(Paragraph p)
			{
				p.AssignSettings(element.Attributes.ParagraphSettings);
			});
			element.IterateRuns(Pro.Text.Range.All, splitRuns: false, delegate(RunBase r)
			{
				r.AssignSettings(element.Attributes.RunSettings);
			});
		}
	}

	private void OnDataModified(string propName)
	{
		this.DataModified?.Invoke(propName, this);
	}

	public void UpdateContainerId(string containerId)
	{
		ContainerId = containerId;
		Actions.UpdateContainerId(containerId);
		Slide.UpdateContainerId(containerId);
	}
}
