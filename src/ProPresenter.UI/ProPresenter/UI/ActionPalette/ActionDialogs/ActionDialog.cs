using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;

namespace ProPresenter.UI.ActionPalette.ActionDialogs;

public partial class ActionDialog : ActionDialogBase, IComponentConnector
{
	public static readonly DependencyProperty ChildProperty = DependencyProperty.Register("Child", typeof(UIElement), typeof(ActionDialog));

	public UIElement? Child
	{
		get
		{
			return (UIElement)((DependencyObject)this).GetValue(ChildProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ChildProperty, (object)value);
		}
	}

	public ActionDialog()
	{
		InitializeComponent();
	}

	private void Done_Click(object? sender, RoutedEventArgs e)
	{
		OnAccept();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
