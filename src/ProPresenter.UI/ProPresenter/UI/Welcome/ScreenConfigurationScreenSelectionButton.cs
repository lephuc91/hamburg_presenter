using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using ProPresenter.DO.OutputConfiguration;
using ProPresenter.UI.OutputConfiguration;
using ProPresenter.UI.ViewModels.Welcome;

namespace ProPresenter.UI.Welcome;

public partial class ScreenConfigurationScreenSelectionButton : UserControl, IComponentConnector
{
	public static readonly DependencyProperty ScreenTargetTypeProperty = DependencyProperty.Register("ScreenTargetType", typeof(ScreenTargetType), typeof(ScreenConfigurationScreenSelectionButton));

	public static readonly DependencyProperty ConfigurationProperty = DependencyProperty.Register("Configuration", typeof(ISimpleScreenConfiguration), typeof(ScreenConfigurationScreenSelectionButton));

	public static readonly DependencyProperty DeviceSelectorProperty = DependencyProperty.Register("DeviceSelector", typeof(DeviceSelector), typeof(ScreenConfigurationScreenSelectionButton));

	public ScreenTargetType ScreenTargetType
	{
		get
		{
			return (ScreenTargetType)((DependencyObject)this).GetValue(ScreenTargetTypeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ScreenTargetTypeProperty, (object)value);
		}
	}

	public ISimpleScreenConfiguration Configuration
	{
		get
		{
			return (ISimpleScreenConfiguration)((DependencyObject)this).GetValue(ConfigurationProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ConfigurationProperty, (object)value);
		}
	}

	public DeviceSelector DeviceSelector
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

	public ScreenConfigurationScreenSelectionButton()
	{
		InitializeComponent();
	}
}
