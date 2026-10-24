using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace Pro.UI.Controls;

public partial class ProgressControl : UserControl, IComponentConnector
{
	public static readonly DependencyProperty ProgressProperty = DependencyProperty.Register("Progress", typeof(double), typeof(ProgressControl));

	public static readonly DependencyProperty CancelCommandProperty = DependencyProperty.Register("CancelCommand", typeof(ICommand), typeof(ProgressControl));

	public double Progress
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(ProgressProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ProgressProperty, (object)value);
		}
	}

	public ICommand CancelCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(CancelCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CancelCommandProperty, (object)value);
		}
	}

	public ProgressControl()
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
