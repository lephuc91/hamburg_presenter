using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Pro.Common.Operations;
using Pro.Common.Time;

namespace ProPresenter.UI.PresentationView.PresentationTimeline;

[TemplatePart(Name = "PART_Track", Type = typeof(Canvas))]
[TemplatePart(Name = "PART_Thumb", Type = typeof(Border))]
public class TimelineScrollBar : Control
{
	private const string PART_THUMB = "PART_Thumb";

	private const string PART_TRACK = "PART_Track";

	private static readonly double SCROLL_LARGE_INCREMENT;

	private TimeSlice _offsetTime;

	private Border? _partThumb;

	private Canvas? _partTrack;

	private double _pixelStride;

	private TimeSlice _scrollDelta;

	private double _xAnchor;

	private static readonly DependencyPropertyKey _isMouseOverThumbPropertyKey;

	public static readonly DependencyProperty DurationProperty;

	public static readonly DependencyProperty IsMouseOverThumbProperty;

	public static readonly DependencyProperty VisibleDurationProperty;

	public static readonly DependencyProperty VisibleDurationStartProperty;

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

	public bool IsMouseOverThumb
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsMouseOverThumbProperty);
		}
		private set
		{
			((DependencyObject)this).SetValue(_isMouseOverThumbPropertyKey, (object)value);
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

	static TimelineScrollBar()
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Expected O, but got Unknown
		SCROLL_LARGE_INCREMENT = 25.0;
		_isMouseOverThumbPropertyKey = DependencyProperty.RegisterReadOnly("IsMouseOverThumb", typeof(bool), typeof(TimelineScrollBar), new PropertyMetadata());
		DurationProperty = DependencyProperty.Register("Duration", typeof(TimeSlice), typeof(TimelineScrollBar), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnDurationPropertyChanged)));
		IsMouseOverThumbProperty = _isMouseOverThumbPropertyKey.DependencyProperty;
		VisibleDurationProperty = DependencyProperty.Register("VisibleDuration", typeof(TimeSlice), typeof(TimelineScrollBar), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnVisibleDurationPropertyChanged)));
		VisibleDurationStartProperty = DependencyProperty.Register("VisibleDurationStart", typeof(TimeSlice), typeof(TimelineScrollBar), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnVisibleDurationStartPropertyChanged)));
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(TimelineScrollBar), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(TimelineScrollBar)));
	}

	public TimelineScrollBar()
	{
		base.Loaded += delegate
		{
			UpdatePixelStride();
			UpdateThumb();
		};
		base.SizeChanged += delegate
		{
			UpdatePixelStride();
			UpdateThumb();
		};
	}

	public void DecrementScroll()
	{
		TimeSlice scrollDelta = _scrollDelta;
		scrollDelta = VisibleDurationStart - scrollDelta;
		scrollDelta = RestrictToBounds(scrollDelta);
		VisibleDurationStart = scrollDelta;
	}

	public void IncrementScroll()
	{
		TimeSlice scrollDelta = _scrollDelta;
		scrollDelta = VisibleDurationStart + scrollDelta;
		scrollDelta = RestrictToBounds(scrollDelta);
		VisibleDurationStart = scrollDelta;
	}

	public override void OnApplyTemplate()
	{
		_partTrack = GetTemplateChild("PART_Track") as Canvas;
		_partThumb = GetTemplateChild("PART_Thumb") as Border;
		if (_partTrack != null)
		{
			_partTrack.PreviewMouseUp += PartTrackOnPreviewMouseUp;
		}
		if (_partThumb != null)
		{
			_partThumb.MouseEnter += PartThumbOnMouseEnter;
			_partThumb.MouseLeave += PartThumbOnMouseLeave;
			_partThumb.PreviewMouseDown += PartThumbOnPreviewMouseDown;
			_partThumb.PreviewMouseMove += PartThumbOnPreviewMouseMove;
			_partThumb.PreviewMouseUp += PartThumbOnPreviewMouseUp;
		}
	}

	protected override void OnPreviewMouseWheel(MouseWheelEventArgs e)
	{
		if (CanScroll())
		{
			if (e.Delta > 0)
			{
				IncrementScroll();
			}
			else
			{
				DecrementScroll();
			}
			e.Handled = true;
		}
	}

	public bool CanScroll()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		return ((Enum)Keyboard.Modifiers).HasFlag((Enum)(object)(ModifierKeys)2);
	}

	private static void OnDurationPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		TimelineScrollBar obj = (TimelineScrollBar)(object)d;
		obj._scrollDelta = (TimeSlice)((DependencyPropertyChangedEventArgs)(ref e)).NewValue / SCROLL_LARGE_INCREMENT;
		obj.UpdatePixelStride();
		obj.UpdateThumb();
	}

	private static void OnVisibleDurationPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		TimelineScrollBar obj = (TimelineScrollBar)(object)d;
		obj.UpdatePixelStride();
		obj.UpdateThumb();
	}

	private static void OnVisibleDurationStartPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		TimelineScrollBar obj = (TimelineScrollBar)(object)d;
		obj.UpdatePixelStride();
		obj.UpdateThumb();
	}

	private void PartThumbOnMouseEnter(object? sender, MouseEventArgs e)
	{
		IsMouseOverThumb = true;
	}

	private void PartThumbOnMouseLeave(object? sender, MouseEventArgs e)
	{
		IsMouseOverThumb = false;
	}

	private void PartThumbOnPreviewMouseDown(object? sender, MouseButtonEventArgs e)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		Point position = e.GetPosition(_partTrack);
		_xAnchor = ((Point)(ref position)).X;
		position = e.GetPosition(_partThumb);
		double x = ((Point)(ref position)).X;
		_offsetTime = TimeSlice.FromMilliseconds(Math.Floor(x * _pixelStride));
		_partThumb?.CaptureMouse();
		base.OnPreviewMouseDown(e);
	}

	private void PartThumbOnPreviewMouseMove(object? sender, MouseEventArgs e)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		if (_partThumb == null || _partThumb.IsMouseCaptured)
		{
			Point position = e.GetPosition(_partTrack);
			double x = ((Point)(ref position)).X;
			if (x - _xAnchor != 0.0)
			{
				TimeSlice time = TimeSlice.FromMilliseconds(Math.Floor(x * _pixelStride)).Subtract(_offsetTime);
				time = RestrictToBounds(time);
				VisibleDurationStart = time;
			}
			base.OnMouseMove(e);
		}
	}

	private void PartThumbOnPreviewMouseUp(object? sender, MouseButtonEventArgs e)
	{
		_partThumb?.ReleaseMouseCapture();
	}

	private void PartTrackOnPreviewMouseUp(object? sender, MouseButtonEventArgs e)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		if (!IsMouseOverThumb)
		{
			Point position = e.GetPosition(_partTrack);
			TimeSlice timeSlice = TimeSlice.FromMilliseconds(Math.Floor(((Point)(ref position)).X * _pixelStride));
			timeSlice -= VisibleDuration / 2.0;
			if (timeSlice <= TimeSlice.Zero)
			{
				VisibleDurationStart = TimeSlice.Zero;
			}
			else if (timeSlice + VisibleDuration >= Duration)
			{
				VisibleDurationStart = Duration - VisibleDuration;
			}
			else
			{
				VisibleDurationStart = timeSlice;
			}
		}
	}

	private TimeSlice RestrictToBounds(TimeSlice time)
	{
		if (time <= TimeSlice.Zero)
		{
			return TimeSlice.Zero;
		}
		if (time + VisibleDuration >= Duration)
		{
			return Duration - VisibleDuration;
		}
		return time;
	}

	private void UpdatePixelStride()
	{
		_pixelStride = ((_partTrack != null) ? (Duration.TotalMilliseconds / _partTrack.ActualWidth) : 0.0);
	}

	private void UpdateThumb()
	{
		if (_partThumb != null && !(_pixelStride <= 0.0))
		{
			Canvas.SetLeft(_partThumb, Math.Floor(VisibleDurationStart.TotalMilliseconds / _pixelStride));
			_partThumb.Width = Math.Ceiling(VisibleDuration.TotalMilliseconds / _pixelStride);
		}
	}
}
