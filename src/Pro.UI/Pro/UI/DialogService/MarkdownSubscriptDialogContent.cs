using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Pro.UI.DialogService;

public partial class MarkdownSubscriptDialogContent : UserControl, IComponentConnector
{
	public static readonly DependencyProperty HeadingProperty = DependencyProperty.Register("Heading", typeof(string), typeof(MarkdownSubscriptDialogContent));

	public static readonly DependencyProperty MessageProperty = DependencyProperty.Register("Message", typeof(string), typeof(MarkdownSubscriptDialogContent));

	public static readonly DependencyProperty MarkdownProperty = DependencyProperty.Register("Markdown", typeof(string), typeof(MarkdownSubscriptDialogContent));

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

	public string Markdown
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(MarkdownProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MarkdownProperty, (object)value);
		}
	}

	public MarkdownSubscriptDialogContent()
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
