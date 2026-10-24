using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.UI.Utility;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.UI.SlideEditor;

public partial class OverlayEditor : UserControl, IComponentConnector
{
	public OverlayEditor()
	{
		InitializeComponent();
	}

	protected override void OnPreviewKeyDown(KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		if ((int)e.Key == 13)
		{
			(base.DataContext as OverlayEditorVM)?.EscapeCommand.Invoke();
		}
	}

	private void textBox_IsVisibleChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		textBox.Focus();
	}
}
