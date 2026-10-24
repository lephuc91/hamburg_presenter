using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using Pro.Text;
using Pro.Text.Fills;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Custom.Elements.Fills;

namespace ProPresenter.DO.Slide.Custom;

public static class CustomSlideHelper
{
	public static double GetBlurAmount(this CustomSlide slide)
	{
		double? num = null;
		if (slide != null)
		{
			IEnumerable<ClosedBezierPath> source = slide.Elements.OfType<ClosedBezierPath>();
			num = source.Select((ClosedBezierPath e) => e.Fill).OfType<BackgroundEffectBlurFill>().FirstOrDefault()?.BlurAmount;
			if (!num.HasValue)
			{
				num = (from r in source.Select((ClosedBezierPath p) => p.Text).NonNull().FirstOrDefault()?.SelectMany((Paragraph p) => p)
					select r.Settings.Fill).OfType<BackgroundBlurTextFill>().FirstOrDefault()?.Blur;
			}
		}
		return num ?? 0.5;
	}

	public static void SynchronizeBlurAmount(this CustomSlide slide, double blurAmount)
	{
		slide?.Elements.ForEach(delegate(SlideElementBase e)
		{
			e.SynchronizeBlurAmount(blurAmount);
		});
	}

	public static void SynchronizeBlurAmount(this SlideElementBase element, double blurAmount)
	{
		if (!(element is ClosedBezierPath closedBezierPath))
		{
			return;
		}
		if (closedBezierPath.Fill is BackgroundEffectBlurFill backgroundEffectBlurFill)
		{
			backgroundEffectBlurFill.BlurAmount = blurAmount;
		}
		if (!(closedBezierPath.Text != null))
		{
			return;
		}
		closedBezierPath.Text.IterateRuns(Range.All, splitRuns: false, delegate(RunBase r)
		{
			if (r.Settings.Fill is BackgroundBlurTextFill backgroundBlurTextFill)
			{
				r.Settings.Fill = new BackgroundBlurTextFill(backgroundBlurTextFill.Saturation, blurAmount);
			}
		});
	}
}
