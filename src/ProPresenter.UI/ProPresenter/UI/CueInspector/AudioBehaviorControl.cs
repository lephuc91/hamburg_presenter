using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.Common.Time;
using Pro.DO.Triggering;

namespace ProPresenter.UI.CueInspector;

public partial class AudioBehaviorControl : UserControl, IComponentConnector
{
	public static readonly DependencyProperty AudioBehaviorTypeProperty = DependencyProperty.Register("AudioBehaviorType", typeof(AudioBehaviorType), typeof(AudioBehaviorControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)AudioBehaviorType.Next, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	public static readonly DependencyProperty SoftLoopProperty = DependencyProperty.Register("SoftLoop", typeof(bool), typeof(AudioBehaviorControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	public static readonly DependencyProperty InPointProperty = DependencyProperty.Register("InPoint", typeof(TimeSlice), typeof(AudioBehaviorControl), new PropertyMetadata((object)default(TimeSlice)));

	public static readonly DependencyProperty OutPointProperty = DependencyProperty.Register("OutPoint", typeof(TimeSlice), typeof(AudioBehaviorControl), new PropertyMetadata((object)default(TimeSlice)));

	public static readonly DependencyProperty DurationProperty = DependencyProperty.Register("Duration", typeof(TimeSlice), typeof(AudioBehaviorControl), new PropertyMetadata((object)default(TimeSlice)));

	public static readonly DependencyProperty DelayTimeProperty = DependencyProperty.Register("DelayTime", typeof(TimeSlice), typeof(AudioBehaviorControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)TimeSlice.Zero, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	public static readonly DependencyProperty PlayRateProperty = DependencyProperty.Register("PlayRate", typeof(double), typeof(AudioBehaviorControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)0.2, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	public static readonly DependencyProperty AudioBehaviorsProperty = DependencyProperty.Register("AudioBehaviors", typeof(IEnumerable<AudioBehaviorType>), typeof(AudioBehaviorControl));

	public static readonly DependencyProperty SetMediaInPointCommandProperty = DependencyProperty.Register("SetMediaInPointCommand", typeof(ICommand), typeof(AudioBehaviorControl));

	public static readonly DependencyProperty SetMediaOutPointCommandProperty = DependencyProperty.Register("SetMediaOutPointCommand", typeof(ICommand), typeof(AudioBehaviorControl));

	public AudioBehaviorType AudioBehaviorType
	{
		get
		{
			return (AudioBehaviorType)((DependencyObject)this).GetValue(AudioBehaviorTypeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AudioBehaviorTypeProperty, (object)value);
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

	public IEnumerable<AudioBehaviorType>? AudioBehaviors
	{
		get
		{
			return (IEnumerable<AudioBehaviorType>)((DependencyObject)this).GetValue(AudioBehaviorsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AudioBehaviorsProperty, (object)value);
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

	public AudioBehaviorControl()
	{
		InitializeComponent();
	}
}
