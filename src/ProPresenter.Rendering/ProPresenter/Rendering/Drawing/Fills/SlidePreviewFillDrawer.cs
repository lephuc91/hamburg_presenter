using System.Windows.Media;
using Pro.Common.Components;
using Pro.Common.Mathematics;
using Pro.Common.Utility;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Custom.Elements.Fills;

namespace ProPresenter.Rendering.Drawing.Fills;

internal class SlidePreviewFillDrawer : IDrawer<IFill>
{
	public void Draw(DrawingContext dc, RenderingMode renderMode, IFill fill, DrawingParams drawingParams)
	{
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		if (!renderMode.IsOutputMode() || renderMode == RenderingMode.OutputComposite || renderMode == RenderingMode.OutputUnder)
		{
			SlidePreviewFill slidePreviewFill = (SlidePreviewFill)fill;
			if (slidePreviewFill.TargetSlide != null)
			{
				BezierPath path = drawingParams.Path;
				Vector2<double> vector = slidePreviewFill.TargetSlide.Size.ScaleToFitSize(path.TightBounds.Size);
				Color secondaryBackground = slidePreviewFill.SecondaryBackgroundColor ?? Colors.Transparent;
				IBitmapHandle bitmapHandle = SlidePreviewRenderer.RenderSlidePreview(slidePreviewFill.TargetSlide, new SlidePreviewRenderParams(vector.Cast<int>(), slidePreviewFill.IncludeBackground, IncludeBackgroundMedia: true, secondaryBackground));
				Vector2<double> position = (path.TightBounds.Size - vector) / 2.0 + bitmapHandle.RenderOffset;
				dc.PushClip(drawingParams.FillGeometry);
				dc.DrawImage(bitmapHandle.BitmapSource, new Rect<double>(position, vector));
				dc.Pop();
			}
		}
	}
}
