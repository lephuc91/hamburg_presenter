using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Collections;
using Pro.Common.Mathematics;
using Pro.Common.Time;
using Pro.UI.Components;
using Pro.UI.Utility;
using ProPresenter.DO.Media;
using ProPresenter.UI.CueInspector;
using ProPresenter.UI.ViewModels.CueInspector;

namespace ProPresenter.UI;

[TemplatePart(Name = "PART_DurationFill", Type = typeof(FrameworkElement))]
[TemplatePart(Name = "PART_LoopedFill", Type = typeof(FrameworkElement))]
[TemplatePart(Name = "PART_ElapsedFill", Type = typeof(FrameworkElement))]
[TemplatePart(Name = "PART_InPointHandle", Type = typeof(FrameworkElement))]
[TemplatePart(Name = "PART_OutPointHandle", Type = typeof(FrameworkElement))]
[TemplatePart(Name = "PART_PlayheadHandle", Type = typeof(FrameworkElement))]
public class PlaybackScrubber : FrameworkElement
{
	private const string DurationFillName = "PART_DurationFill";

	private const string LoopedFillName = "PART_LoopedFill";

	private const string ElapsedFillName = "PART_ElapsedFill";

	private const string InPointHandleName = "PART_InPointHandle";

	private const string OutPointHandleName = "PART_OutPointHandle";

	private const string PlayheadHandleName = "PART_PlayheadHandle";

	private const double LoopedMarkerOpacity = 0.5;

	private readonly List<FrameworkElement?> _children = new List<FrameworkElement>();

	private readonly List<(IPlaybackMarkerItemVM source, List<FrameworkElement?> elements)> _markerCollection = new List<(IPlaybackMarkerItemVM, List<FrameworkElement>)>();

	private readonly List<FrameworkElement?> _loopPointElements = new List<FrameworkElement>();

	private bool _showPlayhead = true;

	private double _dragWidth;

	private Action<TimeSlice>? _dragHandler;

	private Action<TimeSlice>? _dragEnded;

	private IPlaybackMarkerItemVM? _draggedMarker;

	public static readonly DependencyProperty TriggeredMediaProperty = DependencyProperty.Register("TriggeredMedia", typeof(MediaBase), typeof(PlaybackScrubber), new PropertyMetadata((object)null, new PropertyChangedCallback(OnTriggeredMediaPropertyChanged)));

	public static readonly DependencyProperty PrimaryTemplateProperty = DependencyProperty.Register("PrimaryTemplate", typeof(FrameworkTemplate), typeof(PlaybackScrubber), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure, new PropertyChangedCallback(TemplateChanged)));

	public static readonly DependencyProperty MarkerTemplateProperty = DependencyProperty.Register("MarkerTemplate", typeof(FrameworkTemplate), typeof(PlaybackScrubber), (PropertyMetadata)(object)new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure, new PropertyChangedCallback(TemplateChanged)));

	public static readonly DependencyProperty LoopPointTemplateProperty = DependencyProperty.Register("LoopPointTemplate", typeof(FrameworkTemplate), typeof(PlaybackScrubber));

	public static readonly DependencyProperty MarkerContextMenuProperty = DependencyProperty.Register("MarkerContextMenu", typeof(ContextMenu), typeof(PlaybackScrubber), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(TemplateChanged)));

	public static readonly DependencyProperty TotalDurationProperty = DependencyProperty.Register("TotalDuration", typeof(TimeSlice), typeof(PlaybackScrubber), (PropertyMetadata)(object)new FrameworkPropertyMetadata(TimeSlice.Zero, FrameworkPropertyMetadataOptions.AffectsMeasure, new PropertyChangedCallback(LoopChanged)));

	public static readonly DependencyProperty LoopDurationProperty = DependencyProperty.Register("LoopDuration", typeof(TimeSlice), typeof(PlaybackScrubber), (PropertyMetadata)(object)new FrameworkPropertyMetadata(TimeSlice.Zero, FrameworkPropertyMetadataOptions.AffectsMeasure, new PropertyChangedCallback(LoopChanged)));

	public static readonly DependencyProperty PlayheadProperty = DependencyProperty.Register("Playhead", typeof(TimeSlice), typeof(PlaybackScrubber), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)TimeSlice.Zero, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	public static readonly DependencyProperty InPointProperty = DependencyProperty.Register("InPoint", typeof(TimeSlice), typeof(PlaybackScrubber), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)TimeSlice.Zero, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	public static readonly DependencyProperty OutPointProperty = DependencyProperty.Register("OutPoint", typeof(TimeSlice), typeof(PlaybackScrubber), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)TimeSlice.Zero, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	public static readonly DependencyProperty PlaybackMarkersProperty = DependencyProperty.Register("PlaybackMarkers", typeof(INotifyEnumerableChanged<IPlaybackMarkerItemVM>), typeof(PlaybackScrubber), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, new PropertyChangedCallback(MarkersChanged)));

	public static readonly DependencyProperty MarkerOffsetProperty = DependencyProperty.Register("MarkerOffset", typeof(TimeSlice), typeof(PlaybackScrubber), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)TimeSlice.Zero, FrameworkPropertyMetadataOptions.AffectsMeasure));

	public static readonly DependencyProperty BeginScrubCommandProperty = DependencyProperty.Register("BeginScrubCommand", typeof(ICommand<TimeSlice>), typeof(PlaybackScrubber));

	public static readonly DependencyProperty ScrubCommandProperty = DependencyProperty.Register("ScrubCommand", typeof(ICommand<TimeSlice>), typeof(PlaybackScrubber));

	public static readonly DependencyProperty EndScrubCommandProperty = DependencyProperty.Register("EndScrubCommand", typeof(ICommand<TimeSlice>), typeof(PlaybackScrubber));

	public static readonly DependencyProperty StartDragInPointCommandProperty = DependencyProperty.Register("StartDragInPointCommand", typeof(ICommand), typeof(PlaybackScrubber));

	public static readonly DependencyProperty StopDragInPointCommandProperty = DependencyProperty.Register("StopDragInPointCommand", typeof(ICommand), typeof(PlaybackScrubber));

	public static readonly DependencyProperty StartDragOutPointCommandProperty = DependencyProperty.Register("StartDragOutPointCommand", typeof(ICommand), typeof(PlaybackScrubber));

	public static readonly DependencyProperty StopDragOutPointCommandProperty = DependencyProperty.Register("StopDragOutPointCommand", typeof(ICommand), typeof(PlaybackScrubber));

	public static readonly DependencyProperty SelectMarkerCommandProperty = DependencyProperty.Register("SelectMarkerCommand", typeof(ICommand<IPlaybackMarkerItemVM>), typeof(PlaybackScrubber));

	public static readonly DependencyProperty SetContextMenuPositionCommandProperty = DependencyProperty.Register("SetContextMenuPositionCommand", typeof(ICommand<TimeSlice?>), typeof(PlaybackScrubber));

	protected FrameworkElement? TemplateChild { get; private set; }

	protected FrameworkElement? DurationFill { get; private set; }

	protected FrameworkElement? LoopedFill { get; private set; }

	protected FrameworkElement? ElapsedFill { get; private set; }

	protected FrameworkElement? InPointHandle { get; private set; }

	protected FrameworkElement? OutPointHandle { get; private set; }

	protected FrameworkElement? PlayheadHandle { get; private set; }

	protected override int VisualChildrenCount => _children.Count;

	protected bool IsLooping => LoopDuration > TimeSlice.Zero;

	protected TimeSlice LoopSectionDuration
	{
		get
		{
			if (!IsLooping)
			{
				return TotalDuration;
			}
			return MathHelper.Min(LoopDuration, TotalDuration);
		}
	}

	protected int LoopCount
	{
		get
		{
			if (!IsLooping)
			{
				return 1;
			}
			return Math.Max((int)Math.Ceiling(TotalDuration / LoopSectionDuration), 1);
		}
	}

	public FrameworkTemplate PrimaryTemplate
	{
		get
		{
			return (FrameworkTemplate)((DependencyObject)this).GetValue(PrimaryTemplateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PrimaryTemplateProperty, (object)value);
		}
	}

	public FrameworkTemplate MarkerTemplate
	{
		get
		{
			return (FrameworkTemplate)((DependencyObject)this).GetValue(MarkerTemplateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MarkerTemplateProperty, (object)value);
		}
	}

	public FrameworkTemplate LoopPointTemplate
	{
		get
		{
			return (FrameworkTemplate)((DependencyObject)this).GetValue(LoopPointTemplateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LoopPointTemplateProperty, (object)value);
		}
	}

	public ContextMenu MarkerContextMenu
	{
		get
		{
			return (ContextMenu)((DependencyObject)this).GetValue(MarkerContextMenuProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MarkerContextMenuProperty, (object)value);
		}
	}

	public TimeSlice TotalDuration
	{
		get
		{
			return (TimeSlice)((DependencyObject)this).GetValue(TotalDurationProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TotalDurationProperty, (object)value);
		}
	}

	public TimeSlice LoopDuration
	{
		get
		{
			return (TimeSlice)((DependencyObject)this).GetValue(LoopDurationProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LoopDurationProperty, (object)value);
		}
	}

	public TimeSlice Playhead
	{
		get
		{
			return (TimeSlice)((DependencyObject)this).GetValue(PlayheadProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PlayheadProperty, (object)value);
		}
	}

	public TimeSlice InPoint
	{
		get
		{
			return (TimeSlice)((DependencyObject)this).GetValue(InPointProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(InPointProperty, (object)value);
		}
	}

	public TimeSlice OutPoint
	{
		get
		{
			return (TimeSlice)((DependencyObject)this).GetValue(OutPointProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(OutPointProperty, (object)value);
		}
	}

	public INotifyEnumerableChanged<IPlaybackMarkerItemVM> PlaybackMarkers
	{
		get
		{
			return (INotifyEnumerableChanged<IPlaybackMarkerItemVM>)((DependencyObject)this).GetValue(PlaybackMarkersProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PlaybackMarkersProperty, (object)value);
		}
	}

	public TimeSlice MarkerOffset
	{
		get
		{
			return (TimeSlice)((DependencyObject)this).GetValue(MarkerOffsetProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MarkerOffsetProperty, (object)value);
		}
	}

	public ICommand<TimeSlice> BeginScrubCommand
	{
		get
		{
			return (ICommand<TimeSlice>)((DependencyObject)this).GetValue(BeginScrubCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(BeginScrubCommandProperty, (object)value);
		}
	}

	public ICommand<TimeSlice> ScrubCommand
	{
		get
		{
			return (ICommand<TimeSlice>)((DependencyObject)this).GetValue(ScrubCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ScrubCommandProperty, (object)value);
		}
	}

	public ICommand<TimeSlice> EndScrubCommand
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

	public ICommand StartDragInPointCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(StartDragInPointCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(StartDragInPointCommandProperty, (object)value);
		}
	}

	public ICommand StopDragInPointCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(StopDragInPointCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(StopDragInPointCommandProperty, (object)value);
		}
	}

	public ICommand StartDragOutPointCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(StartDragOutPointCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(StartDragOutPointCommandProperty, (object)value);
		}
	}

	public ICommand StopDragOutPointCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(StopDragOutPointCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(StopDragOutPointCommandProperty, (object)value);
		}
	}

	public ICommand<IPlaybackMarkerItemVM> SelectMarkerCommand
	{
		get
		{
			return (ICommand<IPlaybackMarkerItemVM>)((DependencyObject)this).GetValue(SelectMarkerCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectMarkerCommandProperty, (object)value);
		}
	}

	public ICommand<TimeSlice?> SetContextMenuPositionCommand
	{
		get
		{
			return (ICommand<TimeSlice?>)((DependencyObject)this).GetValue(SetContextMenuPositionCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SetContextMenuPositionCommandProperty, (object)value);
		}
	}

	public MediaBase TriggeredMedia
	{
		get
		{
			return (MediaBase)((DependencyObject)this).GetValue(TriggeredMediaProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TriggeredMediaProperty, (object)value);
		}
	}

	public PlaybackScrubber()
	{
		base.MouseUp += delegate
		{
			Focus();
		};
	}

	private static void TemplateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		(d as PlaybackScrubber)?.ApplyTemplates();
	}

	private static void MarkersChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		(d as PlaybackScrubber)?.UpdateMarkers(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as INotifyEnumerableChanged<IPlaybackMarkerItemVM>, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as INotifyEnumerableChanged<IPlaybackMarkerItemVM>);
	}

	private static void LoopChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		(d as PlaybackScrubber)?.UpdateLoopedMarkers();
	}

	private static void OnTriggeredMediaPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (!(d is PlaybackScrubber playbackScrubber))
		{
			return;
		}
		foreach (IPlaybackMarkerItemVM playbackMarker in playbackScrubber.PlaybackMarkers)
		{
			playbackMarker.PlaybackMarkerTooltip = playbackScrubber.GetPlaybackMarkerTooltip(playbackMarker);
		}
	}

	protected override Visual? GetVisualChild(int index)
	{
		return _children[index];
	}

	protected override void OnContextMenuOpening(ContextMenuEventArgs e)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		base.OnContextMenuOpening(e);
		TimeSlice timeSlice;
		if (!(_dragWidth > 0.0))
		{
			timeSlice = TimeSlice.Zero;
		}
		else
		{
			TimeSlice totalDuration = TotalDuration;
			Point position = Mouse.GetPosition(this);
			timeSlice = totalDuration * (((Point)(ref position)).X / _dragWidth);
		}
		TimeSlice value = timeSlice;
		if (IsLooping)
		{
			value %= LoopSectionDuration;
		}
		SetContextMenuPositionCommand?.Invoke(value);
	}

	protected override void OnContextMenuClosing(ContextMenuEventArgs e)
	{
		base.OnContextMenuClosing(e);
		SetContextMenuPositionCommand?.Invoke(null);
	}

	private void AddChild(FrameworkElement? child)
	{
		if (child != null)
		{
			_children.Add(child);
			AddLogicalChild(child);
			AddVisualChild(child);
		}
	}

	private void RemoveChild(FrameworkElement? child)
	{
		if (child != null)
		{
			_children.Remove(child);
			RemoveLogicalChild(child);
			RemoveVisualChild(child);
		}
	}

	private void ApplyTemplates()
	{
		if (InPointHandle != null)
		{
			InPointHandle.MouseLeftButtonDown -= InPointHandle_OnMouseLeftButtonDown;
			InPointHandle.MouseMove -= Drag_OnMouseMove;
			InPointHandle.MouseLeftButtonUp -= Drag_OnMouseLeftButtonUp;
		}
		if (OutPointHandle != null)
		{
			OutPointHandle.MouseLeftButtonDown -= OutPointHandle_OnMouseLeftButtonDown;
			OutPointHandle.MouseMove -= Drag_OnMouseMove;
			OutPointHandle.MouseLeftButtonUp -= Drag_OnMouseLeftButtonUp;
		}
		if (PlayheadHandle != null)
		{
			PlayheadHandle.MouseLeftButtonDown -= PlayheadHandle_OnMouseLeftButtonDown;
			PlayheadHandle.MouseMove -= Drag_OnMouseMove;
			PlayheadHandle.MouseLeftButtonUp -= Drag_OnMouseLeftButtonUp;
		}
		RemoveChild(TemplateChild);
		TemplateChild = PrimaryTemplate?.LoadContent() as FrameworkElement;
		AddChild(TemplateChild);
		DurationFill = FindTemplatePart("PART_DurationFill");
		LoopedFill = FindTemplatePart("PART_LoopedFill");
		ElapsedFill = FindTemplatePart("PART_ElapsedFill");
		InPointHandle = FindTemplatePart("PART_InPointHandle");
		OutPointHandle = FindTemplatePart("PART_OutPointHandle");
		PlayheadHandle = FindTemplatePart("PART_PlayheadHandle");
		if (InPointHandle != null)
		{
			InPointHandle.MouseLeftButtonDown += InPointHandle_OnMouseLeftButtonDown;
			InPointHandle.MouseMove += Drag_OnMouseMove;
			InPointHandle.MouseLeftButtonUp += Drag_OnMouseLeftButtonUp;
		}
		if (OutPointHandle != null)
		{
			OutPointHandle.MouseLeftButtonDown += OutPointHandle_OnMouseLeftButtonDown;
			OutPointHandle.MouseMove += Drag_OnMouseMove;
			OutPointHandle.MouseLeftButtonUp += Drag_OnMouseLeftButtonUp;
		}
		if (PlayheadHandle != null)
		{
			PlayheadHandle.MouseLeftButtonDown += PlayheadHandle_OnMouseLeftButtonDown;
			PlayheadHandle.MouseMove += Drag_OnMouseMove;
			PlayheadHandle.MouseLeftButtonUp += Drag_OnMouseLeftButtonUp;
		}
		UpdateMarkers(null, null);
	}

	private FrameworkElement? FindTemplatePart(string name)
	{
		return ((DependencyObject)(object)this).FindVisualChild((FrameworkElement e) => e.Name == name);
	}

	private void UpdateMarkers(INotifyEnumerableChanged<IPlaybackMarkerItemVM>? oldCollection, INotifyEnumerableChanged<IPlaybackMarkerItemVM>? newCollection)
	{
		if (oldCollection != null)
		{
			oldCollection.CollectionChanged -= PlaybackMarkers_CollectionChanged;
		}
		_markerCollection.Select<(IPlaybackMarkerItemVM, List<FrameworkElement>), IPlaybackMarkerItemVM>(((IPlaybackMarkerItemVM source, List<FrameworkElement> elements) m) => m.source).ToArray().ForEach(RemoveMarker);
		_markerCollection.Clear();
		if (newCollection != null)
		{
			newCollection.CollectionChanged += PlaybackMarkers_CollectionChanged;
		}
		PlaybackMarkers?.ForEach(AddMarker);
	}

	private void PlaybackMarkers_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		switch (e.Action)
		{
		case NotifyCollectionChangedAction.Reset:
			_markerCollection.Select<(IPlaybackMarkerItemVM, List<FrameworkElement>), IPlaybackMarkerItemVM>(((IPlaybackMarkerItemVM source, List<FrameworkElement> elements) m) => m.source).ToArray().ForEach(RemoveMarker);
			_markerCollection.Clear();
			break;
		case NotifyCollectionChangedAction.Remove:
			e.OldItems?.OfType<IPlaybackMarkerItemVM>().ForEach(RemoveMarker);
			break;
		case NotifyCollectionChangedAction.Add:
			e.NewItems?.OfType<IPlaybackMarkerItemVM>().ForEach(AddMarker);
			break;
		}
		SortMarkerElements();
	}

	private void UpdateLoopedMarkers()
	{
		int loopCount = LoopCount;
		foreach (var (source, list) in _markerCollection)
		{
			while (list.Count > loopCount)
			{
				int index = list.Count - 1;
				RemoveMarkerElement(list[index]);
				list.RemoveAt(index);
			}
			for (int i = list.Count; i < LoopCount; i++)
			{
				list.Add(AddMarkerElement(source, i > 0));
			}
		}
		int num = Math.Max(loopCount - 1, 0);
		while (_loopPointElements.Count > num)
		{
			int index2 = _loopPointElements.Count - 1;
			RemoveChild(_loopPointElements[index2]);
			_loopPointElements.RemoveAt(index2);
		}
		while (_loopPointElements.Count < num)
		{
			FrameworkElement frameworkElement = LoopPointTemplate?.LoadContent() as FrameworkElement;
			AddChild(frameworkElement);
			_loopPointElements.Add(frameworkElement);
		}
		SortMarkerElements();
	}

	private void RemoveMarker(IPlaybackMarkerItemVM source)
	{
		if (source != null)
		{
			int num = _markerCollection.FindIndex(((IPlaybackMarkerItemVM source, List<FrameworkElement?> elements) m) => m.source == source);
			if (num >= 0)
			{
				source.PropertyChanged -= MarkerPropertyChanged;
				_markerCollection[num].elements.ForEach(RemoveMarkerElement);
				_markerCollection.RemoveAt(num);
			}
		}
	}

	private void RemoveMarkerElement(FrameworkElement? element)
	{
		if (element != null)
		{
			element.DataContext = null;
			element.ContextMenu = null;
			element.ContextMenuOpening -= Marker_OnContextMenuOpening;
			element.MouseLeftButtonDown -= Marker_OnMouseLeftButtonDown;
			element.MouseMove -= Drag_OnMouseMove;
			element.MouseLeftButtonUp -= Drag_OnMouseLeftButtonUp;
			RemoveChild(element);
		}
	}

	private void AddMarker(IPlaybackMarkerItemVM source)
	{
		if (source != null)
		{
			List<FrameworkElement> list = new List<FrameworkElement>();
			for (int i = 0; i < LoopCount; i++)
			{
				list.Add(AddMarkerElement(source, i > 0));
			}
			_markerCollection.Add((source, list));
			source.PropertyChanged += MarkerPropertyChanged;
		}
	}

	private FrameworkElement? AddMarkerElement(IPlaybackMarkerItemVM source, bool isLooped)
	{
		if (!(MarkerTemplate?.LoadContent() is FrameworkElement frameworkElement))
		{
			return null;
		}
		frameworkElement.DataContext = source;
		source.PlaybackMarkerTooltip = GetPlaybackMarkerTooltip(source);
		TextBlock textBlock = new TextBlock
		{
			TextWrapping = TextWrapping.Wrap,
			MaxWidth = 260.0
		};
		textBlock.SetBinding(TextBlock.TextProperty, new Binding
		{
			Path = new PropertyPath("PlaybackMarkerTooltip"),
			Mode = BindingMode.OneWay
		});
		frameworkElement.ToolTip = new ToolTip
		{
			Content = textBlock
		};
		if (!isLooped)
		{
			if (MarkerContextMenu != null)
			{
				frameworkElement.ContextMenu = MarkerContextMenu;
				frameworkElement.ContextMenuOpening += Marker_OnContextMenuOpening;
			}
			frameworkElement.MouseLeftButtonDown += Marker_OnMouseLeftButtonDown;
			frameworkElement.MouseMove += Drag_OnMouseMove;
			frameworkElement.MouseLeftButtonUp += Drag_OnMouseLeftButtonUp;
		}
		else
		{
			frameworkElement.IsEnabled = false;
			frameworkElement.IsHitTestVisible = false;
			frameworkElement.Opacity = 0.5;
		}
		AddChild(frameworkElement);
		return frameworkElement;
	}

	private string GetPlaybackMarkerTooltip(IPlaybackMarkerItemVM source)
	{
		return TimeToStringFormatter.PlaybackMarkerTimestampToString(source.Timestamp, TriggeredMedia, MarkerOffset) + " " + source.Name;
	}

	private void MarkerPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		string propertyName = e.PropertyName;
		if (propertyName == "Name" || propertyName == "Timestamp")
		{
			if (sender is IPlaybackMarkerItemVM playbackMarkerItemVM)
			{
				playbackMarkerItemVM.PlaybackMarkerTooltip = GetPlaybackMarkerTooltip(playbackMarkerItemVM);
			}
			InvalidateArrange();
		}
	}

	private void SortMarkerElements()
	{
		_markerCollection.Sort(((IPlaybackMarkerItemVM source, List<FrameworkElement?> elements) lhs, (IPlaybackMarkerItemVM source, List<FrameworkElement?> elements) rhs) => getTimestamp(lhs.source).CompareTo(getTimestamp(rhs.source)));
		_markerCollection.ForEach(delegate((IPlaybackMarkerItemVM source, List<FrameworkElement?> elements) m)
		{
			m.elements.ForEach(RemoveChild);
		});
		_markerCollection.ForEach(delegate((IPlaybackMarkerItemVM source, List<FrameworkElement?> elements) m)
		{
			m.elements.ForEach(AddChild);
		});
		InvalidateMeasure();
		TimeSlice getTimestamp(IPlaybackMarkerItemVM source)
		{
			if (source != _draggedMarker)
			{
				return source.Timestamp;
			}
			return TimeSlice.MaxValue;
		}
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		TemplateChild?.Measure(availableSize);
		_markerCollection.ForEach(delegate((IPlaybackMarkerItemVM source, List<FrameworkElement?> elements) m)
		{
			m.elements.ForEach(delegate(FrameworkElement? e)
			{
				//IL_0012: Unknown result type (might be due to invalid IL or missing references)
				e?.Measure(new Vector2<double>(double.PositiveInfinity));
			});
		});
		_loopPointElements.ForEach(delegate(FrameworkElement? e)
		{
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			e?.Measure(new Vector2<double>(double.PositiveInfinity));
		});
		double x;
		Size desiredSize;
		if (!((Size)(ref availableSize)).Width.IsReal())
		{
			FrameworkElement? templateChild = TemplateChild;
			if (templateChild == null)
			{
				x = 0.0;
			}
			else
			{
				desiredSize = templateChild.DesiredSize;
				x = ((Size)(ref desiredSize)).Width;
			}
		}
		else
		{
			x = ((Size)(ref availableSize)).Width;
		}
		double y;
		if (!((Size)(ref availableSize)).Height.IsReal())
		{
			FrameworkElement? templateChild2 = TemplateChild;
			if (templateChild2 == null)
			{
				y = 0.0;
			}
			else
			{
				desiredSize = templateChild2.DesiredSize;
				y = ((Size)(ref desiredSize)).Height;
			}
		}
		else
		{
			y = ((Size)(ref availableSize)).Height;
		}
		return new Vector2<double>(x, y);
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0486: Unknown result type (might be due to invalid IL or missing references)
		//IL_0450: Unknown result type (might be due to invalid IL or missing references)
		//IL_045f: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e4: Unknown result type (might be due to invalid IL or missing references)
		TemplateChild?.Arrange(new Rect<double>((Vector2<double>)finalSize));
		bool isLooping = IsLooping;
		TimeSlice totalDuration = TotalDuration;
		TimeSlice loopSectionDuration = LoopSectionDuration;
		int loopCount = LoopCount;
		TimeSlice timeSlice = InPoint.Clamp(TimeSlice.Zero, OutPoint);
		TimeSlice timeSlice2 = OutPoint.Clamp(InPoint, loopSectionDuration);
		TimeSlice timeSlice3 = Playhead.Clamp(TimeSlice.Zero, totalDuration);
		double width = ((Size)(ref finalSize)).Width;
		double num = width / ((totalDuration > TimeSlice.Zero && loopSectionDuration > TimeSlice.Zero) ? (totalDuration / loopSectionDuration) : 1.0);
		if (DurationFill != null)
		{
			if (loopSectionDuration > TimeSlice.Zero)
			{
				DurationFill.Visibility = Visibility.Visible;
				DurationFill.Width = MathHelper.Max(num * ((timeSlice2 - timeSlice) / loopSectionDuration), 0.0);
				Canvas.SetLeft(DurationFill, num * (timeSlice / loopSectionDuration));
			}
			else
			{
				DurationFill.Visibility = Visibility.Collapsed;
			}
		}
		if (LoopedFill != null)
		{
			if (isLooping && loopCount > 1)
			{
				LoopedFill.Visibility = Visibility.Visible;
				LoopedFill.Width = MathHelper.Max(width - num, 0.0);
				Canvas.SetLeft(LoopedFill, num);
			}
			else
			{
				LoopedFill.Visibility = Visibility.Collapsed;
			}
		}
		if (ElapsedFill != null)
		{
			if (totalDuration > TimeSlice.Zero)
			{
				ElapsedFill.Visibility = Visibility.Visible;
				ElapsedFill.Width = MathHelper.Max(width * (MathHelper.Max(isLooping ? (timeSlice3 - timeSlice) : MathHelper.Min(timeSlice3 - timeSlice, timeSlice2 - timeSlice), TimeSlice.Zero) / totalDuration), 0.0);
				Canvas.SetLeft(ElapsedFill, width * (timeSlice / totalDuration));
			}
			else
			{
				ElapsedFill.Visibility = Visibility.Collapsed;
			}
		}
		if (InPointHandle != null)
		{
			if (loopSectionDuration > TimeSlice.Zero)
			{
				InPointHandle.Visibility = Visibility.Visible;
				Canvas.SetLeft(InPointHandle, num * (timeSlice / loopSectionDuration));
			}
			else
			{
				InPointHandle.Visibility = Visibility.Collapsed;
			}
		}
		if (OutPointHandle != null)
		{
			if (loopSectionDuration > TimeSlice.Zero)
			{
				OutPointHandle.Visibility = Visibility.Visible;
				Canvas.SetLeft(OutPointHandle, num * (timeSlice2 / loopSectionDuration));
			}
			else
			{
				OutPointHandle.Visibility = Visibility.Collapsed;
			}
		}
		if (PlayheadHandle != null)
		{
			if (_showPlayhead && totalDuration > TimeSlice.Zero)
			{
				PlayheadHandle.Visibility = Visibility.Visible;
				Canvas.SetLeft(PlayheadHandle, width * (timeSlice3 / totalDuration));
			}
			else
			{
				PlayheadHandle.Visibility = Visibility.Collapsed;
			}
		}
		foreach (var item3 in _markerCollection)
		{
			IPlaybackMarkerItemVM item = item3.source;
			List<FrameworkElement> item2 = item3.elements;
			TimeSlice timeSlice4 = item.Timestamp - MarkerOffset;
			bool flag = timeSlice4 >= TimeSlice.Zero && timeSlice4 <= loopSectionDuration;
			for (int i = 0; i < item2.Count; i++)
			{
				FrameworkElement frameworkElement = item2[i];
				if (frameworkElement != null)
				{
					TimeSlice timeSlice5 = item.Timestamp - MarkerOffset + loopSectionDuration * i;
					if (!flag || totalDuration <= TimeSlice.Zero || timeSlice5 < TimeSlice.Zero || timeSlice5 > totalDuration)
					{
						frameworkElement.Visibility = Visibility.Collapsed;
						continue;
					}
					frameworkElement.Visibility = Visibility.Visible;
					frameworkElement.Arrange(new Rect<double>(new Vector2<double>(width * (timeSlice5 / totalDuration), 0.0), (Vector2<double>)frameworkElement.DesiredSize));
				}
			}
		}
		for (int j = 0; j < _loopPointElements.Count; j++)
		{
			FrameworkElement frameworkElement2 = _loopPointElements[j];
			frameworkElement2?.Arrange(new Rect<double>(new Vector2<double>(num * (double)(j + 1), 0.0), (Vector2<double>)frameworkElement2.DesiredSize));
		}
		_dragWidth = width;
		return finalSize;
	}

	private void Marker_OnContextMenuOpening(object? sender, ContextMenuEventArgs e)
	{
		if (sender is FrameworkElement { DataContext: IPlaybackMarkerItemVM dataContext })
		{
			SelectMarkerCommand?.Invoke(dataContext);
		}
	}

	private void InPointHandle_OnMouseLeftButtonDown(object? sender, MouseButtonEventArgs e)
	{
		Drag_OnMouseLeftButtonDown(e, InPointHandle, delegate(TimeSlice v)
		{
			TimeSlice timeSlice = clamp(v);
			((DependencyObject)this).SetCurrentValue(InPointProperty, (object)timeSlice);
			((DependencyObject)this).SetCurrentValue(PlayheadProperty, (object)timeSlice);
			ScrubCommand?.Invoke(timeSlice);
		}, delegate(TimeSlice v)
		{
			TimeSlice timeSlice2 = clamp(v);
			((DependencyObject)this).SetCurrentValue(PlayheadProperty, (object)timeSlice2);
			BeginScrubCommand?.Invoke(timeSlice2);
			StartDragInPointCommand?.Invoke();
			_showPlayhead = false;
			InvalidateArrange();
		}, delegate(TimeSlice v)
		{
			TimeSlice timeSlice3 = clamp(v);
			((DependencyObject)this).SetCurrentValue(PlayheadProperty, (object)timeSlice3);
			EndScrubCommand?.Invoke(timeSlice3);
			StopDragInPointCommand?.Invoke();
			_showPlayhead = true;
			InvalidateArrange();
		});
		TimeSlice clamp(TimeSlice target)
		{
			return target.Clamp(TimeSlice.Zero, OutPoint);
		}
	}

	private void OutPointHandle_OnMouseLeftButtonDown(object? sender, MouseButtonEventArgs e)
	{
		Drag_OnMouseLeftButtonDown(e, OutPointHandle, delegate(TimeSlice v)
		{
			TimeSlice timeSlice = clamp(v);
			((DependencyObject)this).SetCurrentValue(OutPointProperty, (object)timeSlice);
			((DependencyObject)this).SetCurrentValue(PlayheadProperty, (object)timeSlice);
			ScrubCommand?.Invoke(timeSlice);
		}, delegate(TimeSlice v)
		{
			TimeSlice timeSlice2 = clamp(v);
			((DependencyObject)this).SetCurrentValue(PlayheadProperty, (object)timeSlice2);
			BeginScrubCommand?.Invoke(timeSlice2);
			StartDragOutPointCommand?.Invoke();
			_showPlayhead = false;
			InvalidateArrange();
		}, delegate(TimeSlice v)
		{
			TimeSlice timeSlice3 = clamp(v);
			((DependencyObject)this).SetCurrentValue(PlayheadProperty, (object)timeSlice3);
			EndScrubCommand?.Invoke(timeSlice3);
			StopDragOutPointCommand?.Invoke();
			_showPlayhead = true;
			InvalidateArrange();
		});
		TimeSlice clamp(TimeSlice target)
		{
			return target.Clamp(InPoint, LoopSectionDuration);
		}
	}

	private void Marker_OnMouseLeftButtonDown(object? sender, MouseButtonEventArgs e)
	{
		FrameworkElement element = sender as FrameworkElement;
		if (element == null)
		{
			return;
		}
		IPlaybackMarkerItemVM source = _markerCollection.FirstOrDefault<(IPlaybackMarkerItemVM, List<FrameworkElement>)>(((IPlaybackMarkerItemVM source, List<FrameworkElement> elements) m) => m.elements.Contains(element)).Item1;
		if (source != null)
		{
			Drag_OnMouseLeftButtonDown(e, element, delegate(TimeSlice v)
			{
				source.Timestamp = v.Clamp(TimeSlice.Zero, LoopSectionDuration) + MarkerOffset;
			}, delegate
			{
				source.StartDragCommand?.Invoke();
				_draggedMarker = source;
				SortMarkerElements();
			}, delegate
			{
				source.StopDragCommand?.Invoke();
				_draggedMarker = null;
				SortMarkerElements();
			});
		}
	}

	private void PlayheadHandle_OnMouseLeftButtonDown(object? sender, MouseButtonEventArgs e)
	{
		Drag_OnMouseLeftButtonDown(e, PlayheadHandle, delegate(TimeSlice v)
		{
			((DependencyObject)this).SetCurrentValue(PlayheadProperty, (object)v);
			ScrubCommand?.Invoke(v);
		}, delegate(TimeSlice v)
		{
			((DependencyObject)this).SetCurrentValue(PlayheadProperty, (object)v);
			BeginScrubCommand?.Invoke(v);
		}, delegate(TimeSlice v)
		{
			((DependencyObject)this).SetCurrentValue(PlayheadProperty, (object)v);
			EndScrubCommand?.Invoke(v);
		});
	}

	protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
	{
		PlayheadHandle_OnMouseLeftButtonDown(this, e);
	}

	private TimeSlice GetMouseTarget(MouseEventArgs e)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return (TotalDuration * (((Vector2<double>)e.GetPosition(this)).X / _dragWidth)).Clamp(TimeSlice.Zero, TotalDuration);
	}

	private void Drag_OnMouseLeftButtonDown(MouseButtonEventArgs e, FrameworkElement? element, Action<TimeSlice>? dragHandler = null, Action<TimeSlice>? dragStarted = null, Action<TimeSlice>? dragEnded = null)
	{
		if (_dragWidth > 0.0 && e.OriginalSource is UIElement { IsMouseCaptured: false })
		{
			_dragHandler = dragHandler;
			_dragEnded = dragEnded;
			dragStarted?.Invoke(GetMouseTarget(e));
			element?.CaptureMouse();
		}
	}

	private void Drag_OnMouseMove(object? sender, MouseEventArgs e)
	{
		if (e.OriginalSource is UIElement { IsMouseCaptured: not false })
		{
			_dragHandler?.Invoke(GetMouseTarget(e));
		}
	}

	private void Drag_OnMouseLeftButtonUp(object? sender, MouseButtonEventArgs e)
	{
		if (e.OriginalSource is UIElement { IsMouseCaptured: not false } uIElement)
		{
			uIElement.ReleaseMouseCapture();
			_dragEnded?.Invoke(GetMouseTarget(e));
			_dragHandler = null;
			_dragEnded = null;
		}
	}
}
