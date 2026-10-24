using System.Windows;
using System.Windows.Markup;
using Pro.UI.Controls.Windowing;

namespace ProPresenter.UI.Capture;

public partial class CaptureNameDialog : ChromedWindow, IComponentConnector
{
	public CaptureNameDialog()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		InitializeComponent();
		base.IsVisibleChanged += (DependencyPropertyChangedEventHandler)delegate
		{
			PresetTextBox.Focus();
			PresetTextBox.SelectAll();
		};
	}
}
