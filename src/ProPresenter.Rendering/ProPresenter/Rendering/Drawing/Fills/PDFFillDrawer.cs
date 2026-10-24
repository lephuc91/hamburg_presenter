using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Pro.Common.Logging;
using Pro.Common.Mathematics;
using Pro.Common.Utility;
using Pro.PDF;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Custom.Elements.Fills;

namespace ProPresenter.Rendering.Drawing.Fills;

internal class PDFFillDrawer : IDrawer<IFill>
{
	public void Draw(DrawingContext dc, RenderingMode renderMode, IFill fill, DrawingParams drawingParams)
	{
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		if (renderMode.IsOutputMode() && renderMode != 0 && renderMode != RenderingMode.OutputUnder)
		{
			return;
		}
		Geometry fillGeometry = drawingParams.FillGeometry;
		BezierPath path = drawingParams.Path;
		BitmapSource imageSource = null;
		Vector2<double> vector = Vector2<double>.One;
		double num = 1.0;
		try
		{
			PDFFill pDFFill = (PDFFill)fill;
			string filename = pDFFill.Filename;
			if (!string.IsNullOrWhiteSpace(filename))
			{
				using PdfRenderer pdfRenderer = new PdfRenderer(filename);
				vector = pdfRenderer.GetPageSize(pDFFill.PageNumber);
				num = vector.ScaleToFitScalar(path.TightBounds.Size);
				imageSource = pdfRenderer.RenderPageToImage(pDFFill.PageNumber, num);
			}
		}
		catch (Exception ex)
		{
			Log.Error("Couldn't render PDF fill for element '{0}' ({1}): {2}", path.Name, path.ID, ex.Message);
			dc.DrawGeometry(Brushes.Transparent, null, fillGeometry);
			return;
		}
		Vector2<double> vector2 = vector * num;
		Vector2<double> position = (path.TightBounds.Size - vector2) / 2.0;
		dc.PushClip(fillGeometry);
		dc.DrawImage(imageSource, new Rect<double>(position, vector2));
		dc.Pop();
	}
}
