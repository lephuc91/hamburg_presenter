using System.Windows;
using System.Windows.Controls;

namespace ProPresenter.UI.SlideEditor;

public class ZoomFactorItemStyleSelector : StyleSelector
{
	public override Style? SelectStyle(object item, DependencyObject container)
	{
		FrameworkElement frameworkElement = container as FrameworkElement;
		if (item is double)
		{
			return frameworkElement?.FindResource("ZoomFactorContextMenuItemStyle") as Style;
		}
		return base.SelectStyle(item, container);
	}
}
