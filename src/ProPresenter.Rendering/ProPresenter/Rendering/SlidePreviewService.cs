using System.Threading.Tasks;
using Pro.Common.Components;
using ProPresenter.DO.Slide.Custom;

namespace ProPresenter.Rendering;

public class SlidePreviewService : ISlidePreviewService
{
	public IBitmapHandle RenderSlidePreview(CustomSlide slide, SlidePreviewRenderParams renderParams)
	{
		return SlidePreviewRenderer.RenderSlidePreview(slide, renderParams);
	}

	public async Task<IBitmapHandle> RenderSlidePreviewAsync(CustomSlide slide, SlidePreviewRenderParams renderParams)
	{
		return await Task.Run(() => RenderSlidePreview(slide, renderParams));
	}
}
