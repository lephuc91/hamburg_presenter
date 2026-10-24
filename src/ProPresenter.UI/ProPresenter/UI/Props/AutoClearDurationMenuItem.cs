using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.UI.Components;

namespace ProPresenter.UI.Props;

public partial class AutoClearDurationMenuItem : MenuItem, IComponentConnector
{
	public static readonly DependencyProperty AutoClearDurationProperty = DependencyProperty.Register("AutoClearDuration", typeof(double), typeof(AutoClearDurationMenuItem));

	public static readonly DependencyProperty SetAutoClearCommandProperty = DependencyProperty.Register("SetAutoClearCommand", typeof(ICommand<double>), typeof(AutoClearDurationMenuItem));

	public static readonly DependencyProperty SetCustomAutoClearCommandProperty = DependencyProperty.Register("SetCustomAutoClearCommand", typeof(ICommand), typeof(AutoClearDurationMenuItem));

	private static readonly DependencyProperty IsDefaultAutoClearDurationEnabledProperty = DependencyProperty.Register("IsDefaultAutoClearDurationEnabled", typeof(bool), typeof(AutoClearDurationMenuItem));

	private static readonly DependencyProperty AutoClearFollowsPropDurationProperty = DependencyProperty.Register("AutoClearFollowsPropDuration", typeof(bool), typeof(AutoClearDurationMenuItem));

	public double AutoClearDuration
	{
		get
		{
			return (double)((DependencyObject)this).GetValue(AutoClearDurationProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AutoClearDurationProperty, (object)value);
		}
	}

	public ICommand<double> SetAutoClearCommand
	{
		get
		{
			return (ICommand<double>)((DependencyObject)this).GetValue(SetAutoClearCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SetAutoClearCommandProperty, (object)value);
		}
	}

	public ICommand SetCustomAutoClearCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(SetCustomAutoClearCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SetCustomAutoClearCommandProperty, (object)value);
		}
	}

	public bool IsDefaultAutoClearDurationEnabled
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsDefaultAutoClearDurationEnabledProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsDefaultAutoClearDurationEnabledProperty, (object)value);
		}
	}

	public bool AutoClearFollowsPropDuration
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(AutoClearFollowsPropDurationProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AutoClearFollowsPropDurationProperty, (object)value);
		}
	}

	public AutoClearDurationMenuItem()
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
