using System;
using System.Windows;
using System.Windows.Media;
using Pro.Common.Mathematics;
using ProPresenter.DO.Slide.Custom.Elements;

namespace ProPresenter.Rendering;

public static class BezierPathHelper
{
	public static Transform GenerateFlipTransform(BezierPath path, Vector2<double> center)
	{
		return new ScaleTransform(path.FlipMode.HasFlag(ElementFlipMode.Horizontal) ? (-1.0) : 1.0, path.FlipMode.HasFlag(ElementFlipMode.Vertical) ? (-1.0) : 1.0, center.X, center.Y);
	}

	public static Geometry GenerateClosedPathGeometry(BezierPath path)
	{
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		Rect<double> bounds = new Rect<double>(Vector2<double>.Zero, path.Size).Abs();
		PathFigure pathFigure = new PathFigure
		{
			IsClosed = true
		};
		Func<Vector2<double>, Vector2<double>> func = (Vector2<double> point) => point.ComponentwiseProduct(bounds.Size);
		for (int i = 0; i < path.Points.Length; i++)
		{
			BezierPoint bezierPoint = path.Points[i];
			BezierPoint bezierPoint2 = path.Points[(i + 1) % path.Points.Length];
			pathFigure.Segments.Add(new BezierSegment(func(bezierPoint.ActiveQ1), func(bezierPoint2.ActiveQ0), func(bezierPoint2.Position), isStroked: true));
			pathFigure.StartPoint = func(bezierPoint2.Position);
		}
		PathGeometry obj = new PathGeometry(new PathFigure[1] { pathFigure })
		{
			Transform = GenerateTransform(bounds, path)
		};
		((Freezable)obj).Freeze();
		return obj;
	}

	public static Geometry GenerateOpenPathGeometry(BezierPath path)
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		Rect<double> bounds = new Rect<double>(Vector2<double>.Zero, path.Size).Abs();
		Func<Vector2<double>, Vector2<double>> func = (Vector2<double> p) => p.ComponentwiseProduct(bounds.Size);
		PathGeometry pathGeometry = new PathGeometry();
		PathFigure pathFigure = new PathFigure
		{
			StartPoint = func(path.Points[0].Position)
		};
		PolyBezierSegment polyBezierSegment = new PolyBezierSegment
		{
			IsStroked = true
		};
		for (int i = 0; i < path.Points.Length - 1; i++)
		{
			polyBezierSegment.Points.Add(func(path.Points[i].ActiveQ1));
			polyBezierSegment.Points.Add(func(path.Points[i + 1].ActiveQ0));
			polyBezierSegment.Points.Add(func(path.Points[i + 1].Position));
		}
		pathFigure.Segments.Add(polyBezierSegment);
		pathGeometry.Figures.Add(pathFigure);
		pathGeometry.Transform = GenerateTransform(bounds, path);
		((Freezable)pathGeometry).Freeze();
		return pathGeometry;
	}

	private static Transform GenerateTransform(Rect<double> bounds, BezierPath path)
	{
		return new TransformGroup
		{
			Children = 
			{
				GenerateFlipTransform(path, bounds.Center),
				(Transform)new TranslateTransform(bounds.Left, bounds.Top)
			}
		};
	}
}
