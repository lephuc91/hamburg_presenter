using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using ProPresenter.Controller.Outputs.Communication;

namespace ProPresenter.UI.ActionPalette;

public partial class ActionPanel : UserControl, IComponentConnector
{
	public static readonly DependencyProperty DevicesProperty = DependencyProperty.Register("Devices", typeof(DeviceCollection), typeof(ActionPanel));

	public DeviceCollection? Devices
	{
		get
		{
			return (DeviceCollection)((DependencyObject)this).GetValue(DevicesProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(DevicesProperty, (object)value);
		}
	}

	public ActionPanel()
	{
		InitializeComponent();
	}
}
