using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.Localization;
using Pro.UI.Controls;
using Pro.UI.DialogService;
using ProPresenter.DO.Capture;

namespace ProPresenter.UI.Capture;

public partial class RtmpCapture : UserControl, IComponentConnector
{
	public RtmpCapture()
	{
		InitializeComponent();
	}

	private void AddressBox_LostFocus(object? sender, RoutedEventArgs e)
	{
		if (sender is PlaceholderTextBox placeholderTextBox && !string.IsNullOrEmpty(placeholderTextBox.Text))
		{
			if (!placeholderTextBox.Text.IsValidAddress())
			{
				MessageDialogService.ShowDialog(string.Empty, LocalizedStrings.Get("RECORDING_WINDOW_RTMP_ADDRESS_INVALID_label"), DefaultButtons.OK, DefaultButtons.OK);
				placeholderTextBox.GetBindingExpression(PlaceholderTextBox.TextProperty)?.UpdateTarget();
			}
			else
			{
				placeholderTextBox.GetBindingExpression(PlaceholderTextBox.TextProperty)?.UpdateSource();
			}
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
