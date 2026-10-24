using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using Pro.Common.Mathematics;
using Pro.Editor.Canvas.Guidelines.Drawing;

namespace Pro.Editor.Canvas.Guidelines;

internal class SpacingGuideline : SnapGuidelineBase
{
	private bool _isHorizontal;

	private double _space;

	private IEnumerable<LineSegment<double>>? _lines;

	private double _previousScaleFactor = 1.0;

	private List<Point> _linePositions = new List<Point>();

	protected double Space
	{
		get
		{
			return _space;
		}
		set
		{
			if (_space != value)
			{
				_space = value;
				_lines = null;
			}
		}
	}

	public SpacingGuideline(bool isHorizontal, double space)
	{
		_space = space;
		_isHorizontal = isHorizontal;
	}

	public override void OnRenderGuideline(DrawingContext dc, Pen pen)
	{
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		base.OnRenderGuideline(dc, pen);
		if (_lines == null || base.ZoomFactor != _previousScaleFactor)
		{
			double farSide = _space * base.ZoomFactor;
			_lines = LineGenerator.GenerateArrow(!_isHorizontal, 0.0, farSide).Concat(LineGenerator.GenerateOrthogonal(!_isHorizontal, 0.0, farSide));
			_previousScaleFactor = base.ZoomFactor;
		}
		foreach (Point linePosition in _linePositions)
		{
			Point current = linePosition;
			Vector2<double> vector = _isHorizontal.Orient(((Point)(ref current)).X, ((Point)(ref current)).Y) * base.ZoomFactor + _isHorizontal.Orient(0.0, -5.0);
			dc.PushTransform(new TranslateTransform(vector.X, vector.Y));
			foreach (LineSegment<double> line in _lines)
			{
				dc.DrawLine(pen, line.A, line.B);
			}
			dc.Pop();
		}
	}

	protected void GenerateLinePosition(Rect<double> a, Rect<double> b)
	{
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		double num = ((!_isHorizontal) ? a.Center.Y : a.Center.X);
		double num2 = ((!_isHorizontal) ? b.Center.Y : b.Center.X);
		Vector2<double> vector = (_isHorizontal ? a.TopLeft : a.TopLeft.Reflect());
		Vector2<double> vector2 = (_isHorizontal ? b.TopLeft : b.TopLeft.Reflect());
		Vector2<double> vector3 = (_isHorizontal ? a.BottomRight : a.BottomRight.Reflect());
		Vector2<double> vector4 = (_isHorizontal ? b.BottomRight : b.BottomRight.Reflect());
		double num3 = ((vector.X < vector2.X) ? vector.X : vector2.X);
		double num4 = ((vector3.X > vector4.X) ? vector3.X : vector4.X);
		double num5 = num + num2 - (num3 + num4) / 2.0;
		double num6 = ((vector3.Y < vector4.Y) ? vector3.Y : vector4.Y);
		_linePositions.Add(new Point(num6, num5));
	}
}
