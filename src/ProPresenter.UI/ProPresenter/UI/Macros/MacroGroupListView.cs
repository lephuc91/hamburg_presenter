using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.UI.Utility;
using ProPresenter.UI.ViewModels.Macros;

namespace ProPresenter.UI.Macros;

public partial class MacroGroupListView : UserControl, IComponentConnector
{
	public static readonly DependencyProperty GotFocusCommandProperty = DependencyProperty.Register("GotFocusCommand", typeof(ICommand), typeof(MacroGroupListView));

	public ICommand GotFocusCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(GotFocusCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(GotFocusCommandProperty, (object)value);
		}
	}

	public MacroGroupListView()
	{
		InitializeComponent();
		base.GotKeyboardFocus += delegate
		{
			GotFocusCommand?.Invoke();
		};
	}

	private void MacroMenu_Opened(object? sender, RoutedEventArgs e)
	{
		if (sender is ContextMenu { PlacementTarget: FrameworkElement placementTarget } && placementTarget.DataContext is IMacroItemVM && base.DataContext is IMacroGroupVM macroGroupVM)
		{
			macroGroupVM.ContextMenuTarget = placementTarget;
		}
	}

	private void MacroMenu_Closed(object? sender, RoutedEventArgs e)
	{
		if (base.DataContext is IMacroGroupVM macroGroupVM)
		{
			macroGroupVM.ContextMenuTarget = null;
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
