using System.Windows.Media;
using System.Windows.Media.Imaging;
using Pro.Common.Mathematics;
using Pro.Common.Utility;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Custom.Elements.Fills;

namespace ProPresenter.Rendering.Drawing.Fills;

internal class BitmapFillDrawer : IDrawer<IFill>
{
	public void Draw(DrawingContext dc, RenderingMode renderMode, IFill fill, DrawingParams drawingParams)
	{
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		if (!renderMode.IsOutputMode() || renderMode == RenderingMode.OutputComposite || renderMode == RenderingMode.OutputUnder)
		{
			Geometry fillGeometry = drawingParams.FillGeometry;
			BezierPath path = drawingParams.Path;
			BitmapSource bitmap = ((BitmapFill)fill).Bitmap;
			if (bitmap != null)
			{
				Vector2<double> vector = new Vector2<double>(bitmap.PixelWidth, bitmap.PixelHeight);
				double num = vector.ScaleToFitScalar(path.TightBounds.Size);
				Vector2<double> position = (path.TightBounds.Size - vector * num) / 2.0;
				dc.PushClip(fillGeometry);
				dc.DrawImage(bitmap, new Rect<double>(position, vector * num));
				dc.Pop();
			}
		}
	}
}
