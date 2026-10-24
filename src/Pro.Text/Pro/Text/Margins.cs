using System;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Utility;
using Pro.Text.Reversibility;

namespace Pro.Text;

public class Margins : NotifyPropertyChangedBase, IEquatable<Margins>, ICloneable<Margins>
{
	private double _left;

	private double _top;

	private double _right;

	private double _bottom;

	public UndoStack? UndoStack { get; set; }

	public double Left
	{
		get
		{
			return _left;
		}
		set
		{
			SetValue("Left", ref _left, value, delegate(double o, double n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.LeftMargin), this, "Left", o, n);
			});
		}
	}

	public double Top
	{
		get
		{
			return _top;
		}
		set
		{
			SetValue("Top", ref _top, value, delegate(double o, double n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.TopMargin), this, "Top", o, n);
			});
		}
	}

	public double Right
	{
		get
		{
			return _right;
		}
		set
		{
			SetValue("Right", ref _right, value, delegate(double o, double n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.RightMargin), this, "Right", o, n);
			});
		}
	}

	public double Bottom
	{
		get
		{
			return _bottom;
		}
		set
		{
			SetValue("Bottom", ref _bottom, value, delegate(double o, double n)
			{
				UndoStack?.Commit(new TaggedUndoAction<UndoActionTypes>(UndoActionTypes.BottomMargin), this, "Bottom", o, n);
			});
		}
	}

	public override int GetHashCode()
	{
		return HashCodeHelper.GenerateHashCode(_left, _top, _right, _bottom);
	}

	public override bool Equals(object? obj)
	{
		if (obj is Margins other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(Margins? other)
	{
		if ((object)other != null && _left == other._left && _top == other._top && _right == other._right)
		{
			return _bottom == other._bottom;
		}
		return false;
	}

	public Margins Clone()
	{
		return new Margins
		{
			_left = _left,
			_top = _top,
			_right = _right,
			_bottom = _bottom
		};
	}

	public static bool operator ==(Margins lhs, Margins rhs)
	{
		return lhs.NullableEquals<Margins>(rhs);
	}

	public static bool operator !=(Margins lhs, Margins rhs)
	{
		return !lhs.NullableEquals<Margins>(rhs);
	}
}
