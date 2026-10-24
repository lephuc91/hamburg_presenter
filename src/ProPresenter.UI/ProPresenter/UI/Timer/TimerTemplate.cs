using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.UI.Components;

namespace ProPresenter.UI.Timer;

public partial class TimerTemplate : UserControl, IComponentConnector
{
	public static readonly DependencyProperty StopCommandProperty = DependencyProperty.Register("StopCommand", typeof(ICommand<Guid>), typeof(TimerTemplate));

	public static readonly DependencyProperty StartCommandProperty = DependencyProperty.Register("StartCommand", typeof(ICommand<Guid>), typeof(TimerTemplate));

	public static readonly DependencyProperty ResetCommandProperty = DependencyProperty.Register("ResetCommand", typeof(ICommand<Guid>), typeof(TimerTemplate));

	public ICommand<Guid>? StopCommand
	{
		get
		{
			return (ICommand<Guid>)((DependencyObject)this).GetValue(StopCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(StopCommandProperty, (object)value);
		}
	}

	public ICommand<Guid>? StartCommand
	{
		get
		{
			return (ICommand<Guid>)((DependencyObject)this).GetValue(StartCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(StartCommandProperty, (object)value);
		}
	}

	public ICommand<Guid>? ResetCommand
	{
		get
		{
			return (ICommand<Guid>)((DependencyObject)this).GetValue(ResetCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ResetCommandProperty, (object)value);
		}
	}

	public TimerTemplate()
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
