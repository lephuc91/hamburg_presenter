using System.Windows;
using System.Windows.Media;
using Pro.Common.Mathematics;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Custom.Elements.Fills;

namespace ProPresenter.Rendering.Drawing.Fills;

internal class GradientFillDrawer : IDrawer<IFill>
{
	public void Draw(DrawingContext dc, RenderingMode renderMode, IFill fill, DrawingParams drawingParams)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		if (!renderMode.IsOutputMode() || renderMode == RenderingMode.OutputComposite || renderMode == RenderingMode.OutputUnder)
		{
			GradientColorFill gradientColorFill = (GradientColorFill)fill;
			Rect bounds = drawingParams.FillGeometry.Bounds;
			Point val = default(Point);
			((Point)(ref val))._002Ector(((Rect)(ref bounds)).Width / 2.0, ((Rect)(ref bounds)).Height / 2.0);
			Vector2<double> vector = FindGradientStartingPoint(gradientColorFill.Angle, bounds);
			Point point = default(Point);
			((Point)(ref point))._002Ector(((Point)(ref val)).X - (vector.X - ((Point)(ref val)).X), ((Point)(ref val)).Y - (vector.Y - ((Point)(ref val)).Y));
			LinearGradientBrush linearGradientBrush = new LinearGradientBrush(gradientColorFill.StartColor, gradientColorFill.StopColor, ToRelativePoint(vector, bounds), ToRelativePoint(point, bounds));
			TransformGroup transformGroup = new TransformGroup();
			transformGroup.Children.Add(BezierPathHelper.GenerateFlipTransform(drawingParams.Path, new Vector2<double>(0.5, 0.5)));
			linearGradientBrush.RelativeTransform = transformGroup;
			dc.DrawGeometry(linearGradientBrush, null, drawingParams.FillGeometry);
		}
	}

	private static Vector2<double> FindGradientStartingPoint(Angle<double> angle, Rect bounds)
	{
		LineExtensions.Intersects(b: new Line<double>(new Vector2<double>(((Rect)(ref bounds)).Width / 2.0, ((Rect)(ref bounds)).Height / 2.0), angle), a: (int)(angle.CartesianValue / 90.0) switch
		{
			0 => new Line<double>(new Vector2<double>(0.0, ((Rect)(ref bounds)).Height), new Angle<double>(angle.InvertedCartesianValue + 90.0)), 
			1 => new Line<double>(new Vector2<double>(((Rect)(ref bounds)).Width, ((Rect)(ref bounds)).Height), new Angle<double>(angle.InvertedCartesianValue + 90.0)), 
			2 => new Line<double>(new Vector2<double>(((Rect)(ref bounds)).Width, 0.0), new Angle<double>(angle.InvertedCartesianValue + 90.0)), 
			_ => new Line<double>(new Vector2<double>(0.0, 0.0), new Angle<double>(angle.InvertedCartesianValue + 90.0)), 
		}, intersection: out var intersection);
		return intersection;
	}

	private static Point ToRelativePoint(Point point, Rect rect)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		return new Point(((Point)(ref point)).X / ((Rect)(ref rect)).Width, ((Point)(ref point)).Y / ((Rect)(ref rect)).Height);
	}
}
