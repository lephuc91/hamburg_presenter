using System.Windows.Markup;
using Pro.UI.Controls.Windowing;

namespace ProPresenter.UI.Welcome;

public partial class WelcomeDialog : ChromedWindow, IComponentConnector
{
	public WelcomeDialog()
	{
		InitializeComponent();
	}
}
