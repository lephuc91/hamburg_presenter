using System;
using System.Collections.Generic;
using System.Linq;
using Pro.Common.Collections;
using Pro.Common.Components.Reversibility;
using Pro.Common.Mathematics;
using Pro.Editor.Canvas.Transforming;
using Pro.Entity;
using Pro.Localization;
using Pro.SerializationInterop.RVProtoData;
using ProPresenter.DO.Slide.Custom.Elements.Handles;

namespace ProPresenter.DO.Slide.Custom.Elements;

public class OpenBezierPath : BezierPath
{
	private static readonly Vector2<double> DefaultSize = Vector2<double>.One;

	private List<BezierPoint> _points = new List<BezierPoint>();

	private bool _isEditModeActive;

	protected override string DisplayName => LocalizedStrings.Get("GLOBAL_SHAPE_LINE");

	public override BezierPathType PathType => BezierPathType.Open;

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

	public event Action<OpenBezierPath>? ClosePath;

	public event System.Action? LeftEditMode;

	public OpenBezierPath()
	{
		Size = DefaultSize;
		EnterEditMode();
	}

	public BezierPoint AddPoint(Vector2<double> point)
	{
		base.UndoStack?.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ElementAddPoint));
		if (!_points.Any())
		{
			Position = point;
		}
		if (Size.Y == 0.0 && point.Y != Position.Y)
		{
			Size += new Vector2<double>(0.0, point.Y - Position.Y);
		}
		else if (Size.X == 0.0 && point.X != Position.X)
		{
			Size += new Vector2<double>(point.X - Position.X, 0.0);
		}
		int index = _points.Count;
		Vector2<double> position = point.ProjectIntoBoundedLocalSpace(new Rect<double>(Position, Size), Rotation);
		BezierPoint newPoint = new BezierPoint(position);
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
		point.UndoStack = base.UndoStack;
		ClearAddPointHandles();
		GenerateAddPointHandles();
		InvalidatePoints();
		NormalizeBounds();
		OnVisualInvalidated();
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
		OpenBezierPath openBezierPath = new OpenBezierPath
		{
			_points = _points.CloneItems().ToList()
		};
		CopyProperties(openBezierPath);
		return openBezierPath;
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
			this.LeftEditMode?.Invoke();
		}
	}

	protected override void OnUndoStackChanged(UndoStack? undoStack)
	{
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
		_points = points.ToList();
	}

	private void ClearAddPointHandles()
	{
		base.CustomHandlesCollection.RemoveRange(base.CustomHandlesCollection.OfType<NewBezierPointHandleData>().ToArray());
	}

	private void GenerateAddPointHandles()
	{
		if (_isEditModeActive)
		{
			for (int i = 0; i < _points.Count - 1; i++)
			{
				base.CustomHandlesCollection.Add(new NewBezierPointHandleData(this, _points[i], _points[i + 1]));
			}
		}
	}

	private void AddCustomHandles(BezierPoint point)
	{
		AddCustomHandles(new global::_003C_003Ez__ReadOnlySingleElementList<BezierPoint>(point));
	}

	private void AddCustomHandles(IEnumerable<BezierPoint> points)
	{
		if (points.Any() && _isEditModeActive)
		{
			base.CustomHandlesCollection.AddRange(points.Select((BezierPoint p) => new BezierHandleSetData(this, p)));
		}
	}

	private void OnClosePath()
	{
		this.ClosePath?.Invoke(this);
	}

	public override void HandleDragStarted(BezierPoint point)
	{
		if (point == _points.FirstOrDefault())
		{
			OnClosePath();
		}
	}

	public override void HandleDragged(BezierPoint point)
	{
		if (point != _points.FirstOrDefault() && base.UndoStack != null && !base.UndoStack.IsRecording)
		{
			base.UndoStack.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ElementMovePoint));
		}
	}

	public override void HandleDragCompleted(BezierPoint point)
	{
		if (point != _points.FirstOrDefault() && base.UndoStack != null && base.UndoStack.IsRecording)
		{
			NormalizeBounds();
			base.UndoStack.EndCommit(null, NormalizeBounds, autoFinalize: true);
		}
	}

	public override void PointToggleStarted(BezierPoint point)
	{
		if (point != _points.FirstOrDefault() && base.UndoStack != null)
		{
			base.UndoStack.BeginCommit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.ElementTogglePoint));
		}
	}

	public override void PointToggleCompleted(BezierPoint point)
	{
		if (point != _points.FirstOrDefault())
		{
			NormalizeBounds();
			base.UndoStack?.EndCommit(null, NormalizeBounds, autoFinalize: true);
		}
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
