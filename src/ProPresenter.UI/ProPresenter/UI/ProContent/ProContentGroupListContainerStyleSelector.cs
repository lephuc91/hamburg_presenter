using System.Windows;
using System.Windows.Controls;
using ProPresenter.UI.ViewModels.ProContent.Group;

namespace ProPresenter.UI.ProContent;

public class ProContentGroupListContainerStyleSelector : StyleSelector
{
	public const string StandardGroupKey = "StandardGroupStyle";

	public const string SearchGroupKey = "SearchGroupStyle";

	public override Style? SelectStyle(object item, DependencyObject container)
	{
		if (!(item is IProContentSearchGroupVM))
		{
			if (item is IProContentGroupVM)
			{
				return findStyle("StandardGroupStyle");
			}
			return null;
		}
		return findStyle("SearchGroupStyle");
		Style? findStyle(string key)
		{
			return (container as FrameworkElement)?.FindResource(key) as Style;
		}
	}
}
