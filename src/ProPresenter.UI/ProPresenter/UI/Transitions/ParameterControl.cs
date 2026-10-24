using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.DO.Transitions;

namespace ProPresenter.UI.Transitions;

public partial class ParameterControl : UserControl, IComponentConnector
{
	public static DependencyProperty TransitionHandlerProperty = DependencyProperty.Register("TransitionHandler", typeof(TransitionHandler), typeof(ParameterControl));

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

	public ParameterControl()
	{
		InitializeComponent();
	}

	private void ResetParamBtn_Click(object? sender, RoutedEventArgs e)
	{
		TransitionHandler?.ActiveParameters?.Reset();
	}
}
