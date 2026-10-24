using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.UI.Components;
using Pro.UI.Utility;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Timer;

namespace ProPresenter.UI.Header;

public partial class HeaderSettings : UserControl, IComponentConnector
{
	public static readonly DependencyProperty HeaderActionProperty = DependencyProperty.Register("HeaderAction", typeof(HeaderAction), typeof(HeaderSettings));

	public static readonly DependencyProperty TimersProperty = DependencyProperty.Register("Timers", typeof(TimerCollection), typeof(HeaderSettings));

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

	public ICommand<TimerData> SelectTimerCommand => new RelayCommand<TimerData>(OnSelectTimerCommand);

	public ICommand<TimerType> ChangeConfigurationCommand => new RelayCommand<TimerType>(OnChangeConfigurationCommand);

	public HeaderSettings()
	{
		InitializeComponent();
	}

	private void TextBox_KeyUp(object? sender, KeyEventArgs e)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		if ((int)e.Key == 6)
		{
			ContextMenu contextMenu = ((DependencyObject)(object)this).FindVisualParent<ContextMenu>();
			if (contextMenu != null)
			{
				contextMenu.IsOpen = !contextMenu.IsOpen;
			}
		}
	}

	private void OnSelectTimerCommand(TimerData timerData)
	{
		if (timerData == null)
		{
			HeaderAction?.Timer?.SetIdentifier(Guid.Empty, string.Empty);
		}
		else
		{
			HeaderAction?.Timer?.SetIdentifier(timerData);
		}
	}

	private void OnChangeConfigurationCommand(TimerType timerType)
	{
		if (HeaderAction?.Timer != null)
		{
			TimerBase configuration = HeaderAction.Timer.Configuration;
			if (configuration == null || configuration.TimerType != timerType)
			{
				HeaderAction.Timer.ChangeTimerType(timerType);
			}
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
