using System;
using System.Windows;
using System.Windows.Markup;
using Pro.UI.Controls.Windowing;

namespace ProPresenter.UI.Settings.PageTemplates.Network;

public partial class AddConnectionView : ChromedWindow, IComponentConnector
{
	public AddConnectionView()
	{
		InitializeComponent();
		base.Activated += AddConnectionView_Activated;
	}

	private void AddConnectionView_Activated(object? sender, EventArgs e)
	{
		ipTextbox.Focus();
		ipTextbox.SelectAll();
	}

	private void Close_Click(object? sender, RoutedEventArgs e)
	{
		base.DialogResult = false;
		Close();
	}
}
