using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.Common.Collections;
using Pro.DO.Audio;
using Pro.UI.Components;
using Pro.ssAPI.Devices;

namespace ProPresenter.UI.Settings.PageTemplates.Audio;

public partial class AudioOutputDeviceContextMenu : ContextMenu, IComponentConnector
{
	public static readonly DependencyProperty AudioOutputDevicesProperty = DependencyProperty.Register("AudioOutputDevices", typeof(IAudioOutputDeviceCollection), typeof(AudioOutputDeviceContextMenu));

	public static readonly DependencyProperty ASIODevicesProperty = DependencyProperty.Register("ASIODevices", typeof(IEnumerable<IAudioOutputDevice>), typeof(AudioOutputDeviceContextMenu));

	public static readonly DependencyProperty WaveOutDevicesProperty = DependencyProperty.Register("WaveOutDevices", typeof(IEnumerable<IAudioOutputDevice>), typeof(AudioOutputDeviceContextMenu));

	public static readonly DependencyProperty SelectDeviceCommandProperty = DependencyProperty.Register("SelectDeviceCommand", typeof(ICommand<IAudioOutputDevice>), typeof(AudioOutputDeviceContextMenu));

	public static readonly DependencyProperty AudioDestinationProperty = DependencyProperty.Register("AudioDestination", typeof(IAudioDestination), typeof(AudioOutputDeviceContextMenu));

	public static readonly DependencyProperty SelectNoDeviceCommandProperty = DependencyProperty.Register("SelectNoDeviceCommand", typeof(ICommand), typeof(AudioOutputDeviceContextMenu));

	public static readonly DependencyProperty IsNoDeviceProperty = DependencyProperty.Register("IsNoDevice", typeof(bool), typeof(AudioOutputDeviceContextMenu), new PropertyMetadata((object)false));

	public static readonly DependencyProperty NoDeviceTextProperty = DependencyProperty.Register("NoDeviceText", typeof(string), typeof(AudioOutputDeviceContextMenu));

	public static readonly DependencyProperty DeviceDisabledProperty = DependencyProperty.Register("DeviceDisabled", typeof(bool), typeof(AudioOutputDeviceContextMenu), new PropertyMetadata((object)false));

	public IAudioOutputDeviceCollection? AudioOutputDevices
	{
		get
		{
			return (IAudioOutputDeviceCollection)((DependencyObject)this).GetValue(AudioOutputDevicesProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AudioOutputDevicesProperty, (object)value);
		}
	}

	public IEnumerable<IAudioOutputDevice>? ASIODevices
	{
		get
		{
			return (IEnumerable<IAudioOutputDevice>)((DependencyObject)this).GetValue(ASIODevicesProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ASIODevicesProperty, (object)value);
		}
	}

	public IEnumerable<IAudioOutputDevice>? WaveOutDevices
	{
		get
		{
			return (IEnumerable<IAudioOutputDevice>)((DependencyObject)this).GetValue(WaveOutDevicesProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(WaveOutDevicesProperty, (object)value);
		}
	}

	public ICommand<IAudioOutputDevice?>? SelectDeviceCommand
	{
		get
		{
			return (ICommand<IAudioOutputDevice>)((DependencyObject)this).GetValue(SelectDeviceCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectDeviceCommandProperty, (object)value);
		}
	}

	public IAudioDestination? AudioDestination
	{
		get
		{
			return (IAudioDestination)((DependencyObject)this).GetValue(AudioDestinationProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AudioDestinationProperty, (object)value);
		}
	}

	public ICommand? SelectNoDeviceCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(SelectNoDeviceCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectNoDeviceCommandProperty, (object)value);
		}
	}

	public bool IsNoDevice
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsNoDeviceProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsNoDeviceProperty, (object)value);
		}
	}

	public string? NoDeviceText
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(NoDeviceTextProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(NoDeviceTextProperty, (object)value);
		}
	}

	public bool DeviceDisabled
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(DeviceDisabledProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DeviceDisabledProperty, (object)value);
		}
	}

	public AudioOutputDeviceContextMenu()
	{
		InitializeComponent();
	}

	private void OnFilterOtherAudioDevice(object? sender, FilterEventArgs e)
	{
		e.Accepted = e.Item is IAudioDevice audioDevice && !audioDevice.DeviceType.IsAnyOf(AudioDeviceType.ASIO, AudioDeviceType.WaveOut);
	}
}
