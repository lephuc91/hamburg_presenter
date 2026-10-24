using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using ProPresenter.DO.Timer;

namespace ProPresenter.UI.Messages;

public partial class ClockTokenTemplate : UserControl, IComponentConnector
{
	public static readonly DependencyProperty ClockNameProperty = DependencyProperty.Register("ClockName", typeof(string), typeof(ClockTokenTemplate));

	public static readonly DependencyProperty ClockDataProperty = DependencyProperty.Register("ClockData", typeof(ClockData), typeof(ClockTokenTemplate));

	public string? ClockName
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(ClockNameProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ClockNameProperty, (object)value);
		}
	}

	public ClockData? ClockData
	{
		get
		{
			return (ClockData)((DependencyObject)this).GetValue(ClockDataProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ClockDataProperty, (object)value);
		}
	}

	public ClockTokenTemplate()
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
