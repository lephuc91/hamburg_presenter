using System.Windows;
using System.Windows.Controls;
using Pro.Common.Mathematics;
using ProPresenter.DO.OutputConfiguration;

namespace ProPresenter.UI;

public class SizeItemStyleSelector : StyleSelector
{
	public override Style? SelectStyle(object item, DependencyObject container)
	{
		if (item is Vector2<double>)
		{
			return (container as FrameworkElement)?.TryFindResource("VectorStyle") as Style;
		}
		if (item is ScreenArrangementBase)
		{
			return (container as FrameworkElement)?.TryFindResource("ScreenStyle") as Style;
		}
		return base.SelectStyle(item, container);
	}
}
