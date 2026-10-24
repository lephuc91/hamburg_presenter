using System.Windows;
using System.Windows.Markup;
using CommunityToolkit.Mvvm.Input;
using Pro.Common.Collections;
using Pro.UI.Components;
using Pro.ssAPI.Devices;
using ProPresenter.DO.LiveVideo;

namespace ProPresenter.UI.LiveVideo;

public partial class VideoInputDeviceSelectorSource : FrameworkCollection, IComponentConnector
{
	public static readonly DependencyProperty AvailableDevicesProperty = DependencyProperty.Register("AvailableDevices", typeof(INotifyEnumerableChanged<IVideoInputDevice>), typeof(VideoInputDeviceSelectorSource));

	public static readonly DependencyProperty SelectedLiveVideoInputProperty = DependencyProperty.Register("SelectedLiveVideoInput", typeof(LiveVideoInput), typeof(VideoInputDeviceSelectorSource));

	public static readonly DependencyProperty IsDeviceConnectedProperty = DependencyProperty.Register("IsDeviceConnected", typeof(bool), typeof(VideoInputDeviceSelectorSource), new PropertyMetadata((object)false));

	public static readonly DependencyProperty SelectVideoDeviceCommandProperty = DependencyProperty.Register("SelectVideoDeviceCommand", typeof(IRelayCommand<SelectVideoDeviceCommandParameter>), typeof(VideoInputDeviceSelectorSource));

	public static readonly DependencyProperty SetNoSourceCommandProperty = DependencyProperty.Register("SetNoSourceCommand", typeof(IRelayCommand), typeof(VideoInputDeviceSelectorSource));

	public static readonly DependencyProperty AddAirCastDeviceCommandProperty = DependencyProperty.Register("AddAirCastDeviceCommand", typeof(IRelayCommand<LiveVideoInput>), typeof(VideoInputDeviceSelectorSource));

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

	public IRelayCommand? SetNoSourceCommand
	{
		get
		{
			return (IRelayCommand)((DependencyObject)this).GetValue(SetNoSourceCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SetNoSourceCommandProperty, (object)value);
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

	public VideoInputDeviceSelectorSource()
	{
		InitializeComponent();
	}
}
