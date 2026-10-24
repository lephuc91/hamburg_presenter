using System.Windows.Media;
using ProPresenter.DO.Slide.Links;

namespace ProPresenter.Rendering.Drawing.Links;

internal class StageMessageDrawer : IDrawer<ILinkedTextObject>
{
	public void Draw(DrawingContext dc, RenderingMode renderMode, ILinkedTextObject data, DrawingParams drawingParams)
	{
		Geometry fillGeometry = drawingParams.FillGeometry;
		if (renderMode.IsOutputMode() && renderMode == RenderingMode.OutputStageFlash)
		{
			dc.DrawGeometry(new SolidColorBrush(((StageMessageLinkedObject)data).FlashColor), null, fillGeometry);
		}
	}
}
