using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Operations;
using Pro.Common.Time;
using Pro.UI.Utility;
using ProPresenter.DO.Presentation;
using ProPresenter.UI.ViewModels.Timeline;

namespace ProPresenter.UI.PresentationView.PresentationTimeline;

[TemplatePart(Name = "PART_CurrentTimeToolTip", Type = typeof(Popup))]
public class TimelineSection : ContentControl
{
	private const string PART_CURRENT_TIME_TOOLTIP = "PART_CurrentTimeToolTip";

	private Popup? _currentTimeToolTip;

	private bool _isDragging;

	private TimeSlice _offsetTime;

	private Canvas? _parentCanvas;

	private TimelineRow? _parentRow;

	private double _xAnchor;

	public static readonly DependencyProperty AllowMoveProperty;

	public static readonly DependencyProperty AllowSelectProperty;

	public static readonly DependencyProperty CornerRadiusProperty;

	public static readonly DependencyProperty DurationProperty;

	public static readonly DependencyProperty FillToNextItemProperty;

	public static readonly DependencyProperty IndexProperty;

	public static readonly DependencyProperty IsSelectedProperty;

	public static readonly DependencyProperty ItemProperty;

	public static readonly DependencyProperty LabelProperty;

	public static readonly DependencyProperty StartTimeProperty;

	public bool AllowMove
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(AllowMoveProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AllowMoveProperty, (object)value);
		}
	}

	public bool AllowSelect
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(AllowSelectProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AllowSelectProperty, (object)value);
		}
	}

	public CornerRadius CornerRadius
	{
		get
		{
			return (CornerRadius)((DependencyObject)this).GetValue(CornerRadiusProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CornerRadiusProperty, (object)value);
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

	public bool FillToNextItem
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(FillToNextItemProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FillToNextItemProperty, (object)value);
		}
	}

	public int Index
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(IndexProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IndexProperty, (object)value);
		}
	}

	public bool IsSelected
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsSelectedProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsSelectedProperty, (object)value);
		}
	}

	public ITimelineItemVM Item
	{
		get
		{
			return (ITimelineItemVM)((DependencyObject)this).GetValue(ItemProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ItemProperty, (object)value);
		}
	}

	public string Label
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(LabelProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LabelProperty, (object)value);
		}
	}

	public TimeSlice StartTime
	{
		get
		{
			return (TimeSlice)((DependencyObject)this).GetValue(StartTimeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(StartTimeProperty, (object)value);
		}
	}

	public bool IsDragging => _isDragging;

	public event Action<TimelineSection>? IsSelectedChanged;

	public event Action? RefreshRequired;

	public event Action<TimelineSection, TimeSlice>? StartTimeChanged;

	private static object OnCoerceStartTimeProperty(DependencyObject d, object value)
	{
		if ((TimeSlice)value < TimeSlice.Zero)
		{
			return TimeSlice.Zero;
		}
		return value;
	}

	private static void OnDataContextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		TimelineSection timelineSection = (TimelineSection)(object)d;
		if (((DependencyPropertyChangedEventArgs)(ref e)).NewValue is ITimelineItemVM item)
		{
			timelineSection.Item = item;
		}
	}

	private static void OnIsSelectedPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		TimelineSection timelineSection = (TimelineSection)(object)d;
		timelineSection.IsSelectedChanged?.Invoke(timelineSection);
	}

	private static void OnItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		TimelineSection source = (TimelineSection)(object)d;
		if (((DependencyPropertyChangedEventArgs)(ref e)).NewValue is ITimelineItemVM bindingSource)
		{
			((DependencyObject?)(object)source).Bind(StartTimeProperty, bindingSource, "StartTime", BindingMode.Default, null, validatesOnNotifyDataError: true, 250);
			((DependencyObject?)(object)source).Bind(DurationProperty, bindingSource, "Duration");
			((DependencyObject?)(object)source).Bind(Control.BackgroundProperty, bindingSource, "Background");
			((DependencyObject?)(object)source).Bind(LabelProperty, bindingSource, "Name");
			((DependencyObject?)(object)source).Bind(FillToNextItemProperty, bindingSource, "FillToNextItem");
		}
	}

	static TimelineSection()
	{
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Expected O, but got Unknown
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Expected O, but got Unknown
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Expected O, but got Unknown
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0249: Expected O, but got Unknown
		AllowMoveProperty = DependencyProperty.Register("AllowMove", typeof(bool), typeof(TimelineSection), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));
		AllowSelectProperty = DependencyProperty.Register("AllowSelect", typeof(bool), typeof(TimelineSection), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));
		CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(TimelineSection));
		DurationProperty = DependencyProperty.Register("Duration", typeof(TimeSlice), typeof(TimelineSection), (PropertyMetadata)(object)new FrameworkPropertyMetadata(TimeSlice.Zero, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange, (PropertyChangedCallback)delegate(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((TimelineSection)(object)d).RefreshRequired?.Invoke();
		}));
		FillToNextItemProperty = DependencyProperty.Register("FillToNextItem", typeof(bool), typeof(TimelineSection), (PropertyMetadata)(object)new FrameworkPropertyMetadata((PropertyChangedCallback)delegate(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((TimelineSection)(object)d).RefreshRequired?.Invoke();
		}));
		IndexProperty = DependencyProperty.Register("Index", typeof(int), typeof(TimelineSection));
		IsSelectedProperty = DependencyProperty.Register("IsSelected", typeof(bool), typeof(TimelineSection), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnIsSelectedPropertyChanged)));
		ItemProperty = DependencyProperty.Register("Item", typeof(ITimelineItemVM), typeof(TimelineSection), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnItemPropertyChanged)));
		LabelProperty = DependencyProperty.Register("Label", typeof(string), typeof(TimelineSection));
		StartTimeProperty = DependencyProperty.Register("StartTime", typeof(TimeSlice), typeof(TimelineSection), (PropertyMetadata)(object)new FrameworkPropertyMetadata(TimeSlice.Zero, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange, null, new CoerceValueCallback(OnCoerceStartTimeProperty)));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(TimelineSection), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(TimelineSection)));
		Control.BackgroundProperty.OverrideMetadata(typeof(TimelineSection), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Brushes.CornflowerBlue));
		FrameworkElement.DataContextProperty.OverrideMetadata(typeof(TimelineSection), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnDataContextPropertyChanged)));
	}

	public TimelineSection()
	{
		base.Loaded += delegate
		{
			_parentRow?.RegisterEventHandlers(this);
			if (_parentCanvas != null)
			{
				base.Height = _parentCanvas.ActualHeight;
				_parentCanvas.SizeChanged += ParentCanvasOnSizeChanged;
			}
		};
		base.Unloaded += delegate
		{
			_parentRow?.UnRegisterEventHandlers(this);
			if (_parentCanvas != null)
			{
				_parentCanvas.SizeChanged -= ParentCanvasOnSizeChanged;
			}
		};
	}

	public void Initialize(TimelineRow row)
	{
		_parentRow = row;
	}

	public override void OnApplyTemplate()
	{
		_currentTimeToolTip = GetTemplateChild("PART_CurrentTimeToolTip") as Popup;
		_parentCanvas = ((DependencyObject)(object)this).FindVisualParent<Canvas>();
	}

	public override string ToString()
	{
		return $"{StartTime} - {StartTime + Duration} - {Item.GroupName}";
	}

	protected override void OnMouseDown(MouseButtonEventArgs e)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		Point position = e.GetPosition(_parentCanvas);
		_xAnchor = ((Point)(ref position)).X;
		Point position2 = e.GetPosition(this);
		_offsetTime = TimeSlice.FromMilliseconds(Math.Floor(((Point)(ref position2)).X * (_parentRow?.PixelStride ?? 1.0)));
		if (_currentTimeToolTip != null)
		{
			_currentTimeToolTip.IsOpen = true;
			_currentTimeToolTip.HorizontalOffset = ((Point)(ref position2)).X + 10.0;
			_currentTimeToolTip.VerticalOffset = ((Point)(ref position2)).Y + 10.0;
		}
		CaptureMouse();
		base.OnMouseDown(e);
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		if (!AllowMove || !base.IsMouseCaptured || e.LeftButton != MouseButtonState.Pressed)
		{
			return;
		}
		Point position = e.GetPosition(this);
		Point position2 = e.GetPosition(_parentCanvas);
		if (((Point)(ref position2)).X - _xAnchor != 0.0)
		{
			_isDragging = true;
			if (!IsSelected)
			{
				_parentRow?.ClearTimelineSelection();
				IsSelected = true;
			}
			TimeSlice timeSlice = TimeSlice.FromMilliseconds(Math.Floor(((Point)(ref position2)).X * (_parentRow?.PixelStride ?? 1.0))).Subtract(_offsetTime) + (_parentRow?.VisibleDurationStart ?? TimeSlice.Zero);
			TimeSlice delta = timeSlice - StartTime;
			TimeSlice? timeSlice2 = _parentRow?.CalculateTimeAdjustment(delta);
			if (timeSlice2.HasValue)
			{
				timeSlice += timeSlice2.Value;
			}
			if (timeSlice < TimeSlice.Zero)
			{
				timeSlice = TimeSlice.Zero;
			}
			this.StartTimeChanged?.Invoke(this, timeSlice - StartTime);
			if (_currentTimeToolTip != null)
			{
				_currentTimeToolTip.HorizontalOffset = ((Point)(ref position)).X + 10.0;
				_currentTimeToolTip.VerticalOffset = ((Point)(ref position)).Y;
			}
		}
		base.OnMouseMove(e);
	}

	protected override void OnMouseUp(MouseButtonEventArgs e)
	{
		if (_currentTimeToolTip != null)
		{
			_currentTimeToolTip.IsOpen = false;
		}
		if (_parentRow != null && !_isDragging)
		{
			ObservableCollection<ITimelineItemVM>? selectedItems = _parentRow.SelectedItems;
			if (selectedItems != null && selectedItems.Any() && !Keyboard.IsKeyDown((Key)118) && e.LeftButton == MouseButtonState.Released)
			{
				_parentRow.ClearSelection();
			}
		}
		if (AllowSelect && !_isDragging)
		{
			IsSelected = !IsSelected || !Keyboard.IsKeyDown((Key)118);
		}
		e.Handled = _isDragging;
		_isDragging = false;
		ReleaseMouseCapture();
		this.RefreshRequired?.Invoke();
	}

	internal void Update(TimelineSection? nextSection)
	{
		if (_parentRow == null || _parentRow.PixelStride <= 0.0 || !_parentRow.IsLoaded || !_parentRow.IsSectionVisible(this))
		{
			base.Width = 0.0;
			ITimelineItemVM item = Item;
			if (item != null && item.Item?.Item?.TimelineItemType == TimelineItemType.Actions)
			{
				base.Visibility = Visibility.Collapsed;
			}
			return;
		}
		ITimelineItemVM item2 = Item;
		if (item2 != null && item2.Item?.Item?.TimelineItemType == TimelineItemType.Actions)
		{
			base.Visibility = Visibility.Visible;
		}
		Panel.SetZIndex(this, Index);
		TimeSlice timeSlice = _parentRow.VisibleDurationStart + _parentRow.VisibleDuration;
		TimeSlice timeSlice2 = StartTime;
		TimeSlice timeSlice3 = (_parentRow.AllowFill ? ((nextSection?.StartTime - StartTime) ?? _parentRow.Duration) : ((nextSection != null && StartTime + Duration >= nextSection.StartTime) ? (nextSection.StartTime - StartTime) : ((!FillToNextItem) ? Duration : ((nextSection == null) ? _parentRow.Duration : (nextSection.StartTime - StartTime)))));
		if (!_parentRow.AllowDrawPastBounds)
		{
			if (StartTime <= _parentRow.VisibleDurationStart)
			{
				timeSlice2 = _parentRow.VisibleDurationStart;
				timeSlice3 -= _parentRow.VisibleDurationStart - StartTime;
			}
			if (timeSlice2 + timeSlice3 >= timeSlice)
			{
				timeSlice3 = timeSlice - timeSlice2;
			}
		}
		timeSlice2 -= _parentRow.VisibleDurationStart;
		double num = Math.Ceiling(timeSlice3.TotalMilliseconds / _parentRow.PixelStride);
		Canvas.SetTop(this, 0.0);
		Canvas.SetLeft(this, Math.Floor(timeSlice2.TotalMilliseconds / _parentRow.PixelStride));
		base.Width = ((num >= 0.0) ? num : 0.0);
	}

	private void ParentCanvasOnSizeChanged(object? sender, SizeChangedEventArgs e)
	{
		base.Height = _parentCanvas?.ActualHeight ?? 0.0;
	}
}
