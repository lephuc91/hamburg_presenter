using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.Common.Time;
using ProPresenter.DO.Timer;

namespace ProPresenter.UI.Timer;

public partial class TimerDetails : UserControl, IComponentConnector
{
	public static readonly DependencyProperty FormatProperty = DependencyProperty.Register("Format", typeof(TimerFormatData), typeof(TimerDetails));

	public static readonly DependencyProperty ShowTimerFormatProperty = DependencyProperty.Register("ShowTimerFormat", typeof(bool), typeof(TimerDetails));

	public static readonly DependencyProperty SelectedTimerTypeProperty = DependencyProperty.Register("SelectedTimerType", typeof(TimerType), typeof(TimerDetails));

	public static readonly DependencyProperty StartTimeProperty = DependencyProperty.Register("StartTime", typeof(TimeSlice), typeof(TimerDetails));

	public static readonly DependencyProperty EndTimeProperty = DependencyProperty.Register("EndTime", typeof(TimeSlice), typeof(TimerDetails));

	public static readonly DependencyProperty HasEndTimeProperty = DependencyProperty.Register("HasEndTime", typeof(bool), typeof(TimerDetails));

	public static readonly DependencyProperty TimeFormatProperty = DependencyProperty.Register("TimeFormat", typeof(TimeFormat), typeof(TimerDetails));

	public static readonly DependencyProperty OverrunProperty = DependencyProperty.Register("Overrun", typeof(bool), typeof(TimerDetails));

	public TimerFormatData? Format
	{
		get
		{
			return (TimerFormatData)((DependencyObject)this).GetValue(FormatProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FormatProperty, (object)value);
		}
	}

	public bool ShowTimerFormat
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowTimerFormatProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowTimerFormatProperty, (object)value);
		}
	}

	public TimerType SelectedTimerType
	{
		get
		{
			return (TimerType)((DependencyObject)this).GetValue(SelectedTimerTypeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedTimerTypeProperty, (object)value);
		}
	}

	public TimeSlice StartTime
	{
		get
		{
			return (TimeSlice)((DependencyObject)this).GetValue(StartTimeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(StartTimeProperty, (object)value);
		}
	}

	public TimeSlice EndTime
	{
		get
		{
			return (TimeSlice)((DependencyObject)this).GetValue(EndTimeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(EndTimeProperty, (object)value);
		}
	}

	public bool HasEndTime
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(HasEndTimeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HasEndTimeProperty, (object)value);
		}
	}

	public TimeFormat TimeFormat
	{
		get
		{
			return (TimeFormat)((DependencyObject)this).GetValue(TimeFormatProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TimeFormatProperty, (object)value);
		}
	}

	public bool Overrun
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(OverrunProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(OverrunProperty, (object)value);
		}
	}

	public TimerDetails()
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
