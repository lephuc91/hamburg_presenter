using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.Common.Utility;
using Pro.UI.Components;
using Pro.UI.Utility;
using ProPresenter.UI.ViewModels.Props;

namespace ProPresenter.UI.Props;

public partial class PropListItemTemplate : UserControl, IComponentConnector
{
	private bool _canToggle;

	public static readonly DependencyProperty TogglePropCommandProperty = DependencyProperty.Register("TogglePropCommand", typeof(ICommand<IPropCueVM>), typeof(PropListItemTemplate));

	public ICommand<IPropCueVM?> TogglePropCommand
	{
		get
		{
			return (ICommand<IPropCueVM>)((DependencyObject)this).GetValue(TogglePropCommandProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TogglePropCommandProperty, (object)value);
		}
	}

	public PropListItemTemplate()
	{
		InitializeComponent();
	}

	protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
	{
		if (!(e.OriginalSource is ButtonBase) && !KeyboardHelper.IsModifierPressed((ModifierKeys)2) && _canToggle)
		{
			TogglePropCommand?.Invoke<IPropCueVM>(base.DataContext as IPropCueVM);
			e.Handled = true;
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
