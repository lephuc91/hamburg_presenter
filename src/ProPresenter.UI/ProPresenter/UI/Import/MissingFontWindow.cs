using System.Windows;
using System.Windows.Markup;
using Pro.UI.Controls.Windowing;

namespace ProPresenter.UI.Import;

public partial class MissingFontWindow : ChromedWindow, IComponentConnector
{
	public MissingFontWindow()
	{
		InitializeComponent();
	}

	private void Continue_Click(object sender, RoutedEventArgs e)
	{
		base.DialogResult = true;
		Close();
	}
}
