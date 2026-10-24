using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.UI.Utility;
using ProPresenter.UI.ViewModels.Settings.Pages;

namespace ProPresenter.UI.Settings.PageTemplates.General;

public partial class CopyrightLayout : UserControl, IComponentConnector
{
	public CopyrightLayout()
	{
		InitializeComponent();
		base.GotFocus += CopyrightLayout_GotFocus;
	}

	private void CopyrightLayout_GotFocus(object? sender, RoutedEventArgs e)
	{
		if (base.DataContext is ICopyrightSettingsVM copyrightSettingsVM)
		{
			copyrightSettingsVM.GotFocusCommand?.Invoke();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
