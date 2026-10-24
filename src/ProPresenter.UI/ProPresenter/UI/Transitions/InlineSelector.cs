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

public partial class InlineSelector : UserControl, IComponentConnector
{
	public static readonly DependencyProperty LabelProperty = DependencyProperty.Register("Label", typeof(string), typeof(InlineSelector));

	public static readonly DependencyProperty OutputControllerProperty = DependencyProperty.Register("OutputController", typeof(ssAPIOutput), typeof(InlineSelector));

	public static readonly DependencyProperty TransitionHandlerProperty = DependencyProperty.Register("TransitionHandler", typeof(TransitionHandler), typeof(InlineSelector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnTransitionHandlerChanged)));

	public static readonly DependencyProperty SelectedTransitionProperty = DependencyProperty.Register("SelectedTransition", typeof(TransitionParameters), typeof(InlineSelector), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	public string? Label
	{
		get
		{
			return (string)((DependencyObject)this).GetValue(LabelProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(LabelProperty, (object)value);
		}
	}

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

	private static void OnTransitionHandlerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((InlineSelector)(object)d).UpdateTransitionHandler((TransitionHandler)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	public InlineSelector()
	{
		InitializeComponent();
	}

	private void UpdateTransitionHandler(TransitionHandler newHandler)
	{
		if (newHandler != null)
		{
			newHandler.IsContinuousFinalize = true;
		}
	}

	private void RemoveButton_Click(object? sender, RoutedEventArgs e)
	{
		TransitionHandler?.RemoveTransition();
	}

	private void FavoriteTransitionNameEdit_PreviewMouseDown(object? sender, MouseButtonEventArgs e)
	{
		TransitionHandler? transitionHandler = TransitionHandler;
		if (transitionHandler == null || transitionHandler.ActiveTransition?.TransitionType != TransitionType.Favorite)
		{
			e.Handled = true;
		}
	}

	private void FavoriteButton_Click(object? sender, RoutedEventArgs e)
	{
		if (TransitionHandler?.ActiveTransition != null)
		{
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
