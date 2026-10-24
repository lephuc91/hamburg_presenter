using System;
using Pro.Common.Mathematics;
using Pro.Common.Utility;
using Pro.ssAPI;

namespace ProPresenter.DO.Slide.Custom.Elements.Fills;

public static class MediaScaleHelper
{
	public static Vector2<double> Scale(Vector2<double> originalSize, Vector2<double> targetSize, ScaleBehavior scaleType)
	{
		switch (scaleType)
		{
		case ScaleBehavior.ScaleToFit:
		case ScaleBehavior.ScaleAndBlur:
			return originalSize.ScaleToFitSize(targetSize);
		case ScaleBehavior.ScaleToFill:
			return originalSize.ScaleToFillSize(targetSize);
		case ScaleBehavior.StretchToFill:
			return targetSize;
		default:
			throw new NotSupportedException();
		}
	}
}
