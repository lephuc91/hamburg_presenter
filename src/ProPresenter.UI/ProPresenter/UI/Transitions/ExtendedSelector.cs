using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using Pro.Common.Nullability;
using Pro.DO.Transitions;
using ProPresenter.Controller.Outputs;
using ProPresenter.DO.Transitions;

namespace ProPresenter.UI.Transitions;

public partial class ExtendedSelector : UserControl, IComponentConnector
{
	public static readonly DependencyProperty OutputControllerProperty = DependencyProperty.Register("OutputController", typeof(ssAPIOutput), typeof(ExtendedSelector));

	public static readonly DependencyProperty TransitionHandlerProperty = DependencyProperty.Register("TransitionHandler", typeof(TransitionHandler), typeof(ExtendedSelector));

	public static readonly DependencyProperty IsGlobalAllowedProperty = DependencyProperty.Register("IsGlobalAllowed", typeof(bool), typeof(ExtendedSelector));

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

	public ExtendedSelector()
	{
		InitializeComponent();
	}

	private void FavoriteTransitionNameEdit_PreviewMouseDown(object? sender, MouseButtonEventArgs e)
	{
		TransitionHandler? transitionHandler = TransitionHandler;
		if (transitionHandler == null || transitionHandler.ActiveTransition?.TransitionType != TransitionType.Favorite)
		{
			e.Handled = true;
		}
	}

	private void AddToFavorite_Click(object? sender, RoutedEventArgs e)
	{
		if (TransitionHandler != null)
		{
			TransitionHandler.ActiveTransition.ThrowWhenNull("TransitionHandler.ActiveTransition");
			if (TransitionHandler.ActiveTransition.TransitionType != TransitionType.Favorite)
			{
				TransitionHandler.ActiveParameters.ThrowWhenNull("TransitionHandler.ActiveParameters");
				TransitionHandler.CreateFavorite(TransitionHelper.CreateNewFavoriteTransitionName(TransitionHandler.ActiveTransition.Preset.Name, Math.Round(TransitionHandler.ActiveParameters.Duration.TotalSeconds, 1)));
				FavoriteTransitionNameEdit.EnterEditMode();
			}
			else
			{
				FavoriteButton.ContextMenu.PlacementTarget = FavoriteButton;
				FavoriteButton.ContextMenu.Placement = PlacementMode.Bottom;
				FavoriteButton.ContextMenu.IsOpen = true;
			}
		}
	}

	private void FavoriteCreatedFromSaveAs()
	{
		FavoriteTransitionNameEdit.EnterEditMode();
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
