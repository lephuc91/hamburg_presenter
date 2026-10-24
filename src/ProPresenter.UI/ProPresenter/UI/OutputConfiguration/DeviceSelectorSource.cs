using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.UI.Components;
using Pro.UI.Utility;
using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.UI.OutputConfiguration;

public partial class DeviceSelectorSource : FrameworkCollection, IComponentConnector
{
	public static readonly DependencyProperty PlacementTargetProperty = DependencyProperty.Register("PlacementTarget", typeof(UIElement), typeof(DeviceSelectorSource));

	public static readonly DependencyProperty AddCombinedScreenCommandProperty = DependencyProperty.Register("AddCombinedScreenCommand", typeof(ICommand), typeof(DeviceSelectorSource));

	public static readonly DependencyProperty AddEdgeBlendScreenCommandProperty = DependencyProperty.Register("AddEdgeBlendScreenCommand", typeof(ICommand), typeof(DeviceSelectorSource));

	public static readonly DependencyProperty AssignDeviceCommandProperty = DependencyProperty.Register("AssignDeviceCommand", typeof(ICommand<DeviceCommandParameter>), typeof(DeviceSelectorSource));

	public static readonly DependencyProperty DevicesProperty = DependencyProperty.Register("Devices", typeof(IEnumerable<IDevice>), typeof(DeviceSelectorSource));

	public static readonly DependencyProperty TemporaryDevicesProperty = DependencyProperty.Register("TemporaryDevices", typeof(IEnumerable<IDevice>), typeof(DeviceSelectorSource));

	public static readonly DependencyProperty AttachedPhysicalDevicesProperty = DependencyProperty.Register("AttachedPhysicalDevices", typeof(IEnumerable<PhysicalDevice>), typeof(DeviceSelectorSource));

	public static readonly DependencyProperty ShowSelectDeviceProperty = DependencyProperty.Register("ShowSelectDevice", typeof(bool), typeof(DeviceSelectorSource), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));

	public static readonly DependencyProperty RemoveDeviceCommandProperty = DependencyProperty.Register("RemoveDeviceCommand", typeof(ICommand), typeof(DeviceSelectorSource));

	public static readonly DependencyProperty CanOpenScreenConfigProperty = DependencyProperty.Register("CanOpenScreenConfig", typeof(bool), typeof(DeviceSelectorSource), new PropertyMetadata((object)false));

	public UIElement? PlacementTarget
	{
		get
		{
			return (UIElement)((DependencyObject)this).GetValue(PlacementTargetProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PlacementTargetProperty, (object)value);
		}
	}

	public ICommand? AddCombinedScreenCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(AddCombinedScreenCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AddCombinedScreenCommandProperty, (object)value);
		}
	}

	public ICommand? AddEdgeBlendScreenCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(AddEdgeBlendScreenCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AddEdgeBlendScreenCommandProperty, (object)value);
		}
	}

	public ICommand<DeviceCommandParameter>? AssignDeviceCommand
	{
		get
		{
			return (ICommand<DeviceCommandParameter>)((DependencyObject)this).GetValue(AssignDeviceCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AssignDeviceCommandProperty, (object)value);
		}
	}

	public IEnumerable<IDevice>? Devices
	{
		get
		{
			return (IEnumerable<IDevice>)((DependencyObject)this).GetValue(DevicesProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DevicesProperty, (object)value);
		}
	}

	public IEnumerable<IDevice>? TemporaryDevices
	{
		get
		{
			return (IEnumerable<IDevice>)((DependencyObject)this).GetValue(TemporaryDevicesProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TemporaryDevicesProperty, (object)value);
		}
	}

	public IEnumerable<PhysicalDevice>? AttachedPhysicalDevices
	{
		get
		{
			return (IEnumerable<PhysicalDevice>)((DependencyObject)this).GetValue(AttachedPhysicalDevicesProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AttachedPhysicalDevicesProperty, (object)value);
		}
	}

	public bool ShowSelectDevice
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowSelectDeviceProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowSelectDeviceProperty, (object)value);
		}
	}

	public ICommand? RemoveDeviceCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(RemoveDeviceCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RemoveDeviceCommandProperty, (object)value);
		}
	}

	public bool CanOpenScreenConfig
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(CanOpenScreenConfigProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanOpenScreenConfigProperty, (object)value);
		}
	}

	public DeviceSelectorSource()
	{
		InitializeComponent();
	}

	private void Unconfigure_Click(object? sender, RoutedEventArgs e)
	{
		object obj = (PlacementTarget as FrameworkElement)?.DataContext;
		DeviceCommandParameter parameter = new DeviceCommandParameter(null, (HardwareScreenRectangleOptions)obj, null);
		AssignDeviceCommand?.Invoke(parameter);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
