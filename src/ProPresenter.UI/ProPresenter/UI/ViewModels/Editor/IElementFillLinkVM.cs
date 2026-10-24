using System.Collections.Generic;
using Pro.UI.Components;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements;

namespace ProPresenter.UI.ViewModels.Editor;

public interface IElementFillLinkVM
{
	IEnumerable<ClosedBezierPath>? LinkableElements { get; }

	ClosedBezierPath? FirstElement { get; }

	CustomSlide? SelectedSlide { get; set; }

	ClosedBezierPath? LinkedElement { get; set; }

	ICommand<ClosedBezierPath> SelectElementCommand { get; }
}
