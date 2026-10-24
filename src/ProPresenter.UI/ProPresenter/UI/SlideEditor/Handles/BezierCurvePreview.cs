using System;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Mathematics;

namespace ProPresenter.UI.SlideEditor.Handles;

internal class BezierCurvePreview : Adorner
{
	private const double PreviewThickness = 3.0;

	private static readonly Brush PreviewBrush = Brushes.Cyan;

	private static readonly Pen PreviewPen = new Pen(PreviewBrush, 3.0)
	{
		DashStyle = DashStyles.Dot
	};

	private readonly Func<bool> _canShow;

	private readonly BezierPointHandle _pointHandle;

	private readonly BezierPointHandle _q1Handle;

	public BezierCurvePreview(BezierPointHandle pointHandle, BezierPointHandle q1Handle, Func<bool> canShow)
		: base(pointHandle)
	{
		_pointHandle = pointHandle;
		_q1Handle = q1Handle;
		_canShow = canShow;
		base.IsHitTestVisible = false;
	}

	protected override void OnRender(DrawingContext drawingContext)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		Vector2<double> vector = (Vector2<double>)Mouse.GetPosition(_pointHandle);
		if (_canShow() && VisualTreeHelper.HitTest(_pointHandle, vector) == null)
		{
			drawingContext.DrawGeometry(null, PreviewPen, GeneratePreviewGeometry(vector));
		}
	}

	private Geometry GeneratePreviewGeometry(Vector2<double> mousePosition)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		BezierSegment bezierSegment = new BezierSegment(-(Vector2<double>)TranslatePoint(Vector2<double>.Zero, _q1Handle), mousePosition, mousePosition, isStroked: true);
		PathFigure pathFigure = new PathFigure(Vector2<double>.Zero, new BezierSegment[1] { bezierSegment }, closed: false);
		return new PathGeometry(new PathFigure[1] { pathFigure });
	}
}
