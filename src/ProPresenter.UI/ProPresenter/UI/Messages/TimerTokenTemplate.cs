using System;
using System.CodeDom.Compiler;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.Common.Collections;
using Pro.UI.Components;
using Pro.UI.Utility;
using ProPresenter.DO.Timer;

namespace ProPresenter.UI.Messages;

public partial class TimerTokenTemplate : UserControl, IComponentConnector
{
	public static readonly DependencyProperty TimerProperty = DependencyProperty.Register("Timer", typeof(TimerData), typeof(TimerTokenTemplate), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnTimerPropertyChanged)));

	public static readonly DependencyProperty FormatProperty = DependencyProperty.Register("Format", typeof(TimerFormatData), typeof(TimerTokenTemplate));

	public static readonly DependencyProperty ShowTimerFormatProperty = DependencyProperty.Register("ShowTimerFormat", typeof(bool), typeof(TimerTokenTemplate), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty ShowTimerControlsProperty = DependencyProperty.Register("ShowTimerControls", typeof(bool), typeof(TimerTokenTemplate), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

	public static readonly DependencyProperty SelectedTimerTypeProperty = DependencyProperty.Register("SelectedTimerType", typeof(TimerType), typeof(TimerTokenTemplate), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)TimerType.Countdown, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	public static readonly DependencyProperty TimersProperty = DependencyProperty.Register("Timers", typeof(TimerCollection), typeof(TimerTokenTemplate), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnTimersPropertyChanged)));

	private static readonly DependencyProperty OriginalTimerProperty = DependencyProperty.Register("OriginalTimer", typeof(TimerData), typeof(TimerTokenTemplate));

	public static readonly DependencyProperty StartCommandProperty = DependencyProperty.Register("StartCommand", typeof(ICommand<TimerData>), typeof(TimerTokenTemplate));

	public static readonly DependencyProperty StopCommandProperty = DependencyProperty.Register("StopCommand", typeof(ICommand<TimerData>), typeof(TimerTokenTemplate));

	public static readonly DependencyProperty ResetCommandProperty = DependencyProperty.Register("ResetCommand", typeof(ICommand<TimerData>), typeof(TimerTokenTemplate));

	public TimerData? Timer
	{
		get
		{
			return (TimerData)((DependencyObject)this).GetValue(TimerProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TimerProperty, (object)value);
		}
	}

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

	public bool ShowTimerControls
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowTimerControlsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowTimerControlsProperty, (object)value);
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

	private TimerData? OriginalTimer
	{
		get
		{
			return (TimerData)((DependencyObject)this).GetValue(OriginalTimerProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(OriginalTimerProperty, (object)value);
		}
	}

	public ICommand<TimerData?>? StartCommand
	{
		get
		{
			return (ICommand<TimerData>)((DependencyObject)this).GetValue(StartCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(StartCommandProperty, (object)value);
		}
	}

	public ICommand<TimerData?>? StopCommand
	{
		get
		{
			return (ICommand<TimerData>)((DependencyObject)this).GetValue(StopCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(StopCommandProperty, (object)value);
		}
	}

	public ICommand<TimerData?>? ResetCommand
	{
		get
		{
			return (ICommand<TimerData>)((DependencyObject)this).GetValue(ResetCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ResetCommandProperty, (object)value);
		}
	}

	private static void OnTimerPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((TimerTokenTemplate)(object)d).UpdateOriginalTimer();
	}

	private static void OnTimersPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((TimerTokenTemplate)(object)d).TimersChanged(((DependencyPropertyChangedEventArgs)(ref e)).OldValue as TimerCollection, ((DependencyPropertyChangedEventArgs)(ref e)).NewValue as TimerCollection);
	}

	public TimerTokenTemplate()
	{
		InitializeComponent();
	}

	private void UpdateOriginalTimer()
	{
		if (Timer != null && Timers != null)
		{
			TimerData timerData = Timers.FirstOrDefaultBy((TimerData t) => t.ID == Timer.ID, (TimerData t) => t.Name == Timer.Name);
			if (timerData != null)
			{
				Timer.Name = timerData.Name;
			}
			((DependencyObject)this).SetCurrentValue(OriginalTimerProperty, (object)timerData);
		}
	}

	private void TimersChanged(TimerCollection? oldTimers, TimerCollection? newTimers)
	{
		if (oldTimers != null)
		{
			oldTimers.CollectionChanged -= Timers_CollectionChanged;
		}
		if (newTimers != null)
		{
			newTimers.ForEach(delegate(TimerData t)
			{
				t.PropertyChanged += Timer_PropertyChanged;
			});
			newTimers.CollectionChanged += Timers_CollectionChanged;
		}
		UpdateOriginalTimer();
	}

	private void Timers_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		e.OldItems?.OfType<TimerData>().ForEach(delegate(TimerData t)
		{
			t.PropertyChanged -= Timer_PropertyChanged;
		});
		e.NewItems?.OfType<TimerData>().ForEach(delegate(TimerData t)
		{
			t.PropertyChanged += Timer_PropertyChanged;
		});
		UpdateOriginalTimer();
	}

	private void Timer_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == "Name")
		{
			UpdateOriginalTimer();
		}
	}

	private void StartTimer(object? sender, RoutedEventArgs e)
	{
		StartCommand?.Invoke<TimerData>(OriginalTimer);
	}

	private void StopTimer(object? sender, RoutedEventArgs e)
	{
		StopCommand?.Invoke<TimerData>(OriginalTimer);
	}

	private void ResetTimer(object? sender, RoutedEventArgs e)
	{
		ResetCommand?.Invoke<TimerData>(OriginalTimer);
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
