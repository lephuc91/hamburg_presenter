using System.Windows;
using System.Windows.Controls;
using Pro.Common.Mathematics;

namespace ProPresenter.UI.Capture.Destination;

internal class ResolutionMenuItemStyleSelector : StyleSelector
{
	private const string ResolutionMenuItemStyle = "ResolutionMenuItemStyle";

	private readonly ResourceDictionary _resources;

	public ResolutionMenuItemStyleSelector(ResourceDictionary resources)
	{
		_resources = resources;
	}

	public override Style SelectStyle(object item, DependencyObject container)
	{
		if (!(item is Vector2<uint>))
		{
			return base.SelectStyle(item, container);
		}
		return (Style)_resources["ResolutionMenuItemStyle"];
	}
}
