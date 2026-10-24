using System.Windows;
using System.Windows.Controls;
using Pro.DO.Effects;
using Pro.DO.Effects.Descriptions;

namespace ProPresenter.UI.Transitions;

public class ParameterControlTemplateSelector : DataTemplateSelector
{
	public override DataTemplate? SelectTemplate(object item, DependencyObject container)
	{
		ParameterDescriptionBase obj = (ParameterDescriptionBase)item;
		FrameworkElement frameworkElement = (FrameworkElement)(object)container;
		return obj.ParameterType switch
		{
			ParameterType.Int => (DataTemplate)frameworkElement.FindResource("IntParamControlTemplate"), 
			ParameterType.Float => (DataTemplate)frameworkElement.FindResource("FloatParamControlTemplate"), 
			ParameterType.Color => (DataTemplate)frameworkElement.FindResource("ColorParamControlTemplate"), 
			ParameterType.Direction => (DataTemplate)frameworkElement.FindResource("DirectionParamControlTemplate"), 
			ParameterType.Double => (DataTemplate)frameworkElement.FindResource("DoubleParamControlTemplate"), 
			_ => null, 
		};
	}
}
