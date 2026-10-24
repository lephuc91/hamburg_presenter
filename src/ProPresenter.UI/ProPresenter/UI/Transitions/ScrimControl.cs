using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using Pro.DO.Transitions;
using ProPresenter.UI.Theming;

namespace ProPresenter.UI.Transitions;

public partial class ScrimControl : UserControl, IComponentConnector
{
	public static readonly DependencyProperty TransitionProperty = DependencyProperty.Register("Transition", typeof(TransitionParameters), typeof(ScrimControl));

	public static readonly DependencyProperty IsMediaTransitionProperty = DependencyProperty.Register("IsMediaTransition", typeof(bool), typeof(ScrimControl));

	public static readonly DependencyProperty FillProperty = DependencyProperty.Register("Fill", typeof(SolidColorBrush), typeof(ScrimControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)(SolidColorBrush)AppTheme.Active.TRANSITIONFOREGROUND_CHECKED_CONTENT));

	public TransitionParameters? Transition
	{
		get
		{
			return (TransitionParameters)((DependencyObject)this).GetValue(TransitionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(TransitionProperty, (object)value);
		}
	}

	public bool IsMediaTransition
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(IsMediaTransitionProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(IsMediaTransitionProperty, (object)value);
		}
	}

	public SolidColorBrush? Fill
	{
		get
		{
			return (SolidColorBrush)((DependencyObject)this).GetValue(FillProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(FillProperty, (object)value);
		}
	}

	public ScrimControl()
	{
		InitializeComponent();
	}
}
