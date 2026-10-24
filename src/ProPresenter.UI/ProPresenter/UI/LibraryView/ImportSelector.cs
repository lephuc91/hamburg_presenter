using System.Windows;
using System.Windows.Markup;
using Pro.UI.Controls.Windowing;

namespace ProPresenter.UI.LibraryView;

public partial class ImportSelector : ChromedWindow, IComponentConnector
{
	public ImportSelector()
	{
		InitializeComponent();
	}

	private void Button_Close(object sender, RoutedEventArgs e)
	{
		if (sender == okButton)
		{
			base.DialogResult = true;
		}
		Close();
	}
}
