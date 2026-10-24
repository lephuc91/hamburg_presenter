using System.Windows.Media;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Custom.Elements.Fills;

namespace ProPresenter.Rendering.Drawing.Fills;

internal class SolidFillDrawer : IDrawer<IFill>
{
	public void Draw(DrawingContext dc, RenderingMode renderMode, IFill fill, DrawingParams drawingParams)
	{
		if (!renderMode.IsOutputMode() || renderMode == RenderingMode.OutputComposite || renderMode == RenderingMode.OutputUnder)
		{
			dc.DrawGeometry(new SolidColorBrush(((SolidColorFill)fill).Color), null, drawingParams.FillGeometry);
		}
	}
}
