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
using Pro.Localization;
using Pro.UI.DialogService;
using ProPresenter.Controller.Outputs;
using ProPresenter.DO.Transitions;

namespace ProPresenter.UI.Transitions;

public partial class SlimSelector : UserControl, IComponentConnector
{
	public static readonly DependencyProperty OutputControllerProperty = DependencyProperty.Register("OutputController", typeof(ssAPIOutput), typeof(SlimSelector));

	public static readonly DependencyProperty TransitionHandlerProperty = DependencyProperty.Register("TransitionHandler", typeof(TransitionHandler), typeof(SlimSelector), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnTransitionHandlerChanged)));

	public static readonly DependencyProperty SelectedTransitionProperty = DependencyProperty.Register("SelectedTransition", typeof(TransitionParameters), typeof(SlimSelector), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

	public static readonly DependencyProperty IsGlobalAllowedProperty = DependencyProperty.Register("IsGlobalAllowed", typeof(bool), typeof(SlimSelector));

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

	private static void OnTransitionHandlerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		((SlimSelector)(object)d).UpdateTransitionHandler((TransitionHandler)((DependencyPropertyChangedEventArgs)(ref e)).NewValue);
	}

	public SlimSelector()
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
		TransitionHandler.ThrowWhenNull("TransitionHandler");
		TransitionHandler.RemoveTransition();
	}

	private void FavoriteTransitionNameEdit_PreviewMouseDown(object? sender, MouseButtonEventArgs e)
	{
		(TransitionHandler?.ActiveTransition).ThrowWhenNull("TransitionHandler?.ActiveTransition");
		if (TransitionHandler.ActiveTransition.TransitionType != TransitionType.Favorite)
		{
			e.Handled = true;
		}
	}

	private void FavoriteButton_Click(object? sender, RoutedEventArgs e)
	{
		if (TransitionHandler != null)
		{
			TransitionHandler.ActiveTransition.ThrowWhenNull("TransitionHandler.ActiveTransition");
			if (TransitionHandler.ActiveTransition.TransitionType != TransitionType.Favorite)
			{
				CreateNewFavorite();
				return;
			}
			FavoriteButton.ContextMenu.PlacementTarget = FavoriteButton;
			FavoriteButton.ContextMenu.Placement = PlacementMode.Bottom;
			FavoriteButton.ContextMenu.IsOpen = true;
		}
	}

	private void FavoriteCreatedFromSaveAs()
	{
		CreateNewFavorite();
	}

	private void CreateNewFavorite()
	{
		NewFavoriteContent newFavoriteContent = new NewFavoriteContent();
		(TransitionHandler?.ActiveTransition).ThrowWhenNull("TransitionHandler?.ActiveTransition");
		TransitionHandler.ActiveParameters.ThrowWhenNull("TransitionHandler.ActiveParameters");
		newFavoriteContent.NameTextbox.Text = TransitionHelper.CreateNewFavoriteTransitionName(TransitionHandler.ActiveTransition.Preset.Name, Math.Round(TransitionHandler.ActiveParameters.Duration.TotalSeconds, 1));
		if (MessageDialogService.ShowDialog(LocalizedStrings.Get("TRANSITIONS_NEW_FAVORITE_WINDOW_title"), (DependencyObject)(object)newFavoriteContent, DefaultButtons.OK | DefaultButtons.CANCEL, DefaultButtons.OK) == DefaultButtons.OK && !string.IsNullOrWhiteSpace(newFavoriteContent.NameTextbox.Text))
		{
			TransitionHandler.CreateFavorite(newFavoriteContent.NameTextbox.Text);
			TransitionHandler.FinalizeTransition();
		}
	}

	[DebuggerNonUserCode]
	[GeneratedCode("PresentationBuildTasks", "9.0.10.0")]
	internal Delegate _CreateDelegate(Type delegateType, string handler)
	{
		return Delegate.CreateDelegate(delegateType, this, handler);
	}
}
