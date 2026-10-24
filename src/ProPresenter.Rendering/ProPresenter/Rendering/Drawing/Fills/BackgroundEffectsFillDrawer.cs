using System.Windows.Media;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.Rendering.Drawing.Links;

namespace ProPresenter.Rendering.Drawing.Fills;

internal class BackgroundEffectsFillDrawer : IDrawer<IFill>
{
	public void Draw(DrawingContext dc, RenderingMode renderMode, IFill data, DrawingParams drawingParams)
	{
		if (renderMode == RenderingMode.OutputContentMask || renderMode == RenderingMode.ShadowContents)
		{
			dc?.DrawGeometry(RenderConstants.MaskBrush, null, drawingParams.FillGeometry);
		}
		else if (!renderMode.IsOutputMode())
		{
			dc?.DrawGeometry(LinkFillDrawerBase.NonresolvedContentBrush, null, drawingParams.FillGeometry);
		}
	}
}
