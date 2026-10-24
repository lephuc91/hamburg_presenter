using System;
using System.Diagnostics;
using Pro.Common.Utility;

namespace Pro.Common.Mathematics;

[DebuggerDisplay("A: {A}, B: {B} | {typeof(T).Name,nq}")]
public struct LineSegment<T> : IEquatable<LineSegment<T>>
{
	private Vector2<T> _a;

	private Vector2<T> _b;

	public Vector2<T> A
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

	public Vector2<T> B
	{
		get
		{
			return _b;
		}
		set
		{
			_b = value;
		}
	}

	public LineSegment(Vector2<T> v)
		: this(v, v)
	{
	}

	public LineSegment(Vector2<T> a, Vector2<T> b)
	{
		_a = a;
		_b = b;
	}

	public override bool Equals(object? obj)
	{
		if (obj is LineSegment<T> other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(LineSegment<T> other)
	{
		if (A.Equals(other.A))
		{
			return B.Equals(other.B);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return HashCodeHelper.GenerateHashCode(_a, _b);
	}

	public LineSegment<K> Cast<K>()
	{
		return new LineSegment<K>(A.Cast<K>(), B.Cast<K>());
	}

	public static bool operator ==(LineSegment<T> lhs, LineSegment<T> rhs)
	{
		return lhs.Equals(rhs);
	}

	public static bool operator !=(LineSegment<T> lhs, LineSegment<T> rhs)
	{
		return !lhs.Equals(rhs);
	}
}
