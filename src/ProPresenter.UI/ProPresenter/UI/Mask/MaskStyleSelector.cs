using System.Windows;
using System.Windows.Controls;
using ProPresenter.DO.Cues;

namespace ProPresenter.UI.Mask;

public class MaskStyleSelector : StyleSelector
{
	public override Style? SelectStyle(object item, DependencyObject container)
	{
		if (!(item is SlideCue))
		{
			return base.SelectStyle(item, container);
		}
		return (container as FrameworkElement)?.TryFindResource("MaskStyle") as Style;
	}
}
