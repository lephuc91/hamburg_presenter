using System.Windows;
using System.Windows.Markup;
using Pro.UI.Controls.Windowing;

namespace ProPresenter.UI.Settings.PageTemplates.Integrations.CCLI;

public partial class AutoReportOptionDialog : ChromedWindow, IComponentConnector
{
	public AutoReportOptionDialog()
	{
		InitializeComponent();
	}

	private void AutoReport_Click(object? sender, RoutedEventArgs e)
	{
		base.DialogResult = true;
	}

	private void ManualReport_Click(object? sender, RoutedEventArgs e)
	{
		base.DialogResult = false;
	}
}
