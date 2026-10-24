using System.Windows;
using Pro.MIDI;
using ProPresenter.DO.Communication.Devices;

namespace ProPresenter.UI.Settings.PageTemplates.Devices;

internal class ActiveMIDIDeviceAdapter : DependencyObject
{
	private bool _ignoreChanges;

	public static DependencyProperty DeviceInfoProperty = DependencyProperty.Register("DeviceInfo", typeof(DeviceInfo), typeof(ActiveMIDIDeviceAdapter), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)default(DeviceInfo), new PropertyChangedCallback(SourcePropertyChanged)));

	public static DependencyProperty ActiveMIDIDevicesProperty = DependencyProperty.Register("ActiveMIDIDevices", typeof(MIDIDevice.ActiveDevices), typeof(ActiveMIDIDeviceAdapter), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(SourcePropertyChanged)));

	public static DependencyProperty IsActiveProperty = DependencyProperty.Register("IsActive", typeof(bool), typeof(ActiveMIDIDeviceAdapter), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(IsActivePropertyChanged)));

	public DeviceInfo DeviceInfo
	{
		get
		{
			return (DeviceInfo)((DependencyObject)this).GetValue(DeviceInfoProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DeviceInfoProperty, (object)value);
		}
	}

	public MIDIDevice.ActiveDevices? ActiveMIDIDevices
	{
		get
		{
			return (MIDIDevice.ActiveDevices)((DependencyObject)this).GetValue(ActiveMIDIDevicesProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ActiveMIDIDevicesProperty, (object)value);
		}
	}

	public bool IsActive
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsActiveProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsActiveProperty, (object)value);
		}
	}

	private static void SourcePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		(d as ActiveMIDIDeviceAdapter)?.OnSourceChanged();
	}

	private static void IsActivePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		(d as ActiveMIDIDeviceAdapter)?.OnIsActiveChanged();
	}

	private void OnSourceChanged()
	{
		if (!_ignoreChanges && ActiveMIDIDevices != null)
		{
			_ignoreChanges = true;
			IsActive = ActiveMIDIDevices[DeviceInfo];
			_ignoreChanges = false;
		}
	}

	private void OnIsActiveChanged()
	{
		if (!_ignoreChanges && ActiveMIDIDevices != null)
		{
			_ignoreChanges = true;
			ActiveMIDIDevices[DeviceInfo] = IsActive;
			_ignoreChanges = false;
		}
	}
}
