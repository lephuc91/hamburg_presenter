using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;
using Pro.Common.Collections;
using Pro.Common.Mathematics;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.DO.Triggering;
using Pro.UI;
using Pro.UI.Components;
using Pro.UI.DependencyInjection;
using Pro.UI.DragDropHelper;
using Pro.UI.Utility;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Arrangements;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Media;
using ProPresenter.DO.Messages;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Playlists;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Props;
using ProPresenter.UI.Controls;
using ProPresenter.UI.ViewModels;
using ProPresenter.UI.ViewModels.Macros;
using ProPresenter.UI.ViewModels.MediaLibrary;
using ProPresenter.UI.ViewModels.Props;
using ProPresenter.UI.ViewModels.Timeline;

namespace ProPresenter.UI.PresentationView.PresentationTimeline;

[TemplatePart(Name = "PART_TimelineItemsControl", Type = typeof(ItemsControl))]
[TemplatePart(Name = "PART_TimelineDurationBar", Type = typeof(TimelineRow))]
[TemplatePart(Name = "PART_ScrollBar", Type = typeof(TimelineScrollBar))]
[TemplatePart(Name = "PART_PlayheadMarker", Type = typeof(Rectangle))]
[TemplatePart(Name = "PART_PlayheadCanvas", Type = typeof(Canvas))]
[TemplatePart(Name = "PART_CurrentTimeToolTip", Type = typeof(Popup))]
[TemplatePart(Name = "PART_ReserveTimeOverlay", Type = typeof(TimelineReserveTimeOverlay))]
[ContentProperty("Rows")]
public class TimelineControl : Control
{
	private bool _isLoaded;

	public const double TOOLTIP_OFFSET = 10.0;

	private const string PART_CURRENT_TIME_TOOLTIP = "PART_CurrentTimeToolTip";

	private const string PART_PLAYHEAD_CANVAS = "PART_PlayheadCanvas";

	private const string PART_PLAYHEAD_MARKER = "PART_PlayheadMarker";

	private const string PART_SCROLLBAR = "PART_ScrollBar";

	private const string PART_TIMELINE_DURATION_BAR_NAME = "PART_TimelineDurationBar";

	private const string PART_TIMELINE_ITEMS_CONTROL_NAME = "PART_TimelineItemsControl";

	private const string PART_TIMELINE_RESERVE_TIME_OVERLAY = "PART_ReserveTimeOverlay";

	private readonly IActionDialogService _actionDialogService;

	private Popup? _currentTimeToolTip;

	private TimelineDurationBar? _partDurationBar;

	private Rectangle? _partPlayheadMarker;

	private TimelineScrollBar? _partScrollBar;

	private ItemsControl? _partTimelineItemsControl;

	private TimelineReserveTimeOverlay? _partReserveTimeOverlay;

	private double _pixelStride;

	private bool _updatingPlayhead;

	private Vector2<double> _mouseDownPos;

	private bool _canDragPlayhead;

	private TimelineSelectionBox? _selectionBox;

	private Vector2<double>? _selectionMouseDownPos;

	private bool _didAddSelectionBox;

	private static readonly DependencyPropertyKey _actualDurationPropertyKey;

	private static readonly DependencyPropertyKey _timeBarSectionsPropertyKey;

	public static readonly DependencyProperty ActionTypeDroppedCommandProperty;

	public static readonly DependencyProperty ActualDurationProperty;

	public static readonly DependencyProperty ClearTypeDroppedCommandProperty;

	public static readonly DependencyProperty CueDroppedCommandProperty;

	public static readonly DependencyProperty CurrentMouseOverTimeProperty;

	public static readonly DependencyProperty CurrentPlayheadTimeProperty;

	public static readonly DependencyProperty DurationProperty;

	public static readonly DependencyProperty FileDroppedCommandProperty;

	public static readonly DependencyProperty IsPlayingProperty;

	public static readonly DependencyProperty IsScrubbingProperty;

	public static readonly DependencyProperty ItemDoubleClickedCommandProperty;

	public static readonly DependencyProperty ItemsProperty;

	public static readonly DependencyProperty JumpToTimeCommandProperty;

	public static readonly DependencyProperty StartScrubCommandProperty;

	public static readonly DependencyProperty EndScrubCommandProperty;

	public static readonly DependencyProperty MediaTypeDroppedCommandProperty;

	public static readonly DependencyProperty RowsProperty;

	public static readonly DependencyProperty SelectedItemsProperty;

	public static readonly DependencyProperty TimeBarSectionsProperty;

	public static readonly DependencyProperty TimelineDataProperty;

	public static readonly DependencyProperty TimelineItemDroppedCommandProperty;

	public static readonly DependencyProperty VisibleDurationProperty;

	public static readonly DependencyProperty VisibleDurationStartProperty;

	public static readonly DependencyProperty ZoomValueProperty;

	public static readonly DependencyProperty CanFollowTimecodeProperty;

	public ICommand<IEnumerable<ActionType>> ActionTypeDroppedCommand
	{
		get
		{
			return (ICommand<IEnumerable<ActionType>>)((DependencyObject)this).GetValue(ActionTypeDroppedCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ActionTypeDroppedCommandProperty, (object)value);
		}
	}

	public TimeSlice ActualDuration
	{
		get
		{
			return (TimeSlice)((DependencyObject)this).GetValue(ActualDurationProperty);
		}
		private set
		{
			((DependencyObject)this).SetValue(_actualDurationPropertyKey, (object)value);
		}
	}

	public ICommand<IEnumerable<ClearType>> ClearTypeDroppedCommand
	{
		get
		{
			return (ICommand<IEnumerable<ClearType>>)((DependencyObject)this).GetValue(ClearTypeDroppedCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ClearTypeDroppedCommandProperty, (object)value);
		}
	}

	public TimeSlice CurrentMouseOverTime
	{
		get
		{
			return (TimeSlice)((DependencyObject)this).GetValue(CurrentMouseOverTimeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CurrentMouseOverTimeProperty, (object)value);
		}
	}

	public TimeSlice CurrentPlayheadTime
	{
		get
		{
			return (TimeSlice)((DependencyObject)this).GetValue(CurrentPlayheadTimeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CurrentPlayheadTimeProperty, (object)value);
		}
	}

	public TimeSlice Duration
	{
		get
		{
			return (TimeSlice)((DependencyObject)this).GetValue(DurationProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DurationProperty, (object)value);
		}
	}

	public ICommand<FileInfo[]> FileDroppedCommand
	{
		get
		{
			return (ICommand<FileInfo[]>)((DependencyObject)this).GetValue(FileDroppedCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FileDroppedCommandProperty, (object)value);
		}
	}

	public bool IsPlaying
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsPlayingProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsPlayingProperty, (object)value);
		}
	}

	public bool IsScrubbing
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsScrubbingProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsScrubbingProperty, (object)value);
		}
	}

	public ICommand<ITimelineItemVM>? ItemDoubleClickedCommand
	{
		get
		{
			return (ICommand<ITimelineItemVM>)((DependencyObject)this).GetValue(ItemDoubleClickedCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ItemDoubleClickedCommandProperty, (object)value);
		}
	}

	public INotifyEnumerableChanged<ITimelineItemVM> Items
	{
		get
		{
			return (INotifyEnumerableChanged<ITimelineItemVM>)((DependencyObject)this).GetValue(ItemsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ItemsProperty, (object)value);
		}
	}

	public ICommand<TimeSlice>? JumpToTimeCommand
	{
		get
		{
			return (ICommand<TimeSlice>)((DependencyObject)this).GetValue(JumpToTimeCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(JumpToTimeCommandProperty, (object)value);
		}
	}

	public ICommand<TimeSlice>? StartScrubCommand
	{
		get
		{
			return (ICommand<TimeSlice>)((DependencyObject)this).GetValue(StartScrubCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(StartScrubCommandProperty, (object)value);
		}
	}

	public ICommand<TimeSlice>? EndScrubCommand
	{
		get
		{
			return (ICommand<TimeSlice>)((DependencyObject)this).GetValue(EndScrubCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(EndScrubCommandProperty, (object)value);
		}
	}

	public ICommand<IEnumerable<MediaType>> MediaTypeDroppedCommand
	{
		get
		{
			return (ICommand<IEnumerable<MediaType>>)((DependencyObject)this).GetValue(MediaTypeDroppedCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MediaTypeDroppedCommandProperty, (object)value);
		}
	}

	public ObservableCollection<TimelineRow>? Rows
	{
		get
		{
			return (ObservableCollection<TimelineRow>)((DependencyObject)this).GetValue(RowsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RowsProperty, (object)value);
		}
	}

	public ObservableCollection<ITimelineItemVM>? SelectedItems
	{
		get
		{
			return (ObservableCollection<ITimelineItemVM>)((DependencyObject)this).GetValue(SelectedItemsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedItemsProperty, (object)value);
		}
	}

	public ObservableCollection<ITimelineItemVM>? TimeBarSections
	{
		get
		{
			return (ObservableCollection<ITimelineItemVM>)((DependencyObject)this).GetValue(TimeBarSectionsProperty);
		}
		private set
		{
			((DependencyObject)this).SetValue(_timeBarSectionsPropertyKey, (object)value);
		}
	}

	public Timeline? TimelineData
	{
		get
		{
			return (Timeline)((DependencyObject)this).GetValue(TimelineDataProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TimelineDataProperty, (object)value);
		}
	}

	public bool CanFollowTimecode
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(CanFollowTimecodeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanFollowTimecodeProperty, (object)value);
		}
	}

	public ICommand<ITimelineItemDropArgs?>? TimelineItemDroppedCommand
	{
		get
		{
			return (ICommand<ITimelineItemDropArgs>)((DependencyObject)this).GetValue(TimelineItemDroppedCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TimelineItemDroppedCommandProperty, (object)value);
		}
	}

	public ICommand<IEnumerable<ITriggerable>> TriggerableDroppedCommand
	{
		get
		{
			return (ICommand<IEnumerable<ITriggerable>>)((DependencyObject)this).GetValue(CueDroppedCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CueDroppedCommandProperty, (object)value);
		}
	}

	public TimeSlice VisibleDuration
	{
		get
		{
			return (TimeSlice)((DependencyObject)this).GetValue(VisibleDurationProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(VisibleDurationProperty, (object)value);
		}
	}

	public TimeSlice VisibleDurationStart
	{
		get
		{
			return (TimeSlice)((DependencyObject)this).GetValue(VisibleDurationStartProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(VisibleDurationStartProperty, (object)value);
		}
	}

	public double ZoomValue
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(ZoomValueProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ZoomValueProperty, (object)value);
		}
	}

	private TimelineDropArgsFactory DropArgsFactory { get; } = new TimelineDropArgsFactory();

	static TimelineControl()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected O, but got Unknown
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Expected O, but got Unknown
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Expected O, but got Unknown
		//IL_0156: Expected O, but got Unknown
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected O, but got Unknown
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Expected O, but got Unknown
		//IL_01a0: Expected O, but got Unknown
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Expected O, but got Unknown
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ec: Expected O, but got Unknown
		//IL_0360: Unknown result type (might be due to invalid IL or missing references)
		//IL_036a: Expected O, but got Unknown
		//IL_0389: Unknown result type (might be due to invalid IL or missing references)
		//IL_0393: Expected O, but got Unknown
		//IL_03c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d8: Expected O, but got Unknown
		//IL_03d8: Expected O, but got Unknown
		//IL_040c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0418: Unknown result type (might be due to invalid IL or missing references)
		//IL_0422: Expected O, but got Unknown
		//IL_0422: Expected O, but got Unknown
		//IL_045a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0464: Expected O, but got Unknown
		//IL_048e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0498: Expected O, but got Unknown
		_actualDurationPropertyKey = DependencyProperty.RegisterReadOnly("ActualDuration", typeof(TimeSlice), typeof(TimelineControl), new PropertyMetadata((object)TimeSlice.Zero));
		_timeBarSectionsPropertyKey = DependencyProperty.RegisterReadOnly("TimeBarSections", typeof(ObservableCollection<ITimelineItemVM>), typeof(TimelineControl), new PropertyMetadata());
		ActionTypeDroppedCommandProperty = DependencyProperty.Register("ActionTypeDroppedCommand", typeof(ICommand<IEnumerable<ActionType>>), typeof(TimelineControl), new PropertyMetadata((PropertyChangedCallback)null));
		ActualDurationProperty = _actualDurationPropertyKey.DependencyProperty;
		ClearTypeDroppedCommandProperty = DependencyProperty.Register("ClearTypeDroppedCommand", typeof(ICommand<IEnumerable<ClearType>>), typeof(TimelineControl), new PropertyMetadata((PropertyChangedCallback)null));
		CueDroppedCommandProperty = DependencyProperty.Register("TriggerableDroppedCommand", typeof(ICommand<IEnumerable<ITriggerable>>), typeof(TimelineControl), new PropertyMetadata((PropertyChangedCallback)null));
		CurrentMouseOverTimeProperty = DependencyProperty.Register("CurrentMouseOverTime", typeof(TimeSlice), typeof(TimelineControl), new PropertyMetadata((object)TimeSlice.Zero));
		CurrentPlayheadTimeProperty = DependencyProperty.Register("CurrentPlayheadTime", typeof(TimeSlice), typeof(TimelineControl), new PropertyMetadata((object)TimeSlice.Zero, new PropertyChangedCallback(OnCurrentPlayheadTimePropertyChanged), new CoerceValueCallback(OnCoerceCurrentPlayheadTime)));
		DurationProperty = DependencyProperty.Register("Duration", typeof(TimeSlice), typeof(TimelineControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata(TimeSlice.Zero, new PropertyChangedCallback(OnDurationPropertyChanged), new CoerceValueCallback(OnCoerceDurationProperty)));
		FileDroppedCommandProperty = DependencyProperty.Register("FileDroppedCommand", typeof(ICommand<FileInfo[]>), typeof(TimelineControl), new PropertyMetadata((PropertyChangedCallback)null));
		IsPlayingProperty = DependencyProperty.Register("IsPlaying", typeof(bool), typeof(TimelineControl));
		IsScrubbingProperty = DependencyProperty.Register("IsScrubbing", typeof(bool), typeof(TimelineControl));
		ItemDoubleClickedCommandProperty = DependencyProperty.Register("ItemDoubleClickedCommand", typeof(ICommand<ITimelineItemVM>), typeof(TimelineControl));
		ItemsProperty = DependencyProperty.Register("Items", typeof(INotifyEnumerableChanged<ITimelineItemVM>), typeof(TimelineControl));
		JumpToTimeCommandProperty = DependencyProperty.Register("JumpToTimeCommand", typeof(ICommand<TimeSlice>), typeof(TimelineControl));
		StartScrubCommandProperty = DependencyProperty.Register("StartScrubCommand", typeof(ICommand<TimeSlice>), typeof(TimelineControl));
		EndScrubCommandProperty = DependencyProperty.Register("EndScrubCommand", typeof(ICommand<TimeSlice>), typeof(TimelineControl));
		MediaTypeDroppedCommandProperty = DependencyProperty.Register("MediaTypeDroppedCommand", typeof(ICommand<IEnumerable<MediaType>>), typeof(TimelineControl), new PropertyMetadata((PropertyChangedCallback)null));
		RowsProperty = DependencyProperty.Register("Rows", typeof(ObservableCollection<TimelineRow>), typeof(TimelineControl));
		SelectedItemsProperty = DependencyProperty.Register("SelectedItems", typeof(ObservableCollection<ITimelineItemVM>), typeof(TimelineControl));
		TimeBarSectionsProperty = _timeBarSectionsPropertyKey.DependencyProperty;
		TimelineDataProperty = DependencyProperty.Register("TimelineData", typeof(Timeline), typeof(TimelineControl), new PropertyMetadata((PropertyChangedCallback)null));
		TimelineItemDroppedCommandProperty = DependencyProperty.Register("TimelineItemDroppedCommand", typeof(ICommand<ITimelineItemDropArgs>), typeof(TimelineControl), new PropertyMetadata((PropertyChangedCallback)null));
		VisibleDurationProperty = DependencyProperty.Register("VisibleDuration", typeof(TimeSlice), typeof(TimelineControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata(TimeSlice.Zero, new PropertyChangedCallback(OnVisibleDurationPropertyChanged), new CoerceValueCallback(OnCoerceVisibleDurationProperty)));
		VisibleDurationStartProperty = DependencyProperty.Register("VisibleDurationStart", typeof(TimeSlice), typeof(TimelineControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata(TimeSlice.Zero, new PropertyChangedCallback(OnVisibleDurationStartPropertyChanged), new CoerceValueCallback(OnCoerceVisibleDurationStartProperty)));
		ZoomValueProperty = DependencyProperty.Register("ZoomValue", typeof(double), typeof(TimelineControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)1.0, new PropertyChangedCallback(OnZoomPercentagePropertyChanged)));
		CanFollowTimecodeProperty = DependencyProperty.Register("CanFollowTimecode", typeof(bool), typeof(TimelineControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnCanFollowTimecodePropertyChanged)));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(TimelineControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(TimelineControl)));
	}

	public TimelineControl()
	{
		Rows = new ObservableCollection<TimelineRow>();
		Rows.CollectionChanged += RowsOnCollectionChanged;
		TimeBarSections = new ObservableCollection<ITimelineItemVM>();
		SelectedItems = new ObservableCollection<ITimelineItemVM>();
		base.Loaded += delegate
		{
			if (!_isLoaded)
			{
				if (_partPlayheadMarker != null)
				{
					BuildPlayheadMarker(_partPlayheadMarker);
				}
				UpdatePixelStride();
				_isLoaded = true;
			}
		};
		base.SizeChanged += delegate
		{
			UpdatePixelStride();
		};
		_actionDialogService = UIServiceProvider.GetService<IActionDialogService>();
		SetBinding(TimelineDataProperty, new Binding("Timeline"));
	}

	public TimeSlice CanvasLocationToTime(double canvasLocation)
	{
		if (_partTimelineItemsControl != null && !double.IsNaN(_partTimelineItemsControl.ActualWidth) && _partTimelineItemsControl.ActualWidth > 0.0)
		{
			return TimeSlice.FromMilliseconds(canvasLocation * _pixelStride) + VisibleDurationStart;
		}
		return TimeSlice.Zero;
	}

	public TimeSlice GetAddTimelineItemLocationTime()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		Point position = Mouse.GetPosition(_partTimelineItemsControl);
		return CanvasLocationToTime(((Point)(ref position)).X);
	}

	public override void OnApplyTemplate()
	{
		_partDurationBar = GetTemplateChild("PART_TimelineDurationBar") as TimelineDurationBar;
		_partTimelineItemsControl = GetTemplateChild("PART_TimelineItemsControl") as ItemsControl;
		_partScrollBar = GetTemplateChild("PART_ScrollBar") as TimelineScrollBar;
		_partPlayheadMarker = GetTemplateChild("PART_PlayheadMarker") as Rectangle;
		_currentTimeToolTip = GetTemplateChild("PART_CurrentTimeToolTip") as Popup;
		_partReserveTimeOverlay = GetTemplateChild("PART_ReserveTimeOverlay") as TimelineReserveTimeOverlay;
		if (_partTimelineItemsControl != null)
		{
			BuildDropActions((DependencyObject)(object)_partTimelineItemsControl);
			Setup_TimelineItemsControl_MouseEvents(_partTimelineItemsControl);
		}
		if (_partDurationBar != null)
		{
			((DependencyObject?)(object)_partDurationBar).Bind(TimelineRow.DurationProperty, this, "ActualDuration");
			((DependencyObject?)(object)_partDurationBar).Bind(TimelineRow.VisibleDurationProperty, this, "VisibleDuration");
			((DependencyObject?)(object)_partDurationBar).Bind(TimelineRow.VisibleDurationStartProperty, this, "VisibleDurationStart");
			_partDurationBar.MouseEnter += PartDurationBarOnMouseEnter;
			_partDurationBar.MouseLeave += PartDurationBarOnMouseLeave;
			_partDurationBar.PreviewMouseDown += PartDurationBarMouseDown;
			_partDurationBar.PreviewMouseMove += PartDurationBarOnMouseMove;
			_partDurationBar.PreviewMouseUp += PartDurationBarMouseUp;
		}
		if (_partScrollBar != null)
		{
			((DependencyObject?)(object)_partScrollBar).Bind(TimelineScrollBar.DurationProperty, this, "ActualDuration");
			((DependencyObject?)(object)_partScrollBar).Bind(TimelineScrollBar.VisibleDurationProperty, this, "VisibleDuration");
			((DependencyObject?)(object)_partScrollBar).Bind(TimelineScrollBar.VisibleDurationStartProperty, this, "VisibleDurationStart", BindingMode.TwoWay);
		}
		if (_partReserveTimeOverlay != null)
		{
			_partReserveTimeOverlay.IsEnabled = !CanFollowTimecode;
		}
		base.OnApplyTemplate();
	}

	protected override void OnPreviewMouseWheel(MouseWheelEventArgs e)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		if (((Enum)Keyboard.Modifiers).HasFlag((Enum)(object)(ModifierKeys)2))
		{
			if (e.Delta > 0)
			{
				_partScrollBar?.IncrementScroll();
			}
			else
			{
				_partScrollBar?.DecrementScroll();
			}
			e.Handled = true;
		}
	}

	private TimeSlice AdjustVisibleDuration(TimeSlice visibleDuration)
	{
		if (Math.Abs(ZoomValue - ActualDuration.TotalSeconds) < double.Epsilon)
		{
			return ActualDuration;
		}
		if (visibleDuration <= TimeSlice.Zero || visibleDuration > ActualDuration)
		{
			return ActualDuration;
		}
		return visibleDuration;
	}

	private TimeSlice AdjustVisibleDurationStart(TimeSlice visibleDurationStart)
	{
		if (visibleDurationStart < TimeSlice.Zero)
		{
			return TimeSlice.Zero;
		}
		if (visibleDurationStart + VisibleDuration > ActualDuration)
		{
			return AdjustVisibleDurationStart(ActualDuration - VisibleDuration);
		}
		return visibleDurationStart;
	}

	private void BuildDropActions(DependencyObject target)
	{
		DropTarget dropTarget = new DropTarget(target);
		DropAction<FileInfo[]> dropAction = dropTarget.AddFileDrop();
		DropAction<DraggedItems<ArrangedCue>> dropAction2 = dropTarget.AddDropType<DraggedItems<ArrangedCue>>();
		DropAction<DraggedItems<MediaCue>> dropAction3 = dropTarget.AddDropType<DraggedItems<MediaCue>>();
		DropAction<DraggedItems<IMediaCueThumbnailVM>> dropAction4 = dropTarget.AddDropType<DraggedItems<IMediaCueThumbnailVM>>();
		DropAction<DraggedItems<IMacroItemVM>> dropAction5 = dropTarget.AddDropType<DraggedItems<IMacroItemVM>>();
		DropAction<DraggedItems<ActionType>> dropAction6 = dropTarget.AddDropType<DraggedItems<ActionType>>();
		DropAction<DraggedItems<ITimerVM>> dropAction7 = dropTarget.AddDropType<DraggedItems<ITimerVM>>();
		DropAction<DraggedItems<ClearType>> dropAction8 = dropTarget.AddDropType<DraggedItems<ClearType>>();
		DropAction<DraggedItems<MediaType>> dropAction9 = dropTarget.AddDropType<DraggedItems<MediaType>>();
		DropAction<DraggedItems<ScreenArrangementBase>> dropAction10 = dropTarget.AddDropType<DraggedItems<ScreenArrangementBase>>();
		DropAction<DraggedItems<Message>> dropAction11 = dropTarget.AddDropType<DraggedItems<Message>>();
		DropAction<DraggedItems<IPropCue>> dropAction12 = dropTarget.AddDropType<DraggedItems<IPropCue>>();
		DropAction<DraggedItems<IClearGroupItemVM>> dropAction13 = dropTarget.AddDropType<DraggedItems<IClearGroupItemVM>>();
		DropAction<DraggedTreeItemsCollection<IPlaylist<MediaCue>>> dropAction14 = dropTarget.AddDropType<DraggedTreeItemsCollection<IPlaylist<MediaCue>>>();
		DropAction<DraggedItems<IPropCueVM>> dropAction15 = dropTarget.AddDropType<DraggedItems<IPropCueVM>>();
		dropAction13.SetIsValidDataPredicate(OnCheckDropItemValid);
		dropAction13.SetOnDataDroppedAction(OnTimelineItemDropped);
		dropAction15.SetIsValidDataPredicate(OnCheckDropItemValid);
		dropAction15.SetOnDataDroppedAction(OnTimelineItemDropped);
		dropAction12.SetIsValidDataPredicate(OnCheckDropItemValid);
		dropAction12.SetOnDataDroppedAction(OnTimelineItemDropped);
		dropAction11.SetIsValidDataPredicate(OnCheckDropItemValid);
		dropAction11.SetOnDataDroppedAction(OnTimelineItemDropped);
		dropAction10.SetIsValidDataPredicate(OnCheckDropItemValid);
		dropAction10.SetOnDataDroppedAction(OnTimelineItemDropped);
		dropAction9.SetIsValidDataPredicate(OnCheckDropItemValid);
		dropAction9.SetOnDataDroppedAction(OnTimelineItemDropped);
		dropAction8.SetIsValidDataPredicate(OnCheckDropItemValid);
		dropAction8.SetOnDataDroppedAction(OnTimelineItemDropped);
		dropAction7.SetIsValidDataPredicate(OnCheckDropItemValid);
		dropAction7.SetOnDataDroppedAction(OnTimelineItemDropped);
		dropAction6.SetIsValidDataPredicate(OnCheckDropItemValid);
		dropAction6.SetOnDataDroppedAction(OnTimelineItemDropped);
		dropAction5.SetIsValidDataPredicate(OnCheckDropItemValid);
		dropAction5.SetOnDataDroppedAction(OnTimelineItemDropped);
		dropAction2.SetIsValidDataPredicate(OnCheckDropItemValid);
		dropAction2.SetOnDataDroppedAction(OnTimelineItemDropped);
		dropAction3.SetIsValidDataPredicate(OnCheckDropItemValid);
		dropAction3.SetOnDataDroppedAction(OnTimelineItemDropped);
		dropAction4.SetIsValidDataPredicate(OnCheckDropItemValid);
		dropAction4.SetOnDataDroppedAction(OnTimelineItemDropped);
		dropAction.SetIsValidDataPredicate(CheckValidFile);
		dropAction.SetOnDataDroppedAction(OnFileDropped);
		dropAction14.SetIsValidDataPredicate(CheckIfPlaylistMediaCuesDropValid);
		dropAction14.SetOnDataDroppedAction(OnPlaylistMedicaCuesDropped);
	}

	private void BuildPlayheadMarker(Rectangle partPlayheadMarker)
	{
		partPlayheadMarker.Height = base.ActualHeight - (_partScrollBar?.ActualHeight ?? 0.0);
		Canvas.SetLeft(partPlayheadMarker, 0.0);
	}

	private bool CheckIfPlaylistMediaCuesDropValid(DraggedTreeItemsCollection<IPlaylist<MediaCue>> arg1, DragEventArgs arg2)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		TimelineDropArgsFactory dropArgsFactory = DropArgsFactory;
		Point position = arg2.GetPosition(_partDurationBar);
		ITimelineItemDropArgs parameter = dropArgsFactory.Create(CanvasLocationToTime(((Point)(ref position)).X), arg1.DraggedTrees.SelectMany((DraggedTreeItems<IPlaylist<MediaCue>> tree) => tree.Items).ToArray());
		return TimelineItemDroppedCommand?.CanExecute(parameter) ?? false;
	}

	private bool CheckValidFile(FileInfo[] arg1, DragEventArgs arg2)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		ICommand<ITimelineItemDropArgs?>? timelineItemDroppedCommand = TimelineItemDroppedCommand;
		if (timelineItemDroppedCommand == null)
		{
			return false;
		}
		Point position = arg2.GetPosition(_partDurationBar);
		return timelineItemDroppedCommand.CanExecute(new FileTimelineItemDropArgs(CanvasLocationToTime(((Point)(ref position)).X), arg1));
	}

	private void ItemDoubleClicked(ITimelineItemVM item)
	{
		ItemDoubleClickedCommand?.Execute(item);
	}

	private bool OnCheckDropItemValid<T>(DraggedItems<T> arg1, DragEventArgs arg2)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		ICommand<ITimelineItemDropArgs?>? timelineItemDroppedCommand = TimelineItemDroppedCommand;
		if (timelineItemDroppedCommand == null)
		{
			return false;
		}
		TimelineDropArgsFactory dropArgsFactory = DropArgsFactory;
		Point position = arg2.GetPosition(_partDurationBar);
		return timelineItemDroppedCommand.CanExecute(dropArgsFactory.Create(CanvasLocationToTime(((Point)(ref position)).X), arg1.Items));
	}

	private static object OnCoerceCurrentPlayheadTime(DependencyObject d, object value)
	{
		TimelineControl timelineControl = (TimelineControl)(object)d;
		TimeSlice timeSlice = (TimeSlice)value;
		if (timeSlice < TimeSlice.Zero)
		{
			return TimeSlice.Zero;
		}
		if (timeSlice > timelineControl.Duration)
		{
			return timelineControl.Duration;
		}
		return value;
	}

	private static object OnCoerceDurationProperty(DependencyObject d, object value)
	{
		if ((TimeSlice)value < TimeSlice.Zero)
		{
			return TimeSlice.Zero;
		}
		return value;
	}

	private static object OnCoerceVisibleDurationProperty(DependencyObject d, object value)
	{
		return ((TimelineControl)(object)d).AdjustVisibleDuration((TimeSlice)value);
	}

	private static object OnCoerceVisibleDurationStartProperty(DependencyObject d, object value)
	{
		TimelineControl obj = (TimelineControl)(object)d;
		TimeSlice visibleDurationStart = (TimeSlice)value;
		return obj.AdjustVisibleDurationStart(visibleDurationStart);
	}

	private static void OnCurrentPlayheadTimePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((TimelineControl)(object)d).UpdatePlayhead();
	}

	private static void OnDurationPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		TimelineControl timelineControl = (TimelineControl)(object)d;
		TimeSlice timeSlice = (TimeSlice)((DependencyPropertyChangedEventArgs)(ref e)).OldValue;
		TimeSlice timeSlice2 = (TimeSlice)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		if (timeSlice == TimeSlice.FromSeconds(timelineControl.ZoomValue))
		{
			timelineControl.VisibleDuration = timeSlice2;
			timelineControl.ZoomValue = timelineControl.VisibleDuration.TotalSeconds;
		}
		else
		{
			double num = 15.0;
			double num2 = timeSlice.TotalSeconds * 0.1;
			double num3 = timeSlice2.TotalSeconds * 0.1;
			double num4 = ((num2 <= num) ? num2 : num);
			double zoomValue = ((num3 <= num) ? num3 : num);
			if (timelineControl.ZoomValue == num4)
			{
				timelineControl.ZoomValue = zoomValue;
			}
			timelineControl.VisibleDuration = TimeSlice.FromSeconds(timelineControl.ZoomValue);
		}
		timelineControl.ActualDuration = timeSlice2 + timeSlice2 * 0.2;
		timelineControl.VisibleDuration = timelineControl.AdjustVisibleDuration(timelineControl.VisibleDuration);
		timelineControl.VisibleDurationStart = timelineControl.AdjustVisibleDurationStart(timelineControl.VisibleDurationStart);
		timelineControl.UpdatePixelStride();
		timelineControl.UpdatePlayhead();
		timelineControl.UpdateBinding(DurationProperty);
	}

	private void OnFileDropped(FileInfo[] arg1, DragEventArgs arg2)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		ICommand<ITimelineItemDropArgs?>? timelineItemDroppedCommand = TimelineItemDroppedCommand;
		if (timelineItemDroppedCommand != null)
		{
			Point position = arg2.GetPosition(_partDurationBar);
			timelineItemDroppedCommand.Execute(new FileTimelineItemDropArgs(CanvasLocationToTime(((Point)(ref position)).X), arg1));
		}
	}

	private void OnPlaylistMedicaCuesDropped(DraggedTreeItemsCollection<IPlaylist<MediaCue>> arg1, DragEventArgs arg2)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		TimelineDropArgsFactory dropArgsFactory = DropArgsFactory;
		Point position = arg2.GetPosition(_partDurationBar);
		ITimelineItemDropArgs parameter = dropArgsFactory.Create(CanvasLocationToTime(((Point)(ref position)).X), arg1.DraggedTrees.SelectMany((DraggedTreeItems<IPlaylist<MediaCue>> tree) => tree.Items).ToArray());
		TimelineItemDroppedCommand?.Execute(parameter);
	}

	private void OnTimelineItemDropped<T>(DraggedItems<T> arg1, DragEventArgs arg2)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		TimelineDropArgsFactory dropArgsFactory = DropArgsFactory;
		Point position = arg2.GetPosition(_partDurationBar);
		ITimelineItemDropArgs timelineItemDropArgs = dropArgsFactory.Create(CanvasLocationToTime(((Point)(ref position)).X), arg1.Items);
		TimelineItemDroppedCommand?.Execute(timelineItemDropArgs);
		ActionTypeTimelineItemDropArgs obj = timelineItemDropArgs as ActionTypeTimelineItemDropArgs;
		IAction action = (obj?.GetAction ?? (timelineItemDropArgs as TriggerableTimelineItemDropArgs)?.GetAction ?? (timelineItemDropArgs as MediaTypeTimelineItemDropArgs)?.GetAction)?.Invoke();
		TimelineRow placement = ((obj == null) ? null : Rows?.LastOrDefault());
		if (action != null && action.CanShowDialogOnDrop(timelineItemDropArgs?.DroppedItems))
		{
			_actionDialogService.ShowEditActionDialog(new ActionDialogParameter(placement, action, TimelineData, null));
		}
	}

	private static void OnVisibleDurationPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		TimelineControl obj = (TimelineControl)(object)d;
		obj.UpdatePixelStride();
		obj.UpdatePlayhead();
		obj.UpdateBinding(VisibleDurationProperty);
	}

	private static void OnVisibleDurationStartPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		TimelineControl obj = (TimelineControl)(object)d;
		obj.UpdatePlayhead();
		obj.UpdateBinding(VisibleDurationStartProperty);
	}

	private static void OnZoomPercentagePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		TimelineControl obj = (TimelineControl)(object)d;
		obj.VisibleDuration = obj.AdjustVisibleDuration(TimeSlice.FromSeconds((double)((DependencyPropertyChangedEventArgs)(ref e)).NewValue));
		obj.VisibleDurationStart = obj.AdjustVisibleDurationStart(obj.VisibleDurationStart);
		obj.UpdatePlayhead();
		obj.UpdateRollingTimeSetWindow();
	}

	private static void OnCanFollowTimecodePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is TimelineControl { _partReserveTimeOverlay: not null } timelineControl)
		{
			timelineControl._partReserveTimeOverlay.IsEnabled = !timelineControl.CanFollowTimecode;
		}
	}

	private void PartDurationBarMouseDown(object? sender, MouseButtonEventArgs e)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		_partDurationBar?.CaptureMouse();
		Point position = e.GetPosition(_partDurationBar);
		_mouseDownPos = (Vector2<double>)position;
		_canDragPlayhead = true;
		CurrentMouseOverTime = GetMouseOverTime(TimeSlice.FromMilliseconds(Math.Floor(((Point)(ref position)).X * _pixelStride)) + VisibleDurationStart);
		StartScrubCommand?.Invoke(CurrentMouseOverTime);
	}

	private void PartDurationBarMouseUp(object? sender, MouseButtonEventArgs e)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		IsScrubbing = false;
		Point position = e.GetPosition(_partDurationBar);
		CurrentMouseOverTime = GetMouseOverTime(TimeSlice.FromMilliseconds(Math.Floor(((Point)(ref position)).X * _pixelStride)) + VisibleDurationStart);
		EndScrubCommand?.Invoke(CurrentMouseOverTime);
		_partDurationBar?.ReleaseMouseCapture();
		_canDragPlayhead = false;
	}

	private void PartDurationBarOnMouseEnter(object? sender, MouseEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		Point position = e.GetPosition(_partDurationBar);
		if (_currentTimeToolTip != null)
		{
			_currentTimeToolTip.IsOpen = true;
			_currentTimeToolTip.HorizontalOffset = ((Point)(ref position)).X + 10.0;
			_currentTimeToolTip.VerticalOffset = ((Point)(ref position)).Y + 10.0;
		}
	}

	private void PartDurationBarOnMouseLeave(object? sender, MouseEventArgs e)
	{
		if (Mouse.LeftButton == MouseButtonState.Released && _currentTimeToolTip != null)
		{
			_currentTimeToolTip.IsOpen = false;
		}
	}

	private void PartDurationBarOnMouseMove(object? sender, MouseEventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		Point position = e.GetPosition(_partDurationBar);
		CurrentMouseOverTime = GetMouseOverTime(TimeSlice.FromMilliseconds(Math.Floor(((Point)(ref position)).X * _pixelStride)) + VisibleDurationStart);
		if (_currentTimeToolTip != null)
		{
			_currentTimeToolTip.HorizontalOffset = ((Point)(ref position)).X + 10.0;
			_currentTimeToolTip.VerticalOffset = ((Point)(ref position)).Y + 10.0;
		}
		if (Mouse.LeftButton == MouseButtonState.Pressed && _canDragPlayhead && _partDurationBar != null && e.CanDrag(_partDurationBar, _mouseDownPos))
		{
			if (!IsScrubbing)
			{
				IsScrubbing = true;
			}
			JumpToTimeCommand?.Invoke(CurrentMouseOverTime);
			if (_currentTimeToolTip != null)
			{
				_currentTimeToolTip.IsOpen = true;
			}
		}
	}

	private TimeSlice GetMouseOverTime(TimeSlice time)
	{
		return TimeSlice.FromSeconds(time.TotalSeconds.Clamp(0.0, Duration.TotalSeconds));
	}

	private void OnRowClicked(RowClickedData data)
	{
		IEnumerable<TimelineRow> enumerable2;
		if (!data.ClearAllSelection)
		{
			IEnumerable<TimelineRow> enumerable = Rows?.Where((TimelineRow r) => r != data.RowClicked).ToArray();
			enumerable2 = enumerable;
		}
		else
		{
			IEnumerable<TimelineRow> enumerable = Rows;
			enumerable2 = enumerable;
		}
		IEnumerable<TimelineRow> enumerable3 = enumerable2;
		if (Keyboard.IsKeyDown((Key)118) || Keyboard.IsKeyDown((Key)119))
		{
			return;
		}
		foreach (TimelineRow item in enumerable3 ?? Enumerable.Empty<TimelineRow>())
		{
			item.ClearSelection();
		}
	}

	private void OnStartTimeChanged(TimeSlice delta)
	{
		if (Rows == null)
		{
			return;
		}
		foreach (ITimelineItemVM item in Rows.SelectMany(delegate(TimelineRow r)
		{
			IEnumerable<ITimelineItemVM> selectedItems = r.SelectedItems;
			return selectedItems ?? Enumerable.Empty<ITimelineItemVM>();
		}))
		{
			item.StartTime += delta;
		}
	}

	private void RowSelectedItemsOnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		if (e.OldItems != null)
		{
			foreach (ITimelineItemVM oldItem in e.OldItems)
			{
				SelectedItems?.Remove(oldItem);
			}
		}
		if (e.NewItems == null)
		{
			return;
		}
		foreach (ITimelineItemVM newItem in e.NewItems)
		{
			SelectedItems?.Add(newItem);
		}
	}

	private void RowsOnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		if (e.OldItems != null)
		{
			foreach (TimelineRow oldItem in e.OldItems)
			{
				oldItem.Clicked -= OnRowClicked;
				oldItem.StartTimeChanged -= OnStartTimeChanged;
				if (oldItem.SelectedItems != null)
				{
					oldItem.SelectedItems.CollectionChanged -= RowSelectedItemsOnCollectionChanged;
				}
				oldItem.ItemDoubleClicked -= ItemDoubleClicked;
			}
		}
		if (e.NewItems == null)
		{
			return;
		}
		foreach (TimelineRow newItem in e.NewItems)
		{
			newItem.Clicked += OnRowClicked;
			newItem.StartTimeChanged += OnStartTimeChanged;
			if (newItem.SelectedItems != null)
			{
				newItem.SelectedItems.CollectionChanged += RowSelectedItemsOnCollectionChanged;
			}
			newItem.ItemDoubleClicked += ItemDoubleClicked;
			((DependencyObject?)(object)newItem).Bind(TimelineRow.DurationProperty, this, "ActualDuration");
			((DependencyObject?)(object)newItem).Bind(TimelineRow.VisibleDurationProperty, this, "VisibleDuration");
			((DependencyObject?)(object)newItem).Bind(TimelineRow.VisibleDurationStartProperty, this, "VisibleDurationStart");
		}
	}

	private void UpdateBinding(DependencyProperty property)
	{
		GetBindingExpression(property)?.UpdateTarget();
	}

	private void UpdatePixelStride()
	{
		if (_partTimelineItemsControl == null || _partTimelineItemsControl.ActualWidth <= 0.0)
		{
			_pixelStride = 0.0;
			return;
		}
		_pixelStride = VisibleDuration.TotalMilliseconds / _partTimelineItemsControl.ActualWidth;
		if (double.IsInfinity(_pixelStride))
		{
			_pixelStride = 0.0;
		}
	}

	private void UpdatePlayhead()
	{
		if (_updatingPlayhead)
		{
			return;
		}
		_updatingPlayhead = true;
		if (IsPlaying)
		{
			if (CurrentPlayheadTime >= Duration)
			{
				_updatingPlayhead = false;
				return;
			}
			if (CurrentPlayheadTime >= VisibleDurationStart + VisibleDuration)
			{
				VisibleDurationStart += VisibleDuration;
			}
			else if (CurrentPlayheadTime < VisibleDurationStart || CurrentPlayheadTime > VisibleDurationStart + VisibleDuration)
			{
				VisibleDurationStart = CurrentPlayheadTime;
			}
		}
		if (_partPlayheadMarker == null)
		{
			_updatingPlayhead = false;
		}
		else if (_pixelStride <= 0.0)
		{
			Canvas.SetLeft(_partPlayheadMarker, 0.0);
			_updatingPlayhead = false;
		}
		else
		{
			double length = (CurrentPlayheadTime - VisibleDurationStart).TotalMilliseconds / _pixelStride;
			Canvas.SetLeft(_partPlayheadMarker, length);
			_updatingPlayhead = false;
		}
	}

	private void UpdateRollingTimeSetWindow()
	{
		double num = ZoomValue / ActualDuration.TotalSeconds;
		TimeSlice timeSlice = ActualDuration * num;
		TimeSlice timeSlice2 = CurrentPlayheadTime - timeSlice / 2.0;
		if (timeSlice2 > TimeSlice.Zero && VisibleDurationStart + VisibleDuration < ActualDuration)
		{
			VisibleDurationStart = timeSlice2;
		}
		else if (timeSlice2 <= TimeSlice.Zero)
		{
			VisibleDurationStart = TimeSlice.Zero;
		}
		else if (timeSlice2 + timeSlice >= ActualDuration)
		{
			VisibleDurationStart = ActualDuration - timeSlice;
		}
		VisibleDuration = timeSlice;
	}

	private void Setup_TimelineItemsControl_MouseEvents(ItemsControl partTimelineItemsControl)
	{
		partTimelineItemsControl.MouseLeftButtonDown += PartTimelineItemsControl_MouseLeftButtonDown;
		partTimelineItemsControl.MouseMove += PartTimelineItemsControl_MouseMove;
		partTimelineItemsControl.MouseLeftButtonUp += PartTimelineItemsControl_MouseLeftButtonUp;
		_selectionBox = new TimelineSelectionBox(partTimelineItemsControl);
	}

	private void PartTimelineItemsControl_MouseLeftButtonDown(object? sender, MouseButtonEventArgs e)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		Focus();
		DependencyObject val = VisualTreeHelper.HitTest(_partTimelineItemsControl, e.GetPosition(_partTimelineItemsControl))?.VisualHit;
		if (e.ChangedButton == MouseButton.Left && !(e.Source is ContentPresenter) && val?.FindVisualParent<TimelineSection>() == null)
		{
			_partTimelineItemsControl?.CaptureMouse();
			_selectionMouseDownPos = (Vector2<double>)e.GetPosition(_partTimelineItemsControl);
		}
		else
		{
			_selectionMouseDownPos = null;
		}
	}

	private void PartTimelineItemsControl_MouseMove(object? sender, MouseEventArgs e)
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		if (_selectionMouseDownPos.HasValue && _partTimelineItemsControl != null && e.CanDrag(_partTimelineItemsControl, _selectionMouseDownPos.Value))
		{
			Rect<double> selectionBounds = GetSelectionBounds(_selectionMouseDownPos.Value, (Vector2<double>)e.GetPosition(_partTimelineItemsControl));
			UpdateSelectionBounds(selectionBounds);
			SelectItemsInBounds(selectionBounds);
		}
	}

	private void PartTimelineItemsControl_MouseLeftButtonUp(object? sender, MouseButtonEventArgs e)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		_partTimelineItemsControl?.ReleaseMouseCapture();
		DependencyObject val = VisualTreeHelper.HitTest(_partTimelineItemsControl, e.GetPosition(_partTimelineItemsControl))?.VisualHit;
		if (!_didAddSelectionBox)
		{
			ClearSelection(val);
		}
		HideSelectionBox();
		if (!_selectionMouseDownPos.HasValue)
		{
			val?.FindVisualParent<TimelineRow>()?.RaiseEvent(e);
		}
		_selectionMouseDownPos = null;
	}

	private void ClearSelection(DependencyObject? hitControl)
	{
		if (hitControl != null && hitControl.FindVisualParent<TimelineSection>() == null)
		{
			EnumerateAllSections(delegate(TimelineRow _, ITimelineItemVM _, TimelineSection section)
			{
				section.IsSelected = false;
			});
		}
	}

	private void UpdateSelectionBounds(Rect<double> bounds)
	{
		_selectionBox?.UpdateBounds(bounds);
		if (!_didAddSelectionBox)
		{
			this.AddAdorner(_selectionBox);
			_didAddSelectionBox = true;
		}
	}

	private void HideSelectionBox()
	{
		this.RemoveAdorner(_selectionBox);
		_didAddSelectionBox = false;
	}

	private Rect<double> GetSelectionBounds(Vector2<double> start, Vector2<double> current)
	{
		return new Rect<double>(start, new Vector2<double>(current.X.Clamp(0.0, _partTimelineItemsControl?.ActualWidth ?? 0.0), current.Y.Clamp(0.0, _partTimelineItemsControl?.ActualHeight ?? 0.0)) - start).Abs();
	}

	private void SelectItemsInBounds(Rect<double> selectionBounds)
	{
		SelectedItems?.Clear();
		EnumerateAllSections(delegate(TimelineRow row, ITimelineItemVM item, TimelineSection section)
		{
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			//IL_0023: Unknown result type (might be due to invalid IL or missing references)
			FrameworkElement frameworkElement = GetTargetElement(row, section) ?? section;
			Vector2<double> position = (Vector2<double>)frameworkElement.TranslatePoint(Vector2<double>.Zero, _partTimelineItemsControl);
			Vector2<double> size = new Vector2<double>(frameworkElement.ActualWidth, frameworkElement.ActualHeight);
			section.IsSelected = RectExtensions.Intersects(targetRect: new Rect<double>(position, size), sourceRect: selectionBounds);
			if (section.IsSelected)
			{
				SelectedItems?.Add(item);
			}
		});
	}

	private static FrameworkElement? GetTargetElement(TimelineRow row, FrameworkElement element)
	{
		if (row is ActionTimelineRow)
		{
			return ((DependencyObject)(object)element).FindVisualChild<ActionItemTemplate>();
		}
		return element;
	}

	private void EnumerateAllSections(Action<TimelineRow, ITimelineItemVM, TimelineSection> action)
	{
		IEnumerable<TimelineRow> rows = Rows;
		foreach (TimelineRow item in rows ?? Enumerable.Empty<TimelineRow>())
		{
			foreach (ITimelineItemVM item2 in item.Items.OfType<ITimelineItemVM>())
			{
				if (item.ItemContainerGenerator.ContainerFromItem(item2) is TimelineSection arg)
				{
					action(item, item2, arg);
				}
			}
		}
	}
}
