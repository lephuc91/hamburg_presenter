using System;
using Pro.Common.Components;
using Pro.Common.Components.Reversibility;
using Pro.Common.Utility;
using Pro.Text.Reversibility;

namespace Pro.Text;

public class TabStop : NotifyPropertyChangedBase, IEquatable<TabStop>
{
	private int? _hashCode;

	private double _position;

	private TabStopType _type;

	public double Position
	{
		get
		{
			return _position;
		}
		set
		{
			SetValue("Position", ref _position, value, delegate(double o, double n)
			{
				UndoStack?.Commit(UndoActionTypes.TextTabStopPosition.ToAction(), this, "Position", o, n);
			});
		}
	}

	public TabStopType Type
	{
		get
		{
			return _type;
		}
		set
		{
			SetValue("Type", ref _type, value, delegate(TabStopType o, TabStopType n)
			{
				UndoStack?.Commit(UndoActionTypes.TextTabStopType.ToAction(), this, "Type", o, n, null, null, autoFinalize: true);
			});
		}
	}

	public UndoStack? UndoStack { get; set; }

	public TabStop(double position, TabStopType type = TabStopType.Left)
	{
		_position = position;
		_type = type;
	}

	public override int GetHashCode()
	{
		if (!_hashCode.HasValue)
		{
			_hashCode = HashCodeHelper.GenerateHashCode(_position);
		}
		return _hashCode.Value;
	}

	public override bool Equals(object? obj)
	{
		if (obj is TabStop other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(TabStop? other)
	{
		if ((object)other != null && _position == other._position)
		{
			return _type == other._type;
		}
		return false;
	}

	public static bool operator ==(TabStop lhs, TabStop rhs)
	{
		return lhs.NullableEquals<TabStop>(rhs);
	}

	public static bool operator !=(TabStop lhs, TabStop rhs)
	{
		return !lhs.NullableEquals<TabStop>(rhs);
	}
}
