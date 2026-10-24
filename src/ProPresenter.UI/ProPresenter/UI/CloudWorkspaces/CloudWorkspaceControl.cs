using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace ProPresenter.UI.CloudWorkspaces;

public partial class CloudWorkspaceControl : UserControl, IComponentConnector
{
	public static readonly DependencyProperty ShowExtraMenuItemsProperty = DependencyProperty.Register("ShowExtraMenuItems", typeof(bool), typeof(CloudWorkspaceControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public bool ShowExtraMenuItems
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowExtraMenuItemsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowExtraMenuItemsProperty, (object)value);
		}
	}

	public CloudWorkspaceControl()
	{
		InitializeComponent();
	}
}
