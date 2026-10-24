using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.Common.MessageService;
using Pro.Common.MessageService.AppMessages;
using Pro.Localization;
using Pro.UI.DependencyInjection;
using Pro.UI.DialogService;
using Pro.UI.Utility;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.DO.Settings;
using ProPresenter.DO.Settings.AppSettings;

namespace ProPresenter.UI.OutputConfiguration;

public partial class Hardware : UserControl, IComponentConnector, IStyleConnector
{
	private readonly IApp _app;

	private readonly IMessageService _messageService;

	public static readonly DependencyProperty HardwareRectangleProperty = DependencyProperty.Register("HardwareRectangle", typeof(HardwareScreenRectangleOptions), typeof(Hardware));

	public static readonly DependencyProperty DeviceSelectorProperty = DependencyProperty.Register("DeviceSelector", typeof(DeviceSelector), typeof(Hardware));

	public HardwareScreenRectangleOptions? HardwareRectangle
	{
		get
		{
			return (HardwareScreenRectangleOptions)((DependencyObject)this).GetValue(HardwareRectangleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HardwareRectangleProperty, (object)value);
		}
	}

	public DeviceSelector? DeviceSelector
	{
		get
		{
			return (DeviceSelector)((DependencyObject)this).GetValue(DeviceSelectorProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DeviceSelectorProperty, (object)value);
		}
	}

	public Hardware()
	{
		InitializeComponent();
		_app = UIServiceProvider.GetService<IApp>();
		_messageService = UIServiceProvider.GetService<IMessageService>();
	}

	private void DeviceMode_Click(object? sender, RoutedEventArgs e)
	{
		if (!(sender is MenuItem menuItem))
		{
			return;
		}
		DeviceMode deviceMode = menuItem.DataContext as DeviceMode;
		if (menuItem.DataContext is DynamicDeviceMode dynamicDeviceMode)
		{
			if (dynamicDeviceMode.DisplayValue == null)
			{
				if (!CustomSizeHelper.TrySetCustomSize(HardwareRectangle?.OutputDevice?.DeviceMode, out DeviceMode mode))
				{
					return;
				}
				deviceMode = mode;
			}
			else
			{
				deviceMode = dynamicDeviceMode.DisplayValue as DeviceMode;
			}
		}
		if (deviceMode != null && HardwareRectangle?.OutputDevice != null)
		{
			DeviceCommandParameter parameter = new DeviceCommandParameter(null, HardwareRectangle, HardwareRectangle.OutputDevice, deviceMode);
			DeviceSelector?.AssignDeviceCommand?.Invoke<DeviceCommandParameter>(parameter);
		}
	}

	private void HdrFormat_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		if (e.AddedItems.Count <= 0)
		{
			return;
		}
		object obj = e.AddedItems[0];
		if (obj is HdrFormats && (HdrFormats)obj != 0 && _app.RenderBitDepth == BitDepth.Normal)
		{
			_app.RenderBitDepth = BitDepth.Enhanced;
			MessageDialogService.ShowDialogNonBlocking(LocalizedStrings.Get("SCREEN_CONFIGURATION_HARDWARE_TAB_OUTPUT_HDR_FORMAT_RELAUNCH_title"), LocalizedStrings.Get("SCREEN_CONFIGURATION_HARDWARE_TAB_OUTPUT_HDR_FORMAT_RELAUNCH_message"), new global::_003C_003Ez__ReadOnlyArray<ButtonDescriptor>(new ButtonDescriptor[2]
			{
				new ButtonDescriptor(LocalizedStrings.Get("SCREEN_CONFIGURATION_HARDWARE_TAB_OUTPUT_HDR_FORMAT_BUTTON_RELAUNCH_now"), IsDefault: true, IsCancel: false, delegate
				{
					_messageService.PublishMessage(new RequestApplicationRestartMessage());
				}),
				new ButtonDescriptor(LocalizedStrings.Get("SCREEN_CONFIGURATION_HARDWARE_TAB_OUTPUT_HDR_FORMAT_BUTTON_RELAUNCH_later"), IsDefault: false, IsCancel: true)
			}));
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
