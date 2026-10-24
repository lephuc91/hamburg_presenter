using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.UI.Utility;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.UI.Settings.PageTemplates.Network;

public partial class NetworkLinkView : UserControl, IComponentConnector
{
	public NetworkLinkView()
	{
		InitializeComponent();
	}

	private void AddMenu_Opened(object? sender, RoutedEventArgs e)
	{
		(base.DataContext as INetworkLinkVM)?.RefreshEnvironmentCommand?.Invoke();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
