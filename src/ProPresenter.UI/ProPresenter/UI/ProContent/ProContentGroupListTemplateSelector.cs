using System.Windows;
using System.Windows.Controls;
using ProPresenter.UI.ViewModels.ProContent.Group;

namespace ProPresenter.UI.ProContent;

public class ProContentGroupListTemplateSelector : DataTemplateSelector
{
	public const string StandardGroupKey = "StandardGroupTemplate";

	public const string SearchGroupKey = "SearchGroupTemplate";

	public override DataTemplate? SelectTemplate(object item, DependencyObject container)
	{
		if (!(item is IProContentSearchGroupVM))
		{
			if (item is IProContentGroupVM)
			{
				return FindTemplate(container, "StandardGroupTemplate");
			}
			return null;
		}
		return FindTemplate(container, "SearchGroupTemplate");
	}

	private static DataTemplate? FindTemplate(DependencyObject container, string key)
	{
		return (container as FrameworkElement)?.FindResource(key) as DataTemplate;
	}
}
