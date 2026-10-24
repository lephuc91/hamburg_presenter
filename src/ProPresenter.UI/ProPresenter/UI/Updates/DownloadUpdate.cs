using System.Windows;
using System.Windows.Markup;
using Pro.UI.Controls.Windowing;

namespace ProPresenter.UI.Updates;

public partial class DownloadUpdate : ChromedWindow, IComponentConnector
{
	public DownloadUpdate()
	{
		InitializeComponent();
	}

	private void CloseDialog_Click(object? sender, RoutedEventArgs e)
	{
		Close();
	}
}
