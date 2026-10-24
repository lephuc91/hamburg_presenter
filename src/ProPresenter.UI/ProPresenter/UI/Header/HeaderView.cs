using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.UI.Components;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Timer;

namespace ProPresenter.UI.Header;

public partial class HeaderView : UserControl, IComponentConnector
{
	public static readonly DependencyProperty HeaderActionProperty = DependencyProperty.Register("HeaderAction", typeof(HeaderAction), typeof(HeaderView));

	public static readonly DependencyProperty TimersProperty = DependencyProperty.Register("Timers", typeof(TimerCollection), typeof(HeaderView));

	public static readonly DependencyProperty TriggerHeaderItemCommandProperty = DependencyProperty.Register("TriggerHeaderItemCommand", typeof(ICommand<HeaderAction>), typeof(HeaderView));

	public HeaderAction? HeaderAction
	{
		get
		{
			return (HeaderAction)((DependencyObject)this).GetValue(HeaderActionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HeaderActionProperty, (object)value);
		}
	}

	public TimerCollection? Timers
	{
		get
		{
			return (TimerCollection)((DependencyObject)this).GetValue(TimersProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TimersProperty, (object)value);
		}
	}

	public ICommand<HeaderAction>? TriggerHeaderItemCommand
	{
		get
		{
			return (ICommand<HeaderAction>)((DependencyObject)this).GetValue(TriggerHeaderItemCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TriggerHeaderItemCommandProperty, (object)value);
		}
	}

	public HeaderView()
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
