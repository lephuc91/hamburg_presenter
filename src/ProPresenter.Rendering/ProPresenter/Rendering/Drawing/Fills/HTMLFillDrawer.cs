using System.Windows.Media;
using Pro.Common.Mathematics;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Custom.Elements.Fills;
using ProPresenter.Rendering.Drawing.Links;

namespace ProPresenter.Rendering.Drawing.Fills;

internal class HTMLFillDrawer : IDrawer<IFill>
{
	public void Draw(DrawingContext dc, RenderingMode renderMode, IFill fill, DrawingParams drawingParams)
	{
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		HTMLFill hTMLFill = (HTMLFill)fill;
		if (renderMode.IsOutputMode() || renderMode.IsEditor())
		{
			if (!renderMode.IsOutputMode() || renderMode == RenderingMode.OutputComposite || renderMode == RenderingMode.OutputUnder)
			{
				if (hTMLFill.Bitmap != null)
				{
					dc.PushClip(drawingParams.FillGeometry);
					dc.DrawImage(hTMLFill.Bitmap, new Rect<double>(drawingParams.Path.Size));
					dc.Pop();
				}
				if (!renderMode.IsOutputMode())
				{
					dc.DrawGeometry((hTMLFill.Bitmap != null) ? LinkFillDrawerBase.ResolvedContentBrush : LinkFillDrawerBase.NonresolvedContentBrush, null, drawingParams.FillGeometry);
				}
				if (renderMode.IsEditor() && hTMLFill.Bitmap == null)
				{
					dc.DrawText(((HTMLFill)fill).WebMedia.Url, drawingParams.FillGeometry, drawingParams.Path);
				}
			}
		}
		else
		{
			dc.DrawGeometry(LinkFillDrawerBase.NonresolvedContentBrush, null, drawingParams.FillGeometry);
		}
	}
}
