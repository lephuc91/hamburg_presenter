using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Pro.UI.Components;
using ProPresenter.UI.ViewModels;

namespace ProPresenter.UI.ActionPalette.ActionDialogs;

public abstract class ActionDialogBase : UserControl, IDialogContent
{
	public static readonly DependencyProperty PlacementProperty = DependencyProperty.Register("Placement", typeof(PlacementMode), typeof(ActionDialogBase));

	public PlacementMode Placement
	{
		get
		{
			return (PlacementMode)((DependencyObject)this).GetValue(PlacementProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PlacementProperty, (object)value);
		}
	}

	public event Action? Accept;

	public event Action? Cancel;

	protected ActionDialogBase()
	{
		Accept += ActionDialogBase_Accept;
	}

	protected void OnAccept()
	{
		this.Accept?.Invoke();
	}

	protected void OnCancel()
	{
		this.Cancel?.Invoke();
	}

	private void ActionDialogBase_Accept()
	{
		if (base.DataContext is IActionDialogContext actionDialogContext)
		{
			actionDialogContext.OnDone();
		}
	}
}
