using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.UI.Components;
using Pro.UI.Utility;
using ProPresenter.DO.LiveVideo;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Links;
using ProPresenter.DO.Timer;

namespace ProPresenter.UI.SlideEditor.Inspectors.Links;

public partial class VisibilityConditionTemplate : UserControl, IComponentConnector, IStyleConnector
{
	public static readonly DependencyProperty AvailableElementsCollectionProperty = DependencyProperty.Register("AvailableElementsCollection", typeof(IEnumerable<SlideElementBase>), typeof(VisibilityConditionTemplate));

	public static readonly DependencyProperty AvailableTimerCollectionProperty = DependencyProperty.Register("AvailableTimerCollection", typeof(TimerCollection), typeof(VisibilityConditionTemplate));

	public static readonly DependencyProperty AvailableLiveVideoInputsProperty = DependencyProperty.Register("AvailableLiveVideoInputs", typeof(LiveVideoInputCollection), typeof(VisibilityConditionTemplate));

	public static readonly DependencyProperty SetElementVisibilityLinkCommandProperty = DependencyProperty.Register("SetElementVisibilityLinkCommand", typeof(ICommand<(VisibilityCondition, SlideElementBase)>), typeof(VisibilityConditionTemplate));

	public static readonly DependencyProperty SetTimerVisibilityLinkCommandProperty = DependencyProperty.Register("SetTimerVisibilityLinkCommand", typeof(ICommand<(VisibilityCondition, TimerData)>), typeof(VisibilityConditionTemplate));

	public static readonly DependencyProperty SetVideoCountdownVisibilityLinkCommandProperty = DependencyProperty.Register("SetVideoCountdownVisibilityLinkCommand", typeof(ICommand<VisibilityCondition>), typeof(VisibilityConditionTemplate));

	public static readonly DependencyProperty SetAudioCountdownVisibilityLinkCommandProperty = DependencyProperty.Register("SetAudioCountdownVisibilityLinkCommand", typeof(ICommand<VisibilityCondition>), typeof(VisibilityConditionTemplate));

	public static readonly DependencyProperty SetCaptureSessionVisibilityLinkCommandProperty = DependencyProperty.Register("SetCaptureSessionVisibilityLinkCommand", typeof(ICommand<VisibilityCondition>), typeof(VisibilityConditionTemplate));

	public static readonly DependencyProperty SetVideoInputVisibilityLinkCommandProperty = DependencyProperty.Register("SetVideoInputVisibilityLinkCommand", typeof(ICommand<VisibilityCondition>), typeof(VisibilityConditionTemplate));

	public static readonly DependencyProperty AddConditionCommandProperty = DependencyProperty.Register("AddConditionCommand", typeof(ICommand), typeof(VisibilityConditionTemplate));

	public static readonly DependencyProperty RemoveConditionCommandProperty = DependencyProperty.Register("RemoveConditionCommand", typeof(ICommand<VisibilityCondition>), typeof(VisibilityConditionTemplate));

	public static readonly DependencyProperty CanRemoveConditionProperty = DependencyProperty.Register("CanRemoveCondition", typeof(bool), typeof(VisibilityConditionTemplate));

	public IEnumerable<SlideElementBase> AvailableElementsCollection
	{
		get
		{
			return (IEnumerable<SlideElementBase>)((DependencyObject)this).GetValue(AvailableElementsCollectionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AvailableElementsCollectionProperty, (object)value);
		}
	}

	public TimerCollection AvailableTimerCollection
	{
		get
		{
			return (TimerCollection)((DependencyObject)this).GetValue(AvailableTimerCollectionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AvailableTimerCollectionProperty, (object)value);
		}
	}

	public LiveVideoInputCollection AvailableLiveVideoInputs
	{
		get
		{
			return (LiveVideoInputCollection)((DependencyObject)this).GetValue(AvailableLiveVideoInputsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AvailableLiveVideoInputsProperty, (object)value);
		}
	}

	public ICommand<(VisibilityCondition, SlideElementBase)> SetElementVisibilityLinkCommand
	{
		get
		{
			return (ICommand<(VisibilityCondition, SlideElementBase)>)((DependencyObject)this).GetValue(SetElementVisibilityLinkCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SetElementVisibilityLinkCommandProperty, (object)value);
		}
	}

	public ICommand<(VisibilityCondition, TimerData)> SetTimerVisibilityLinkCommand
	{
		get
		{
			return (ICommand<(VisibilityCondition, TimerData)>)((DependencyObject)this).GetValue(SetTimerVisibilityLinkCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SetTimerVisibilityLinkCommandProperty, (object)value);
		}
	}

	public ICommand<VisibilityCondition> SetVideoCountdownVisibilityLinkCommand
	{
		get
		{
			return (ICommand<VisibilityCondition>)((DependencyObject)this).GetValue(SetVideoCountdownVisibilityLinkCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SetVideoCountdownVisibilityLinkCommandProperty, (object)value);
		}
	}

	public ICommand<VisibilityCondition> SetAudioCountdownVisibilityLinkCommand
	{
		get
		{
			return (ICommand<VisibilityCondition>)((DependencyObject)this).GetValue(SetAudioCountdownVisibilityLinkCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SetAudioCountdownVisibilityLinkCommandProperty, (object)value);
		}
	}

	public ICommand<VisibilityCondition> SetCaptureSessionVisibilityLinkCommand
	{
		get
		{
			return (ICommand<VisibilityCondition>)((DependencyObject)this).GetValue(SetCaptureSessionVisibilityLinkCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SetCaptureSessionVisibilityLinkCommandProperty, (object)value);
		}
	}

	public ICommand<VisibilityCondition> SetVideoInputVisibilityLinkCommand
	{
		get
		{
			return (ICommand<VisibilityCondition>)((DependencyObject)this).GetValue(SetVideoCountdownVisibilityLinkCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SetVideoCountdownVisibilityLinkCommandProperty, (object)value);
		}
	}

	public ICommand AddConditionCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(AddConditionCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AddConditionCommandProperty, (object)value);
		}
	}

	public ICommand<VisibilityCondition> RemoveConditionCommand
	{
		get
		{
			return (ICommand<VisibilityCondition>)((DependencyObject)this).GetValue(RemoveConditionCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(RemoveConditionCommandProperty, (object)value);
		}
	}

	public bool CanRemoveCondition
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(CanRemoveConditionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(CanRemoveConditionProperty, (object)value);
		}
	}

	public VisibilityConditionTemplate()
	{
		InitializeComponent();
	}

	private void ElementVisibilityLink_Click(object? sender, RoutedEventArgs e)
	{
		if (e.OriginalSource is FrameworkElement { DataContext: SlideElementBase dataContext } && base.DataContext is VisibilityCondition item)
		{
			SetElementVisibilityLinkCommand?.Invoke((item, dataContext));
		}
	}

	private void TimerVisibilityLink_Click(object? sender, RoutedEventArgs e)
	{
		if (e.OriginalSource is FrameworkElement { DataContext: TimerData dataContext } && base.DataContext is VisibilityCondition item)
		{
			SetTimerVisibilityLinkCommand?.Invoke((item, dataContext));
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
