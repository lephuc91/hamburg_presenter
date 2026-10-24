using System;
using System.Windows;
using System.Windows.Markup;
using Pro.Common.Nullability;
using Pro.DO.Transitions;
using Pro.DO.Transitions.Favorite;
using Pro.UI.Controls;
using ProPresenter.DO.Transitions;

namespace ProPresenter.UI.Transitions;

public partial class FavoriteButton : BorderlessButton, IComponentConnector
{
	public static readonly DependencyProperty TransitionHandlerProperty = DependencyProperty.Register("TransitionHandler", typeof(TransitionHandler), typeof(FavoriteButton));

	public static readonly DependencyProperty AutoCreateFavoriteProperty = DependencyProperty.Register("AutoCreateFavorite", typeof(bool), typeof(FavoriteButton), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));

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

	public bool AutoCreateFavorite
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(AutoCreateFavoriteProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AutoCreateFavoriteProperty, (object)value);
		}
	}

	public event Action? FavoriteCreatedFromSaveAs;

	public FavoriteButton()
	{
		InitializeComponent();
	}

	private void Save_Click(object? sender, RoutedEventArgs e)
	{
		TransitionHandler?.SaveChanges();
	}

	private void SaveAs_Click(object? sender, RoutedEventArgs e)
	{
		if (AutoCreateFavorite)
		{
			(TransitionHandler?.ActiveTransition).ThrowWhenNull("TransitionHandler?.ActiveTransition");
			TransitionHandler.ActiveParameters.ThrowWhenNull("TransitionHandler.ActiveParameters");
			TransitionHandler.CreateFavorite(TransitionHelper.CreateNewFavoriteTransitionName(TransitionHandler.ActiveTransition.Preset.Name, Math.Round(TransitionHandler.ActiveParameters.Duration.TotalSeconds, 1)));
		}
		this.FavoriteCreatedFromSaveAs?.Invoke();
	}

	private void Remove_Click(object? sender, RoutedEventArgs e)
	{
		if (TransitionHandler?.ActiveTransition is FavoriteTransition transition)
		{
			TransitionHandler.RemoveFavorite(transition);
		}
	}
}
