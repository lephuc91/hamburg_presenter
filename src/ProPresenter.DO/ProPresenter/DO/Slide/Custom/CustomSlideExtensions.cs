using Pro.ssAPI;
using ProPresenter.DO.Media;
using ProPresenter.DO.Media.Properties;

namespace ProPresenter.DO.Slide.Custom;

public static class CustomSlideExtensions
{
	public static void SetupSlideBackgroundSampler(this CustomSlide slide, VisualMedia? media)
	{
		if (media == null)
		{
			slide.BackgroundMediaSampler = null;
			return;
		}
		slide.BackgroundMediaSampler = delegate
		{
			DrawingProperties obj = ((IDrawMedia)media)?.Drawing;
			return new SampleMediaInfo(scaleBehavior: obj?.ScaleBehavior ?? ScaleBehavior.StretchToFill, scaleAlignment: obj?.ScaleAlignment ?? ScaleAlignment.MiddleCenter, flipHorizontally: obj?.FlipHorizontally ?? false, flipVertically: obj?.FlipVertically ?? false, source: obj?.PreviewImage);
		};
	}
}
