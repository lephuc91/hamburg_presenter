using System.Windows.Markup;

namespace Pro.Editor.Canvas.Popovers;

public partial class SliderPopover : PopoverBase, IComponentConnector
{
	public SliderPopover(IPopover dataContext)
	{
		base.DataContext = dataContext;
		InitializeComponent();
	}
}
