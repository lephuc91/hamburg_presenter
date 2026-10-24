using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace ProPresenter.UI.Settings;

public partial class SettingsHeaderNavigation : UserControl, IComponentConnector
{
	public SettingsHeaderNavigation()
	{
		InitializeComponent();
	}

	private void Navigate_Click(object? sender, RoutedEventArgs e)
	{
		Focus();
	}
}
