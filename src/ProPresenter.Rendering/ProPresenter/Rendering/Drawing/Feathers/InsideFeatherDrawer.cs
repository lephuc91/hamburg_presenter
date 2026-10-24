using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;
using Pro.Common.Effects;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Custom.Elements.Shapes;

namespace ProPresenter.Rendering.Drawing.Feathers;

internal class InsideFeatherDrawer : IDrawer<IFeather>
{
	private const int MAX_BLUR_RADIUS_PER_PASS = 100;

	public void Draw(DrawingContext dc, RenderingMode renderMode, IFeather data, DrawingParams drawingParams)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0310: Unknown result type (might be due to invalid IL or missing references)
		//IL_0329: Unknown result type (might be due to invalid IL or missing references)
		Rect bounds = drawingParams.FillGeometry.Bounds;
		double width = ((Rect)(ref bounds)).Width;
		bounds = drawingParams.FillGeometry.Bounds;
		double height = ((Rect)(ref bounds)).Height;
		double num = Math.Min(width, height) / 2.0;
		BezierPath path = drawingParams.Path;
		if (!(path is RightTriangleShape))
		{
			if (!(path is IsoscelesTriangleShape))
			{
				if (!(path is RhombusShape))
				{
					if (!(path is StarShape starShape))
					{
						if (!(path is PolygonShape polygonShape))
						{
							if (path is RightArrowShape { Corner: var corner })
							{
								corner.X *= width;
								corner.Y *= height;
								double num2 = Math.Sqrt(height * height / 4.0 + (width - corner.X) * (width - corner.X));
								double num3 = height / 2.0 + num2;
								num = Math.Max(Math.Sqrt((num3 - height) * height * height / 4.0 / num3), height / 2.0 - corner.Y);
							}
						}
						else
						{
							num *= Math.Cos(Math.PI / (double)polygonShape.PointCount);
						}
					}
					else
					{
						num *= 1.0 - starShape.CenterRadius;
					}
				}
				else
				{
					num *= Math.Sqrt(2.0) / 2.0;
				}
			}
			else
			{
				double num4 = Math.Sqrt(width * width / 4.0 + height * height);
				double num5 = width / 2.0 + num4;
				num = width * Math.Sqrt(1.0 - width / num5) / 2.0;
			}
		}
		else
		{
			double num6 = Math.Sqrt(width * width + height * height);
			double num7 = (width + height + num6) / 2.0;
			num = Math.Sqrt((num7 - width) * (num7 - height) * (num7 - num6) / num7);
		}
		num *= data.Radius * 0.75;
		double num8 = Math.Ceiling(num / 100.0);
		double radius = num / Math.Sqrt(num8);
		DrawingVisual drawingVisual = new DrawingVisual();
		using (DrawingContext drawingContext = drawingVisual.RenderOpen())
		{
			Pen pen = new Pen(Brushes.Black, num * 2.0);
			drawingContext.DrawGeometry(null, pen, drawingParams.FillGeometry);
		}
		for (int i = 0; (double)i < num8; i++)
		{
			drawingVisual = new DrawingVisual
			{
				Children = { (Visual)drawingVisual }
			};
			drawingVisual.Effect = new BlurEffect
			{
				Radius = radius,
				KernelType = KernelType.Gaussian,
				RenderingBias = RenderingBias.Performance
			};
		}
		drawingVisual = new DrawingVisual
		{
			Children = { (Visual)drawingVisual }
		};
		drawingVisual.Effect = new InvertEffect
		{
			InvertTransparency = true
		};
		dc.PushOpacityMask(new VisualBrush(drawingVisual)
		{
			Stretch = Stretch.None,
			TileMode = TileMode.None,
			Viewport = drawingParams.FillGeometry.Bounds,
			ViewportUnits = BrushMappingMode.Absolute,
			Viewbox = drawingParams.FillGeometry.Bounds,
			ViewboxUnits = BrushMappingMode.Absolute
		});
	}
}
