using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Collections;
using Pro.ssAPI.Devices;
using ProPresenter.DO.LiveVideo;

namespace ProPresenter.UI.LiveVideo;

public partial class VideoInputDeviceSelector : UserControl, IComponentConnector
{
	public static readonly DependencyProperty AvailableDevicesProperty = DependencyProperty.Register("AvailableDevices", typeof(INotifyEnumerableChanged<IVideoInputDevice>), typeof(VideoInputDeviceSelector));

	public static readonly DependencyProperty IsDeviceConnectedProperty = DependencyProperty.Register("IsDeviceConnected", typeof(bool), typeof(VideoInputDeviceSelector), new PropertyMetadata((object)false));

	public static readonly DependencyProperty SelectedLiveVideoInputProperty = DependencyProperty.Register("SelectedLiveVideoInput", typeof(LiveVideoInput), typeof(VideoInputDeviceSelector));

	public static readonly DependencyProperty SelectVideoDeviceCommandProperty = DependencyProperty.Register("SelectVideoDeviceCommand", typeof(IRelayCommand<SelectVideoDeviceCommandParameter>), typeof(VideoInputDeviceSelector));

	public static readonly DependencyProperty AddAirCastDeviceCommandProperty = DependencyProperty.Register("AddAirCastDeviceCommand", typeof(IRelayCommand<LiveVideoInput>), typeof(VideoInputDeviceSelector));

	public static readonly DependencyProperty ClearSelectedVideoInputDeviceCommandProperty = DependencyProperty.Register("ClearSelectedVideoInputDeviceCommand", typeof(ICommand), typeof(VideoInputDeviceSelector));

	public INotifyEnumerableChanged<IVideoInputDevice>? AvailableDevices
	{
		get
		{
			return (INotifyEnumerableChanged<IVideoInputDevice>)((DependencyObject)this).GetValue(AvailableDevicesProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AvailableDevicesProperty, (object)value);
		}
	}

	public bool IsDeviceConnected
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsDeviceConnectedProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsDeviceConnectedProperty, (object)value);
		}
	}

	public LiveVideoInput? SelectedLiveVideoInput
	{
		get
		{
			return (LiveVideoInput)((DependencyObject)this).GetValue(SelectedLiveVideoInputProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedLiveVideoInputProperty, (object)value);
		}
	}

	public IRelayCommand<SelectVideoDeviceCommandParameter>? SelectVideoDeviceCommand
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

	public ICommand? ClearSelectedVideoInputDeviceCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(ClearSelectedVideoInputDeviceCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ClearSelectedVideoInputDeviceCommandProperty, (object)value);
		}
	}

	public IRelayCommand<LiveVideoInput?>? AddAirCastDeviceCommand
	{
		get
		{
			return (IRelayCommand<LiveVideoInput>)((DependencyObject)this).GetValue(AddAirCastDeviceCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AddAirCastDeviceCommandProperty, (object)value);
		}
	}

	public VideoInputDeviceSelector()
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
