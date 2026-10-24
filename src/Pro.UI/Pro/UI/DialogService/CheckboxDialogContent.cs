using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Pro.UI.DialogService;

public partial class CheckboxDialogContent : UserControl, IComponentConnector
{
	public static readonly DependencyProperty HeadingProperty = DependencyProperty.Register("Heading", typeof(string), typeof(CheckboxDialogContent));

	public static readonly DependencyProperty MessageProperty = DependencyProperty.Register("Message", typeof(string), typeof(CheckboxDialogContent));

	public static readonly DependencyProperty CheckboxTextProperty = DependencyProperty.Register("CheckboxText", typeof(string), typeof(CheckboxDialogContent));

	public static readonly DependencyProperty CheckedProperty = DependencyProperty.Register("Checked", typeof(bool), typeof(CheckboxDialogContent));

	public string Heading
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(HeadingProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HeadingProperty, (object)value);
		}
	}

	public string Message
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(MessageProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MessageProperty, (object)value);
		}
	}

	public string CheckboxText
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(CheckboxTextProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CheckboxTextProperty, (object)value);
		}
	}

	public bool Checked
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(CheckedProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CheckedProperty, (object)value);
		}
	}

	public CheckboxDialogContent()
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
