using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.UI.Controls.Windowing;
using Pro.UI.DialogService;

namespace ProPresenter.UI.Capture;

public partial class ResiAbortUploadWindow : ChromedWindow, IComponentConnector
{
	public ForceQuitButton? Result { get; private set; }

	public ResiAbortUploadWindow()
	{
		InitializeComponent();
	}

	private void Button_Click(object? sender, RoutedEventArgs e)
	{
		if (sender is Button { DataContext: var dataContext } && dataContext is ForceQuitButton value)
		{
			Result = value;
		}
		Close();
	}
}
