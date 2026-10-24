using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using Pro.Common.Collections;
using Pro.Common.Components;
using Pro.Common.FeatureFlag;
using Pro.Common.FileSystem;
using Pro.Common.Mathematics;
using Pro.Common.Nullability;
using Pro.Common.Time;
using Pro.Common.Time.Timer;
using Pro.Common.Utility;
using Pro.DO.Label;
using Pro.DO.Storage;
using Pro.DO.Transitions;
using Pro.Editor;
using Pro.Editor.Canvas;
using Pro.Editor.Canvas.Snapping.Lines;
using Pro.Localization;
using Pro.Text;
using Pro.UI.Components;
using Pro.UI.DialogService;
using Pro.UI.Themes;
using Pro.ssAPI;
using ProPresenter.Controller;
using ProPresenter.Controller.Outputs;
using ProPresenter.DO;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Analytics;
using ProPresenter.DO.Analytics.Events.TrackedEvents;
using ProPresenter.DO.Analytics.Events.TrackedEvents.EditorToolbar;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.DependencyInjection;
using ProPresenter.DO.Import;
using ProPresenter.DO.Import.Requests;
using ProPresenter.DO.Media;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Custom.Elements.Fills;
using ProPresenter.DO.Slide.Custom.Elements.Shapes;
using ProPresenter.DO.Slide.Custom.Elements.Strokes;
using ProPresenter.DO.Slide.Links;
using ProPresenter.DO.Slide.Links.Text.Slide;
using ProPresenter.DO.Themes;
using ProPresenter.DO.Timer;
using ProPresenter.UI.Commands;
using ProPresenter.UI.SlideEditor;
using ProPresenter.UI.SlideEditor.Pens;
using ProPresenter.UI.Thumbnails;
using ProPresenter.UI.ViewModels;
using ProPresenter.UI.ViewModels.Editor;
using ProPresenter.UI.ViewModels.MediaLibrary;
using ProPresenter.ViewModels.Props;

namespace ProPresenter.ViewModels.Editor;

public abstract class SlideEditorVM : LinkedNotifyPropertyChangedBase, ISlideEditorVM, INotifyPropertyChanged
{
	private const double DefaultNewShapeSize = 180.0;

	private readonly IImportProcessFactory _importProcessFactory;

	private readonly IAdvanced _advancedSettings;

	private readonly ObservableCollection<CustomSlide> _selectedSlides = new ObservableCollection<CustomSlide>();

	private CustomSlide? _selectedSlide;

	private EditMode _editMode;

	private IPenTool? _activePen;

	private InspectorTab _selectedDocumentTab = InspectorTab.Document;

	private InspectorTab _selectedPropTab = InspectorTab.PropSlide;

	private InspectorTab _selectedTemplateTab = InspectorTab.Template;

	private InspectorTab _selectedShapeTab = InspectorTab.Shape;

	private double _zoomFactor = EditorPreferences.Settings.ZoomFactor;

	private bool _ignoreSelectionChanges;

	private string _penHelperText = string.Empty;

	private static readonly double[] _fixedZoomFactors = new double[7] { 0.25, 0.5, 0.75, 1.0, 1.25, 1.5, 2.0 };

	private bool _isCustomZoomInput;

	private bool _isNotesInspectorVisible;

	private Vector2<double>? _mediaElementPosition;

	private BitmapSource? _backgroundImage;

	private BitmapSource? _videoInputThumbnailImage;

	private ProPresenter.UI.ViewModels.Editor.InsertEditorObjectSourceType _insertionSource;

	protected IApp App { get; }

	protected ITimerFactory TimerFactory { get; }

	protected IProPresenterDOFactoryProvider FactoryProvider { get; }

	protected ITransitionDescriptionCollection TransitionDescriptions { get; }

	protected IMessageDialogService MessageDialogService { get; }

	protected ICurrentTime CurrentTime { get; }

	protected IEditorService EditorService { get; }

	protected IMediaFactory MediaFactory { get; }

	protected IFlagService FlagService { get; }

	public ObservableCollection<CustomSlide> Slides { get; } = new ObservableCollection<CustomSlide>();

	public CustomSlide? SelectedSlide
	{
		get
		{
			return _selectedSlide;
		}
		private set
		{
			SetValue<CustomSlide>("SelectedSlide", ref _selectedSlide, value, delegate(CustomSlide o, CustomSlide n)
			{
				if (o != null)
				{
					o.PropertyChanged -= base.RaiseLinkedValues;
				}
				if (n != null)
				{
					n.PropertyChanged += base.RaiseLinkedValues;
				}
				ShapeInspectorVM.SelectedSlide = n;
				TextInspectorVM.SelectedSlide = n;
				SlideInspectorVM.SelectedSlide = n;
				BuildInspectorVM.SelectedSlide = n;
				TextLinkVM.SelectedSlide = n;
				BuildInspectorVM.Builds = n?.Builds;
				OnSelectedSlideChanged(o, n);
			});
		}
	}

	public ImmutableObservableCollection<CustomSlide> SelectedSlides => _selectedSlides.ConvertImmutable();

	public IEnumerable<CustomSlide> OrderedSelectedSlides => _selectedSlides.OrderBy((CustomSlide s) => Slides.IndexOf(s));

	public ssAPIOutput OutputController => EditorService.OutputController;

	private static EditorPreferences Settings => EditorPreferences.Settings;

	public EditMode EditMode
	{
		get
		{
			return _editMode;
		}
		set
		{
			SetValue("EditMode", ref _editMode, value, delegate(EditMode o, EditMode n)
			{
				ShapeInspectorVM.EditMode = n;
				TextInspectorVM.EditMode = n;
				TextLinkVM.EditMode = n;
				PasteStrategy.EditMode = n;
				TemplateSlideInspectorVM.EditMode = n;
				BuildInspectorVM.EditMode = n;
				OnPropertyChanged("AvailableInspectorTabs");
				OnPropertyChanged("SelectedInspectorTab");
				OnPropertyChanged("IsTemplateEditMode");
				OnPropertyChanged("IsSlideEditMode");
				OnPropertyChanged("CanShowSlideNotes");
				OnPropertyChanged("ShowFullAddMenu");
				OnPropertyChanged("ShowCheckerboard");
			});
		}
	}

	public abstract CommandTargetType CommandTargetType { get; }

	public ObservableCollection<SlideElementBase> SelectedSlideElements => SelectedCanvasElements.ConvertTwoWay<SlideElementBase, ICanvasElement>();

	public ObservableCollection<ICanvasElement> SelectedCanvasElements { get; } = new ObservableCollection<ICanvasElement>();

	public Color SlidesGuidesColor
	{
		get
		{
			return Settings.SlideGuidelineColor;
		}
		set
		{
			Settings.SlideGuidelineColor = value;
		}
	}

	public Color TemplateGuidesColor
	{
		get
		{
			return Settings.TemplateGuidelineColor;
		}
		set
		{
			Settings.TemplateGuidelineColor = value;
		}
	}

	public Color AlignmentGuidesColor
	{
		get
		{
			return Settings.AlignmentGuidelineColor;
		}
		set
		{
			Settings.AlignmentGuidelineColor = value;
		}
	}

	protected virtual Color PrimaryBackgroundColor => System.Windows.Media.Colors.Transparent;

	protected virtual Color SecondaryBackgroundColor => System.Windows.Media.Colors.Transparent;

	protected virtual Color TertiaryBackgroundColor => System.Windows.Media.Colors.Transparent;

	public Color CanvasGridColor
	{
		get
		{
			return Settings.CanvasGridColor;
		}
		set
		{
			Settings.CanvasGridColor = value;
		}
	}

	public Color SlideNoteBackground
	{
		get
		{
			return Settings.SlideNoteBackground;
		}
		set
		{
			Settings.SlideNoteBackground = value;
		}
	}

	public bool ShowSlideNotesRuler
	{
		get
		{
			return Settings.ShowSlideNotesRuler;
		}
		set
		{
			Settings.ShowSlideNotesRuler = value;
		}
	}

	public abstract bool UsePrimaryBackground { get; set; }

	public abstract bool UseSecondaryBackground { get; set; }

	public bool ShowCanvasGrid
	{
		get
		{
			return Settings.ShowCanvasGrid;
		}
		set
		{
			Settings.ShowCanvasGrid = value;
		}
	}

	public Color Background
	{
		get
		{
			if (!UsePrimaryBackground)
			{
				return SecondaryBackground;
			}
			return PrimaryBackgroundColor;
		}
	}

	public Color SecondaryBackground
	{
		get
		{
			if (!UseSecondaryBackground)
			{
				return TertiaryBackgroundColor;
			}
			return SecondaryBackgroundColor;
		}
	}

	public bool ShowFullAddMenu => EditMode != EditMode.Mask;

	public bool IsLocked => SelectedCanvasElements.Any((ICanvasElement e) => e.IsLocked);

	public bool IsHidden => SelectedCanvasElements.Any((ICanvasElement e) => e.IsHidden);

	public bool IsScaleToFitActive
	{
		get
		{
			return Settings.ScaleToFit;
		}
		set
		{
			Settings.ScaleToFit = value;
		}
	}

	public bool ShowSlidesGuides
	{
		get
		{
			return Settings.ShowSlideGuidelines;
		}
		set
		{
			Settings.ShowSlideGuidelines = value;
		}
	}

	public bool ShowTemplateGuides
	{
		get
		{
			return Settings.ShowTemplateGuidelines;
		}
		set
		{
			Settings.ShowTemplateGuidelines = value;
		}
	}

	public bool ShowRelativeSpacing
	{
		get
		{
			return Settings.ShowRelativeSpacingGuidelines;
		}
		set
		{
			Settings.ShowRelativeSpacingGuidelines = value;
		}
	}

	public bool ShowRelativeSizing
	{
		get
		{
			return Settings.ShowRelativeSizingGuidelines;
		}
		set
		{
			Settings.ShowRelativeSizingGuidelines = value;
		}
	}

	public bool ShowCenterGuides
	{
		get
		{
			return Settings.ShowCenterAlignmentGuidelines;
		}
		set
		{
			Settings.ShowCenterAlignmentGuidelines = value;
		}
	}

	public bool ShowEdgeGuides
	{
		get
		{
			return Settings.ShowEdgeAlignmentGuidelines;
		}
		set
		{
			Settings.ShowEdgeAlignmentGuidelines = value;
		}
	}

	public bool GuidelinesEnabled
	{
		get
		{
			if (!ShowSlidesGuides && !ShowTemplateGuides && !ShowRelativeSpacing && !ShowRelativeSizing && !ShowCenterGuides)
			{
				return ShowEdgeGuides;
			}
			return true;
		}
	}

	public bool IsRulerVisible
	{
		get
		{
			return Settings.ShowRuler;
		}
		set
		{
			Settings.ShowRuler = value;
		}
	}

	public double ZoomFactor
	{
		get
		{
			return _zoomFactor;
		}
		set
		{
			SetValue("ZoomFactor", ref _zoomFactor, value, delegate(double o, double n)
			{
				Settings.ZoomFactor = n;
				UpdateSortedZoomFactors();
				IsCustomZoomInput = false;
			});
		}
	}

	public double CanvasGridSpacing
	{
		get
		{
			return Settings.CanvasGridSpacing;
		}
		set
		{
			Settings.CanvasGridSpacing = value;
		}
	}

	public int CanvasGridSubdivisions
	{
		get
		{
			return Settings.CanvasGridSubdivisions;
		}
		set
		{
			Settings.CanvasGridSubdivisions = value;
		}
	}

	public bool ShowCheckerboard
	{
		get
		{
			bool value;
			return Settings.ShowCheckerboard.TryGetValue(EditMode, out value) && value;
		}
		set
		{
			Settings.ShowCheckerboard[EditMode] = value;
		}
	}

	public bool SlideNotesVisible
	{
		get
		{
			return Layout.Settings.SlideNotesVisible;
		}
		set
		{
			Layout.Settings.SlideNotesVisible = value;
		}
	}

	public bool IsNotesInspectorVisible
	{
		get
		{
			return _isNotesInspectorVisible;
		}
		private set
		{
			SetValue("IsNotesInspectorVisible", ref _isNotesInspectorVisible, value);
		}
	}

	public bool CanShowSlideNotes => EditMode == EditMode.Presentation;

	private bool IsTextTabVisible => SelectedCanvasElements.OfType<ClosedBezierPath>().Any();

	public bool IsTemplateEditMode
	{
		get
		{
			if (EditMode != EditMode.Template && EditMode != EditMode.CCLITemplate && EditMode != EditMode.Mask)
			{
				return EditMode == EditMode.Prop;
			}
			return true;
		}
	}

	public bool IsSlideEditMode
	{
		get
		{
			if (EditMode != 0)
			{
				return EditMode == EditMode.Stage;
			}
			return true;
		}
	}

	public bool IsCustomZoomInput
	{
		get
		{
			return _isCustomZoomInput;
		}
		set
		{
			SetValue("IsCustomZoomInput", ref _isCustomZoomInput, value);
		}
	}

	public InspectorTab AvailableInspectorTabs
	{
		get
		{
			InspectorTab inspectorTab = InspectorTab.None;
			if (SelectedCanvasElements.Any())
			{
				inspectorTab |= InspectorTab.Shape;
			}
			else
			{
				switch (EditMode)
				{
				case EditMode.Stage:
					inspectorTab |= InspectorTab.StageLayout;
					break;
				case EditMode.Prop:
					inspectorTab |= InspectorTab.PropSlide;
					break;
				case EditMode.Mask:
					inspectorTab |= InspectorTab.Mask;
					break;
				case EditMode.Template:
				case EditMode.CCLITemplate:
					inspectorTab |= InspectorTab.Template;
					break;
				case EditMode.Presentation:
					inspectorTab |= InspectorTab.Slide;
					inspectorTab |= InspectorTab.Document;
					break;
				}
			}
			if (IsTextTabVisible)
			{
				inspectorTab |= InspectorTab.Text;
			}
			if ((EditMode == EditMode.Presentation && SelectedCanvasElements.AllOf<BezierPath>()) || ((EditMode == EditMode.Template || EditMode == EditMode.CCLITemplate || EditMode == EditMode.Prop) && SelectedCanvasElements.AnyOf<BezierPath>()))
			{
				inspectorTab |= InspectorTab.Build;
			}
			return inspectorTab;
		}
	}

	private InspectorTab SelectedDocumentTab
	{
		get
		{
			InspectorTab availableInspectorTabs = AvailableInspectorTabs;
			if (_selectedDocumentTab == InspectorTab.Document && !availableInspectorTabs.HasFlag(InspectorTab.Document))
			{
				_selectedDocumentTab = InspectorTab.Slide;
			}
			return _selectedDocumentTab;
		}
	}

	private InspectorTab SelectedShapeTab
	{
		get
		{
			InspectorTab availableInspectorTabs = AvailableInspectorTabs;
			if (_selectedShapeTab == InspectorTab.Shape && !availableInspectorTabs.HasFlag(InspectorTab.Shape))
			{
				_selectedShapeTab = InspectorTab.Text;
			}
			else if (_selectedShapeTab == InspectorTab.Text && !availableInspectorTabs.HasFlag(InspectorTab.Text))
			{
				_selectedShapeTab = InspectorTab.Shape;
			}
			return _selectedShapeTab;
		}
	}

	public InspectorTab SelectedInspectorTab
	{
		get
		{
			bool flag = SelectedCanvasElements.Any();
			InspectorTab inspectorTab;
			switch (EditMode)
			{
			case EditMode.Stage:
				inspectorTab = (flag ? SelectedShapeTab : InspectorTab.StageLayout);
				break;
			case EditMode.Prop:
				inspectorTab = (flag ? SelectedShapeTab : _selectedPropTab);
				break;
			case EditMode.Mask:
				inspectorTab = (flag ? SelectedShapeTab : InspectorTab.Mask);
				break;
			case EditMode.Template:
			case EditMode.CCLITemplate:
				inspectorTab = (flag ? SelectedShapeTab : _selectedTemplateTab);
				break;
			default:
				inspectorTab = (flag ? SelectedShapeTab : SelectedDocumentTab);
				break;
			}
			InspectorTab inspectorTab2 = inspectorTab;
			if (!AvailableInspectorTabs.HasFlag(inspectorTab2))
			{
				return InspectorTab.Shape;
			}
			return inspectorTab2;
		}
		set
		{
			switch (value)
			{
			case InspectorTab.Document:
			case InspectorTab.StageLayout:
			case InspectorTab.Mask:
			case InspectorTab.Slide:
				_selectedDocumentTab = value;
				break;
			case InspectorTab.Template:
				_selectedTemplateTab = value;
				break;
			case InspectorTab.PropSlide:
				_selectedPropTab = value;
				break;
			case InspectorTab.Shape:
			case InspectorTab.Text:
				_selectedShapeTab = value;
				break;
			case InspectorTab.Build:
				_selectedShapeTab = value;
				_selectedDocumentTab = value;
				break;
			}
			OnPropertyChanged("SelectedInspectorTab");
		}
	}

	public abstract string SelectedItemName { get; set; }

	public IDocumentInspectorVM DocumentInspectorVM { get; }

	public IStageLayoutInspectorVM StageLayoutInspectorVM { get; }

	public ISlideInspectorVM SlideInspectorVM { get; }

	public ITemplateSlideInspectorVM TemplateSlideInspectorVM { get; }

	public IPropsInspectorVM PropsInspectorVM { get; }

	public IShapeInspectorVM ShapeInspectorVM { get; }

	public ITextInspectorVM TextInspectorVM { get; }

	public ITextLinkVM TextLinkVM { get; }

	public IBuildInspectorVM BuildInspectorVM { get; }

	public OverlayEditorVM OverlayEditorVM { get; } = new OverlayEditorVM();

	public IPenTool? ActivePen
	{
		get
		{
			return _activePen;
		}
		set
		{
			SetValue<IPenTool>("ActivePen", ref _activePen, value, delegate(IPenTool o, IPenTool n)
			{
				if (n == null)
				{
					PublishAnalytics(new CustomShape(FactoryProvider.MediaFactory, FactoryProvider.TextDocumentFactory, ""), _insertionSource);
				}
				if (o is OpenBezierPathPen openBezierPathPen)
				{
					openBezierPathPen.DrawingStarted -= OnPenDraw;
				}
				if (n is OpenBezierPathPen openBezierPathPen2)
				{
					openBezierPathPen2.DrawingStarted += OnPenDraw;
					PenHelperText = LocalizedStrings.Get("EDITOR_POPOVER_CUSTOM_SHAPE_DRAWING_STEP_ONE_label");
				}
				OnPropertyChanged("ShowPenHelper");
			});
		}
	}

	public bool ShowPenHelper => ActivePen != null;

	public string PenHelperText
	{
		get
		{
			return _penHelperText;
		}
		private set
		{
			SetValue("PenHelperText", ref _penHelperText, value);
		}
	}

	protected IPasteStrategy PasteStrategy => EditorService.PasteStrategy;

	public ObservableCollection<double> SortedZoomFactors { get; }

	public ViewportRequestor ViewportRequestor { get; } = new ViewportRequestor();

	public static IEnumerable<TimerData> Timers => DataVault.TimerDocument.Timers;

	protected virtual string? MediaRoot
	{
		get
		{
			if (!_advancedSettings.ManageMediaAutomatically)
			{
				return null;
			}
			return CommonPaths.MediaAssets;
		}
	}

	public abstract ICommand<TemplateSlide> AddCommand { get; }

	public BitmapSource? VideoInputThumbnailImage
	{
		get
		{
			return _videoInputThumbnailImage;
		}
		private set
		{
			SetValue("VideoInputThumbnailImage", ref _videoInputThumbnailImage, value);
		}
	}

	public BitmapSource? BackgroundImage
	{
		get
		{
			return _backgroundImage;
		}
		private set
		{
			SetValue("BackgroundImage", ref _backgroundImage, value);
		}
	}

	public bool IsBackgroundImagePending => SelectedSlide?.IsBackgroundMediaPending ?? false;

	public bool IncludeBackground => GetIncludeBackground();

	public ScaleBehavior BackgroundImageScale => (GetMediaActions()?.Select((MediaAction x) => x.Media).OfType<IDrawMedia>().FirstOrDefault())?.Drawing.ScaleBehavior ?? ScaleBehavior.ScaleToFit;

	public ScaleAlignment BackgroundImageAlignment => (GetMediaActions()?.Select((MediaAction x) => x.Media).OfType<IDrawMedia>().FirstOrDefault())?.Drawing.EffectiveScaleAlignment ?? ScaleAlignment.MiddleCenter;

	public ICommand ActivateCustomZoomFactorInputCommand => new RelayCommand(delegate
	{
		IsCustomZoomInput = true;
	});

	public ICommand<double> ChangeZoomFactorCommand => new RelayCommand<double>(OnChangeZoomFactorCommand);

	public ICommand ToggleScaleToFitCommand => new RelayCommand(delegate
	{
		IsScaleToFitActive = !IsScaleToFitActive;
	});

	public ICommand<BezierPoint> RemovePointCommand => new RelayCommand<BezierPoint>(RemovePoint, RemovePointCanExecute);

	public abstract ICommand DuplicateCommand { get; }

	public abstract ICommand CopyCommand { get; }

	public abstract ICommand CutCommand { get; }

	public abstract ICommand PasteSlidesCommand { get; }

	public ICommand PasteCommand => new RelayCommand(PasteCommandExecuted, CanPaste);

	public abstract ICommand DeleteCommand { get; }

	public virtual ICommand? BreakTextToNewSlideCommand { get; }

	public virtual ICommand? BreakTextToNextSlideCommand { get; }

	public ICommand<AddElementCommandParameters?> AddShapeCommand => new RelayCommand<AddElementCommandParameters>(AddElement);

	public ICommand<ProPresenter.UI.ViewModels.Editor.InsertEditorObjectSourceType> AddMediaCommand => new RelayCommand<ProPresenter.UI.ViewModels.Editor.InsertEditorObjectSourceType>(OnAddMediaCommand);

	public ICommand<(FileInfo[], Vector2<double>)> ImportMediaCommand => new RelayCommand<(FileInfo[], Vector2<double>)>(OnImportMediaCommand);

	public ICommand<ProPresenter.UI.ViewModels.Editor.InsertEditorObjectSourceType> ActivatePenCommand => new RelayCommand<ProPresenter.UI.ViewModels.Editor.InsertEditorObjectSourceType>(OnActivatePenCommand);

	public ICommand<ProPresenter.UI.ViewModels.Editor.InsertEditorObjectSourceType> AddLiveVideoElementCommand => new RelayCommand<ProPresenter.UI.ViewModels.Editor.InsertEditorObjectSourceType>(OnAddLiveVideoElementCommand);

	public ICommand<ProPresenter.UI.ViewModels.Editor.InsertEditorObjectSourceType> AddHTMLElementCommand => new RelayCommand<ProPresenter.UI.ViewModels.Editor.InsertEditorObjectSourceType>(OnAddHTMLElementCommand);

	public ICommand TriggerSelectedSlideCommand => new RelayCommand(TriggerSelectedSlideCommandExecuted, () => SelectedSlide != null);

	public ICommand<AddElementCommandParameters?> AddCurrentStageSlideCommand => new RelayCommand<AddElementCommandParameters>(OnAddCurrentStageSlideCommand);

	public ICommand<AddElementCommandParameters?> AddNextStageSlideCommand => new RelayCommand<AddElementCommandParameters>(OnAddNextStageSlideCommand);

	public ICommand<AddElementCommandParameters?> AddTimerStageItemCommand => new RelayCommand<AddElementCommandParameters>(OnAddTimerStageItemCommand);

	public ICommand<ProPresenter.UI.ViewModels.Editor.InsertEditorObjectSourceType> AddMessageCommand => new RelayCommand<ProPresenter.UI.ViewModels.Editor.InsertEditorObjectSourceType>(OnAddMessageCommand);

	public ICommand<ProPresenter.UI.ViewModels.Editor.InsertEditorObjectSourceType> AddStageVideoCountDownElementCommand => new RelayCommand<ProPresenter.UI.ViewModels.Editor.InsertEditorObjectSourceType>(OnAddStageVideoCountDownElementCommand);

	public ICommand<ProPresenter.UI.ViewModels.Editor.InsertEditorObjectSourceType> AddAudioCountDownElementCommand => new RelayCommand<ProPresenter.UI.ViewModels.Editor.InsertEditorObjectSourceType>(OnAddAudioCountDownElementCommand);

	public ICommand<AddElementCommandParameters?> AddPlaybackMarkerElementCommand => new RelayCommand<AddElementCommandParameters>(OnAddPlaybackMarkerElementCommand);

	public ICommand<ProPresenter.UI.ViewModels.Editor.InsertEditorObjectSourceType> AddTimecodeElementCommand => new RelayCommand<ProPresenter.UI.ViewModels.Editor.InsertEditorObjectSourceType>(AddTimecodeElementCommandExecuted);

	public ICommand<ProPresenter.UI.ViewModels.Editor.InsertEditorObjectSourceType> AddSystemClockElementCommand => new RelayCommand<ProPresenter.UI.ViewModels.Editor.InsertEditorObjectSourceType>(OnAddSystemClockElementCommand);

	public ICommand<ProPresenter.UI.ViewModels.Editor.InsertEditorObjectSourceType> AddChordChartElementCommand => new RelayCommand<ProPresenter.UI.ViewModels.Editor.InsertEditorObjectSourceType>(OnAddChordChartElementCommand);

	public ICommand<AddElementCommandParameters?> AddScreenPreviewElementCommand => new RelayCommand<AddElementCommandParameters>(OnAddScreenPreviewElementCommand);

	public ICommand<ProPresenter.UI.ViewModels.Editor.InsertEditorObjectSourceType> AddPCOLiveElementCommand => new RelayCommand<ProPresenter.UI.ViewModels.Editor.InsertEditorObjectSourceType>(OnAddPCOLiveElementCommand);

	public ICommand<AddElementCommandParameters?> AddGroupElementCommand => new RelayCommand<AddElementCommandParameters>(OnAddGroupElementCommand);

	public ICommand<AddElementCommandParameters?> AddSlideLabelElementCommand => new RelayCommand<AddElementCommandParameters>(OnAddSlideLabelElementCommand);

	public ICommand<ProPresenter.UI.ViewModels.Editor.InsertEditorObjectSourceType> AddCaptureStatusElementCommand => new RelayCommand<ProPresenter.UI.ViewModels.Editor.InsertEditorObjectSourceType>(OnAddCaptureStatusElementCommand);

	public ICommand<AddElementCommandParameters?> AddStaticSlideImageCommand => new RelayCommand<AddElementCommandParameters>(OnAddSlidePreviewImage);

	public ICommand HideElementsCommand => new RelayCommand(OnHideElementsCommand, () => SelectedSlideElements.Any());

	public ICommand LockElementsCommand => new RelayCommand(OnLockElementsCommand, () => SelectedSlideElements.Any());

	public ICommand CopyElementsCommand => new RelayCommand(OnCopyElementsCommand, () => SelectedSlideElements.Any());

	public ICommand DuplicateElementsCommand => new RelayCommand(OnDuplicateElementsCommand, () => SelectedSlideElements.Any());

	public ICommand CutElementsCommand => new RelayCommand(OnCutElementsCommand, () => SelectedSlideElements.Any());

	public ICommand PasteElementsCommand => new RelayCommand(OnPasteElementsCommand, PasteStrategy.CanPasteElements);

	public ICommand DeleteElementsCommand => new RelayCommand(delegate
	{
		OnDeleteElementsCommand(SelectedSlideElements.ToArray());
	}, () => SelectedSlideElements.Any((SlideElementBase e) => !e.IsLocked) && SelectedSlideElements.OfType<ClosedBezierPath>().None((ClosedBezierPath e) => e.IsEditModeActive));

	public ICommand DeleteUnlockedElementsCommand => new RelayCommand(delegate
	{
		OnDeleteElementsCommand(SelectedSlideElements.Where((SlideElementBase e) => !e.IsLocked).ToArray());
	}, () => SelectedSlideElements.Any((SlideElementBase e) => !e.IsLocked) && SelectedSlideElements.OfType<ClosedBezierPath>().None((ClosedBezierPath e) => e.IsEditModeActive));

	public ICommand CopyStaticGuidesCommand => new RelayCommand(OnCopyStaticGuidesCommand, () => SelectedSlide?.StaticGuides.Any() ?? false);

	public ICommand PasteStaticGuidesCommand => new RelayCommand(OnPasteStaticGuidesCommand, ClipboardManager.ContainsData<StaticSL[]>);

	public ICommand RemoveAllGuidesCommand => new RelayCommand(OnRemoveAllGuidelinesCommand, () => SelectedSlide?.StaticGuides.Any() ?? false);

	public ICommand<CustomSlide> SelectSlideCommand => new RelayCommand<CustomSlide>(OnSelectSlideCommand);

	public ICommand SelectAllSlidesCommand => new RelayCommand(OnSelectAllSlidesCommand);

	public virtual ICommand MovePreviousSlideCommand => new RelayCommand(OnMovePreviousSlideCommand, () => SelectedSlide != null);

	public virtual ICommand MoveNextSlideCommand => new RelayCommand(OnMoveNextSlideCommand, () => SelectedSlide != null);

	public ICommand<DragDropCommandParameters<CustomSlide, PresentationBase>> MoveSlidesCommand => new RelayCommand<DragDropCommandParameters<CustomSlide, PresentationBase>>(OnDropSlidesCommand);

	public ICommand<CustomSlide> UpdateSelectedSlidesCommand => new RelayCommand<CustomSlide>(OnUpdateSelectedSlidesCommand, (CustomSlide s) => s != null);

	public ICommand<bool> ZoomCommand => new RelayCommand<bool>(OnSlideZoomCommand, (bool z) => SelectedSlide != null);

	public ICommand ZoomToActualSizeCommand => new RelayCommand(OnZoomToActualSizeCommand, () => SelectedSlide != null);

	public virtual ICommand<TemplateSlide>? SelectTemplateCommand => null;

	public ICommand SlideNoteTextBoxGotFocusCommand => new RelayCommand(delegate
	{
		IsNotesInspectorVisible = true;
	});

	public ICommand CanvasGotFocusCommand => new RelayCommand(delegate
	{
		IsNotesInspectorVisible = false;
	});

	public ICommand<int> SelectSlideByIndexCommand => new RelayCommand<int>(OnSelectSlideByIndexCommand);

	public ICommand ToggleGridCommand => new RelayCommand(delegate
	{
		ShowCanvasGrid = !ShowCanvasGrid;
	}, () => (int)Keyboard.Modifiers == 1);

	public ICommand<SlideElementBase> SelectElementCommand => new RelayCommand<SlideElementBase>(OnSelectElementCommand, (SlideElementBase e) => e != null);

	public ICommand ToggleAllGuidelinesCommand => new RelayCommand(OnToggleAllGuidelinesCommand);

	public ICommand<ClosedBezierPath> FitToTextCommand => new RelayCommand<ClosedBezierPath>(OnFitToTextCommand);

	public ICommand<ClosedBezierPath> OverlayEditCommand => new RelayCommand<ClosedBezierPath>(OnOverlayEditCommand, delegate(ClosedBezierPath e)
	{
		ClosedBezierPath closedBezierPath = e ?? SelectedCanvasElements.FirstOrDefaultOf<ClosedBezierPath>();
		return closedBezierPath != null && !closedBezierPath.TextLink.IsEnabled;
	});

	public ICommand BringForwardElementsCommand => new RelayCommand(delegate
	{
		ChangeElementZOrder(ZOrderDirection.Forward);
	}, () => SelectedSlideElements.Any());

	public ICommand BringToFrontElementsCommand => new RelayCommand(delegate
	{
		ChangeElementZOrder(ZOrderDirection.Front);
	}, () => SelectedSlideElements.Any());

	public ICommand SendBackwardElementsCommand => new RelayCommand(delegate
	{
		ChangeElementZOrder(ZOrderDirection.Backward);
	}, () => SelectedSlideElements.Any());

	public ICommand SendToBackElementsCommand => new RelayCommand(delegate
	{
		ChangeElementZOrder(ZOrderDirection.Back);
	}, () => SelectedSlideElements.Any());

	public ICommand CreateNewSlideFromSelectedSlideCommand => new RelayCommand(CreateNewSlideFromSelectedSlideCommandExecuted, () => SelectedSlide != null);

	public event Action? RequestCanvasScroll;

	protected SlideEditorVM(IEditorService editorService, IApp app, ITimerFactory timerFactory, IImport import, IProPresenterResourceService resourceService, IProcessHelper processHelper, IFileSystem fileSystem, IAdvanced advanced, IGeneral general, IImportProcessFactory importProcessFactory, IProPresenterDOFactoryProvider factoryProvider, ITransitionDescriptionCollection transitionDescriptions, IMessageDialogService messageDialogService, IFlagService flagService, ICurrentTime currentTime, IMediaCueThumbnailOverlayVMFactory? overlayVMFactory = null)
	{
		_importProcessFactory = importProcessFactory;
		FactoryProvider = factoryProvider;
		TransitionDescriptions = transitionDescriptions;
		MessageDialogService = messageDialogService;
		FlagService = flagService;
		CurrentTime = currentTime;
		_selectedSlides.CollectionChanged += delegate
		{
			OnPropertyChanged("OrderedSelectedSlides");
		};
		EditorService = editorService;
		App = app;
		_advancedSettings = advanced;
		TimerFactory = timerFactory;
		MediaFactory = FactoryProvider.MediaFactory;
		PasteStrategy.EditMode = EditMode;
		FillMediaProvider mediaProvider = new FillMediaProvider(new FillMediaValidator(), importProcessFactory, FactoryProvider.MediaFactory, () => (EditMode != EditMode.Mask) ? FileFilters.VisualFilter : FileFilters.ImageOnlyFilter, () => MediaRoot);
		SlideInspectorVM = new SlideInspectorVM(mediaProvider, overlayVMFactory, app, import, processHelper, fileSystem, advanced, importProcessFactory, factoryProvider, transitionDescriptions);
		StageLayoutInspectorVM = new StageLayoutInspectorVM();
		TemplateSlideInspectorVM = new TemplateSlideInspectorVM(mediaProvider, app, import, transitionDescriptions);
		PropsInspectorVM = new PropsInspectorVM(EditorService.OutputController, new PropPrompts());
		DocumentInspectorVM = new DocumentInspectorVM(EditorService.OutputController, general, advanced);
		ShapeInspectorVM shapeInspectorVM = new ShapeInspectorVM(EditorService.OutputRepository, app, SelectedCanvasElements, mediaProvider, factoryProvider);
		ShapeInspectorVM = shapeInspectorVM;
		TextInspectorVM = new TextInspectorVM(SelectedCanvasElements, mediaProvider);
		switch (CommandTargetType)
		{
		case CommandTargetType.SlideEditor:
			TextInspectorVM.CommandTargetType = CommandTargetType.SlideTextInspector;
			break;
		case CommandTargetType.TemplateEditor:
			TextInspectorVM.CommandTargetType = CommandTargetType.TemplateTextInspector;
			break;
		case CommandTargetType.MaskEditor:
			TextInspectorVM.CommandTargetType = CommandTargetType.MaskTextInspector;
			break;
		case CommandTargetType.PropEditor:
			TextInspectorVM.CommandTargetType = CommandTargetType.PropTextInspector;
			break;
		}
		TextLinkVM = new TextLinkVM(resourceService.Timers, SelectedCanvasElements, app, general);
		BuildInspectorVM = new BuildInspectorVM(SelectedSlideElements, EditorService.OutputController);
		LinkProperties("AlignmentGuidelineColor", "AlignmentGuidesColor");
		LinkProperties("ScaleToFit", "IsScaleToFitActive");
		LinkProperties("ShowCenterAlignmentGuidelines", "ShowCenterGuides");
		LinkProperties("ShowEdgeAlignmentGuidelines", "ShowEdgeGuides");
		LinkProperties("ShowRelativeSizingGuidelines", "ShowRelativeSizing");
		LinkProperties("ShowRelativeSpacingGuidelines", "ShowRelativeSpacing");
		LinkProperties("ShowRuler", "IsRulerVisible");
		LinkProperties("ShowSlideGuidelines", "ShowSlidesGuides");
		LinkProperties("ShowTemplateGuidelines", "ShowTemplateGuides");
		LinkProperties("SlideGuidelineColor", "SlidesGuidesColor");
		LinkProperties("TemplateGuidelineColor", "TemplateGuidesColor");
		LinkProperties("ShowCanvasGrid", "ShowCanvasGrid");
		LinkProperties("CanvasGridColor", "CanvasGridColor");
		LinkProperties("CanvasGridSpacing", "CanvasGridSpacing");
		LinkProperties("CanvasGridSubdivisions", "CanvasGridSubdivisions");
		LinkProperties("SlideNoteBackground", "SlideNoteBackground");
		LinkProperties("ShowSlideNotesRuler", "ShowSlideNotesRuler");
		LinkAction("ZoomFactor", delegate
		{
			if (!IsScaleToFitActive)
			{
				ZoomFactor = EditorPreferences.Settings.ZoomFactor;
			}
		});
		LinkProperties(new global::_003C_003Ez__ReadOnlyArray<string>(new string[6] { "ShowSlideGuidelines", "ShowTemplateGuidelines", "ShowRelativeSpacingGuidelines", "ShowRelativeSizingGuidelines", "ShowCenterAlignmentGuidelines", "ShowEdgeAlignmentGuidelines" }), "GuidelinesEnabled");
		LinkProperties("SlideNotesVisible", "SlideNotesVisible");
		LinkAction("SlideNotesVisible", delegate
		{
			IsNotesInspectorVisible = false;
		});
		LinkProperties(new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "Text", "IsEditModeActive" }), new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "SelectedInspectorTab", "AvailableInspectorTabs" }));
		EditorPreferences.Settings.ShowCheckerboard.CollectionChanged += delegate
		{
			OnPropertyChanged("ShowCheckerboard");
			OnPropertyChanged("PrimaryBackgroundColor");
			OnPropertyChanged("Background");
		};
		ShapeInspectorVM.PropertyChanged += base.RaiseLinkedValues;
		Settings.PropertyChanged += base.RaiseLinkedValues;
		Layout.Settings.PropertyChanged += base.RaiseLinkedValues;
		SelectedCanvasElements.CollectionChanged += delegate(object? s, NotifyCollectionChangedEventArgs e)
		{
			e.OldItems?.OfType<ClosedBezierPath>().ForEach(delegate(ClosedBezierPath p)
			{
				p.PropertyChanged -= base.RaiseLinkedValues;
			});
			e.NewItems?.OfType<ClosedBezierPath>().ForEach(delegate(ClosedBezierPath p)
			{
				p.PropertyChanged += base.RaiseLinkedValues;
			});
			OnPropertyChanged("AvailableInspectorTabs");
			OnPropertyChanged("SelectedInspectorTab");
			OnPropertyChanged("IsHidden");
			OnPropertyChanged("IsLocked");
		};
		SelectedSlides.CollectionChanged += OnSelectedSlidesChanged;
		LinkProperties(new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "IsBackgroundMediaPending", "SelectedSlide" }), "IsBackgroundImagePending");
		SortedZoomFactors = new ObservableCollection<double>();
		UpdateSortedZoomFactors();
	}

	protected virtual void OnSelectedSlideChanged(CustomSlide? oldValue, CustomSlide? newValue)
	{
	}

	protected void TriggerSlide(ArrangedCue slide)
	{
		EditorService.TriggerSlide(slide, overrideEnable: true, ShouldSuppressGotoNext());
	}

	protected virtual bool ShouldSuppressGotoNext()
	{
		return true;
	}

	protected virtual void TriggerSelectedSlideCommandExecuted()
	{
		TriggerSlide(GetArrangedCueFromSelectedSlide());
	}

	protected virtual ArrangedCue GetArrangedCueFromSelectedSlide()
	{
		if (SelectedSlide == null)
		{
			throw new InvalidOperationException("SelectedSlide must be non null");
		}
		return new ArrangedCue(SelectedSlide.ToCue(FactoryProvider, TransitionDescriptions), new CueGroup(new CustomPresentation(App, TimerFactory, FactoryProvider, TransitionDescriptions, MessageDialogService, CurrentTime), new GroupLabel(string.Empty), FactoryProvider, TransitionDescriptions));
	}

	private void OnChangeZoomFactorCommand(double value)
	{
		IsScaleToFitActive = false;
		ZoomFactor = value;
		this.RequestCanvasScroll?.Invoke();
	}

	private void OnPenDraw(BezierPath path, bool isNew)
	{
		PenHelperText = LocalizedStrings.Get(isNew ? "EDITOR_POPOVER_CUSTOM_SHAPE_DRAWING_STEP_TWO_label" : "EDITOR_POPOVER_CUSTOM_SHAPE_DRAWING_STEP_THREE_label");
	}

	private void RemovePoint(BezierPoint point)
	{
		BezierPath? bezierPath = FindShapeByPoint(point);
		if (bezierPath is CustomShape customShape)
		{
			customShape.RemovePoint(point);
		}
		if (bezierPath is OpenBezierPath openBezierPath)
		{
			openBezierPath.RemovePoint(point);
		}
	}

	private bool RemovePointCanExecute(BezierPoint point)
	{
		if (point == null)
		{
			return false;
		}
		BezierPath bezierPath = FindShapeByPoint(point);
		if (bezierPath != null)
		{
			int num = bezierPath.Points.Length;
			if (bezierPath is CustomShape)
			{
				return num > 3;
			}
			if (bezierPath is OpenBezierPath)
			{
				return num > 2;
			}
		}
		return false;
	}

	private BezierPath? FindShapeByPoint(BezierPoint point)
	{
		return SelectedCanvasElements?.OfType<BezierPath>().FirstOrDefault((BezierPath p) => p.Points.Contains(point));
	}

	private static void PlaceElement(BezierPath newShape)
	{
		if (newShape.Size == Vector2<double>.Zero)
		{
			newShape.Size = new Vector2<double>(180.0);
			newShape.Position -= newShape.Size / 2.0;
		}
	}

	protected void AddNewElement(BezierPath newShape, ProPresenter.UI.ViewModels.Editor.InsertEditorObjectSourceType insertionSource = ProPresenter.UI.ViewModels.Editor.InsertEditorObjectSourceType.None)
	{
		if (SelectedSlide == null)
		{
			throw new InvalidOperationException("SelectedSlide must be non null");
		}
		PlaceElement(newShape);
		if (newShape.PathType == BezierPathType.Closed && EditMode == EditMode.Mask && newShape is ClosedBezierPath closedBezierPath && closedBezierPath.Fill.Type == ProPresenter.DO.Slide.Custom.Elements.Fills.FillType.Solid)
		{
			((SolidColorFill)closedBezierPath.Fill).Color = System.Windows.Media.Colors.Black;
		}
		SelectedSlide.AddElement(newShape, userInitiated: false);
		PublishAnalytics(newShape, insertionSource);
		SelectedCanvasElements.Clear();
		SelectedCanvasElements.Add(newShape);
		if (newShape is TextShape)
		{
			SelectedInspectorTab = InspectorTab.Text;
			OnPropertyChanged("SelectedInspectorTab");
		}
	}

	protected void AddElement(AddElementCommandParameters? parameter)
	{
		if (SelectedSlide == null)
		{
			throw new InvalidOperationException("SelectedSlide must be non null");
		}
		ShapeType? shapeType = parameter?.NewShape;
		if (shapeType.HasValue)
		{
			ShapeType valueOrDefault = shapeType.GetValueOrDefault();
			ProPresenter.UI.ViewModels.Editor.InsertEditorObjectSourceType insertionSource = ((parameter.InsertionSource != ProPresenter.UI.ViewModels.Editor.InsertEditorObjectSourceType.None) ? parameter.InsertionSource : ProPresenter.UI.ViewModels.Editor.InsertEditorObjectSourceType.EditorHotkey);
			AddNewElement(valueOrDefault.ConstructShape(FactoryProvider, SelectedSlide.Size, SelectedSlide.ContainerId), insertionSource);
		}
	}

	private void OnAddMediaCommand(ProPresenter.UI.ViewModels.Editor.InsertEditorObjectSourceType insertionSource)
	{
		_insertionSource = insertionSource;
		OpenFileDialog openFileDialog = new OpenFileDialog
		{
			Filter = ((EditMode == EditMode.Mask) ? FileFilters.ImageOnlyFilter : FileFilters.VisualFilter)
		};
		if (openFileDialog.ShowDialog() == true)
		{
			LoadMedia(new global::_003C_003Ez__ReadOnlySingleElementList<string>(openFileDialog.FileName), null);
		}
	}

	private void OnImportMediaCommand((FileInfo[] files, Vector2<double> position) param)
	{
		LoadMedia(param.files.Select((FileInfo f) => f.FullName), param.position);
	}

	private void OnActivatePenCommand(ProPresenter.UI.ViewModels.Editor.InsertEditorObjectSourceType insertionSource)
	{
		_insertionSource = insertionSource;
		ActivePen = new OpenBezierPathPen();
	}

	private void LoadMedia(IEnumerable<string> files, Vector2<double>? position = null, bool forceManageMedia = false)
	{
		SelectedSlide.ThrowWhenNull("SelectedSlide");
		_mediaElementPosition = position;
		_importProcessFactory.Create(files.Select((string file) => new FileImportRequest(file, delegate(string o, string n, FileMediaBase? createdMedia)
		{
			FileMediaBase fileMediaBase = createdMedia ?? MediaFactory.CreateEmptyFileMedia(n, SelectedSlide.ContainerId, null);
			fileMediaBase.MetadataLoadSuccessful += SourceMetadataLoadSuccessful;
			fileMediaBase.MetadataLoadFailed += SourceMetadataLoadfailed;
			if (fileMediaBase.MetadataLoaded)
			{
				fileMediaBase.MetadataLoadSuccessful -= SourceMetadataLoadSuccessful;
				fileMediaBase.MetadataLoadFailed -= SourceMetadataLoadfailed;
				if (fileMediaBase.IsValid)
				{
					SourceMetadataLoadSuccessful(fileMediaBase);
				}
				else
				{
					SourceMetadataLoadfailed(fileMediaBase);
				}
			}
			if (fileMediaBase is VisualMedia visualMedia)
			{
				visualMedia.SetThumbnailToFullSize();
			}
			if (createdMedia == null)
			{
				fileMediaBase.UpdateSource(userInitiated: true, (RelativePath)n);
			}
		})
		{
			ContainerId = SelectedSlide.ContainerId,
			TargetFolder = MediaRoot,
			ForceManageMedia = forceManageMedia
		})).StartImport();
	}

	private void SourceMetadataLoadSuccessful(FileMediaBase media)
	{
		if (SelectedSlide == null)
		{
			throw new InvalidOperationException("SelectedSlide must be non null");
		}
		media.MetadataLoadSuccessful -= SourceMetadataLoadSuccessful;
		media.MetadataLoadFailed -= SourceMetadataLoadfailed;
		if (media is VisualMedia visualMedia)
		{
			Vector2<double> vector = visualMedia.Metadata.Size.Cast<double>().Min(SelectedSlide.Size);
			RectangleShape rectangleShape = new RectangleShape(FactoryProvider, SelectedSlide.ContainerId)
			{
				Fill = new MediaFill(FactoryProvider.MediaFactory, SelectedSlide.ContainerId)
				{
					Media = visualMedia
				},
				Size = vector
			};
			AddNewElement(rectangleShape, _insertionSource);
			if (_mediaElementPosition.HasValue)
			{
				rectangleShape.Position = _mediaElementPosition.Value - vector / 2.0;
			}
		}
	}

	private void SourceMetadataLoadfailed(FileMediaBase media)
	{
		media.MetadataLoadSuccessful -= SourceMetadataLoadSuccessful;
		media.MetadataLoadFailed -= SourceMetadataLoadfailed;
	}

	private void OnAddHTMLElementCommand(ProPresenter.UI.ViewModels.Editor.InsertEditorObjectSourceType insertionSource)
	{
		if (SelectedSlide == null)
		{
			throw new InvalidOperationException("SelectedSlide must be non null");
		}
		AddNewElement(new RectangleShape(FactoryProvider, SelectedSlide.ContainerId)
		{
			Fill = new HTMLFill(),
			Size = SelectedSlide.Size * 0.8,
			Name = LocalizedStrings.Get("MEDIA_FILL_TYPE_WEB")
		}, insertionSource);
	}

	private void OnAddLiveVideoElementCommand(ProPresenter.UI.ViewModels.Editor.InsertEditorObjectSourceType insertionSource)
	{
		if (SelectedSlide == null)
		{
			throw new InvalidOperationException("SelectedSlide must be non null");
		}
		AddNewElement(new RectangleShape(FactoryProvider, SelectedSlide.ContainerId)
		{
			Fill = new LiveVideoFill(FactoryProvider.MediaFactory),
			Size = SelectedSlide.Size * 0.25
		}, insertionSource);
	}

	private void MaybeInitializeElementSettings(SlideMenuTextMode slideMode, ClosedBezierPath element)
	{
		if (slideMode == SlideMenuTextMode.TextAndChords)
		{
			element.Text.Settings.ChordPro.Enabled = true;
			element.Text.Settings.ChordPro.Color = App.MultiTracksChordNotationTextColor;
			element.Text.Settings.ChordPro.Notation = ChordProNotationType.Chords;
		}
	}

	private void OnAddCurrentStageSlideCommand(AddElementCommandParameters? parameters)
	{
		SlideMenuTextMode? slideMenuTextMode = parameters?.SlideMenuTextMode;
		if (slideMenuTextMode.HasValue)
		{
			SlideMenuTextMode valueOrDefault = slideMenuTextMode.GetValueOrDefault();
			ClosedBezierPath closedBezierPath = GenerateLinkedElement((valueOrDefault == SlideMenuTextMode.TextOnly) ? new Vector2<double>(500.0, 400.0) : new Vector2<double>(500.0, 150.0), null, new SlideTextLinkedObject(SlideTargetSourceMode.Current, valueOrDefault.ToSlideTextSourceMode()));
			MaybeInitializeElementSettings(valueOrDefault, closedBezierPath);
			AddNewElement(closedBezierPath, parameters.InsertionSource);
		}
	}

	private void OnAddNextStageSlideCommand(AddElementCommandParameters? parameters)
	{
		SlideMenuTextMode? slideMenuTextMode = parameters?.SlideMenuTextMode;
		if (slideMenuTextMode.HasValue)
		{
			SlideMenuTextMode valueOrDefault = slideMenuTextMode.GetValueOrDefault();
			ClosedBezierPath closedBezierPath = GenerateLinkedElement((valueOrDefault == SlideMenuTextMode.TextOnly) ? new Vector2<double>(500.0, 400.0) : new Vector2<double>(500.0, 150.0), null, new SlideTextLinkedObject(SlideTargetSourceMode.Next, valueOrDefault.ToSlideTextSourceMode()));
			MaybeInitializeElementSettings(valueOrDefault, closedBezierPath);
			AddNewElement(closedBezierPath, parameters.InsertionSource);
		}
	}

	private void OnAddTimerStageItemCommand(AddElementCommandParameters? parameters)
	{
		TimerData timerData = parameters?.TimerData;
		if (timerData != null)
		{
			AddNewElement(GenerateLinkedElement(new Vector2<double>(400.0, 150.0), null, new TimerLinkedObject(timerData)), parameters.InsertionSource);
		}
	}

	private void OnAddMessageCommand(ProPresenter.UI.ViewModels.Editor.InsertEditorObjectSourceType insertionSource)
	{
		AddNewElement(GenerateLinkedElement(new Vector2<double>(600.0, 300.0), null, new StageMessageLinkedObject()), insertionSource);
	}

	private void OnAddStageVideoCountDownElementCommand(ProPresenter.UI.ViewModels.Editor.InsertEditorObjectSourceType insertionSource)
	{
		AddNewElement(GenerateLinkedElement(new Vector2<double>(400.0, 150.0), null, new VideoCountdownLinkedObject()), insertionSource);
	}

	private void OnAddAudioCountDownElementCommand(ProPresenter.UI.ViewModels.Editor.InsertEditorObjectSourceType insertionSource)
	{
		AddNewElement(GenerateLinkedElement(new Vector2<double>(400.0, 150.0), null, new AudioCountdownLinkedObject()), insertionSource);
	}

	private void OnAddPlaybackMarkerElementCommand(AddElementCommandParameters? parameters)
	{
		PlaybackMarkerIdentifierType? playbackMarkerIdentifierType = parameters?.PlaybackMarkerIdentifierType;
		if (playbackMarkerIdentifierType.HasValue)
		{
			PlaybackMarkerIdentifierType valueOrDefault = playbackMarkerIdentifierType.GetValueOrDefault();
			AddNewElement(GenerateLinkedElement(new Vector2<double>(400.0, 150.0), null, new PlaybackMarkerTextLinkedObject
			{
				MarkerIdentifier = new PlaybackMarkerIdentifier(PlaybackMarkerIdentifierDestination.Presentation, valueOrDefault)
			}), parameters.InsertionSource);
		}
	}

	private void OnAddSystemClockElementCommand(ProPresenter.UI.ViewModels.Editor.InsertEditorObjectSourceType insertionSource)
	{
		AddNewElement(GenerateLinkedElement(new Vector2<double>(400.0, 150.0), null, new ClockTextLinkedObject(new ClockData())), insertionSource);
	}

	private void OnAddChordChartElementCommand(ProPresenter.UI.ViewModels.Editor.InsertEditorObjectSourceType insertionSource)
	{
		AddNewElement(GenerateLinkedElement(new Vector2<double>(300.0, 400.0), new ChordChartLinkedObject()), insertionSource);
	}

	private void OnAddScreenPreviewElementCommand(AddElementCommandParameters? parameters)
	{
		ScreenArrangementBase screenArrangementBase = parameters?.ScreenArrangementBase;
		if (screenArrangementBase != null)
		{
			AddNewElement(GenerateLinkedElement(new Vector2<double>(300.0), new OutputScreenLinkedObject(screenArrangementBase)), parameters.InsertionSource);
		}
	}

	private void OnAddPCOLiveElementCommand(ProPresenter.UI.ViewModels.Editor.InsertEditorObjectSourceType insertionSource)
	{
		AddNewElement(GenerateLinkedElement(new Vector2<double>(600.0, 300.0), new PCOLiveLinkedObject()), insertionSource);
	}

	private void OnAddGroupElementCommand(AddElementCommandParameters? parameters)
	{
		GroupSourceType? groupSourceType = parameters?.GroupSourceType;
		if (groupSourceType.HasValue)
		{
			GroupSourceType valueOrDefault = groupSourceType.GetValueOrDefault();
			GroupColorLinkedObject linkedObject = new GroupColorLinkedObject(valueOrDefault);
			GroupNameLinkedObject linkedObject2 = new GroupNameLinkedObject(valueOrDefault);
			RoundedRectangleShape roundedRectangleShape = new RoundedRectangleShape(FactoryProvider, SelectedSlide.ContainerId)
			{
				Size = new Vector2<double>(600.0, 300.0),
				CornerRadius = 0.4,
				Stroke = new Stroke
				{
					IsEnabled = true,
					StrokeColor = System.Windows.Media.Colors.White,
					StrokeThickness = 3.0,
					Style = StrokeStyle.SolidLine
				},
				Fill = 
				{
					IsEnabled = true
				}
			};
			roundedRectangleShape.Text.IterateRuns(Pro.Text.Range.All, splitRuns: false, delegate(RunBase r)
			{
				r.Settings.Fill = new SolidTextFill(System.Windows.Media.Colors.White);
				r.Settings.CharacterSize = 60;
			});
			roundedRectangleShape.FillLink.LinkedObject = linkedObject;
			roundedRectangleShape.TextLink.LinkedObject = linkedObject2;
			AddNewElement(roundedRectangleShape, parameters.InsertionSource);
		}
	}

	private void OnAddSlideLabelElementCommand(AddElementCommandParameters? parameters)
	{
		SlideTargetSourceMode? slideTargetSourceMode = parameters?.SlideTargetSourceMode;
		if (slideTargetSourceMode.HasValue)
		{
			SlideTargetSourceMode valueOrDefault = slideTargetSourceMode.GetValueOrDefault();
			SlideLabelColorLinkedObject linkedObject = new SlideLabelColorLinkedObject(valueOrDefault);
			SlideLabelTextLinkedObject linkedObject2 = new SlideLabelTextLinkedObject(valueOrDefault);
			RoundedRectangleShape roundedRectangleShape = new RoundedRectangleShape(FactoryProvider, SelectedSlide.ContainerId)
			{
				Size = new Vector2<double>(600.0, 300.0),
				CornerRadius = 0.4,
				Stroke = new Stroke
				{
					IsEnabled = true,
					StrokeColor = System.Windows.Media.Colors.White,
					StrokeThickness = 3.0,
					Style = StrokeStyle.SolidLine
				},
				Fill = 
				{
					IsEnabled = true
				}
			};
			roundedRectangleShape.Text.IterateRuns(Pro.Text.Range.All, splitRuns: false, delegate(RunBase r)
			{
				r.Settings.Fill = new SolidTextFill(System.Windows.Media.Colors.White);
				r.Settings.CharacterSize = 60;
			});
			roundedRectangleShape.FillLink.LinkedObject = linkedObject;
			roundedRectangleShape.TextLink.LinkedObject = linkedObject2;
			AddNewElement(roundedRectangleShape, parameters.InsertionSource);
		}
	}

	private void OnAddCaptureStatusElementCommand(ProPresenter.UI.ViewModels.Editor.InsertEditorObjectSourceType insertionSource)
	{
		ClosedBezierPath defaultShape = GetDefaultShape();
		defaultShape.FillLink.LinkedObject = new CaptureStatusColorLinkedObject();
		defaultShape.TextLink.LinkedObject = new CaptureTextLinkedObject();
		AddNewElement(defaultShape, insertionSource);
	}

	private void AddTimecodeElementCommandExecuted(ProPresenter.UI.ViewModels.Editor.InsertEditorObjectSourceType insertionSource)
	{
		ClosedBezierPath defaultShape = GetDefaultShape();
		defaultShape.FillLink.LinkedObject = new TimecodeStatusColorLinkedObject();
		defaultShape.TextLink.LinkedObject = new TimecodeTextLinkedObject();
		AddNewElement(defaultShape, insertionSource);
	}

	private ClosedBezierPath GetDefaultShape()
	{
		RoundedRectangleShape roundedRectangleShape = new RoundedRectangleShape(FactoryProvider, SelectedSlide.ContainerId);
		roundedRectangleShape.Size = new Vector2<double>(500.0, 180.0);
		roundedRectangleShape.CornerRadius = 0.2;
		roundedRectangleShape.Stroke = new Stroke
		{
			IsEnabled = true,
			StrokeColor = ((Pro.UI.Themes.Brushes.GetBrush(Pro.UI.Themes.Brushes.DefaultElementStroke) as SolidColorBrush)?.Color ?? System.Windows.Media.Colors.Transparent),
			StrokeThickness = 3.0,
			Style = StrokeStyle.SolidLine
		};
		roundedRectangleShape.Fill.IsEnabled = true;
		roundedRectangleShape.Text.IterateRuns(Pro.Text.Range.All, splitRuns: false, delegate(RunBase r)
		{
			r.Settings.Fill = new SolidTextFill();
			r.Settings.CharacterSize = 60;
		});
		return roundedRectangleShape;
	}

	private void OnAddSlidePreviewImage(AddElementCommandParameters? parameters)
	{
		if (parameters != null && parameters.SlideTargetSourceMode.HasValue)
		{
			SlideTargetSourceMode value = parameters.SlideTargetSourceMode.Value;
			AddNewElement(GenerateLinkedElement(new Vector2<double>(500.0, 150.0), new SlideImageLinkedObject(value)), parameters.InsertionSource);
		}
	}

	private ClosedBezierPath GenerateLinkedElement(Vector2<double> size, ILinkedFillObject? linkedFillObject = null, ILinkedTextObject? linkedTextObject = null)
	{
		RectangleShape rectangleShape = new RectangleShape(FactoryProvider, SelectedSlide.ContainerId);
		rectangleShape.Size = size;
		rectangleShape.Fill.IsEnabled = linkedTextObject == null;
		rectangleShape.Text.IterateRuns(Pro.Text.Range.All, splitRuns: false, delegate(RunBase r)
		{
			r.Settings.Fill = new SolidTextFill(System.Windows.Media.Colors.White);
		});
		rectangleShape.FillLink.LinkedObject = linkedFillObject;
		rectangleShape.TextLink.LinkedObject = linkedTextObject;
		return rectangleShape;
	}

	private void OnHideElementsCommand()
	{
		bool isHidden = IsHidden;
		SelectedCanvasElements.ForEach(delegate(ICanvasElement e)
		{
			e.IsHidden = !isHidden;
		});
		OnPropertyChanged("IsHidden");
	}

	private void OnLockElementsCommand()
	{
		bool isLocked = IsLocked;
		SelectedCanvasElements.ForEach(delegate(ICanvasElement e)
		{
			e.IsLocked = !isLocked;
		});
		OnPropertyChanged("IsLocked");
	}

	private void OnCopyElementsCommand()
	{
		ClipboardManager.SetData(SelectedSlideElements.CloneItems().ToArray());
	}

	private void OnDuplicateElementsCommand()
	{
		if (SelectedSlide == null)
		{
			throw new InvalidOperationException("SelectedSlide must be non null");
		}
		IEnumerable<ICanvasElement> items = SelectedSlide.DuplicateElements(SelectedSlideElements);
		SelectedSlideElements.Clear();
		SelectedSlideElements.AddRange(items);
	}

	private void OnCutElementsCommand()
	{
		OnCopyElementsCommand();
		OnDeleteElementsCommand(SelectedSlideElements.ToArray());
	}

	private void PasteCommandExecuted()
	{
		if (PasteElementsCommand.CanExecute(null))
		{
			foreach (CustomSlide orderedSelectedSlide in OrderedSelectedSlides)
			{
				OnPasteElement(orderedSelectedSlide, updateSelectedCanvasElements: false);
			}
			return;
		}
		if (PasteSlidesCommand.CanExecute(null))
		{
			PasteSlidesCommand.Execute(null);
		}
	}

	private bool CanPaste()
	{
		if (!PasteElementsCommand.CanExecute(null))
		{
			return PasteSlidesCommand.CanExecute(null);
		}
		return true;
	}

	private void OnPasteElementsCommand()
	{
		if (SelectedSlide == null)
		{
			throw new InvalidOperationException("SelectedSlide must be non null");
		}
		OnPasteElement(SelectedSlide);
	}

	private void OnPasteElement(CustomSlide targetSlide, bool updateSelectedCanvasElements = true)
	{
		(SlideElementBase, RelativePath)[] array = PasteStrategy.GetPastableItems(targetSlide.ContainerId).ToArray();
		if (updateSelectedCanvasElements)
		{
			SelectedCanvasElements.Clear();
		}
		HashSet<SlideElementBase> mediaLoadedForElements = new HashSet<SlideElementBase>();
		using (targetSlide.UndoStack?.Transaction())
		{
			(SlideElementBase, RelativePath)[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				(SlideElementBase, RelativePath) tuple = array2[i];
				if (tuple.Item1 is ClosedBezierPath closedBezierPath)
				{
					if ((closedBezierPath.Fill as MediaFill)?.Media != null && (object)tuple.Item2 != null)
					{
						RelativePath item = tuple.Item2;
						LoadMedia(item.FullPath.ToEnumerable(), null, forceManageMedia: true);
						mediaLoadedForElements.Add(tuple.Item1);
						continue;
					}
					if (closedBezierPath is TextShape textShape)
					{
						textShape.Text.IterateAllRuns(delegate(Pro.Text.Range range, RunBase runBase)
						{
							if (EditMode.IsAnyOf(EditMode.CCLITemplate, EditMode.Mask, EditMode.Prop, EditMode.Stage) && runBase.Settings.Fill.TextFillType.IsAnyOf(TextFillType.BackgroundInvert, TextFillType.BackgroundBlur))
							{
								Color? color = Pro.UI.Themes.Colors.GetColor(Pro.UI.Themes.Colors.DefaultTextFill);
								runBase.Settings.Fill = new SolidTextFill(color.HasValue ? color.Value : default(Color));
							}
						});
					}
				}
				PublishAnalytics(tuple.Item1, ProPresenter.UI.ViewModels.Editor.InsertEditorObjectSourceType.EditorCopyPaste);
				if (updateSelectedCanvasElements)
				{
					SelectedCanvasElements.Add(tuple.Item1);
				}
			}
			SlideElementBase[] array3 = (from x in array
				select x.Element into x
				where !mediaLoadedForElements.Contains(x)
				select x).ToArray();
			if (array3.Length != 0)
			{
				targetSlide.AddElements(array3, userInitiated: true, repositionElements: true, resetZIndex: true, addMediaReferences: true);
			}
		}
	}

	protected virtual void OnDeleteElementsCommand(IEnumerable<SlideElementBase> elements)
	{
		if (SelectedSlide == null)
		{
			throw new InvalidOperationException("SelectedSlide must be non null");
		}
		SelectedSlide.RemoveElements(elements);
		SelectedCanvasElements.RemoveRange(elements);
	}

	private void OnCopyStaticGuidesCommand()
	{
		if (SelectedSlide == null)
		{
			throw new InvalidOperationException("SelectedSlide must be non null");
		}
		ClipboardManager.SetData(SelectedSlide.StaticGuides.Select((StaticSL g) => g.Clone()).ToArray());
	}

	private void OnPasteStaticGuidesCommand()
	{
		if (SelectedSlide == null)
		{
			throw new InvalidOperationException("SelectedSlide must be non null");
		}
		StaticGuidelineCollection staticGuides = SelectedSlide.StaticGuides;
		IEnumerable<StaticSL> data = ClipboardManager.GetData<StaticSL[]>();
		staticGuides.AddStaticSLs(data ?? Enumerable.Empty<StaticSL>());
	}

	private void OnRemoveAllGuidelinesCommand()
	{
		if (SelectedSlide == null)
		{
			throw new InvalidOperationException("SelectedSlide must be non null");
		}
		SelectedSlide.StaticGuides.RemoveStaticSLs(SelectedSlide.StaticGuides.ToArray());
	}

	private void OnSelectedSlidesChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		if (!_ignoreSelectionChanges && (SelectedSlide == null || !_selectedSlides.Contains(SelectedSlide)))
		{
			SelectedSlide = _selectedSlides.FirstOrDefault();
		}
		OnPropertyChanged("SelectedSlides");
	}

	protected virtual void OnSelectSlideCommand(CustomSlide slide)
	{
		SelectSlides(Slides, slide);
	}

	protected void SelectSlides(IEnumerable<CustomSlide> sourceSlides, CustomSlide targetSlide)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		ModifierKeys modifiers = Keyboard.Modifiers;
		CustomSlide[] array = (modifiers.AnyFlags<ModifierKeys>((ModifierKeys)6) ? SelectionHelper<CustomSlide>.FindSelectedItems(sourceSlides, _selectedSlides, targetSlide, modifiers).ToArray() : new CustomSlide[1] { targetSlide });
		if (array.Any())
		{
			SelectSlides(array);
		}
	}

	public void SelectSlide(CustomSlide? slide)
	{
		SelectSlides(new global::_003C_003Ez__ReadOnlySingleElementList<CustomSlide>(slide));
	}

	public void SelectSlides(IEnumerable<CustomSlide?>? slides)
	{
		_selectedSlides.Clear();
		if (slides != null)
		{
			_selectedSlides.AddRange(slides.NotNull());
		}
	}

	protected virtual void OnSelectAllSlidesCommand()
	{
		SelectSlides(Slides);
	}

	protected void DeselectSlides(IEnumerable<CustomSlide> slides)
	{
		_selectedSlides.RemoveRange(slides);
	}

	protected void StartIgnoringSelection()
	{
		_ignoreSelectionChanges = true;
	}

	protected void StopIgnoringSelection()
	{
		_ignoreSelectionChanges = false;
	}

	protected void AllowSelectionForBlock(Action action)
	{
		StopIgnoringSelection();
		action();
		StartIgnoringSelection();
	}

	private void OnMovePreviousSlideCommand()
	{
		int num = ((SelectedSlide != null) ? Slides.IndexOf(SelectedSlide) : 0);
		SelectSlide((num == 0) ? Slides[0] : Slides[num - 1]);
	}

	private void OnMoveNextSlideCommand()
	{
		int num = ((SelectedSlide != null) ? Slides.IndexOf(SelectedSlide) : 0);
		CustomSlide slide;
		if (num != Slides.Count - 1)
		{
			slide = Slides[num + 1];
		}
		else
		{
			ObservableCollection<CustomSlide> slides = Slides;
			slide = slides[slides.Count - 1];
		}
		SelectSlide(slide);
	}

	protected abstract void OnDropSlidesCommand(DragDropCommandParameters<CustomSlide, PresentationBase> e);

	protected static CustomSlide? GetSlideAtOffset(IEnumerable<CustomSlide> targetSlides, CustomSlide? targetSlide, bool isForward)
	{
		return targetSlides.ElementAtOrDefault(targetSlides.IndexOf<CustomSlide>(targetSlide) + (isForward ? 1 : (-1)));
	}

	private void OnUpdateSelectedSlidesCommand(CustomSlide slide)
	{
		_ignoreSelectionChanges = true;
		if (!_selectedSlides.Contains(slide))
		{
			SelectSlide(slide);
		}
		_ignoreSelectionChanges = false;
	}

	protected void InsertSlide(CustomSlide slide, int index)
	{
		Slides.Insert(index, slide);
		SelectSlide(slide);
	}

	private void UpdateSortedZoomFactors()
	{
		bool flag = SortedZoomFactors.Except(_fixedZoomFactors).Any();
		double item = SortedZoomFactors.Except(_fixedZoomFactors).FirstOrDefault();
		SortedZoomFactors.Clear();
		List<double> list = new List<double>(_fixedZoomFactors);
		if (!IsScaleToFitActive)
		{
			if (flag && _fixedZoomFactors.Contains(Settings.ZoomFactor))
			{
				list.Add(item);
			}
			else
			{
				list.Add(Settings.ZoomFactor);
			}
		}
		else if (flag)
		{
			list.Add(item);
		}
		SortedZoomFactors.AddRange(from z in list.Distinct()
			orderby z
			select z);
	}

	private void OnSlideZoomCommand(bool isZoomIn)
	{
		IsScaleToFitActive = false;
		if (isZoomIn)
		{
			ZoomFactor += 0.1;
		}
		else if (ZoomFactor >= 0.2)
		{
			ZoomFactor -= 0.1;
		}
		else if (ZoomFactor < 0.2)
		{
			ZoomFactor = 0.1;
		}
		this.RequestCanvasScroll?.Invoke();
	}

	private void OnZoomToActualSizeCommand()
	{
		IsScaleToFitActive = false;
		ZoomFactor = 1.0;
		this.RequestCanvasScroll?.Invoke();
	}

	private void OnSelectSlideByIndexCommand(int slideIndex)
	{
		CustomSlide slide = GetSlide(slideIndex - 1);
		if (slide != null)
		{
			SelectSlide(slide);
		}
	}

	protected virtual CustomSlide? GetSlide(int slideIndex)
	{
		return null;
	}

	private void OnSelectElementCommand(SlideElementBase element)
	{
		SelectedCanvasElements.Clear();
		SelectedCanvasElements.Add(element);
	}

	private void OnToggleAllGuidelinesCommand()
	{
		bool flag = ShowSlidesGuides && ShowTemplateGuides && ShowRelativeSpacing && ShowRelativeSizing && ShowCenterGuides && ShowEdgeGuides;
		ShowSlidesGuides = !flag;
		ShowTemplateGuides = !flag;
		ShowRelativeSpacing = !flag;
		ShowRelativeSizing = !flag;
		ShowCenterGuides = !flag;
		ShowEdgeGuides = !flag;
	}

	private static void OnFitToTextCommand(ClosedBezierPath element)
	{
		element.FitToText();
	}

	private void OnOverlayEditCommand(ClosedBezierPath element)
	{
		OverlayShownEvent.Publish((element == null) ? OverlayShowSource.ContextMenu : OverlayShowSource.PlusButtonMenu);
		OverlayEditorVM.Element = element ?? SelectedCanvasElements.FirstOrDefaultOf<ClosedBezierPath>();
	}

	private void ChangeElementZOrder(ZOrderDirection direction)
	{
		if (SelectedSlide == null)
		{
			throw new InvalidOperationException("SelectedSlide must be non null");
		}
		ElementOrdonnance.ChangeElementZOrder(SelectedSlide.Elements, SelectedSlideElements, direction);
	}

	protected virtual IEnumerable<MediaAction>? GetMediaActions()
	{
		return null;
	}

	protected async Task LoadBackgroundImageAsync()
	{
		IEnumerable<MediaAction> mediaActions = GetMediaActions()?.OfType<MediaAction>() ?? Enumerable.Empty<MediaAction>();
		global::_003C_003Ey__InlineArray2<Task<BitmapSource>> buffer = default(global::_003C_003Ey__InlineArray2<Task<BitmapSource>>);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray2<Task<BitmapSource>>, Task<BitmapSource>>(ref buffer, 0) = LoadVideoInputThumbnailAsync(mediaActions);
		global::_003CPrivateImplementationDetails_003E.InlineArrayElementRef<global::_003C_003Ey__InlineArray2<Task<BitmapSource>>, Task<BitmapSource>>(ref buffer, 1) = LoadFullSizeVisualMediaThumbnailAsync(mediaActions);
		BitmapSource[] array = await Task.WhenAll(global::_003CPrivateImplementationDetails_003E.InlineArrayAsReadOnlySpan<global::_003C_003Ey__InlineArray2<Task<BitmapSource>>, Task<BitmapSource>>(in buffer, 2));
		VideoInputThumbnailImage = array[0];
		BackgroundImage = array[1];
	}

	private async Task<BitmapSource?> LoadFullSizeVisualMediaThumbnailAsync(IEnumerable<MediaAction> mediaActions)
	{
		VisualMedia visualMedia = mediaActions?.Select((MediaAction a) => a.Media).OfType<VisualMedia>().FirstOrDefault();
		if (SelectedSlide == null || visualMedia == null)
		{
			return null;
		}
		return await EditorService.GetVisualMediaFullSizeThumbnailAsync(visualMedia, SelectedSlide.Size);
	}

	private async Task<BitmapSource?> LoadVideoInputThumbnailAsync(IEnumerable<MediaAction> mediaActions)
	{
		LiveVideoMedia liveVideoMedia = mediaActions?.Select((MediaAction a) => a.Media).OfType<LiveVideoMedia>().FirstOrDefault();
		if (SelectedSlide == null || liveVideoMedia == null)
		{
			return null;
		}
		return await EditorService.GetLiveVideoMediaPreviewAsync(liveVideoMedia, SelectedSlide.Size);
	}

	protected virtual bool GetIncludeBackground()
	{
		return true;
	}

	private void CreateNewSlideFromSelectedSlideCommandExecuted()
	{
		TemplateSlide parameter = ((SelectedSlide == null) ? new TemplateSlide(FactoryProvider, TransitionDescriptions, FlagService) : new TemplateSlide(FactoryProvider, SelectedSlide, FlagService));
		if (AddCommand.CanExecute(parameter))
		{
			AddCommand.Execute(parameter);
		}
	}

	private static void PublishAnalytics(SlideElementBase elementType, ProPresenter.UI.ViewModels.Editor.InsertEditorObjectSourceType fromInsertionSource)
	{
		if (fromInsertionSource != ProPresenter.UI.ViewModels.Editor.InsertEditorObjectSourceType.None)
		{
			ProPresenter.UI.ViewModels.Editor.InsertedTypes? insertedTypeForAnalytics = GetInsertedTypeForAnalytics(elementType);
			if (insertedTypeForAnalytics.HasValue)
			{
				EditorObjectAddedEvent.Publish((ProPresenter.DO.Analytics.Events.TrackedEvents.EditorToolbar.InsertEditorObjectSourceType)fromInsertionSource, (ProPresenter.DO.Analytics.Events.TrackedEvents.EditorToolbar.InsertedTypes)insertedTypeForAnalytics.Value);
			}
		}
	}

	private static ProPresenter.UI.ViewModels.Editor.InsertedTypes? GetInsertedTypeForAnalytics(SlideElementBase elementType)
	{
		if (elementType is TextShape)
		{
			return ProPresenter.UI.ViewModels.Editor.InsertedTypes.EditorText;
		}
		if (elementType is RhombusShape || elementType is DoubleArrowShape || elementType is EllipseShape || elementType is IsoscelesTriangleShape || elementType is PolygonShape || elementType is RightArrowShape || elementType is RightArrowShape || elementType is RightTriangleShape || elementType is StarShape)
		{
			return ProPresenter.UI.ViewModels.Editor.InsertedTypes.EditorShape;
		}
		if (!(elementType is CustomShape))
		{
			if (!(elementType is RectangleShape rectangleShape))
			{
				if (elementType is RoundedRectangleShape roundedRectangleShape)
				{
					if (roundedRectangleShape.FillLink.IsEnabled)
					{
						LinkedFillType? linkedFillType = roundedRectangleShape.FillLink.LinkedObject?.LinkedFillType;
						if (linkedFillType.HasValue && linkedFillType == LinkedFillType.TimecodeStatusColor)
						{
							return ProPresenter.UI.ViewModels.Editor.InsertedTypes.EditorTimecode;
						}
						linkedFillType = roundedRectangleShape.FillLink.LinkedObject?.LinkedFillType;
						if (linkedFillType.HasValue && linkedFillType == LinkedFillType.GroupColor)
						{
							return ProPresenter.UI.ViewModels.Editor.InsertedTypes.EditorGroup;
						}
						linkedFillType = roundedRectangleShape.FillLink.LinkedObject?.LinkedFillType;
						if (linkedFillType.HasValue && linkedFillType == LinkedFillType.SlideLabelColor)
						{
							return ProPresenter.UI.ViewModels.Editor.InsertedTypes.EditorLabel;
						}
						linkedFillType = roundedRectangleShape.FillLink.LinkedObject?.LinkedFillType;
						if (linkedFillType.HasValue && linkedFillType == LinkedFillType.CaptureStatusColor)
						{
							return ProPresenter.UI.ViewModels.Editor.InsertedTypes.EditorCaptureStatus;
						}
						return null;
					}
					return ProPresenter.UI.ViewModels.Editor.InsertedTypes.EditorShape;
				}
				return null;
			}
			if (rectangleShape.Fill is HTMLFill)
			{
				return ProPresenter.UI.ViewModels.Editor.InsertedTypes.EditorWeb;
			}
			if (rectangleShape.Fill is LiveVideoFill)
			{
				return ProPresenter.UI.ViewModels.Editor.InsertedTypes.EditorVideoInput;
			}
			if (rectangleShape.Fill is MediaFill)
			{
				return ProPresenter.UI.ViewModels.Editor.InsertedTypes.EditorMedia;
			}
			RectangleShape rectangleShape2 = rectangleShape;
			if (rectangleShape2.FillLink.IsEnabled)
			{
				LinkedFillType? linkedFillType2 = rectangleShape2.FillLink.LinkedObject?.LinkedFillType;
				if (linkedFillType2.HasValue && linkedFillType2.GetValueOrDefault() == LinkedFillType.ChordChart)
				{
					return ProPresenter.UI.ViewModels.Editor.InsertedTypes.EditorChordChart;
				}
				if (linkedFillType2.HasValue && linkedFillType2 == LinkedFillType.PCOLive)
				{
					return ProPresenter.UI.ViewModels.Editor.InsertedTypes.EditorPlanningCenterLive;
				}
				if (linkedFillType2.HasValue && linkedFillType2 == LinkedFillType.PreviewScreen)
				{
					return ProPresenter.UI.ViewModels.Editor.InsertedTypes.EditorScreenPreview;
				}
				if (string.IsNullOrWhiteSpace(rectangleShape2.FillLink.DisplayText))
				{
					return null;
				}
				ILinkedFillObject? linkedObject = rectangleShape2.FillLink.LinkedObject;
				if (linkedObject != null && linkedObject.TargetSourceMode == SlideTargetSourceMode.Next)
				{
					return ProPresenter.UI.ViewModels.Editor.InsertedTypes.EditorNextSlide;
				}
				ILinkedFillObject? linkedObject2 = rectangleShape2.FillLink.LinkedObject;
				if (linkedObject2 != null && linkedObject2.TargetSourceMode == SlideTargetSourceMode.Current)
				{
					return ProPresenter.UI.ViewModels.Editor.InsertedTypes.EditorCurrentSlide;
				}
			}
			else if (rectangleShape2.TextLink.IsEnabled)
			{
				switch (rectangleShape2.TextLink.LinkedObject?.LinkedTextType)
				{
				case LinkedTextType.StageMessage:
					return ProPresenter.UI.ViewModels.Editor.InsertedTypes.EditorStageMessage;
				case LinkedTextType.CurrentSlide:
					return ProPresenter.UI.ViewModels.Editor.InsertedTypes.EditorCurrentSlide;
				case LinkedTextType.NextSlide:
					return ProPresenter.UI.ViewModels.Editor.InsertedTypes.EditorNextSlide;
				case LinkedTextType.Timer:
					return ProPresenter.UI.ViewModels.Editor.InsertedTypes.EditorTimer;
				case LinkedTextType.Clock:
					return ProPresenter.UI.ViewModels.Editor.InsertedTypes.EditorSystemClock;
				case LinkedTextType.VideoCountdown:
					return ProPresenter.UI.ViewModels.Editor.InsertedTypes.EditorVideoCountdown;
				case LinkedTextType.AudioCountdown:
					return ProPresenter.UI.ViewModels.Editor.InsertedTypes.EditorAudioCountdown;
				case LinkedTextType.PlaybackMarkerText:
					return ProPresenter.UI.ViewModels.Editor.InsertedTypes.EditorPlaybackMarker;
				}
			}
			return ProPresenter.UI.ViewModels.Editor.InsertedTypes.EditorShape;
		}
		return ProPresenter.UI.ViewModels.Editor.InsertedTypes.EditorCustomShape;
	}
}
