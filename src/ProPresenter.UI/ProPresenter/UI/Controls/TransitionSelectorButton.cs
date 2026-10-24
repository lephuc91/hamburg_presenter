using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.DO.Transitions;

namespace ProPresenter.UI.Controls;

public partial class TransitionSelectorButton : UserControl, IComponentConnector
{
	public static readonly DependencyProperty SelectedTransitionProperty = DependencyProperty.Register("SelectedTransition", typeof(TransitionParameters), typeof(TransitionSelectorButton), new PropertyMetadata(new PropertyChangedCallback(OnTranitionUpdated)));

	public static readonly DependencyProperty HideWhenNullProperty = DependencyProperty.Register("HideWhenNull", typeof(bool), typeof(TransitionSelectorButton), new PropertyMetadata((object)false, new PropertyChangedCallback(OnTranitionUpdated)));

	public static readonly DependencyProperty AlwaysActiveProperty = DependencyProperty.Register("AlwaysActive", typeof(bool), typeof(TransitionSelectorButton), new PropertyMetadata((object)false));

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

	public bool HideWhenNull
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(HideWhenNullProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(HideWhenNullProperty, (object)value);
		}
	}

	public bool AlwaysActive
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(AlwaysActiveProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(AlwaysActiveProperty, (object)value);
		}
	}

	public TransitionSelectorButton()
	{
		InitializeComponent();
	}

	private static void OnTranitionUpdated(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		if (d is TransitionSelectorButton { HideWhenNull: not false } transitionSelectorButton)
		{
			transitionSelectorButton.Visibility = ((!(transitionSelectorButton.SelectedTransition != null)) ? Visibility.Collapsed : Visibility.Visible);
		}
	}
}
