using System.Windows;
using CommunityToolkit.Mvvm.Input;
using Pro.UI.Utility;
using ProPresenter.DO.Communication;

namespace ProPresenter.UI.Settings.PageTemplates.Devices;

public class DeviceChildPageButton : ChildPageButton
{
	public static readonly DependencyProperty GotoPageProperty = DependencyProperty.Register("SetTargetDeviceCommand", typeof(IRelayCommand<IDevice>), typeof(DeviceChildPageButton), new PropertyMetadata((PropertyChangedCallback)null));

	public static readonly DependencyProperty SetTargetDeviceCommandParameterProperty = DependencyProperty.Register("SetTargetDeviceCommandParameter", typeof(IDevice), typeof(DeviceChildPageButton), new PropertyMetadata((PropertyChangedCallback)null));

	public IRelayCommand<IDevice?>? SetTargetDeviceCommand
	{
		get
		{
			return (IRelayCommand<IDevice>)((DependencyObject)this).GetValue(GotoPageProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(GotoPageProperty, (object)value);
		}
	}

	public IDevice? SetTargetDeviceCommandParameter
	{
		get
		{
			return (IDevice)((DependencyObject)this).GetValue(SetTargetDeviceCommandParameterProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SetTargetDeviceCommandParameterProperty, (object)value);
		}
	}

	protected override void OnGotoPage()
	{
		if (SetTargetDeviceCommandParameter != null)
		{
			SetTargetDeviceCommand?.Invoke<IDevice>(SetTargetDeviceCommandParameter);
		}
	}
}
