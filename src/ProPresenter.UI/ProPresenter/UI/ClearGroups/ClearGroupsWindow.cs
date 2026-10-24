using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows.Markup;
using Pro.UI.Controls.Windowing;
using Pro.UI.Utility;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.UI.ClearGroups;

public partial class ClearGroupsWindow : ChromedWindow, IComponentConnector
{
	public ClearGroupsWindow()
	{
		InitializeComponent();
		base.GotKeyboardFocus += delegate
		{
			if (base.DataContext is IClearGroupCollectionVM clearGroupCollectionVM)
			{
				clearGroupCollectionVM.GotFocusCommand?.Invoke();
			}
		};
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
