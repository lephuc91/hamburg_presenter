using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ProPresenter.DO.Cues;
using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.UI;

public class ScreenMenuItemStyleSelector : StyleSelector
{
	public override Style? SelectStyle(object item, DependencyObject container)
	{
		FrameworkElement frameworkElement = container as FrameworkElement;
		if (item is KeyValuePair<ScreenArrangementBase, SlideCue>)
		{
			return frameworkElement?.FindResource("StageScreenArrangementMenuItemStyle") as Style;
		}
		return base.SelectStyle(item, container);
	}
}
