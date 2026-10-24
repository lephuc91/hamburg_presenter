using System.Windows;
using System.Windows.Controls;
using Pro.DO.Effects;
using Pro.DO.Effects.Descriptions;

namespace ProPresenter.UI.CueInspector.EffectParametersControl;

public class EffectParameterControlTemplateSelector : DataTemplateSelector
{
	public override DataTemplate? SelectTemplate(object item, DependencyObject container)
	{
		ParameterDescriptionBase parameterDescriptionBase = (ParameterDescriptionBase)item;
		FrameworkElement frameworkElement = container as FrameworkElement;
		if (parameterDescriptionBase == null || frameworkElement == null)
		{
			return null;
		}
		return parameterDescriptionBase.ParameterType switch
		{
			ParameterType.Int => frameworkElement.FindResource("EffectIntParamControlTemplate") as DataTemplate, 
			ParameterType.Float => frameworkElement.FindResource("EffectFloatParamControlTemplate") as DataTemplate, 
			ParameterType.Color => frameworkElement.FindResource("EffectColorParamControlTemplate") as DataTemplate, 
			ParameterType.Direction => frameworkElement.FindResource("EffectDirectionParamControlTemplate") as DataTemplate, 
			ParameterType.Double => frameworkElement.FindResource("EffectDoubleParamControlTemplate") as DataTemplate, 
			_ => null, 
		};
	}
}
