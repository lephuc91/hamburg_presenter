using System.Threading.Tasks;
using Pro.Common.Components;
using ProPresenter.DO.Slide.Custom;

namespace ProPresenter.Rendering;

public interface ISlidePreviewService
{
	IBitmapHandle RenderSlidePreview(CustomSlide slide, SlidePreviewRenderParams renderParams);

	Task<IBitmapHandle> RenderSlidePreviewAsync(CustomSlide slide, SlidePreviewRenderParams renderParams);
}
