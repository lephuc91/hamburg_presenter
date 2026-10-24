using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using Pro.UI.Controls.Windowing;

namespace ProPresenter.UI.LibraryView;

public partial class PowerpointImportSelector : ChromedWindow, IComponentConnector
{
	public PowerpointImportSelector()
	{
		InitializeComponent();
	}

	private void Button_Close(object sender, RoutedEventArgs e)
	{
		if (sender == okButton)
		{
			base.DialogResult = true;
		}
		Close();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
