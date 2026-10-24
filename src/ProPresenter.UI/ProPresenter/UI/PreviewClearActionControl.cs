using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.UI.Components;
using ProPresenter.DO.ClearGroups;

namespace ProPresenter.UI;

public partial class PreviewClearActionControl : UserControl, IComponentConnector, IStyleConnector
{
	public static readonly DependencyProperty ClearGroupsProperty = DependencyProperty.Register("ClearGroups", typeof(ClearGroup[]), typeof(PreviewClearActionControl));

	public static readonly DependencyProperty TriggerClearGroupCommandProperty = DependencyProperty.Register("TriggerClearGroupCommand", typeof(ICommand<ClearGroup>), typeof(PreviewClearActionControl));

	public static readonly DependencyProperty ClearAllCommandProperty = DependencyProperty.Register("ClearAllCommand", typeof(ICommand), typeof(PreviewClearActionControl));

	public static readonly DependencyProperty ClearAudioCommandProperty = DependencyProperty.Register("ClearAudioCommand", typeof(ICommand), typeof(PreviewClearActionControl));

	public static readonly DependencyProperty ClearMessagesCommandProperty = DependencyProperty.Register("ClearMessagesCommand", typeof(ICommand), typeof(PreviewClearActionControl));

	public static readonly DependencyProperty ClearPropsCommandProperty = DependencyProperty.Register("ClearPropsCommand", typeof(ICommand), typeof(PreviewClearActionControl));

	public static readonly DependencyProperty ClearAnnouncementCommandProperty = DependencyProperty.Register("ClearAnnouncementCommand", typeof(ICommand), typeof(PreviewClearActionControl));

	public static readonly DependencyProperty ClearSlideCommandProperty = DependencyProperty.Register("ClearSlideCommand", typeof(ICommand), typeof(PreviewClearActionControl));

	public static readonly DependencyProperty ClearBackgroundCommandProperty = DependencyProperty.Register("ClearBackgroundCommand", typeof(ICommand), typeof(PreviewClearActionControl));

	public static readonly DependencyProperty ClearVideoInputCommandProperty = DependencyProperty.Register("ClearVideoInputCommand", typeof(ICommand), typeof(PreviewClearActionControl));

	private static readonly DependencyProperty MouseOverClearGroupProperty = DependencyProperty.Register("MouseOverClearGroup", typeof(ClearGroup), typeof(PreviewClearActionControl));

	public ClearGroup[] ClearGroups
	{
		get
		{
			return (ClearGroup[])((DependencyObject)this).GetValue(ClearGroupsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ClearGroupsProperty, (object)value);
		}
	}

	public ICommand<ClearGroup> TriggerClearGroupCommand
	{
		get
		{
			return (ICommand<ClearGroup>)((DependencyObject)this).GetValue(TriggerClearGroupCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TriggerClearGroupCommandProperty, (object)value);
		}
	}

	public ICommand ClearAllCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(ClearAllCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ClearAllCommandProperty, (object)value);
		}
	}

	public ICommand ClearAudioCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(ClearAudioCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ClearAudioCommandProperty, (object)value);
		}
	}

	public ICommand ClearMessagesCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(ClearMessagesCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ClearMessagesCommandProperty, (object)value);
		}
	}

	public ICommand ClearPropsCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(ClearPropsCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ClearPropsCommandProperty, (object)value);
		}
	}

	public ICommand ClearAnnouncementCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(ClearAnnouncementCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ClearAnnouncementCommandProperty, (object)value);
		}
	}

	public ICommand ClearSlideCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(ClearSlideCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ClearSlideCommandProperty, (object)value);
		}
	}

	public ICommand ClearBackgroundCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(ClearBackgroundCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ClearBackgroundCommandProperty, (object)value);
		}
	}

	public ICommand ClearVideoInputCommand
	{
		get
		{
			return (ICommand)((DependencyObject)this).GetValue(ClearVideoInputCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ClearVideoInputCommandProperty, (object)value);
		}
	}

	private ClearGroup? MouseOverClearGroup
	{
		get
		{
			return (ClearGroup)((DependencyObject)this).GetValue(MouseOverClearGroupProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(MouseOverClearGroupProperty, (object)value);
		}
	}

	public PreviewClearActionControl()
	{
		InitializeComponent();
	}

	private void ClearGroupButton_MouseMove(object? sender, MouseEventArgs e)
	{
		if (sender is Button { DataContext: ClearGroup dataContext })
		{
			MouseOverClearGroup = dataContext;
		}
	}

	private void ClearGroupButton_MouseLeave(object? sender, MouseEventArgs e)
	{
		MouseOverClearGroup = null;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
