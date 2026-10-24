using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.UI.Components;
using Pro.UI.Utility;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Timer;

namespace ProPresenter.UI.Timer;

public partial class TimerActionContent : UserControl, IComponentConnector
{
	public static readonly DependencyProperty TimerActionProperty = DependencyProperty.Register("TimerAction", typeof(TimerAction), typeof(TimerActionContent));

	public static readonly DependencyProperty TimersProperty = DependencyProperty.Register("Timers", typeof(TimerCollection), typeof(TimerActionContent));

	public static readonly DependencyProperty SelectTimerCommandProperty = DependencyProperty.Register("SelectTimerCommand", typeof(ICommand<TimerData>), typeof(TimerActionContent));

	public static readonly DependencyProperty ChangeConfigurationCommandProperty = DependencyProperty.Register("ChangeConfigurationCommand", typeof(ICommand<TimerType>), typeof(TimerActionContent));

	public static readonly DependencyProperty CanDeSelectTimerProperty = DependencyProperty.Register("CanDeSelectTimer", typeof(bool), typeof(TimerActionContent), new PropertyMetadata((object)false));

	public TimerAction? TimerAction
	{
		get
		{
			return (TimerAction)((DependencyObject)this).GetValue(TimerActionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TimerActionProperty, (object)value);
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

	public ICommand<TimerData>? SelectTimerCommand
	{
		get
		{
			return (ICommand<TimerData>)((DependencyObject)this).GetValue(SelectTimerCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectTimerCommandProperty, (object)value);
		}
	}

	public ICommand<TimerType>? ChangeConfigurationCommand
	{
		get
		{
			return (ICommand<TimerType>)((DependencyObject)this).GetValue(ChangeConfigurationCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ChangeConfigurationCommandProperty, (object)value);
		}
	}

	public bool CanDeSelectTimer
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(CanDeSelectTimerProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanDeSelectTimerProperty, (object)value);
		}
	}

	public TimerActionContent()
	{
		InitializeComponent();
	}

	private void TimerType_SelectionChanged(object? sender, SelectionChangedEventArgs e)
	{
		if ((sender as ComboBox)?.SelectedItem is TimerType parameter)
		{
			ChangeConfigurationCommand?.Invoke(parameter);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
