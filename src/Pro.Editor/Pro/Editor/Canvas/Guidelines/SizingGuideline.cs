using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using Pro.Common.Mathematics;
using Pro.Editor.Canvas.Guidelines.Drawing;
using Pro.Editor.Canvas.Snapping.Lines;

namespace Pro.Editor.Canvas.Guidelines;

internal class SizingGuideline : SnapGuidelineBase
{
	private const double LineOffset = 15.0;

	private EqualSizingSL _snapLine;

	private Rect<double> _sourceBounds;

	private IEnumerable<LineSegment<double>>? _lines;

	private double _previousScaleFactor = 1.0;

	private Matrix<double> _transformMatrix = Matrix<double>.Identity;

	public SizingGuideline(EqualSizingSL snapLine, Rect<double> finalBounds)
	{
		_snapLine = snapLine;
		_sourceBounds = finalBounds;
	}

	public override void OnRenderGuideline(DrawingContext dc, Pen pen)
	{
		base.OnRenderGuideline(dc, pen);
		if (_lines == null || base.ZoomFactor != _previousScaleFactor)
		{
			double farSide = _snapLine.Size * base.ZoomFactor;
			_lines = LineGenerator.GenerateArrow(!_snapLine.IsHorizontal, 0.0, farSide).Concat(LineGenerator.GenerateOrthogonal(!_snapLine.IsHorizontal, 0.0, farSide));
			_previousScaleFactor = base.ZoomFactor;
			_transformMatrix = _snapLine.Owners.First().CanvasParent.GetGlobalTransformMatrix(base.ZoomFactor);
		}
		RenderLine(dc, _sourceBounds, pen);
		foreach (ICanvasElement owner in _snapLine.Owners)
		{
			RenderLine(dc, owner.SnapBounds, pen);
		}
	}

	private void RenderLine(DrawingContext dc, Rect<double> bounds, Pen pen)
	{
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		double pos = (_snapLine.IsHorizontal ? bounds.Top : bounds.Left);
		double magnitude = ((!_snapLine.IsHorizontal) ? bounds.Top : bounds.Left) - 15.0;
		Vector2<double> vector = _snapLine.IsHorizontal.Orient(pos, magnitude) * base.ZoomFactor;
		dc.PushTransform(new TranslateTransform(vector.X, vector.Y));
		if (_lines != null)
		{
			foreach (LineSegment<double> line in _lines)
			{
				dc.DrawLine(pen, line.A * _transformMatrix, line.B * _transformMatrix);
			}
		}
		dc.Pop();
	}
}
