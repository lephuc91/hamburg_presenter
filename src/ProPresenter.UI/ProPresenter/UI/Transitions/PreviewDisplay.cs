using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using Pro.Common.Mathematics;
using Pro.Common.Time;
using ProPresenter.Controller.Outputs.ssAPI;

namespace ProPresenter.UI.Transitions;

public partial class PreviewDisplay : Grid, IComponentConnector
{
	private readonly DispatcherTimer _playbackTimer = new DispatcherTimer
	{
		Interval = TimeSlice.FromSeconds(1.0 / 60.0),
		IsEnabled = false
	};

	private readonly Clock _playbackClock = new Clock();

	public static readonly DependencyProperty PreviewProperty = DependencyProperty.Register("Preview", typeof(TransitionPreview), typeof(PreviewDisplay), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(PreviewChanged)));

	public static readonly DependencyProperty PlaybackDurationProperty = DependencyProperty.Register("PlaybackDuration", typeof(TimeSlice), typeof(PreviewDisplay), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)TimeSlice.FromSeconds(1.0)));

	public static readonly DependencyProperty TitleTextProperty = DependencyProperty.Register("TitleText", typeof(string), typeof(PreviewDisplay), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)string.Empty));

	public static readonly DependencyProperty AutoPlayTransitionProperty = DependencyProperty.Register("AutoPlayTransition", typeof(bool), typeof(PreviewDisplay), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));

	public static readonly DependencyProperty HideSubtitleProperty = DependencyProperty.Register("HideSubtitle", typeof(bool), typeof(PreviewDisplay));

	public TransitionPreview? Preview
	{
		get
		{
			return (TransitionPreview)((DependencyObject)this).GetValue(PreviewProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PreviewProperty, (object)value);
		}
	}

	public TimeSlice PlaybackDuration
	{
		get
		{
			return (TimeSlice)((DependencyObject)this).GetValue(PlaybackDurationProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PlaybackDurationProperty, (object)value);
		}
	}

	public string TitleText
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(TitleTextProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TitleTextProperty, (object)value);
		}
	}

	public bool AutoPlayTransition
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(AutoPlayTransitionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AutoPlayTransitionProperty, (object)value);
		}
	}

	public bool HideSubtitle
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(HideSubtitleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HideSubtitleProperty, (object)value);
		}
	}

	private static void PreviewChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((PreviewDisplay)(object)d).OnPreviewChanged((TransitionPreview)((DependencyPropertyChangedEventArgs)(ref e)).OldValue, (TransitionPreview)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	public PreviewDisplay()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		InitializeComponent();
		_playbackTimer.Tick += OnPlaybackTimerTick;
	}

	private void UpdateDisplayFrame(double offset = 0.5, bool readMouse = true)
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		if (Preview == null || !Preview.IsLoaded)
		{
			PreviewImage.Source = null;
			return;
		}
		if (PreviewImage.IsMouseOver && readMouse)
		{
			Vector2<double> vector = (Vector2<double>)Mouse.GetPosition(PreviewImage);
			offset = vector.X / PreviewImage.ActualWidth;
			Line mouseOverLine = MouseOverLine;
			double x2 = (MouseOverLine.X2 = vector.X);
			mouseOverLine.X1 = x2;
			MouseOverLine.Y1 = 0.0;
			MouseOverLine.Y2 = PreviewImage.ActualHeight;
			MouseOverLine.Visibility = Visibility.Visible;
		}
		else
		{
			MouseOverLine.Visibility = Visibility.Hidden;
		}
		BitmapSource[] frames = Preview.Frames;
		int num = frames.Length;
		int num2 = (int)Math.Min(Math.Max(offset * (double)(num - 1), 0.0), num - 1);
		PreviewImage.Source = frames[num2];
	}

	protected override void OnPreviewMouseMove(MouseEventArgs e)
	{
		StopTransitionPreview();
	}

	protected override void OnMouseLeave(MouseEventArgs e)
	{
		UpdateDisplayFrame();
	}

	protected override void OnPreviewMouseLeftButtonUp(MouseButtonEventArgs e)
	{
		if (AutoPlayTransition)
		{
			PlayTransitionPreview();
		}
	}

	private void OnPreviewChanged(TransitionPreview oldPreview, TransitionPreview newPreview)
	{
		if (oldPreview != null)
		{
			oldPreview.FramesLoaded -= OnFramesLoaded;
		}
		if (newPreview != null)
		{
			newPreview.FramesLoaded += OnFramesLoaded;
		}
		if (newPreview != null && newPreview.IsLoaded)
		{
			OnFramesLoaded();
		}
	}

	private void OnFramesLoaded()
	{
		if (AutoPlayTransition)
		{
			PlayTransitionPreview();
		}
		else
		{
			UpdateDisplayFrame();
		}
	}

	public void StopTransitionPreview()
	{
		_playbackTimer.IsEnabled = false;
		UpdateDisplayFrame();
	}

	public void PlayTransitionPreview()
	{
		_playbackClock.Restart();
		UpdateDisplayFrame(0.0, readMouse: false);
		_playbackTimer.IsEnabled = true;
	}

	private void OnPlaybackTimerTick(object? sender, EventArgs e)
	{
		if (_playbackClock.ElapsedTime <= PlaybackDuration)
		{
			UpdateDisplayFrame(_playbackClock.ElapsedTime.TotalSeconds / PlaybackDuration.TotalSeconds, readMouse: false);
		}
		else
		{
			StopTransitionPreview();
		}
	}
}
