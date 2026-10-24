using System.Collections.Generic;
using System.Windows;
using System.Windows.Markup;
using Pro.Common.Time;
using Pro.UI.Components;
using Pro.ssAPI;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Media;
using ProPresenter.DO.Media.Properties;

namespace ProPresenter.UI.MediaLibrary;

public partial class MediaActionMenuSource : FrameworkCollection, IComponentConnector
{
	public static readonly DependencyProperty MediaActionProperty = DependencyProperty.Register("MediaAction", typeof(MediaAction), typeof(MediaActionMenuSource), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnMediaActionPropertyChanged)));

	public static readonly DependencyProperty CanSetTargetLayerProperty = DependencyProperty.Register("CanSetTargetLayer", typeof(bool), typeof(MediaActionMenuSource), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty DrawingProperty = DependencyProperty.Register("Drawing", typeof(DrawingProperties), typeof(MediaActionMenuSource));

	public static readonly DependencyProperty TransportProperty = DependencyProperty.Register("Transport", typeof(TransportProperties), typeof(MediaActionMenuSource));

	public static readonly DependencyProperty VideoProperty = DependencyProperty.Register("Video", typeof(VideoProperties), typeof(MediaActionMenuSource));

	public static readonly DependencyProperty SupportsPremultipliedAlphaSettingProperty = DependencyProperty.Register("SupportsPremultipliedAlphaSetting", typeof(bool), typeof(MediaActionMenuSource));

	public static readonly DependencyProperty SetMediaTargetLayerCommandProperty = DependencyProperty.Register("SetMediaTargetLayerCommand", typeof(ICommand<TriggerLayer>), typeof(MediaActionMenuSource));

	public static readonly DependencyProperty SetMediaScaleBehaviorCommandProperty = DependencyProperty.Register("SetMediaScaleBehaviorCommand", typeof(ICommand<ScaleBehavior>), typeof(MediaActionMenuSource));

	public static readonly DependencyProperty SetAlphaTypeCommandProperty = DependencyProperty.Register("SetAlphaTypeCommand", typeof(ICommand<AlphaType>), typeof(MediaActionMenuSource));

	public static readonly DependencyProperty SetPlaybackBehaviorCommandProperty = DependencyProperty.Register("SetPlaybackBehaviorCommand", typeof(ICommand<PlaybackBehaviorType>), typeof(MediaActionMenuSource));

	public static readonly DependencyProperty SetSoftLoopDurationCommandProperty = DependencyProperty.Register("SetSoftLoopDurationCommand", typeof(ICommand<TimeSlice?>), typeof(MediaActionMenuSource));

	public static readonly DependencyProperty SetEndBehaviorTypeCommandProperty = DependencyProperty.Register("SetEndBehaviorTypeCommand", typeof(ICommand<EndBehaviorType>), typeof(MediaActionMenuSource));

	public IEnumerable<TimeSlice> SoftLoopDurations { get; } = SoftLoopHelper.Durations;

	public MediaAction? MediaAction
	{
		get
		{
			return (MediaAction)((DependencyObject)this).GetValue(MediaActionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MediaActionProperty, (object)value);
		}
	}

	public bool CanSetTargetLayer
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(CanSetTargetLayerProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanSetTargetLayerProperty, (object)value);
		}
	}

	private DrawingProperties? Drawing
	{
		get
		{
			return (DrawingProperties)((DependencyObject)this).GetValue(DrawingProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DrawingProperty, (object)value);
		}
	}

	private TransportProperties? Transport
	{
		get
		{
			return (TransportProperties)((DependencyObject)this).GetValue(TransportProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TransportProperty, (object)value);
		}
	}

	private VideoProperties? Video
	{
		get
		{
			return (VideoProperties)((DependencyObject)this).GetValue(VideoProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(VideoProperty, (object)value);
		}
	}

	private bool SupportsPremultipliedAlphaSetting
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(SupportsPremultipliedAlphaSettingProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SupportsPremultipliedAlphaSettingProperty, (object)value);
		}
	}

	public ICommand<TriggerLayer>? SetMediaTargetLayerCommand
	{
		get
		{
			return (ICommand<TriggerLayer>)((DependencyObject)this).GetValue(SetMediaTargetLayerCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SetMediaTargetLayerCommandProperty, (object)value);
		}
	}

	public ICommand<ScaleBehavior>? SetMediaScaleBehaviorCommand
	{
		get
		{
			return (ICommand<ScaleBehavior>)((DependencyObject)this).GetValue(SetMediaScaleBehaviorCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SetMediaScaleBehaviorCommandProperty, (object)value);
		}
	}

	public ICommand<AlphaType>? SetAlphaTypeCommand
	{
		get
		{
			return (ICommand<AlphaType>)((DependencyObject)this).GetValue(SetAlphaTypeCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SetAlphaTypeCommandProperty, (object)value);
		}
	}

	public ICommand<PlaybackBehaviorType>? SetPlaybackBehaviorCommand
	{
		get
		{
			return (ICommand<PlaybackBehaviorType>)((DependencyObject)this).GetValue(SetPlaybackBehaviorCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SetPlaybackBehaviorCommandProperty, (object)value);
		}
	}

	public ICommand<TimeSlice?>? SetSoftLoopDurationCommand
	{
		get
		{
			return (ICommand<TimeSlice?>)((DependencyObject)this).GetValue(SetSoftLoopDurationCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SetSoftLoopDurationCommandProperty, (object)value);
		}
	}

	public ICommand<EndBehaviorType>? SetEndBehaviorTypeCommand
	{
		get
		{
			return (ICommand<EndBehaviorType>)((DependencyObject)this).GetValue(SetEndBehaviorTypeCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SetEndBehaviorTypeCommandProperty, (object)value);
		}
	}

	private static void OnMediaActionPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		MediaAction mediaAction = ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as MediaAction;
		((DependencyObject)(MediaActionMenuSource)(object)d).SetCurrentValue(DrawingProperty, (object)(mediaAction?.Media as IDrawMedia)?.Drawing);
		((DependencyObject)(MediaActionMenuSource)(object)d).SetCurrentValue(TransportProperty, (object)(mediaAction?.Media as ITransportMedia)?.Transport);
		((DependencyObject)(MediaActionMenuSource)(object)d).SetCurrentValue(VideoProperty, (object)(mediaAction?.Media as IVideoMedia)?.Video);
		((DependencyObject)(MediaActionMenuSource)(object)d).SetCurrentValue(SupportsPremultipliedAlphaSettingProperty, (object)((mediaAction?.Media as VisualMedia)?.Metadata?.SupportsAlphaChannel == true));
	}

	public MediaActionMenuSource()
	{
		InitializeComponent();
	}
}
