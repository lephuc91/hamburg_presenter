using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using Pro.DO.Transitions;
using ProPresenter.Controller.Outputs;

namespace ProPresenter.UI.Transitions;

public partial class ButtonSelector : UserControl, IComponentConnector
{
	public static readonly DependencyProperty OutputControllerProperty = DependencyProperty.Register("OutputController", typeof(ssAPIOutput), typeof(ButtonSelector));

	public static readonly DependencyProperty SelectedTransitionProperty = DependencyProperty.Register("SelectedTransition", typeof(TransitionParameters), typeof(ButtonSelector), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	public static readonly DependencyProperty TransitionHandlerProperty = DependencyProperty.Register("TransitionHandler", typeof(TransitionHandler), typeof(ButtonSelector));

	public static readonly DependencyProperty SelectorButtonSelectorStyleProperty = DependencyProperty.Register("SelectorButtonSelectorStyle", typeof(SelectorButtonSelectorStyle), typeof(ButtonSelector), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)SelectorButtonSelectorStyle.Extended));

	public static readonly DependencyProperty SelectorButtonContentTypeProperty = DependencyProperty.Register("SelectorButtonContentType", typeof(SelectorButtonContentType), typeof(ButtonSelector), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)SelectorButtonContentType.ChooseAndName));

	public static readonly DependencyProperty IsGlobalAllowedProperty = DependencyProperty.Register("IsGlobalAllowed", typeof(bool), typeof(ButtonSelector));

	public static readonly DependencyProperty PopupPlacementProperty = DependencyProperty.Register("PopupPlacement", typeof(PlacementMode), typeof(ButtonSelector), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)PlacementMode.Top));

	public ssAPIOutput? OutputController
	{
		get
		{
			return (ssAPIOutput)((DependencyObject)this).GetValue(OutputControllerProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(OutputControllerProperty, (object)value);
		}
	}

	public TransitionParameters? SelectedTransition
	{
		get
		{
			return (TransitionParameters)((DependencyObject)this).GetValue(SelectedTransitionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectedTransitionProperty, (object)value);
		}
	}

	public TransitionHandler? TransitionHandler
	{
		get
		{
			return (TransitionHandler)((DependencyObject)this).GetValue(TransitionHandlerProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TransitionHandlerProperty, (object)value);
		}
	}

	public SelectorButtonSelectorStyle SelectorButtonSelectorStyle
	{
		get
		{
			return (SelectorButtonSelectorStyle)((DependencyObject)this).GetValue(SelectorButtonSelectorStyleProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectorButtonSelectorStyleProperty, (object)value);
		}
	}

	public SelectorButtonContentType SelectorButtonContentType
	{
		get
		{
			return (SelectorButtonContentType)((DependencyObject)this).GetValue(SelectorButtonContentTypeProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(SelectorButtonContentTypeProperty, (object)value);
		}
	}

	public bool IsGlobalAllowed
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsGlobalAllowedProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsGlobalAllowedProperty, (object)value);
		}
	}

	public PlacementMode PopupPlacement
	{
		get
		{
			return (PlacementMode)((DependencyObject)this).GetValue(PopupPlacementProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(PopupPlacementProperty, (object)value);
		}
	}

	public event Action? SelectorClosed;

	public ButtonSelector()
	{
		InitializeComponent();
	}

	private void TransitionPopup_Opened(object? sender, EventArgs e)
	{
		if (TransitionHandler != null)
		{
			TransitionHandler.ActivateTransition(SelectedTransition);
		}
	}

	private void TransitionPopup_Closed(object? sender, EventArgs e)
	{
		if (TransitionHandler != null && TransitionHandler.IsActive)
		{
			TransitionHandler.FinalizeTransition();
		}
		this.SelectorClosed?.Invoke();
	}

	public void OpenSelector()
	{
		TransitionPopupButton.IsChecked = true;
	}
}
