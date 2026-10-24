using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using CommunityToolkit.Mvvm.Input;
using Pro.UI.Controls.Windowing;

namespace ProPresenter.UI.Registration.PopUpAlerts;

public partial class FullySignedOut : ChromedWindow, IComponentConnector
{
	public ICommand CloseCommand { get; }

	public FullySignedOut()
	{
		CloseCommand = new RelayCommand(base.Close);
		InitializeComponent();
	}

	private void Close_Click(object? sender, RoutedEventArgs e)
	{
		Close();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
