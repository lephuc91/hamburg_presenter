using System.Windows;
using System.Windows.Markup;
using Pro.UI.Controls.Windowing;

namespace ProPresenter.UI.Settings.PageTemplates.Inputs;

public partial class AirCastDownloadPluginFailed : ChromedWindow, IComponentConnector
{
	public AirCastDownloadPluginFailed()
	{
		InitializeComponent();
	}

	private void Download_Click(object sender, RoutedEventArgs e)
	{
		base.DialogResult = true;
	}

	private void Cancel_Click(object sender, RoutedEventArgs e)
	{
		base.DialogResult = false;
	}
}
