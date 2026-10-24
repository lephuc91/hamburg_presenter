using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Pro.Common.Mathematics;
using Pro.Editor.Canvas;
using Pro.Editor.Canvas.Handles;
using Pro.Editor.Canvas.Transforming;
using Pro.UI.Utility;
using ProPresenter.DO.Slide.Custom;
using ProPresenter.DO.Slide.Custom.Elements;

namespace ProPresenter.UI.SlideEditor.Handles;

public class BezierPointHandle : HandleBase
{
	private const double HandleRadius = 4.0;

	private const double HandleEdgeThickness = 1.0;

	private const double LineThickness = 2.0;

	private static readonly Brush FillBrush = Brushes.White;

	private static readonly Brush SelectedFillBrush = Brushes.Red;

	private static readonly Pen BorderPen = new Pen(Brushes.Red, 1.0);

	private static readonly Pen SelectedBorderPen = new Pen(Brushes.Black, 1.0);

	private static readonly Pen LinePen = new Pen(Brushes.Gray, 2.0);

	private readonly BezierPath _element;

	private readonly BezierHandleSetProvider _set;

	private BezierCurvePreview? _preview;

	public static readonly DependencyProperty ShowPreviewProperty = DependencyProperty.Register("ShowPreview", typeof(bool), typeof(BezierPointHandle), (PropertyMetadata)(object)new FrameworkPropertyMetadata(new PropertyChangedCallback(OnShowPreviewPropertyChanged)));

	public BezierPoint Point { get; }

	public bool ShowPreview
	{
		get
		{
			return (bool)((DependencyObject)this).GetValue(ShowPreviewProperty);
		}
		set
		{
			((DependencyObject)this).SetValue(ShowPreviewProperty, (object)value);
		}
	}

	public override bool CanSelect => true;

	protected Rect<double> ElementBounds => new Rect<double>(_element.Position, _element.Size);

	public event Action<BezierPointHandle>? DragStarted;

	public event Action<BezierPointHandle>? Dragged;

	public event Action<BezierPointHandle>? DragCompleted;

	public event Action<BezierPointHandle>? PointToggleStarted;

	public event Action<BezierPointHandle>? PointToggleCompleted;

	private static void OnShowPreviewPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		(d as BezierPointHandle)?.UpdatePreview();
	}

	public BezierPointHandle(BezierPath element, BezierPoint point, BezierHandleSetProvider set)
	{
		_element = element;
		_set = set;
		Point = point;
	}

	protected override bool IsHandleActive()
	{
		if (!base.IsSelected)
		{
			return _set.IsActive;
		}
		return true;
	}

	protected override ITooltipDataSource? OnDragStarted(out ITransform? activeTransform)
	{
		this.DragStarted?.Invoke(this);
		return base.OnDragStarted(out activeTransform);
	}

	public void StartBezierPointDrag(MouseEventArgs e)
	{
		UpdateLayout();
		RaiseEvent(e);
	}

	public void StartControlPointDrag(MouseEventArgs e)
	{
		Point.IsCurved = true;
		BezierControlPointHandle bezierControlPointHandle = _set.Handles.OfType<BezierControlPointHandle>().First((BezierControlPointHandle h) => !h.IsQ0);
		bezierControlPointHandle.AngleToggle = true;
		bezierControlPointHandle.DistanceToggle = true;
		bezierControlPointHandle.OnMouseClick(new MouseButtonEventArgs(e.Device as MouseDevice, e.Timestamp, MouseButton.Left));
	}

	private void UpdatePreview()
	{
		this.ResetIndicator();
		if (ShowPreview)
		{
			if (this.GetAdornerLayer() == null)
			{
				return;
			}
			BezierPointHandle bezierPointHandle = _set.Handles.First((BezierPointHandle h) => !(h is BezierControlPointHandle));
			BezierPointHandle q1Handle = (Point.IsCurved ? _set.Handles.OfType<BezierControlPointHandle>().First((BezierControlPointHandle h) => !h.IsQ0) : bezierPointHandle);
			_preview = new BezierCurvePreview(bezierPointHandle, q1Handle, () => !_element.CustomHandles.OfType<BezierPointHandle>().Any((BezierPointHandle h) => h.IsMouseCaptured));
			this.AddAdorner(_preview);
		}
		InvalidateVisual();
	}

	protected override void OnDragged(Vector2<double> startPoint, Vector2<double> lastPoint, Vector2<double> currentPoint)
	{
		this.Dragged?.Invoke(this);
		MovePoint(ProjectIntoLocalSpace(lastPoint) - ProjectIntoLocalSpace(currentPoint));
	}

	protected virtual void MovePoint(Vector2<double> delta)
	{
		if (base.SelectedHandles == null)
		{
			return;
		}
		foreach (BezierPoint item in from h in base.SelectedHandles.OfType<BezierPointHandle>()
			select h.Point)
		{
			item.Position -= delta;
			item.Q0 -= delta;
			item.Q1 -= delta;
		}
	}

	protected override void OnDragEnded()
	{
		this.DragCompleted?.Invoke(this);
	}

	internal void InvalidateLines()
	{
		InvalidateVisual();
	}

	protected override void OnRenderHandle(DrawingContext dc)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		dc.DrawLine(LinePen, Vector2<double>.Zero, scale(Point.ActiveQ0) * base.LayoutScale);
		dc.DrawLine(LinePen, Vector2<double>.Zero, scale(Point.ActiveQ1) * base.LayoutScale);
		dc.DrawEllipse(base.IsSelected ? SelectedFillBrush : FillBrush, base.IsSelected ? SelectedBorderPen : BorderPen, Vector2<double>.Zero, 4.0, 4.0);
		_preview?.InvalidateVisual();
		Vector2<double> scale(Vector2<double> v)
		{
			return (_element.FlipMode.FlipPoint(v) - _element.FlipMode.FlipPoint(Point.Position)).ComponentwiseProduct(_element.Size);
		}
	}

	protected override void OnUpdateLocation()
	{
		UpdateLocation(Point.Position);
		UpdatePreview();
	}

	protected override bool DidHandleMove(PropertyChangedEventArgs e)
	{
		string propertyName = e.PropertyName;
		if (propertyName == "FlipMode" || propertyName == "Position")
		{
			return true;
		}
		return base.DidHandleMove(e);
	}

	protected void UpdateLocation(Vector2<double> localPoint)
	{
		base.Location = ProjectIntoWorldSpace(localPoint);
	}

	protected override void OnMouseDown(MouseButtonEventArgs e)
	{
		InvalidateVisual();
		base.OnMouseDown(e);
	}

	protected override void OnMouseDoubleClick(MouseButtonEventArgs e)
	{
		TogglePoint();
	}

	protected override void OnUpdateCursor()
	{
		base.Cursor = Cursors.Hand;
	}

	protected Vector2<double> ProjectIntoWorldSpace(Vector2<double> point)
	{
		return ProjectPoint(_element.FlipMode.FlipPoint(point), Vector2Extensions.ProjectIntoWorldSpace);
	}

	protected Vector2<double> ProjectIntoLocalSpace(Vector2<double> point)
	{
		return _element.FlipMode.FlipPoint(ProjectPoint(point, BezierPathMath.ProjectIntoBoundedLocalSpace));
	}

	private void TogglePoint()
	{
		this.PointToggleStarted?.Invoke(this);
		BezierPathMath.ToggleBezierPoint(Point, _element);
		UpdatePreview();
		this.PointToggleCompleted?.Invoke(this);
	}

	private Vector2<double> ProjectPoint(Vector2<double> point, Func<Vector2<double>, Rect<double>, Angle<double>, Vector2<double>> projector)
	{
		return projector(point, new Rect<double>(_element.Position, _element.Size), _element.Rotation);
	}
}
