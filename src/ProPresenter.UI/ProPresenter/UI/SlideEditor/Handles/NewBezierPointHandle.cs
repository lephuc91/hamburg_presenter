using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using Pro.Common.Mathematics;
using Pro.Common.Time;
using Pro.Editor.Canvas.Handles;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements;
using ProPresenter.DO.Slide.Custom.Elements.Handles;

namespace ProPresenter.UI.SlideEditor.Handles;

public class NewBezierPointHandle : HandleBase
{
	private const double CurveValue = 0.5;

	private const double OpacityAnimationSpeed = 4.0;

	private const double OpacityAnimationRadius = 15.0;

	private const double HandleRadius = 3.0;

	private const double HandleEdgeThickness = 1.0;

	private static readonly Brush FillBrush = Brushes.White;

	private static readonly Pen BorderPen = new Pen(Brushes.Gray, 1.0);

	private readonly BezierPath _path;

	private readonly BezierPoint _startPoint;

	private readonly BezierPoint _endPoint;

	private readonly Clock _animationClock = new Clock(autoStart: true);

	private readonly DispatcherTimer _animationTimer = new DispatcherTimer();

	private Rect<double> PathBounds => new Rect<double>(_path.Position, _path.Size);

	public NewBezierPointHandle(BezierPath path, BezierPoint startPoint, BezierPoint endPoint)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		_path = path;
		_startPoint = startPoint;
		_endPoint = endPoint;
		_animationTimer.Interval = TimeSpan.FromSeconds(1.0 / 60.0);
		_animationTimer.Tick += delegate
		{
			UpdateOpacity();
		};
		_animationTimer.Start();
		base.Opacity = 0.0;
	}

	protected override void OnDragged(Vector2<double> startPoint, Vector2<double> lastPoint, Vector2<double> currentPoint)
	{
	}

	protected override void OnMouseClick(MouseButtonEventArgs e)
	{
		BezierPoint newBezierPoint = _path.InsertPoint(_startPoint, _endPoint, 0.5);
		_path.CustomHandles.OfType<BezierHandleSetData>().FirstOrDefault((BezierHandleSetData s) => s.Point == newBezierPoint)?.StartBezierPointDrag(e);
	}

	protected override void OnRenderHandle(DrawingContext dc)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		dc.DrawEllipse(FillBrush, BorderPen, Vector2<double>.Zero, 3.0, 3.0);
	}

	protected override void OnUpdateLocation()
	{
		base.Location = _path.FlipMode.FlipPoint(BezierPathMath.EvaluateCubicCurve(0.5, _startPoint.Position, _startPoint.ActiveQ1, _endPoint.ActiveQ0, _endPoint.Position)).ProjectIntoWorldSpace(PathBounds, _path.Rotation);
	}

	protected override void OnUpdateCursor()
	{
		base.Cursor = Cursors.Hand;
	}

	private void UpdateOpacity()
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		double num = _animationClock.Restart().TotalSeconds * 4.0;
		base.Opacity = (((Vector2<double>)Mouse.GetPosition(this)).IsWithin(Vector2<double>.Zero, 15.0, 15.0) ? Math.Min(base.Opacity + num, 1.0) : Math.Max(base.Opacity - num, 0.0));
	}

	protected override bool DidHandleMove(PropertyChangedEventArgs e)
	{
		return e.PropertyName == "FlipMode";
	}
}
