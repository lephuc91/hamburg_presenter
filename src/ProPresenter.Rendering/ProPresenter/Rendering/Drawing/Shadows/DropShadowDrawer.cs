using System.Windows.Media;
using System.Windows.Media.Effects;
using Pro.Common.Mathematics;
using Pro.Editor.Canvas;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Custom.Elements.Shadows;

namespace ProPresenter.Rendering.Drawing.Shadows;

internal class DropShadowDrawer : IDrawer<IShadow>
{
	public void Draw(DrawingContext dc, RenderingMode renderMode, IShadow shadow, DrawingParams drawingParams)
	{
		//IL_0374: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c2: Unknown result type (might be due to invalid IL or missing references)
		if (renderMode.IsOutputMode() && renderMode != 0 && renderMode != RenderingMode.OutputUnder)
		{
			return;
		}
		BezierPath path = drawingParams.Path;
		Geometry maskGeometry = drawingParams.MaskGeometry;
		Brush maskBrush = drawingParams.MaskBrush;
		DrawerSet drawers = drawingParams.Drawers;
		DropShadow dropShadow = (DropShadow)shadow;
		Angle<double> angle = dropShadow.Angle - path.Rotation;
		Vector2<double> vector = new Vector2<double>(path.FlipMode.HasFlag(ElementFlipMode.Horizontal) ? (2.0 * (path.Center().X - path.TightBounds.Position.X) - path.TightBounds.Size.X) : 0.0, path.FlipMode.HasFlag(ElementFlipMode.Vertical) ? (2.0 * (path.Center().Y - path.TightBounds.Position.Y) - path.TightBounds.Size.Y) : 0.0);
		Rect<double> rect = new Rect<double>(path.TightBounds.Position + vector - path.Position, path.TightBounds.Size).Abs().Pad(dropShadow.BlurRadius);
		Vector2<double> vector2 = new Vector2<double>(dropShadow.Offset, 0.0).Rotate(Vector2<double>.Zero, angle.InvertedCartesianValue);
		Rect<double> rect2 = new Rect<double>(rect.Position + vector2, rect.Size);
		bool flag = rect2.Height > rect2.Width;
		DrawingVisual drawingVisual = new DrawingVisual();
		drawingVisual.Effect = new DropShadowEffect
		{
			BlurRadius = dropShadow.BlurRadius,
			Color = dropShadow.Color,
			Opacity = dropShadow.Opacity,
			RenderingBias = RenderingBias.Quality,
			Direction = (flag ? 90 : 180),
			ShadowDepth = (flag ? rect2.Height : rect2.Width)
		};
		using (DrawingContext drawingContext = drawingVisual.RenderOpen())
		{
			IFill fill = (path as ClosedBezierPath)?.Fill;
			IDrawer<IFill> drawer = ((path.PathType == BezierPathType.Closed && fill != null) ? drawers.GetFillDrawer(fill.Type) : null);
			IDrawer<IStroke> strokeDrawer = drawers.GetStrokeDrawer(path.Stroke.Type);
			IDrawer<IFeather> featherDrawer = drawers.GetFeatherDrawer(path.Feather.Type);
			int num;
			if (path.Feather.IsEnabled)
			{
				num = ((path.Feather.Radius > 0.0) ? 1 : 0);
				if (num != 0)
				{
					featherDrawer.Draw(drawingContext, RenderingMode.ShadowContents, path.Feather, drawingParams);
				}
			}
			else
			{
				num = 0;
			}
			if (maskGeometry != null)
			{
				drawingContext.PushClip(maskGeometry);
			}
			if (maskBrush != null)
			{
				drawingContext.PushOpacityMask(maskBrush);
			}
			if (drawer != null && fill != null && fill.IsEnabled)
			{
				drawer.Draw(drawingContext, RenderingMode.ShadowContents, fill, drawingParams);
			}
			if (maskBrush != null)
			{
				drawingContext.Pop();
			}
			if (maskGeometry != null)
			{
				drawingContext.Pop();
			}
			if (strokeDrawer != null && path.Stroke.IsEnabled)
			{
				strokeDrawer.Draw(drawingContext, RenderingMode.ShadowContents, path.Stroke, drawingParams);
			}
			else
			{
				drawingContext.DrawGeometry(Brushes.Transparent, null, drawingParams.FillGeometry);
			}
			if (num != 0)
			{
				drawingContext.Pop();
			}
		}
		dc.PushClip(new RectangleGeometry(rect2));
		Rect<double> rect3 = rect2;
		if (flag)
		{
			rect3.Height += rect2.Height;
		}
		else
		{
			rect3.Width += rect2.Width;
		}
		dc.DrawRectangle(new VisualBrush(drawingVisual), null, rect3);
		dc.Pop();
	}
}
