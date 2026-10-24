using System.Windows;
using System.Windows.Controls;

namespace Pro.UI;

public class InterfaceItemContainerTemplateSelector : ItemContainerTemplateSelector
{
	public ResourceDictionary? TemplateDictionary { get; set; }

	public override DataTemplate? SelectTemplate(object item, ItemsControl parentItemsControl)
	{
		return item?.GetType().GetDataTemplate(TemplateDictionary ?? parentItemsControl.Resources);
	}
}
