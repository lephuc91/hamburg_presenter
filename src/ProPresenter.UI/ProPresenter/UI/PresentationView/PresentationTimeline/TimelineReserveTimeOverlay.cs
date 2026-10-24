using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Pro.Common.Operations;
using Pro.Common.Time;
using Pro.UI.Controls;
using Pro.UI.Themes;

namespace ProPresenter.UI.PresentationView.PresentationTimeline;

public class TimelineReserveTimeOverlay : Canvas
{
	private TimeSlice _duration;

	private TimeSlice _offsetTime;

	private Rectangle _partOverlay;

	private Icon _partThumb;

	private double _pixelStride;

	private double _xAnchor;

	public static readonly DependencyProperty ActualDurationProperty;

	public static readonly DependencyProperty DurationProperty;

	public static readonly DependencyProperty VisibleDurationProperty;

	public static readonly DependencyProperty VisibleDurationStartProperty;

	public TimeSlice ActualDuration
	{
		get
		{
			return (TimeSlice)((DependencyObject)this).GetValue(ActualDurationProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ActualDurationProperty, (object)value);
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

	static TimelineReserveTimeOverlay()
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected O, but got Unknown
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected O, but got Unknown
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Expected O, but got Unknown
		ActualDurationProperty = DependencyProperty.Register("ActualDuration", typeof(TimeSlice), typeof(TimelineReserveTimeOverlay), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)TimeSlice.Zero, new PropertyChangedCallback(OnActualDurationPropertyChanged)));
		DurationProperty = DependencyProperty.Register("Duration", typeof(TimeSlice), typeof(TimelineReserveTimeOverlay), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)TimeSlice.Zero, new PropertyChangedCallback(OnDurationPropertyChanged)));
		VisibleDurationProperty = DependencyProperty.Register("VisibleDuration", typeof(TimeSlice), typeof(TimelineReserveTimeOverlay), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)TimeSlice.Zero, new PropertyChangedCallback(OnVisibleDurationPropertyChanged)));
		VisibleDurationStartProperty = DependencyProperty.Register("VisibleDurationStart", typeof(TimeSlice), typeof(TimelineReserveTimeOverlay), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)TimeSlice.Zero, new PropertyChangedCallback(OnVisibleDurationStartPropertyChanged)));
		UIElement.ClipToBoundsProperty.OverrideMetadata(typeof(TimelineReserveTimeOverlay), new PropertyMetadata((object)true));
	}

	public TimelineReserveTimeOverlay()
	{
		_partOverlay = new Rectangle
		{
			Fill = System.Windows.Media.Brushes.Black,
			Opacity = 0.4,
			IsHitTestVisible = false
		};
		base.Children.Add(_partOverlay);
		_partThumb = new Icon
		{
			IconSize = IconSize.XSmall,
			Source = Icons.GetIcon(Icons.LeftArrow)
		};
		_partThumb.PreviewMouseDown += ThumbOnPreviewMouseDown;
		_partThumb.PreviewMouseMove += ThumbOnPreviewMouseMove;
		_partThumb.PreviewMouseUp += ThumbOnPreviewMouseUp;
		base.Children.Add(_partThumb);
		base.Loaded += delegate
		{
			UpdatePixelStride();
			Update();
		};
		base.SizeChanged += delegate
		{
			UpdatePixelStride();
			Update();
		};
	}

	private static void OnActualDurationPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		TimelineReserveTimeOverlay obj = (TimelineReserveTimeOverlay)(object)d;
		obj.UpdatePixelStride();
		obj.Update();
	}

	private static void OnDurationPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		TimelineReserveTimeOverlay obj = (TimelineReserveTimeOverlay)(object)d;
		TimeSlice duration = (TimeSlice)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
		obj._duration = duration;
		obj.UpdatePixelStride();
		obj.Update();
	}

	private static void OnVisibleDurationPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		TimelineReserveTimeOverlay obj = (TimelineReserveTimeOverlay)(object)d;
		obj.UpdatePixelStride();
		obj.Update();
	}

	private static void OnVisibleDurationStartPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		TimelineReserveTimeOverlay obj = (TimelineReserveTimeOverlay)(object)d;
		obj.UpdatePixelStride();
		obj.Update();
	}

	private void ThumbOnPreviewMouseDown(object? sender, MouseButtonEventArgs e)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		Point position = e.GetPosition(this);
		_xAnchor = ((Point)(ref position)).X;
		Point position2 = e.GetPosition(_partThumb);
		_offsetTime = TimeSlice.FromMilliseconds(Math.Floor(((Point)(ref position2)).X * _pixelStride));
		_partThumb?.CaptureMouse();
		e.Handled = true;
	}

	private void ThumbOnPreviewMouseMove(object? sender, MouseEventArgs e)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		if (e.LeftButton == MouseButtonState.Pressed)
		{
			e.GetPosition(_partThumb);
			Point position = e.GetPosition(this);
			if (((Point)(ref position)).X - _xAnchor != 0.0)
			{
				TimeSlice duration = TimeSlice.FromMilliseconds(Math.Floor(((Point)(ref position)).X * _pixelStride)).Subtract(_offsetTime) + VisibleDurationStart;
				_duration = duration;
				Update();
				e.Handled = true;
			}
		}
	}

	private void ThumbOnPreviewMouseUp(object? sender, MouseButtonEventArgs e)
	{
		_partThumb?.ReleaseMouseCapture();
		Duration = _duration;
		e.Handled = true;
	}

	private void Update()
	{
		if (base.IsLoaded && !(_pixelStride <= 0.0))
		{
			if ((Duration >= VisibleDurationStart && Duration <= VisibleDurationStart + VisibleDuration) || VisibleDurationStart > Duration)
			{
				_partOverlay.Height = base.ActualHeight;
				double num = (ActualDuration - _duration).TotalMilliseconds / _pixelStride;
				double length = (_duration - VisibleDurationStart).TotalMilliseconds / _pixelStride;
				_partOverlay.Width = ((num > 0.0) ? num : 0.0);
				Canvas.SetLeft(_partOverlay, length);
				Canvas.SetTop(_partThumb, 4.0);
				Canvas.SetLeft(_partThumb, length);
				_partOverlay.Visibility = Visibility.Visible;
				_partThumb.Visibility = Visibility.Visible;
			}
			else
			{
				_partOverlay.Visibility = Visibility.Collapsed;
				_partThumb.Visibility = Visibility.Collapsed;
			}
		}
	}

	private void UpdatePixelStride()
	{
		if (base.ActualWidth <= 0.0)
		{
			_pixelStride = 0.0;
			return;
		}
		_pixelStride = VisibleDuration.TotalMilliseconds / base.ActualWidth;
		if (double.IsInfinity(_pixelStride))
		{
			_pixelStride = 0.0;
		}
	}
}
