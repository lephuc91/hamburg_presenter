using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media.Animation;
using Pro.Common.Time;
using Pro.Common.Utility;
using Pro.UI.Components;
using Pro.UI.Utility;
using ProPresenter.UI.ViewModels.Macros;

namespace ProPresenter.UI.Macros;

public partial class MacroListItemTemplate : UserControl, IComponentConnector
{
	private readonly DoubleAnimation _triggerAnimation;

	public static readonly DependencyProperty TriggerMacroCommandProperty = DependencyProperty.Register("TriggerMacroCommand", typeof(ICommand<IMacroItemVM>), typeof(MacroListItemTemplate));

	public static readonly DependencyProperty IsTriggeringProperty = DependencyProperty.Register("IsTriggering", typeof(bool), typeof(MacroListItemTemplate), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnIsTriggeringChanged)));

	public ICommand<IMacroItemVM> TriggerMacroCommand
	{
		get
		{
			return (ICommand<IMacroItemVM>)((DependencyObject)this).GetValue(TriggerMacroCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TriggerMacroCommandProperty, (object)value);
		}
	}

	public bool IsTriggering
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsTriggeringProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsTriggeringProperty, (object)value);
		}
	}

	private static void OnIsTriggeringChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		(d as MacroListItemTemplate)?.IsTriggerChanged((bool)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	public MacroListItemTemplate()
	{
		InitializeComponent();
		_triggerAnimation = new DoubleAnimation
		{
			From = 0.0,
			To = 1.0,
			BeginTime = TimeSlice.FromMilliseconds(0.0),
			Duration = new Duration(TimeSlice.FromMilliseconds(200.0)),
			AutoReverse = true
		};
		_triggerAnimation.Completed += TriggerAnimation_Completed;
	}

	private void TriggerAnimation_Completed(object? sender, EventArgs e)
	{
		if (IsTriggering)
		{
			triggerBorder.BeginAnimation(UIElement.OpacityProperty, _triggerAnimation);
		}
	}

	protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
	{
		if (!KeyboardHelper.IsModifierPressed((ModifierKeys)2) && base.DataContext is IMacroItemVM parameter)
		{
			TriggerMacroCommand?.Invoke(parameter);
		}
	}

	private void IsTriggerChanged(bool newValue)
	{
		if (newValue)
		{
			triggerBorder.BeginAnimation(UIElement.OpacityProperty, _triggerAnimation);
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
