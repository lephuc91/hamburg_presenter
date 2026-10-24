using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.DO.Audio;

namespace ProPresenter.UI.CueInspector;

public partial class ChannelControl : UserControl, IComponentConnector
{
	public static readonly DependencyProperty MediaAudioChannelProperty = DependencyProperty.Register("MediaAudioChannel", typeof(MediaChannel), typeof(ChannelControl));

	public static readonly DependencyProperty AudioMapProperty = DependencyProperty.Register("AudioMap", typeof(AudioMap<MediaChannel, Bus>), typeof(ChannelControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnAudioMapChanged)));

	private static readonly DependencyProperty OutputsProperty = DependencyProperty.Register("Outputs", typeof(IEnumerable<Bus>), typeof(ChannelControl));

	public MediaChannel? MediaAudioChannel
	{
		get
		{
			return (MediaChannel)((DependencyObject)this).GetValue(MediaAudioChannelProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MediaAudioChannelProperty, (object)value);
		}
	}

	public AudioMap<MediaChannel, Bus>? AudioMap
	{
		get
		{
			return (AudioMap<MediaChannel, Bus>)((DependencyObject)this).GetValue(AudioMapProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AudioMapProperty, (object)value);
		}
	}

	private IEnumerable<Bus>? Outputs
	{
		get
		{
			return (IEnumerable<Bus>)((DependencyObject)this).GetValue(OutputsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(OutputsProperty, (object)value);
		}
	}

	private static void OnAudioMapChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((ChannelControl)(object)d).AudioMapChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as AudioMap<MediaChannel, Bus>, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as AudioMap<MediaChannel, Bus>);
	}

	public ChannelControl()
	{
		InitializeComponent();
	}

	private void AudioMapChanged(AudioMap<MediaChannel, Bus>? oldValue, AudioMap<MediaChannel, Bus>? newValue)
	{
		if (oldValue != null)
		{
			oldValue.MapInvalidated -= UpdateMappedOutputs;
		}
		if (newValue != null)
		{
			newValue.MapInvalidated += UpdateMappedOutputs;
		}
		UpdateMappedOutputs();
	}

	private void UpdateMappedOutputs()
	{
		object outputs;
		if (MediaAudioChannel != null)
		{
			outputs = AudioMap?.OutputSet?.Where((Bus o) => AudioMap.IsMapped(MediaAudioChannel, o));
		}
		else
		{
			IEnumerable<Bus> enumerable = Enumerable.Empty<Bus>();
			outputs = enumerable;
		}
		Outputs = (IEnumerable<Bus>?)outputs;
	}
}
