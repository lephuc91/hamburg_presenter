using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Pro.UI.Controls;

public partial class DropDownButton : UserControl, IComponentConnector
{
	public static readonly DependencyProperty CustomContentProperty = DependencyProperty.Register("CustomContent", typeof(object), typeof(DropDownButton));

	public static readonly DependencyProperty CustomContextMenuProperty = DependencyProperty.Register("CustomContextMenu", typeof(ContextMenu), typeof(DropDownButton));

	public object CustomContent
	{
		get
		{
			return ((DependencyObject)this).GetValue(CustomContentProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CustomContentProperty, value);
		}
	}

	public ContextMenu CustomContextMenu
	{
		get
		{
			return (ContextMenu)((DependencyObject)this).GetValue(CustomContextMenuProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CustomContextMenuProperty, (object)value);
		}
	}

	public DropDownButton()
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
