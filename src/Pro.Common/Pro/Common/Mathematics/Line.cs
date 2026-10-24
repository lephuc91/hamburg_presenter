using System;
using System.Diagnostics;
using Pro.Common.Utility;

namespace Pro.Common.Mathematics;

[DebuggerDisplay("P: {P}, A: {A} | {typeof(T).Name,nq}")]
public struct Line<T> : IEquatable<Line<T>>
{
	private Vector2<T> _p;

	private Angle<T> _a;

	public Vector2<T> P
	{
		get
		{
			return _p;
		}
		set
		{
			_p = value;
		}
	}

	public Angle<T> A
	{
		get
		{
			return _a;
		}
		set
		{
			_a = value;
		}
	}

	public Line(Vector2<T> p, Angle<T> a)
	{
		_p = p;
		_a = a;
	}

	public override bool Equals(object? obj)
	{
		if (obj is Line<T> other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(Line<T> other)
	{
		if (P.Equals(other.P))
		{
			return A.Equals(other.A);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return HashCodeHelper.GenerateHashCode(_p, _a);
	}

	public static bool operator ==(Line<T> lhs, Line<T> rhs)
	{
		return lhs.Equals(rhs);
	}

	public static bool operator !=(Line<T> lhs, Line<T> rhs)
	{
		return !lhs.Equals(rhs);
	}
}
