using System.Windows.Media;
using Pro.Common.Components;
using ProPresenter.DO.Cues;
using ProPresenter.DO.Presentation;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.Rendering;

namespace ProPresenter.Controller.Remote.Apps;

public class SlidePreviewEncoder : ISlidePreviewEncoder
{
	private readonly IImageEncoder _imageEncoder;

	public SlidePreviewEncoder(IImageEncoder? imageEncoder = null)
	{
		_imageEncoder = imageEncoder ?? new ImageEncoder();
	}

	public string Encode(SlideCue slide, int slideQuality)
	{
		if (slideQuality <= 0 || !(slide.SlideAction?.Slide is CustomSlide { Size: var size } customSlide))
		{
			return string.Empty;
		}
		int num;
		if (!customSlide.UseBackgroundColor)
		{
			IPresentation? parentPresentation = slide.ParentPresentation;
			num = ((parentPresentation != null && parentPresentation.UseBackgroundColor && slide.GetIncludeBackground()) ? 1 : 0);
		}
		else
		{
			num = 1;
		}
		bool includeBackground = (byte)num != 0;
		IBitmapHandle bitmapHandle = SlidePreviewRenderer.RenderSlidePreview(customSlide, new SlidePreviewRenderParams((size * ((double)slideQuality / size.X)).Cast<int>(), includeBackground, IncludeBackgroundMedia: true, slide.ParentPresentation?.BackgroundColor ?? Colors.Transparent));
		return _imageEncoder.Encode(bitmapHandle.BitmapSource);
	}
}
