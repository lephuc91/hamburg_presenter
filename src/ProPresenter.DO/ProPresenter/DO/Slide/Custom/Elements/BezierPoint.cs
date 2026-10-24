using System;
using System.Diagnostics.CodeAnalysis;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Mathematics;
using Pro.Common.ObjectBinding;
using Pro.Common.Utility;
using Pro.DO.Utility;
using Pro.Entity;
using Pro.SerializationInterop.RVProtoData;

namespace ProPresenter.DO.Slide.Custom.Elements;

public class BezierPoint : NotifyPropertyChangedBase, IRenderEquatable<BezierPoint>, IRenderHashable, ICloneable<BezierPoint>
{
	private Vector2<double> _position;

	private Vector2<double> _q0;

	private Vector2<double> _q1;

	private bool _isCurved;

	public Vector2<double> Position
	{
		get
		{
			return _position;
		}
		set
		{
			SetValue("Position", ref _position, value, delegate(Vector2<double> o, Vector2<double> n)
			{
				UndoStack?.Commit(UndoActionTypes.ElementMovePoint.ToAction(), this, "Position", o, n);
				OnDataModified();
			});
		}
	}

	public Vector2<double> Q0
	{
		get
		{
			return _q0;
		}
		set
		{
			SetValue("Q0", ref _q0, value, delegate(Vector2<double> o, Vector2<double> n)
			{
				UndoStack?.Commit(UndoActionTypes.ElementMovePoint.ToAction(), this, "Q0", o, n);
				OnDataModified();
				OnPropertyChanged("ActiveQ0");
			});
		}
	}

	public Vector2<double> Q1
	{
		get
		{
			return _q1;
		}
		set
		{
			SetValue("Q1", ref _q1, value, delegate(Vector2<double> o, Vector2<double> n)
			{
				UndoStack?.Commit(UndoActionTypes.ElementMovePoint.ToAction(), this, "Q1", o, n);
				OnDataModified();
				OnPropertyChanged("ActiveQ1");
			});
		}
	}

	public bool IsCurved
	{
		get
		{
			return _isCurved;
		}
		set
		{
			SetValue("IsCurved", ref _isCurved, value, delegate(bool o, bool n)
			{
				UndoStack?.Commit(UndoActionTypes.ElementTogglePoint.ToAction(), this, "IsCurved", o, n);
				OnDataModified();
				OnPropertyChanged("Q0");
				OnPropertyChanged("Q1");
				OnPropertyChanged("ActiveQ0");
				OnPropertyChanged("ActiveQ1");
			});
		}
	}

	public Vector2<double> ActiveQ0
	{
		get
		{
			if (!IsCurved)
			{
				return Position;
			}
			return _q0;
		}
	}

	public Vector2<double> ActiveQ1
	{
		get
		{
			if (!IsCurved)
			{
				return Position;
			}
			return _q1;
		}
	}

	public UndoStack? UndoStack { get; set; }

	public event Action<BezierPoint>? DataModified;

	public static ObjectBinder<BezierPoint, IGraphics.Types.IPath.Types.IBezierPoint> CreateBinder(BezierPoint left, IGraphics.Types.IPath.Types.IBezierPoint right)
	{
		ObjectBinder<BezierPoint, IGraphics.Types.IPath.Types.IBezierPoint> objectBinder = new ObjectBinder<BezierPoint, IGraphics.Types.IPath.Types.IBezierPoint>(left, right);
		objectBinder.Bind((BezierPoint l) => l.WhenPropertyChanges("Position"), (IGraphics.Types.IPath.Types.IBezierPoint r) => r.Point.WhenValueChanges, delegate(BezierPoint l, IGraphics.Types.IPath.Types.IBezierPoint r)
		{
			r.Point.Set(l.Position.ToPoint());
		}, delegate(IGraphics.Types.IPath.Types.IBezierPoint r, BezierPoint l)
		{
			l.Position = r.Point.Value.ToVector2d();
		}).Bind((BezierPoint l) => l.WhenPropertyChanges("Q0"), (IGraphics.Types.IPath.Types.IBezierPoint r) => r.Q0.WhenValueChanges, delegate(BezierPoint l, IGraphics.Types.IPath.Types.IBezierPoint r)
		{
			r.Q0.Set(l.Q0.ToPoint());
		}, delegate(IGraphics.Types.IPath.Types.IBezierPoint r, BezierPoint l)
		{
			l.Q0 = r.Q0.Value.ToVector2d();
		}).Bind((BezierPoint l) => l.WhenPropertyChanges("Q1"), (IGraphics.Types.IPath.Types.IBezierPoint r) => r.Q1.WhenValueChanges, delegate(BezierPoint l, IGraphics.Types.IPath.Types.IBezierPoint r)
		{
			r.Q1.Set(l.Q1.ToPoint());
		}, delegate(IGraphics.Types.IPath.Types.IBezierPoint r, BezierPoint l)
		{
			l.Q1 = r.Q1.Value.ToVector2d();
		})
			.Bind((BezierPoint l) => l.WhenPropertyChanges("IsCurved"), (IGraphics.Types.IPath.Types.IBezierPoint r) => r.Curved.WhenValueChanges, delegate(BezierPoint l, IGraphics.Types.IPath.Types.IBezierPoint r)
			{
				r.Curved.Set(l.IsCurved);
			}, delegate(IGraphics.Types.IPath.Types.IBezierPoint r, BezierPoint l)
			{
				l.IsCurved = r.Curved.Value;
			});
		return objectBinder;
	}

	public BezierPoint()
	{
	}

	public BezierPoint(Vector2<double> position)
	{
		_position = position;
		_q0 = position;
		_q1 = position;
	}

	public bool RenderEquals([NotNullWhen(true)] BezierPoint? other)
	{
		if (other != null && _position == other._position && _q0 == other._q0 && _q1 == other._q1)
		{
			return _isCurved == other._isCurved;
		}
		return false;
	}

	public int GetRenderHashCode()
	{
		return RenderHashCodeHelper.GenerateHashCode(_position, _q0, _q1, _isCurved);
	}

	public BezierPoint Clone()
	{
		return new BezierPoint
		{
			_position = _position,
			_q0 = _q0,
			_q1 = _q1,
			_isCurved = _isCurved
		};
	}

	protected internal Graphics.Types.Path.Types.BezierPoint Serialize()
	{
		return new Graphics.Types.Path.Types.BezierPoint
		{
			Point = Position.ToProtoPoint(),
			Q0 = Q0.ToProtoPoint(),
			Q1 = Q1.ToProtoPoint(),
			Curved = IsCurved
		};
	}

	protected internal void Deserialize(Graphics.Types.Path.Types.BezierPoint point)
	{
		Position = point.Point.ToVector();
		Q0 = point.Q0.ToVector();
		Q1 = point.Q1.ToVector();
		IsCurved = point.Curved;
	}

	private void OnDataModified()
	{
		this.DataModified?.Invoke(this);
	}
}
