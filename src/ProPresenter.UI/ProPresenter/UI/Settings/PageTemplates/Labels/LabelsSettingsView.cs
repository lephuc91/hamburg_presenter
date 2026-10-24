using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.UI.Utility;
using ProPresenter.UI.ViewModels.Settings.Pages.Labels;

namespace ProPresenter.UI.Settings.PageTemplates.Labels;

public partial class LabelsSettingsView : UserControl, IComponentConnector
{
	public LabelsSettingsView()
	{
		InitializeComponent();
		base.GotKeyboardFocus += LabelsSettingsView_GotKeyboardFocus;
	}

	private void LabelsSettingsView_GotKeyboardFocus(object? sender, KeyboardFocusChangedEventArgs e)
	{
		OnGotFocus();
	}

	private void OnGotFocus()
	{
		if (base.DataContext is ILabelsSettingsVM labelsSettingsVM)
		{
			labelsSettingsVM.GotFocusCommand?.Invoke();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
