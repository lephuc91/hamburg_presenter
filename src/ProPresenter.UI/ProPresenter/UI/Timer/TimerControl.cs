using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using ProPresenter.DO.Timer;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.UI.Timer;

public partial class TimerControl : UserControl, IComponentConnector
{
	public static readonly DependencyProperty TimersProperty = DependencyProperty.Register("Timers", typeof(TimerCollection), typeof(TimerControl));

	public static readonly DependencyProperty CurrentTimerProperty = DependencyProperty.Register("CurrentTimer", typeof(TimerData), typeof(TimerControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((PropertyChangedCallback)delegate(DependencyObject s, DependencyPropertyChangedEventArgs e)
	{
		((TimerControl)(object)s).TimerTypeSelectorVM.SelectedTimer = (TimerData)((DependencyPropertyChangedEventArgs)(ref e)).NewValue;
	}));

	public static readonly DependencyProperty ShowLabelProperty = DependencyProperty.Register("ShowLabel", typeof(bool), typeof(TimerControl));

	public HeaderViewTimerTypeSelectorVM TimerTypeSelectorVM { get; } = new HeaderViewTimerTypeSelectorVM();

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

	public TimerData? CurrentTimer
	{
		get
		{
			return (TimerData)((DependencyObject)this).GetValue(CurrentTimerProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CurrentTimerProperty, (object)value);
		}
	}

	public bool ShowLabel
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowLabelProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowLabelProperty, (object)value);
		}
	}

	public TimerControl()
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
