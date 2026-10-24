using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace ProPresenter.UI.TestPattern;

public partial class TestPatternPropertiesView : UserControl, IComponentConnector
{
	public TestPatternPropertiesView()
	{
		InitializeComponent();
	}

	private void Properties_RequestBringIntoView(object? sender, RequestBringIntoViewEventArgs e)
	{
		e.Handled = true;
	}
}
