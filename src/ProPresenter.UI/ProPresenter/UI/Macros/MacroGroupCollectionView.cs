using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.UI.Utility;
using ProPresenter.UI.ViewModels.Macros;

namespace ProPresenter.UI.Macros;

public partial class MacroGroupCollectionView : UserControl, IComponentConnector
{
	public MacroGroupCollectionView()
	{
		InitializeComponent();
		base.PreviewMouseDown += MacroGroupCollectionView_PreviewMouseDown;
	}

	private void MacroGroupCollectionView_PreviewMouseDown(object? sender, MouseButtonEventArgs e)
	{
		if (base.DataContext is IMacroGroupCollectionVM macroGroupCollectionVM)
		{
			macroGroupCollectionVM.GotFocusCommand?.Invoke();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
