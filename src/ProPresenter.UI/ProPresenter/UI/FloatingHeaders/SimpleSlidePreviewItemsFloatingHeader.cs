using System.Linq;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.UI.SlideEditor;

namespace ProPresenter.UI.FloatingHeaders;

public class SimpleSlidePreviewItemsFloatingHeader : SlidePreviewItemsFloatingHeaderControlBase<SlideContainerBase>
{
	protected override void ScrollToSlide(CustomSlide slide)
	{
		ScrollIntoView(base.Items?.FirstOrDefault((SlideContainerBase c) => c.Slide == slide), 0.0, null);
	}
}
