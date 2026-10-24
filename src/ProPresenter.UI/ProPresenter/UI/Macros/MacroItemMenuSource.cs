using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using Pro.UI.Components;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.UI.Macros;

public partial class MacroItemMenuSource : FrameworkCollection, IComponentConnector
{
	public static readonly DependencyProperty ActionsMenuVMProperty = DependencyProperty.Register("ActionsMenuVM", typeof(IActionsMenuVM), typeof(MacroItemMenuSource));

	public IActionsMenuVM ActionsMenuVM
	{
		get
		{
			return (IActionsMenuVM)((DependencyObject)this).GetValue(ActionsMenuVMProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ActionsMenuVMProperty, (object)value);
		}
	}

	public MacroItemMenuSource()
	{
		InitializeComponent();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
