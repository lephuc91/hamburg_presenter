using System.Windows.Media;
using ProPresenter.DO.Slide.Custom.Elements;

namespace ProPresenter.Rendering.Drawing.Strokes;

internal class StrokeDrawer : IDrawer<IStroke>
{
	private const double MiterRatioLimit = 4.0;

	public void Draw(DrawingContext dc, RenderingMode renderMode, IStroke stroke, DrawingParams drawingParams)
	{
		if (!renderMode.IsOutputMode() || renderMode == RenderingMode.OutputComposite || renderMode == RenderingMode.OutputOver)
		{
			Pen pen = new Pen(new SolidColorBrush(stroke.StrokeColor), stroke.StrokeThickness)
			{
				MiterLimit = 4.0,
				DashStyle = new DashStyle(stroke.Pattern, 0.0),
				DashCap = PenLineCap.Flat
			};
			dc.DrawGeometry(null, pen, drawingParams.FillGeometry);
		}
	}
}
