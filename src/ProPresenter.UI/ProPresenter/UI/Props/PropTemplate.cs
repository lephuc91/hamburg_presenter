using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.Common.Utility;
using Pro.Localization;
using Pro.UI.Components;
using Pro.UI.Utility;
using ProPresenter.DO.Actions;
using ProPresenter.DO.Props;

namespace ProPresenter.UI.Props;

public partial class PropTemplate : UserControl, IComponentConnector
{
	private bool _canToggle;

	public static readonly DependencyProperty ActivePropsProperty = DependencyProperty.Register("ActiveProps", typeof(IEnumerable<IPropCue>), typeof(PropTemplate), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnActivePropsPropertyChanged)));

	public static readonly DependencyProperty TogglePropCommandProperty = DependencyProperty.Register("TogglePropCommand", typeof(ICommand<IPropCue>), typeof(PropTemplate));

	private static readonly DependencyProperty IsActiveProperty = DependencyProperty.Register("IsActive", typeof(bool), typeof(PropTemplate));

	public IEnumerable<IPropCue> ActiveProps
	{
		get
		{
			return (IEnumerable<IPropCue>)((DependencyObject)this).GetValue(ActivePropsProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ActivePropsProperty, (object)value);
		}
	}

	public ICommand<IPropCue?> TogglePropCommand
	{
		get
		{
			return (ICommand<IPropCue>)((DependencyObject)this).GetValue(TogglePropCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TogglePropCommandProperty, (object)value);
		}
	}

	private bool IsActive
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsActiveProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsActiveProperty, (object)value);
		}
	}

	private static void OnActivePropsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		(d as PropTemplate)?.ActivePropsChanged(((DependencyPropertyChangedEventArgs)(ref e)).NewValue as IEnumerable<IPropCue>);
	}

	public PropTemplate()
	{
		InitializeComponent();
	}

	private bool CheckIfActive(IPropCue cue)
	{
		object dataContext = base.DataContext;
		IPropCue prop = dataContext as IPropCue;
		if (prop == null)
		{
			return false;
		}
		if (cue == null)
		{
			return false;
		}
		if (cue.ID == prop.ID)
		{
			return true;
		}
		return (from e in cue.Actions.OfType<PropAction>()
			select e.PropID == prop.ID).Any((bool b) => b);
	}

	private void ActivePropsChanged(IEnumerable<IPropCue>? activeProps)
	{
		if (base.DataContext is IPropCue)
		{
			bool flag = activeProps?.Any((IPropCue activeProp) => CheckIfActive(activeProp)) ?? false;
			string text = LocalizedStrings.Get(flag ? "PROPS_WINDOW_TABLE_ROW_CLICK_TO_CLEAR_PROP_tooltip" : "PROPS_WINDOW_TABLE_ROW_CLICK_TO_TRIGGER_PROP_tooltip");
			((DependencyObject)this).SetCurrentValue(IsActiveProperty, (object)flag);
			((DependencyObject)this).SetCurrentValue(FrameworkElement.ToolTipProperty, (object)text);
		}
	}

	protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
	{
		if (!KeyboardHelper.IsModifierPressed((ModifierKeys)2) && _canToggle)
		{
			TogglePropCommand?.Invoke<IPropCue>(base.DataContext as IPropCue);
		}
		_canToggle = false;
	}

	protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
	{
		_canToggle = true;
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
