using System.Windows;
using System.Windows.Markup;

namespace ProPresenter.UI.SlideEditor.Inspectors.Links;

public partial class PreviewFile : Window, IComponentConnector
{
	public PreviewFile()
	{
		InitializeComponent();
	}

	public void ViewContent(string title, string content)
	{
		base.Title = title;
		textBlock.Text = content;
		ShowDialog();
	}
}
