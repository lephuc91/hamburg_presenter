using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using ProPresenter.UI.ViewModels.OutputConfiguration;

namespace ProPresenter.UI.OutputConfiguration;

public partial class AlphaKey : UserControl, IComponentConnector
{
	public static readonly DependencyProperty ContextProperty = DependencyProperty.Register("Context", typeof(IAlphaKeySettingsVM), typeof(AlphaKey));

	public static readonly DependencyProperty DeviceSelectorProperty = DependencyProperty.Register("DeviceSelector", typeof(DeviceSelector), typeof(AlphaKey));

	public IAlphaKeySettingsVM? Context
	{
		get
		{
			return (IAlphaKeySettingsVM)((DependencyObject)this).GetValue(ContextProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ContextProperty, (object)value);
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

	public AlphaKey()
	{
		InitializeComponent();
	}
}
