using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.UI.Controls.Windowing;

namespace ProPresenter.UI.LibraryView;

public partial class SaveAsTemplateWindow : ChromedWindow, IComponentConnector
{
	public string? TemplateName { get; set; }

	public SaveAsTemplateWindow()
	{
		InitializeComponent();
		base.Loaded += delegate
		{
			templateName.Text = TemplateName;
			templateName.SelectAll();
			templateName.Focus();
		};
	}

	private void Cancel_Click(object? sender, RoutedEventArgs e)
	{
		base.DialogResult = false;
	}

	private void Save_Click(object? sender, RoutedEventArgs e)
	{
		TemplateName = templateName.Text;
		base.DialogResult = true;
	}

	private void TemplateName_PreviewKeyDown(object? sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		if ((int)e.Key == 13)
		{
			base.DialogResult = false;
		}
	}
}
