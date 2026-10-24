using System.Windows;
using System.Windows.Controls;

namespace Pro.UI;

public class InterfaceDataTemplateSelector : DataTemplateSelector
{
	public ResourceDictionary TemplateDictionary { get; set; } = new ResourceDictionary();

	public override DataTemplate? SelectTemplate(object item, DependencyObject container)
	{
		return item?.GetType().GetDataTemplate(TemplateDictionary);
	}
}
