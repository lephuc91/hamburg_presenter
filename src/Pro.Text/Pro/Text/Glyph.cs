using System;
using System.Windows;
using System.Windows.Media;
using Pro.Common.Mathematics;

namespace Pro.Text;

internal class Glyph
{
	public Geometry Geometry { get; }

	public double Baseline { get; }

	public Rect<double> Bounds { get; }

	internal Glyph(GlyphInfo glyphInfo)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		Geometry = BuildGeometry(glyphInfo);
		Baseline = glyphInfo.Baseline;
		Bounds = (Rect<double>)Geometry.Bounds;
	}

	private static Geometry BuildGeometry(GlyphInfo glyphInfo)
	{
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		PathFigure[] array = new PathFigure[glyphInfo.GetContourCount()];
		double baseline = glyphInfo.Baseline;
		for (int i = 0; i < array.Length; i++)
		{
			int contourPointCount = glyphInfo.GetContourPointCount(i);
			Func<Vector2<double>, Vector2<double>> func = (Vector2<double> v) => new Vector2<double>(v.X, baseline - v.Y);
			PathFigure pathFigure = new PathFigure
			{
				IsClosed = true
			};
			for (int j = 0; j < contourPointCount; j++)
			{
				glyphInfo.GetPoint(i, j, out var position, out var q, out var q2);
				pathFigure.Segments.Add(new BezierSegment(func(q), func(q2), func(position), isStroked: true));
				pathFigure.StartPoint = func(position);
			}
			array[i] = pathFigure;
		}
		PathGeometry obj = new PathGeometry(array)
		{
			FillRule = FillRule.Nonzero
		};
		((Freezable)obj).Freeze();
		return obj;
	}
}
