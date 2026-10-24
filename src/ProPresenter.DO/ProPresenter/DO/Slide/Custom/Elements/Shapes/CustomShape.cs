using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.DO.Utility;
using Pro.Editor.Canvas.Transforming;
using Pro.Entity;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Media;
using ProPresenter.DO.Slide.Custom.Elements.Handles;

namespace ProPresenter.DO.Slide.Custom.Elements.Shapes;

public class CustomShape : ClosedBezierPath
{
	private readonly List<BezierPoint> _points = new List<BezierPoint>();

	private bool _isEditModeActive;

	public override string DefaultShapeName => LocalizedStrings.Get("GLOBAL_SHAPE_CUSTOM");

	public override HandleLocation SupportedCanvasHandles
	{
		get
		{
			if (!_isEditModeActive)
			{
				return base.SupportedCanvasHandles;
			}
			return HandleLocation.None;
		}
	}

	public CustomShape(IMediaFactory mediaFactory, ITextDocumentFactory textDocumentFactory, string containerId)
		: base(mediaFactory, textDocumentFactory, containerId)
	{
	}

	public CustomShape(IMediaFactory mediaFactory, ITextDocumentFactory textDocumentFactory, BezierPath path, string containerId, bool normalizeBounds = true)
		: base(mediaFactory, textDocumentFactory, containerId)
	{
		_points.AddRange(path.Points?.CloneItems() ?? Enumerable.Empty<BezierPoint>());
		path.CopyProperties(this);
		base.AdditionalInfo &= ~AdditionalInfo.Text;
		if (normalizeBounds)
		{
			NormalizeBounds();
		}
	}

	public override BezierPoint InsertPoint(BezierPoint startPoint, BezierPoint endPoint, double t)
	{
		base.UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ElementAddPoint));
		int index = _points.IndexOf(endPoint);
		BezierPoint newPoint = BezierPathMath.SplitCurve(startPoint, endPoint, t);
		base.UndoStack?.Commit(delegate
		{
			OnRemovePoint(index);
		}, delegate
		{
			OnInsertPoint(index, newPoint);
		});
		OnInsertPoint(index, newPoint);
		base.UndoStack?.EndCommit(null, null, autoFinalize: true);
		return newPoint;
	}

	public void RemovePoint(BezierPoint point)
	{
		base.UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ElementRemovePoint));
		int index = _points.IndexOf(point);
		base.UndoStack?.Commit(delegate
		{
			OnInsertPoint(index, point);
		}, delegate
		{
			OnRemovePoint(index);
		});
		OnRemovePoint(index);
		base.UndoStack?.EndCommit(null, null, autoFinalize: true);
	}

	private void OnInsertPoint(int index, BezierPoint point)
	{
		_points.Insert(index, point);
		ClearAddPointHandles();
		GenerateAddPointHandles();
		InvalidatePoints();
		NormalizeBounds();
		OnVisualInvalidated();
		point.UndoStack = base.UndoStack;
		AddCustomHandles(point);
	}

	private void OnRemovePoint(int index)
	{
		BezierPoint point = _points[index];
		point.UndoStack = null;
		_points.Remove(point);
		base.CustomHandlesCollection.RemoveRange((from s in base.CustomHandlesCollection.OfType<BezierHandleSetData>()
			where s.Point == point
			select s).ToArray());
		ClearAddPointHandles();
		GenerateAddPointHandles();
		InvalidatePoints();
		NormalizeBounds();
		OnVisualInvalidated();
	}

	public override SlideElementBase Clone()
	{
		CustomShape customShape = new CustomShape(base.MediaFactory, base.TextDocumentFactory, this, base.ContainerId, normalizeBounds: false);
		CopyProperties(customShape);
		return customShape;
	}

	protected override void OnUndoStackChanged(UndoStack? undoStack)
	{
		base.OnUndoStackChanged(undoStack);
		_points.ForEach(delegate(BezierPoint p)
		{
			p.UndoStack = undoStack;
		});
	}

	protected override IEnumerable<BezierPoint> GeneratePoints()
	{
		return _points;
	}

	protected override Graphics.Types.Path.Types.Shape SerializeShape()
	{
		return new Graphics.Types.Path.Types.Shape
		{
			Type = Graphics.Types.Path.Types.Shape.Types.Type.Custom
		};
	}

	protected override void OnPointsDeserialized(BezierPoint[] points)
	{
		_points.Clear();
		_points.AddRange(points);
	}

	public override void OnDeselected()
	{
		LeaveEditMode();
		base.OnDeselected();
	}

	public void EnterEditMode()
	{
		if (!_isEditModeActive)
		{
			_isEditModeActive = true;
			AddCustomHandles(_points);
			GenerateAddPointHandles();
			OnPropertyChanged("SupportedCanvasHandles");
		}
	}

	public void LeaveEditMode()
	{
		if (_isEditModeActive)
		{
			base.CustomHandlesCollection.RemoveRange(base.CustomHandlesCollection.OfType<BezierHandleSetData>().ToArray());
			ClearAddPointHandles();
			_isEditModeActive = false;
			OnPropertyChanged("SupportedCanvasHandles");
		}
	}

	private void ClearAddPointHandles()
	{
		base.CustomHandlesCollection.RemoveRange(base.CustomHandlesCollection.OfType<NewBezierPointHandleData>().ToArray());
	}

	private void GenerateAddPointHandles()
	{
		if (_isEditModeActive)
		{
			for (int i = 0; i < _points.Count; i++)
			{
				base.CustomHandlesCollection.Add(new NewBezierPointHandleData(this, _points[i], _points[(i + 1) % _points.Count]));
			}
		}
	}

	private void AddCustomHandles(BezierPoint point)
	{
		AddCustomHandles(new BezierPoint[1] { point });
	}

	private void AddCustomHandles(IEnumerable<BezierPoint> points)
	{
		if (points.Any() && _isEditModeActive)
		{
			base.CustomHandlesCollection.AddRange(points.Select((BezierPoint p) => new BezierHandleSetData(this, p)));
		}
	}

	public override void HandleDragged(BezierPoint point)
	{
		if (base.UndoStack != null && !base.UndoStack.IsRecording)
		{
			base.UndoStack.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ElementMovePoint));
		}
	}

	public override void HandleDragCompleted(BezierPoint point)
	{
		if (base.UndoStack != null && base.UndoStack.IsRecording)
		{
			NormalizeBounds();
			base.UndoStack.EndCommit(null, NormalizeBounds, autoFinalize: true);
		}
	}

	public override void PointToggleStarted(BezierPoint point)
	{
		base.UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ElementTogglePoint));
	}

	public override void PointToggleCompleted(BezierPoint point)
	{
		NormalizeBounds();
		base.UndoStack?.EndCommit(null, NormalizeBounds, autoFinalize: true);
	}

	private void NormalizeBounds()
	{
		BezierPathMath.NormalizeBounds(this);
	}

	protected override bool IsSyncCompatibleShape(IGraphics.Types.IPath.Types.Shape.Types.Type type)
	{
		return type == IGraphics.Types.IPath.Types.Shape.Types.Type.Custom;
	}
}
