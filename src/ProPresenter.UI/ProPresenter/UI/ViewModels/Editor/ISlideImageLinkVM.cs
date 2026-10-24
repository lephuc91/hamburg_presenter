using Pro.UI.Components;
using ProPresenter.DO.Slide.Links;

namespace ProPresenter.UI.ViewModels.Editor;

public interface ISlideImageLinkVM
{
	SlideTargetSourceMode SlideTargetSourceMode { get; }

	ICommand<SlideTargetSourceMode> SlideImageFillCommand { get; }
}
