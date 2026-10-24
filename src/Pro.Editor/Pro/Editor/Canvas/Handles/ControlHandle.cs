using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using Pro.Common.Mathematics;
using Pro.Editor.Canvas.Transforming;

namespace Pro.Editor.Canvas.Handles;

public class ControlHandle : HandleBase
{
	private const double HandleCircleRadius = 3.5;

	private const double HandleEdgeThickness = 0.5;

	private static readonly Brush HandleFillBrush = Brushes.SkyBlue;

	private static readonly Pen HandleEdgePen = new Pen(Brushes.Black, 0.5);

	private readonly ICanvasElement _sourceElement;

	private readonly Func<Vector2<double>> _locationPredicate;

	private readonly Action<Vector2<double>, Vector2<double>, Vector2<double>> _draggedAction;

	private readonly Predicate<PropertyChangedEventArgs> _movedPredicate;

	private readonly ITooltipDataSource? _toolTipDataSource;

	public ControlHandle(ICanvasElement sourceElement, Func<Vector2<double>> locationPredicate, Action<Vector2<double>, Vector2<double>, Vector2<double>> draggedAction, Predicate<PropertyChangedEventArgs> movedPredicate, ITooltipDataSource? tooltipDataSource = null)
	{
		_sourceElement = sourceElement;
		_locationPredicate = locationPredicate;
		_draggedAction = draggedAction;
		_movedPredicate = movedPredicate;
		_toolTipDataSource = tooltipDataSource;
	}

	protected internal override void OnUpdateLocation()
	{
		Vector2<double> origin = _sourceElement.Center();
		base.Location = (_locationPredicate().ComponentwiseProduct(_sourceElement.Size) + _sourceElement.Position).Rotate(origin, _sourceElement.Rotation.InvertedCartesianValue) * base.TransformMatrix;
	}

	protected override void OnRenderHandle(DrawingContext dc)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		dc.DrawEllipse(HandleFillBrush, HandleEdgePen, new Point(0.0, 0.0), 3.5, 3.5);
	}

	protected override ITooltipDataSource? OnDragStarted(out ITransform? activeTransform)
	{
		base.OnDragStarted(out activeTransform);
		return _toolTipDataSource;
	}

	protected override void OnDragged(Vector2<double> startPoint, Vector2<double> lastPoint, Vector2<double> currentPoint)
	{
		Vector2<double> origin = _sourceElement.Center();
		Vector2<double> position = _sourceElement.Position;
		Vector2<double> scale = _sourceElement.Size.Invert();
		startPoint = (startPoint.Rotate(origin, _sourceElement.Rotation.CartesianValue) - position).ComponentwiseProduct(scale);
		lastPoint = (lastPoint.Rotate(origin, _sourceElement.Rotation.CartesianValue) - position).ComponentwiseProduct(scale);
		currentPoint = (currentPoint.Rotate(origin, _sourceElement.Rotation.CartesianValue) - position).ComponentwiseProduct(scale);
		_draggedAction(startPoint, lastPoint, currentPoint);
	}

	protected internal override bool DidHandleMove(PropertyChangedEventArgs e)
	{
		if (!_movedPredicate(e))
		{
			return base.DidHandleMove(e);
		}
		return true;
	}
}
