using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.DO.Audio;
using Pro.ssAPI.Devices;

namespace ProPresenter.UI.Settings.PageTemplates.Inputs;

public partial class ChannelSetMixer : UserControl, IComponentConnector
{
	public static readonly DependencyProperty ChannelSetProperty = DependencyProperty.Register("ChannelSet", typeof(ChannelSet<DeviceChannel>), typeof(ChannelSetMixer));

	public static readonly DependencyProperty MasterChannelProperty = DependencyProperty.Register("MasterChannel", typeof(DeviceChannel), typeof(ChannelSetMixer));

	public static readonly DependencyProperty ChannelMapProperty = DependencyProperty.Register("ChannelMap", typeof(AudioMap<DeviceChannel, Bus>), typeof(ChannelSetMixer));

	public static readonly DependencyProperty ChannelLevelsProperty = DependencyProperty.Register("ChannelLevels", typeof(IEnumerable<IAudioChannelLevel>), typeof(ChannelSetMixer));

	public ChannelSet<DeviceChannel>? ChannelSet
	{
		get
		{
			return (ChannelSet<DeviceChannel>)((DependencyObject)this).GetValue(ChannelSetProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ChannelSetProperty, (object)value);
		}
	}

	public DeviceChannel? MasterChannel
	{
		get
		{
			return (DeviceChannel)((DependencyObject)this).GetValue(MasterChannelProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MasterChannelProperty, (object)value);
		}
	}

	public AudioMap<DeviceChannel, Bus>? ChannelMap
	{
		get
		{
			return (AudioMap<DeviceChannel, Bus>)((DependencyObject)this).GetValue(ChannelMapProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ChannelMapProperty, (object)value);
		}
	}

	public IEnumerable<IAudioChannelLevel>? ChannelLevels
	{
		get
		{
			return (IEnumerable<IAudioChannelLevel>)((DependencyObject)this).GetValue(ChannelLevelsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ChannelLevelsProperty, (object)value);
		}
	}

	public ChannelSetMixer()
	{
		InitializeComponent();
	}
}
