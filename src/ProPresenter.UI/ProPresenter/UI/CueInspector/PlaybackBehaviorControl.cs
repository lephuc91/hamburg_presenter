using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.Common.Time;
using Pro.ssAPI;
using ProPresenter.DO.Media;
using ProPresenter.DO.Media.Properties;

namespace ProPresenter.UI.CueInspector;

public partial class PlaybackBehaviorControl : UserControl, IComponentConnector
{
	public static readonly DependencyProperty ActiveInlineViewProperty = DependencyProperty.Register("ActiveInlineView", typeof(InlineType), typeof(PlaybackBehaviorControl), new PropertyMetadata((object)InlineType.Presentation, new PropertyChangedCallback(OnInlineViewChanged)));

	public static readonly DependencyProperty HideDelayFieldProperty = DependencyProperty.Register("HideDelayField", typeof(bool), typeof(PlaybackBehaviorControl), new PropertyMetadata((object)false));

	public static readonly DependencyProperty ShowRetriggeringBehaviorFieldProperty = DependencyProperty.Register("ShowRetriggeringBehaviorField", typeof(bool), typeof(PlaybackBehaviorControl), new PropertyMetadata((object)false));

	public static readonly DependencyProperty MediaTypeProperty = DependencyProperty.Register("MediaType", typeof(MediaType), typeof(PlaybackBehaviorControl), new PropertyMetadata((object)MediaType.Image));

	public static readonly DependencyProperty PlaybackBehaviorTypeProperty = DependencyProperty.Register("PlaybackBehaviorType", typeof(PlaybackBehaviorType), typeof(PlaybackBehaviorControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)PlaybackBehaviorType.Stop, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	public static readonly DependencyProperty LoopCountProperty = DependencyProperty.Register("LoopCount", typeof(int), typeof(PlaybackBehaviorControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	public static readonly DependencyProperty LoopTimeProperty = DependencyProperty.Register("LoopTime", typeof(TimeSlice), typeof(PlaybackBehaviorControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)TimeSlice.Zero, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	public static readonly DependencyProperty SoftLoopProperty = DependencyProperty.Register("SoftLoop", typeof(bool), typeof(PlaybackBehaviorControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	public static readonly DependencyProperty EndBehaviorTypeProperty = DependencyProperty.Register("EndBehaviorType", typeof(EndBehaviorType), typeof(PlaybackBehaviorControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)EndBehaviorType.HoldLastFrame, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	public static readonly DependencyProperty FramesPerSecondProperty = DependencyProperty.Register("FramesPerSecond", typeof(double), typeof(PlaybackBehaviorControl), new PropertyMetadata((object)0.0));

	public static readonly DependencyProperty InPointProperty = DependencyProperty.Register("InPoint", typeof(TimeSlice), typeof(PlaybackBehaviorControl), new PropertyMetadata((object)default(TimeSlice)));

	public static readonly DependencyProperty OutPointProperty = DependencyProperty.Register("OutPoint", typeof(TimeSlice), typeof(PlaybackBehaviorControl), new PropertyMetadata((object)default(TimeSlice)));

	public static readonly DependencyProperty DurationProperty = DependencyProperty.Register("Duration", typeof(TimeSlice), typeof(PlaybackBehaviorControl), new PropertyMetadata((object)default(TimeSlice)));

	public static readonly DependencyProperty DelayTimeProperty = DependencyProperty.Register("DelayTime", typeof(TimeSlice), typeof(PlaybackBehaviorControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)TimeSlice.Zero, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	public static readonly DependencyProperty PlayRateProperty = DependencyProperty.Register("PlayRate", typeof(double), typeof(PlaybackBehaviorControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)0.2, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	public static readonly DependencyProperty RetriggerBehaviorProperty = DependencyProperty.Register("RetriggerBehavior", typeof(RetriggerBehavior), typeof(PlaybackBehaviorControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)RetriggerBehavior.Automatic, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	public static readonly DependencyProperty SetMediaInPointCommandProperty = DependencyProperty.Register("SetMediaInPointCommand", typeof(ICommand), typeof(PlaybackBehaviorControl));

	public static readonly DependencyProperty SetMediaOutPointCommandProperty = DependencyProperty.Register("SetMediaOutPointCommand", typeof(ICommand), typeof(PlaybackBehaviorControl));

	public static readonly DependencyProperty HardwareDecodingBehaviorProperty = DependencyProperty.Register("HardwareDecodingBehavior", typeof(HardwareDecodingBehaviorType), typeof(PlaybackBehaviorControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)HardwareDecodingBehaviorType.Automatic, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	public MediaType MediaType
	{
		get
		{
			return (MediaType)((DependencyObject)this).GetValue(MediaTypeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MediaTypeProperty, (object)value);
		}
	}

	public PlaybackBehaviorType PlaybackBehaviorType
	{
		get
		{
			return (PlaybackBehaviorType)((DependencyObject)this).GetValue(PlaybackBehaviorTypeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PlaybackBehaviorTypeProperty, (object)value);
		}
	}

	public int LoopCount
	{
		get
		{
			return (int)((DependencyObject)this).GetValue(LoopCountProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LoopCountProperty, (object)value);
		}
	}

	public TimeSlice LoopTime
	{
		get
		{
			return (TimeSlice)((DependencyObject)this).GetValue(LoopTimeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LoopTimeProperty, (object)value);
		}
	}

	public bool SoftLoop
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(SoftLoopProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SoftLoopProperty, (object)value);
		}
	}

	public EndBehaviorType EndBehaviorType
	{
		get
		{
			return (EndBehaviorType)((DependencyObject)this).GetValue(EndBehaviorTypeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(EndBehaviorTypeProperty, (object)value);
		}
	}

	public double FramesPerSecond
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(FramesPerSecondProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FramesPerSecondProperty, (object)value);
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

	public TimeSlice DelayTime
	{
		get
		{
			return (TimeSlice)((DependencyObject)this).GetValue(DelayTimeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DelayTimeProperty, (object)value);
		}
	}

	public double PlayRate
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(PlayRateProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PlayRateProperty, (object)value);
		}
	}

	public bool HideDelayField
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(HideDelayFieldProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HideDelayFieldProperty, (object)value);
		}
	}

	public InlineType ActiveInlineView
	{
		get
		{
			return (InlineType)((DependencyObject)this).GetValue(ActiveInlineViewProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ActiveInlineViewProperty, (object)value);
		}
	}

	public RetriggerBehavior RetriggerBehavior
	{
		get
		{
			return (RetriggerBehavior)((DependencyObject)this).GetValue(RetriggerBehaviorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RetriggerBehaviorProperty, (object)value);
		}
	}

	public bool ShowRetriggeringBehaviorField
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowRetriggeringBehaviorFieldProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowRetriggeringBehaviorFieldProperty, (object)value);
		}
	}

	public ICommand? SetMediaInPointCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(SetMediaInPointCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SetMediaInPointCommandProperty, (object)value);
		}
	}

	public ICommand? SetMediaOutPointCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(SetMediaOutPointCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SetMediaOutPointCommandProperty, (object)value);
		}
	}

	public HardwareDecodingBehaviorType HardwareDecodingBehavior
	{
		get
		{
			return (HardwareDecodingBehaviorType)((DependencyObject)this).GetValue(HardwareDecodingBehaviorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HardwareDecodingBehaviorProperty, (object)value);
		}
	}

	public PlaybackBehaviorControl()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		InitializeComponent();
		base.DataContextChanged += new DependencyPropertyChangedEventHandler(OnDataContextChanged);
	}

	private void OnDataContextChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		if (sender is PlaybackBehaviorControl { DataContext: not null })
		{
			SetBinding(ActiveInlineViewProperty, new Binding
			{
				Path = new PropertyPath("ActiveInlineView")
			});
		}
	}

	private static void OnInlineViewChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is PlaybackBehaviorControl { DataContext: not null } playbackBehaviorControl)
		{
			playbackBehaviorControl.HideDelayField = playbackBehaviorControl.ActiveInlineView != InlineType.Presentation;
		}
	}
}
