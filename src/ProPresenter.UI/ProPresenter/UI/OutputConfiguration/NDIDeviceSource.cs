using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.UI.Components;
using Pro.UI.Utility;
using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.UI.OutputConfiguration;

public partial class NDIDeviceSource : MenuItem, IComponentConnector, IStyleConnector
{
	public static readonly DependencyProperty PlacementTargetProperty = DependencyProperty.Register("PlacementTarget", typeof(UIElement), typeof(NDIDeviceSource));

	public static readonly DependencyProperty AssignDeviceCommandProperty = DependencyProperty.Register("AssignDeviceCommand", typeof(ICommand<DeviceCommandParameter>), typeof(NDIDeviceSource));

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

	public NDIDeviceSource()
	{
		InitializeComponent();
	}

	private void Mode_Click(object? sender, RoutedEventArgs e)
	{
		DeviceMode deviceMode = null;
		object obj = (PlacementTarget as FrameworkElement)?.DataContext;
		if (sender is MenuItem menuItem)
		{
			if (menuItem.DataContext is DeviceMode deviceMode2)
			{
				deviceMode = deviceMode2;
			}
			else if (menuItem.DataContext is DynamicDeviceMode)
			{
				if (!CustomSizeHelper.TrySetCustomSize((obj as HardwareScreenRectangleOptions)?.OutputDevice?.DeviceMode, out DeviceMode mode))
				{
					return;
				}
				deviceMode = mode;
			}
		}
		if (obj != null && deviceMode != null)
		{
			DeviceCommandParameter parameter = null;
			if (obj is ScreenTargetType value)
			{
				parameter = new DeviceCommandParameter(value, null, SoftDevice.CreateNDIDevice(deviceMode), deviceMode);
			}
			else if (obj is HardwareScreenRectangleOptions targetRectangle)
			{
				parameter = new DeviceCommandParameter(null, targetRectangle, SoftDevice.CreateNDIDevice(deviceMode), deviceMode);
			}
			else if (obj is Screen screen)
			{
				parameter = new DeviceCommandParameter(null, screen.MainOutput, SoftDevice.CreateNDIDevice(deviceMode), deviceMode);
			}
			AssignDeviceCommand?.Invoke<DeviceCommandParameter>(parameter);
		}
	}
}
