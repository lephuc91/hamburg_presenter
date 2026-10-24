using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.Mathematics;

namespace Pro.Editor.Canvas.Guidelines.Drawing;

internal static class LineGenerator
{
	internal const double ArrrowHeight = 10.0;

	public static IEnumerable<LineSegment<double>> GenerateArrow(bool isHorizontal, double nearSide, double farSide)
	{
		Func<double, double, Vector2<double>> func = (double pos, double magnitude) => isHorizontal.Orient(pos, magnitude);
		LineSegment<double>[] array = new LineSegment<double>[1]
		{
			new LineSegment<double>(func(5.0, nearSide), func(5.0, farSide))
		};
		LineSegment<double>[] second = new LineSegment<double>[4]
		{
			new LineSegment<double>(func(5.0, nearSide), func(0.0, nearSide + 10.0)),
			new LineSegment<double>(func(5.0, nearSide), func(10.0, nearSide + 10.0)),
			new LineSegment<double>(func(5.0, farSide), func(0.0, farSide - 10.0)),
			new LineSegment<double>(func(5.0, farSide), func(10.0, farSide - 10.0))
		};
		if (!(Math.Abs(farSide - nearSide) > 25.0))
		{
			return array;
		}
		return array.Concat(second);
	}

	public static IEnumerable<LineSegment<double>> GenerateOrthogonal(bool isHorizontal, double nearSide, double farSide)
	{
		Func<double, double, Vector2<double>> func = (double pos, double magnitude) => isHorizontal.Orient(pos, magnitude);
		return new LineSegment<double>[2]
		{
			new LineSegment<double>(func(0.0, nearSide), func(10.0, nearSide)),
			new LineSegment<double>(func(0.0, farSide), func(10.0, farSide))
		};
	}
}
