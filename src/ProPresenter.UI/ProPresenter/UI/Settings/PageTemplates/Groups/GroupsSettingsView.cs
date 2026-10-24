using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.UI.Utility;
using ProPresenter.UI.ViewModels.Settings.Pages.Groups;

namespace ProPresenter.UI.Settings.PageTemplates.Groups;

public partial class GroupsSettingsView : UserControl, IComponentConnector
{
	public GroupsSettingsView()
	{
		InitializeComponent();
		base.GotKeyboardFocus += GroupsSettingsView_GotKeyboardFocus;
	}

	private void GroupsSettingsView_GotKeyboardFocus(object? sender, KeyboardFocusChangedEventArgs e)
	{
		OnGotFocus();
	}

	private void OnGotFocus()
	{
		if (base.DataContext is IGroupsSettingsVM groupsSettingsVM)
		{
			groupsSettingsVM.GotFocusCommand?.Invoke();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
