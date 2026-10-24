using System.Windows.Controls;
using System.Windows.Markup;

namespace ProPresenter.UI.Updates;

public partial class UpdateToDate : UserControl, IComponentConnector
{
	public string Version { get; }

	public UpdateToDate(string version)
	{
		Version = version;
		InitializeComponent();
	}
}
