using System.Windows;
using System.Windows.Markup;
using Pro.Common.Mathematics;
using Pro.UI.Components;
using Pro.UI.Controls.Windowing;
using Pro.UI.Utility;
using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.UI.OutputConfiguration;

public partial class NewCustomDevice : ChromedWindow, IComponentConnector
{
	public static readonly DependencyProperty DeviceProperty = DependencyProperty.Register("Device", typeof(PlaceholderDevice), typeof(NewCustomDevice));

	public static readonly DependencyProperty NewPlaceholderDeviceCommandProperty = DependencyProperty.Register("NewPlaceholderDeviceCommand", typeof(ICommand<DeviceCommandParameter>), typeof(NewCustomDevice));

	public PlaceholderDevice? Device
	{
		get
		{
			return (PlaceholderDevice)((DependencyObject)this).GetValue(DeviceProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DeviceProperty, (object)value);
		}
	}

	public ICommand<DeviceCommandParameter>? NewPlaceholderDeviceCommand
	{
		get
		{
			return (ICommand<DeviceCommandParameter>)((DependencyObject)this).GetValue(NewPlaceholderDeviceCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(NewPlaceholderDeviceCommandProperty, (object)value);
		}
	}

	public HardwareScreenRectangleOptions? HardwareRectangle { get; set; }

	public ScreenTargetType? ScreenTargetType { get; set; }

	public NewCustomDevice()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		InitializeComponent();
		base.IsVisibleChanged += new DependencyPropertyChangedEventHandler(NewCustomDevice_IsVisibleChanged);
	}

	private void NewCustomDevice_IsVisibleChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		if (base.IsVisible)
		{
			((DependencyObject)this).SetValue(DeviceProperty, (object)new PlaceholderDevice(Vector2<int>.One));
		}
	}

	private void OK_Click(object? sender, RoutedEventArgs e)
	{
		Close();
		NewPlaceholderDeviceCommand?.Invoke(new DeviceCommandParameter(ScreenTargetType, HardwareRectangle, Device));
	}

	private void Cancel_Click(object? sender, RoutedEventArgs e)
	{
		Close();
	}
}
