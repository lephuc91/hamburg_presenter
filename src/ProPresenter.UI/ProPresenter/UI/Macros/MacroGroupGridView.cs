using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using ProPresenter.UI.ViewModels.Macros;

namespace ProPresenter.UI.Macros;

public partial class MacroGroupGridView : UserControl, IComponentConnector
{
	public MacroGroupGridView()
	{
		InitializeComponent();
	}

	private void MacroMenu_Closed(object? sender, RoutedEventArgs e)
	{
		if (base.DataContext is IMacroGroupVM macroGroupVM)
		{
			macroGroupVM.ContextMenuTarget = null;
		}
	}

	private void MacroMenu_Opened(object? sender, RoutedEventArgs e)
	{
		if (sender is ContextMenu { PlacementTarget: FrameworkElement placementTarget } && base.DataContext is IMacroGroupVM macroGroupVM)
		{
			macroGroupVM.ContextMenuTarget = placementTarget;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
