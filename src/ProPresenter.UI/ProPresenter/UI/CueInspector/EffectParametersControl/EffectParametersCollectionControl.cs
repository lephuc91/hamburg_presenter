using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Pro.DO.Effects;

namespace ProPresenter.UI.CueInspector.EffectParametersControl;

public partial class EffectParametersCollectionControl : UserControl, IComponentConnector
{
	public static readonly DependencyProperty EffectParametersProperty = DependencyProperty.Register("EffectParameters", typeof(EffectParameters), typeof(EffectParametersCollectionControl));

	public EffectParameters? EffectParameters
	{
		get
		{
			return (EffectParameters)((DependencyObject)this).GetValue(EffectParametersProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(EffectParametersProperty, (object)value);
		}
	}

	public EffectParametersCollectionControl()
	{
		InitializeComponent();
	}
}
