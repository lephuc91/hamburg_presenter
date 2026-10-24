using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.UI.Utility;
using ProPresenter.UI.ViewModels.Props;

namespace ProPresenter.UI.Props;

public partial class PropGroups : UserControl, IComponentConnector
{
	public PropGroups()
	{
		InitializeComponent();
		base.PreviewMouseDown += PropGroups_PreviewMouseDown;
	}

	private void PropGroups_PreviewMouseDown(object? sender, MouseButtonEventArgs e)
	{
		if (base.DataContext is IPropGroupCollectionVM propGroupCollectionVM)
		{
			propGroupCollectionVM.GotFocusCommand?.Invoke();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
