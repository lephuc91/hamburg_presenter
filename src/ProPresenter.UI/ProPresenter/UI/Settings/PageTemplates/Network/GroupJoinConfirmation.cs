using System.Windows;
using System.Windows.Markup;
using Pro.UI.Controls.Windowing;

namespace ProPresenter.UI.Settings.PageTemplates.Network;

public partial class GroupJoinConfirmation : ChromedWindow, IComponentConnector
{
	public GroupJoinConfirmation()
	{
		InitializeComponent();
	}

	private void Close_Click(object? sender, RoutedEventArgs e)
	{
		base.DialogResult = false;
		Close();
	}
}
