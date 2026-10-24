using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls.Primitives;
using Pro.DO.Triggering;
using ProPresenter.DO.Actions;

namespace ProPresenter.UI.ViewModels;

public class ActionDialogParameter
{
	public FrameworkElement? Placement { get; }

	public IAction? Action { get; }

	public IActionRepository? Target { get; }

	public IEnumerable<IActionRepository>? OtherTarget { get; }

	public PlacementMode PlacementMode { get; }

	public HorizontalAlignment HorizontalAlignment { get; }

	public VerticalAlignment VerticalAlignment { get; }

	public ActionDialogParameter(FrameworkElement? placement, IAction? action, IActionRepository? target, IEnumerable<IActionRepository>? otherTarget, PlacementMode placementMode = PlacementMode.Bottom, HorizontalAlignment horizontalAlignment = HorizontalAlignment.Center, VerticalAlignment verticalAlignment = VerticalAlignment.Stretch)
	{
		Placement = placement;
		Action = action;
		Target = target;
		OtherTarget = otherTarget;
		PlacementMode = placementMode;
		HorizontalAlignment = horizontalAlignment;
		VerticalAlignment = verticalAlignment;
	}
}
