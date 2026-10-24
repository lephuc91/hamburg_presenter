using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.UI.Components;
using ProPresenter.Controller;
using ProPresenter.DO.ClearGroups;

namespace ProPresenter.UI;

public partial class ScreenPreviewControl : UserControl, IComponentConnector
{
	public static readonly DependencyProperty LoadPreviewCommandProperty = DependencyProperty.Register("LoadPreviewCommand", typeof(ICommand<CreateRenderViewParameters>), typeof(ScreenPreviewControl));

	public static readonly DependencyProperty UnloadPreviewCommandProperty = DependencyProperty.Register("UnloadPreviewCommand", typeof(ICommand<DestroyRenderViewParameters>), typeof(ScreenPreviewControl));

	public static readonly DependencyProperty ShowGTNTButtonProperty = DependencyProperty.Register("ShowGTNTButton", typeof(bool), typeof(ScreenPreviewControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	public static readonly DependencyProperty TriggerClearGroupCommandProperty = DependencyProperty.Register("TriggerClearGroupCommand", typeof(ICommand<ClearGroup>), typeof(ScreenPreviewControl));

	public static readonly DependencyProperty ClearAllCommandCommandProperty = DependencyProperty.Register("ClearAllCommand", typeof(ICommand), typeof(ScreenPreviewControl));

	public static readonly DependencyProperty ClearAudioCommandProperty = DependencyProperty.Register("ClearAudioCommand", typeof(ICommand), typeof(ScreenPreviewControl));

	public static readonly DependencyProperty ClearMessagesCommandProperty = DependencyProperty.Register("ClearMessagesCommand", typeof(ICommand), typeof(ScreenPreviewControl));

	public static readonly DependencyProperty ClearPropsCommandProperty = DependencyProperty.Register("ClearPropsCommand", typeof(ICommand), typeof(ScreenPreviewControl));

	public static readonly DependencyProperty ClearAnnouncementCommandProperty = DependencyProperty.Register("ClearAnnouncementCommand", typeof(ICommand), typeof(ScreenPreviewControl));

	public static readonly DependencyProperty ClearSlideCommandProperty = DependencyProperty.Register("ClearSlideCommand", typeof(ICommand), typeof(ScreenPreviewControl));

	public static readonly DependencyProperty ClearBackgroundCommandProperty = DependencyProperty.Register("ClearBackgroundCommand", typeof(ICommand), typeof(ScreenPreviewControl));

	public static readonly DependencyProperty ClearVideoInputCommandProperty = DependencyProperty.Register("ClearVideoInputCommand", typeof(ICommand), typeof(ScreenPreviewControl));

	public ICommand<CreateRenderViewParameters> LoadPreviewCommand
	{
		get
		{
			return (ICommand<CreateRenderViewParameters>)((DependencyObject)this).GetValue(LoadPreviewCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LoadPreviewCommandProperty, (object)value);
		}
	}

	public ICommand<DestroyRenderViewParameters> UnloadPreviewCommand
	{
		get
		{
			return (ICommand<DestroyRenderViewParameters>)((DependencyObject)this).GetValue(UnloadPreviewCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(UnloadPreviewCommandProperty, (object)value);
		}
	}

	public bool ShowGTNTButton
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowGTNTButtonProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowGTNTButtonProperty, (object)value);
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
			return (ICommand)((DependencyObject)this).GetValue(ClearAllCommandCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ClearAllCommandCommandProperty, (object)value);
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

	public ScreenPreviewControl()
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
