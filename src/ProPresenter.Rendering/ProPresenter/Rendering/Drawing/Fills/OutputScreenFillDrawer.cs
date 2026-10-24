using System.Windows.Media;
using ProPresenter.DO.Slide.Custom.Elements;

namespace ProPresenter.Rendering.Drawing.Fills;

internal class OutputScreenFillDrawer : IDrawer<IFill>
{
	public void Draw(DrawingContext dc, RenderingMode renderMode, IFill fill, DrawingParams drawingParams)
	{
		if (renderMode == RenderingMode.OutputContentMask)
		{
			dc.DrawGeometry(Brushes.White, null, drawingParams.FillGeometry);
		}
	}
}
