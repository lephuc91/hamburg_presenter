using System.Windows;
using System.Windows.Markup;
using Pro.UI.Controls.Windowing;

namespace ProPresenter.UI.Downloads;

public partial class CleanupPlaceholderActionsDialog : ChromedWindow, IComponentConnector
{
	public CleanupPlaceholderActionsDialog()
	{
		InitializeComponent();
	}

	private void Remove_Click(object? sender, RoutedEventArgs e)
	{
		base.DialogResult = true;
		Close();
	}

	private void Keep_Click(object? sender, RoutedEventArgs e)
	{
		base.DialogResult = false;
		Close();
	}
}
