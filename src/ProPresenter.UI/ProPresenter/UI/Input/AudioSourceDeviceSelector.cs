using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using CommunityToolkit.Mvvm.Input;
using Pro.DO.Audio;
using Pro.ssAPI.Devices;
using ProPresenter.UI.LiveVideo;

namespace ProPresenter.UI.Input;

public partial class AudioSourceDeviceSelector : UserControl, IComponentConnector
{
	public static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(AudioSource), typeof(AudioSourceDeviceSelector));

	public static readonly DependencyProperty AudioDevicesProperty = DependencyProperty.Register("AudioDevices", typeof(IEnumerable<IAudioInputDevice>), typeof(AudioSourceDeviceSelector));

	public static readonly DependencyProperty VideoDevicesProperty = DependencyProperty.Register("VideoDevices", typeof(IEnumerable<IVideoInputDevice>), typeof(AudioSourceDeviceSelector));

	public static readonly DependencyProperty DefaultVideoDeviceProperty = DependencyProperty.Register("DefaultVideoDevice", typeof(IVideoInputDevice), typeof(AudioSourceDeviceSelector));

	public static readonly DependencyProperty ClearDeviceCommandProperty = DependencyProperty.Register("ClearDeviceCommand", typeof(IRelayCommand), typeof(AudioSourceDeviceSelector));

	public static readonly DependencyProperty SelectVideoDeviceCommandProperty = DependencyProperty.Register("SelectVideoDeviceCommand", typeof(IRelayCommand<SelectVideoDeviceCommandParameter>), typeof(AudioSourceDeviceSelector));

	public static readonly DependencyProperty SelectAudioDeviceCommandProperty = DependencyProperty.Register("SelectAudioDeviceCommand", typeof(IRelayCommand<IAudioInputDevice>), typeof(AudioSourceDeviceSelector));

	public static readonly DependencyProperty AddAirCastDeviceCommandProperty = DependencyProperty.Register("AddAirCastDeviceCommand", typeof(IRelayCommand<AudioSource>), typeof(AudioSourceDeviceSelector));

	public AudioSource? Source
	{
		get
		{
			return (AudioSource)((DependencyObject)this).GetValue(SourceProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SourceProperty, (object)value);
		}
	}

	public IEnumerable<IAudioInputDevice> AudioDevices
	{
		get
		{
			return (IEnumerable<IAudioInputDevice>)((DependencyObject)this).GetValue(AudioDevicesProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AudioDevicesProperty, (object)value);
		}
	}

	public IEnumerable<IVideoInputDevice> VideoDevices
	{
		get
		{
			return (IEnumerable<IVideoInputDevice>)((DependencyObject)this).GetValue(VideoDevicesProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(VideoDevicesProperty, (object)value);
		}
	}

	public IVideoInputDevice DefaultVideoDevice
	{
		get
		{
			return (IVideoInputDevice)((DependencyObject)this).GetValue(DefaultVideoDeviceProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DefaultVideoDeviceProperty, (object)value);
		}
	}

	public IRelayCommand? ClearDeviceCommand
	{
		get
		{
			return (IRelayCommand)((DependencyObject)this).GetValue(ClearDeviceCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ClearDeviceCommandProperty, (object)value);
		}
	}

	public IRelayCommand<SelectVideoDeviceCommandParameter?>? SelectVideoDeviceCommand
	{
		get
		{
			return (IRelayCommand<SelectVideoDeviceCommandParameter>)((DependencyObject)this).GetValue(SelectVideoDeviceCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectVideoDeviceCommandProperty, (object)value);
		}
	}

	public IRelayCommand<IAudioInputDevice>? SelectAudioDeviceCommand
	{
		get
		{
			return (IRelayCommand<IAudioInputDevice>)((DependencyObject)this).GetValue(SelectAudioDeviceCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectAudioDeviceCommandProperty, (object)value);
		}
	}

	public IRelayCommand<AudioSource?>? AddAirCastDeviceCommand
	{
		get
		{
			return (IRelayCommand<AudioSource>)((DependencyObject)this).GetValue(AddAirCastDeviceCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AddAirCastDeviceCommandProperty, (object)value);
		}
	}

	public AudioSourceDeviceSelector()
	{
		InitializeComponent();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
