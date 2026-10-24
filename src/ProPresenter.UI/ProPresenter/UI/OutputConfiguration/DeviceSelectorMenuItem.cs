using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.Common.Collections;
using Pro.UI.Components;
using Pro.UI.Utility;
using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.UI.OutputConfiguration;

public partial class DeviceSelectorMenuItem : MenuItem, IComponentConnector, IStyleConnector
{
	public class MenuItemStyleSelector : StyleSelector
	{
		private const string BaseDeviceStyleKey = "deviceStyle";

		private const string DeviceWithmodesStyleKey = "deviceWithModesStyle";

		private const string PhysicalDeviceStyleKey = "physicalDeviceStyle";

		private readonly ResourceDictionary _resources;

		public MenuItemStyleSelector(ResourceDictionary resources)
		{
			_resources = resources;
		}

		public override Style SelectStyle(object item, DependencyObject container)
		{
			if (item is SoftDevice)
			{
				return (Style)_resources["deviceWithModesStyle"];
			}
			if (item is PhysicalDevice)
			{
				DeviceType? deviceType = (item as PhysicalDevice)?.DeviceType;
				if (deviceType.HasValue && deviceType == DeviceType.BlackmagicCard)
				{
					return (Style)_resources["deviceWithModesStyle"];
				}
				return (Style)_resources["physicalDeviceStyle"];
			}
			if (item is DeviceBase)
			{
				return (Style)_resources["deviceStyle"];
			}
			return base.SelectStyle(item, container);
		}
	}

	public static readonly DependencyProperty AttachedPhysicalDevicesProperty = DependencyProperty.Register("AttachedPhysicalDevices", typeof(IEnumerable<PhysicalDevice>), typeof(DeviceSelectorMenuItem));

	public static readonly DependencyProperty AddCombinedScreenCommandProperty = DependencyProperty.Register("AddCombinedScreenCommand", typeof(ICommand), typeof(DeviceSelectorMenuItem));

	public static readonly DependencyProperty AddEdgeBlendScreenCommandProperty = DependencyProperty.Register("AddEdgeBlendScreenCommand", typeof(ICommand), typeof(DeviceSelectorMenuItem));

	public static readonly DependencyProperty AssignDeviceCommandProperty = DependencyProperty.Register("AssignDeviceCommand", typeof(ICommand<DeviceCommandParameter>), typeof(DeviceSelectorMenuItem));

	public static readonly DependencyProperty DevicesProperty = DependencyProperty.Register("Devices", typeof(IEnumerable<IDevice>), typeof(DeviceSelectorMenuItem));

	public static readonly DependencyProperty TemporaryDevicesProperty = DependencyProperty.Register("TemporaryDevices", typeof(IEnumerable<IDevice>), typeof(DeviceSelectorMenuItem));

	public static readonly DependencyProperty ShowSelectDeviceProperty = DependencyProperty.Register("ShowSelectDevice", typeof(bool), typeof(DeviceSelectorMenuItem), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));

	public static readonly DependencyProperty RemoveDeviceCommandProperty = DependencyProperty.Register("RemoveDeviceCommand", typeof(ICommand), typeof(DeviceSelectorMenuItem));

	public static readonly DependencyProperty IdentifyScreenCommandProperty = DependencyProperty.Register("IdentifyScreenCommand", typeof(ICommand<PhysicalDevice>), typeof(DeviceSelectorMenuItem));

	public static readonly DependencyProperty ClearScreenIdentifyCommandProperty = DependencyProperty.Register("ClearScreenIdentifyCommand", typeof(ICommand), typeof(DeviceSelectorMenuItem));

	public static readonly DependencyProperty CanOpenScreenConfigProperty = DependencyProperty.Register("CanOpenScreenConfig", typeof(bool), typeof(DeviceSelectorMenuItem), new PropertyMetadata((object)false));

	public static readonly DependencyProperty PlacementTargetProperty = DependencyProperty.Register("PlacementTarget", typeof(UIElement), typeof(DeviceSelectorMenuItem));

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

	public ICommand<DeviceCommandParameter?>? AssignDeviceCommand
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

	public ICommand<PhysicalDevice>? IdentifyScreenCommand
	{
		get
		{
			return (ICommand<PhysicalDevice>)((DependencyObject)this).GetValue(IdentifyScreenCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IdentifyScreenCommandProperty, (object)value);
		}
	}

	public ICommand? ClearScreenIdentifyCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(ClearScreenIdentifyCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ClearScreenIdentifyCommandProperty, (object)value);
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

	public DeviceSelectorMenuItem()
	{
		InitializeComponent();
		base.ItemContainerStyleSelector = new MenuItemStyleSelector(base.Resources);
	}

	private void AssignDevice(DeviceBase? device, DeviceModeBase? mode)
	{
		object obj = (PlacementTarget as FrameworkElement)?.DataContext;
		if (device != null && obj != null)
		{
			DeviceCommandParameter parameter = null;
			if (obj is ScreenTargetType value)
			{
				parameter = new DeviceCommandParameter(value, null, device, mode);
			}
			else if (obj is HardwareScreenRectangleOptions targetRectangle)
			{
				parameter = new DeviceCommandParameter(null, targetRectangle, device, mode);
			}
			else if (obj is Screen screen)
			{
				parameter = new DeviceCommandParameter(null, screen.MainOutput, device, mode);
			}
			AssignDeviceCommand?.Invoke<DeviceCommandParameter>(parameter);
		}
	}

	private void Device_Click(object? sender, RoutedEventArgs e)
	{
		if (!(sender is MenuItem menuItem))
		{
			return;
		}
		DeviceBase device = menuItem.DataContext as DeviceBase;
		DeviceModeBase mode = (e.OriginalSource as MenuItem)?.DataContext as DeviceModeBase;
		if ((e.OriginalSource as MenuItem)?.DataContext is DynamicDeviceMode dynamicDeviceMode)
		{
			if (dynamicDeviceMode.DisplayValue == null)
			{
				if (!CustomSizeHelper.TrySetCustomSize((menuItem.DataContext as DeviceBase)?.DeviceMode, out DeviceMode mode2))
				{
					return;
				}
				mode = mode2;
			}
			else
			{
				mode = dynamicDeviceMode.DisplayValue;
			}
		}
		AssignDevice(device, mode);
	}

	private void ModeMenu_Opened(object? sender, RoutedEventArgs e)
	{
		MenuItem deviceItem = sender as MenuItem;
		if (deviceItem == null)
		{
			return;
		}
		ItemContainerGenerator icg = deviceItem.ItemContainerGenerator;
		if (icg.Status != GeneratorStatus.ContainersGenerated)
		{
			EventHandler handler = null;
			handler = delegate
			{
				if (icg.Status == GeneratorStatus.ContainersGenerated || icg.Status == GeneratorStatus.Error)
				{
					icg.StatusChanged -= handler;
					UpdateModeChecks(deviceItem);
				}
			};
			deviceItem.ItemContainerGenerator.StatusChanged += handler;
		}
		else
		{
			UpdateModeChecks(deviceItem);
		}
	}

	private void UpdateModeChecks(MenuItem menuItem)
	{
		DeviceBase deviceBase = (DeviceBase)menuItem.DataContext;
		int count = menuItem.Items.Count;
		for (int i = 0; i < count; i++)
		{
			if (menuItem.ItemContainerGenerator.ContainerFromIndex(i) is MenuItem menuItem2)
			{
				DeviceMode deviceMode = menuItem2.DataContext as DeviceMode;
				if (deviceMode == null && menuItem2.DataContext is DynamicDeviceMode dynamicDeviceMode)
				{
					deviceMode = dynamicDeviceMode.DisplayValue as DeviceMode;
				}
				if (deviceMode != null)
				{
					menuItem2.IsChecked = deviceBase.ModeIndex == deviceMode.ModeIndex;
				}
			}
		}
	}

	protected override void OnSubmenuOpened(RoutedEventArgs e)
	{
		((DependencyObject)this).SetCurrentValue(PlacementTargetProperty, (object)((DependencyObject)(object)this).FindVisualParent<ContextMenu>()?.PlacementTarget);
		if (PlacementTarget is FrameworkElement { DataContext: var dataContext })
		{
			HardwareScreenRectangleOptions rectangle = dataContext as HardwareScreenRectangleOptions;
			if (rectangle != null)
			{
				(from i in base.Items.OfType<DeviceBase>()
					select base.ItemContainerGenerator.ContainerFromItem(i) as MenuItem).NotNull().ForEach(delegate(MenuItem m)
				{
					m.IsChecked = rectangle != null && rectangle.OutputDevice == m.DataContext;
				});
			}
		}
		base.OnSubmenuOpened(e);
	}

	protected override void OnSubmenuClosed(RoutedEventArgs e)
	{
		ClearScreenIdentifyCommand?.Invoke();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
