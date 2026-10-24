using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows;
using Pro.Common.Operations;
using Pro.Common.Utility;
using Pro.Common.Win32;

namespace Pro.Common.Mathematics;

[DebuggerDisplay("X: {X}, Y: {Y} | {typeof(T).Name,nq}")]
public struct Vector2<T> : IEquatable<Vector2<T>>
{
	public static readonly Vector2<T> NegativeOne = new Vector2<T>(Constants<T>.NegativeOne);

	public static readonly Vector2<T> Zero = new Vector2<T>(Constants<T>.Zero);

	public static readonly Vector2<T> One = new Vector2<T>(Constants<T>.One);

	public static readonly Vector2<T> UnitX = new Vector2<T>(Constants<T>.One, Constants<T>.Zero);

	public static readonly Vector2<T> UnitY = new Vector2<T>(Constants<T>.Zero, Constants<T>.One);

	private T _x;

	private T _y;

	public T X
	{
		get
		{
			return _x;
		}
		set
		{
			_x = value;
		}
	}

	public T Y
	{
		get
		{
			return _y;
		}
		set
		{
			_y = value;
		}
	}

	public Vector2(T v)
		: this(v, v)
	{
	}

	public Vector2(T x, T y)
	{
		_x = x;
		_y = y;
	}

	public override bool Equals(object? obj)
	{
		if (obj is Vector2<T> other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(Vector2<T> other)
	{
		if (X.Equal(other.X))
		{
			return Y.Equal(other.Y);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return HashCodeHelper.GenerateHashCode(_x, _y);
	}

	public Vector2<K> Cast<K>()
	{
		return new Vector2<K>(X.Cast<K, T>(), Y.Cast<K, T>());
	}

	public override string ToString()
	{
		return $"X:{{{X}}}, Y:{{{Y}}}";
	}

	public static Vector2<T> operator -(Vector2<T> v)
	{
		return new Vector2<T>(v.X.Negate(), v.Y.Negate());
	}

	public static Vector2<T> operator -(Vector2<T> lhs, Vector2<T> rhs)
	{
		return new Vector2<T>(lhs.X.Subtract(rhs.X), lhs.Y.Subtract(rhs.Y));
	}

	public static Vector2<T> operator +(Vector2<T> lhs, Vector2<T> rhs)
	{
		return new Vector2<T>(lhs.X.Add(rhs.X), lhs.Y.Add(rhs.Y));
	}

	public static Vector2<T> operator *(Vector2<T> v, T f)
	{
		return new Vector2<T>(v.X.Multiply(f), v.Y.Multiply(f));
	}

	public static Vector2<T> operator *(T f, Vector2<T> v)
	{
		return new Vector2<T>(v.X.Multiply(f), v.Y.Multiply(f));
	}

	public static Vector2<T> operator /(Vector2<T> v, T f)
	{
		return new Vector2<T>(v.X.Divide(f), v.Y.Divide(f));
	}

	public static bool operator ==(Vector2<T> lhs, Vector2<T> rhs)
	{
		return lhs.Equals(rhs);
	}

	public static bool operator !=(Vector2<T> lhs, Vector2<T> rhs)
	{
		return !lhs.Equals(rhs);
	}

	public static explicit operator Vector2<T>(Point p)
	{
		return new Vector2<T>(((Point)(ref p)).X.Cast<T, double>(), ((Point)(ref p)).Y.Cast<T, double>());
	}

	public static implicit operator Point(Vector2<T> v)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		return new Point(v.X.Cast<double, T>(), v.Y.Cast<double, T>());
	}

	public static explicit operator Vector2<T>(Vector v)
	{
		return new Vector2<T>(((Vector)(ref v)).X.Cast<T, double>(), ((Vector)(ref v)).Y.Cast<T, double>());
	}

	public static implicit operator Vector(Vector2<T> v)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		return new Vector(v.X.Cast<double, T>(), v.Y.Cast<double, T>());
	}

	public static explicit operator Vector2<T>(Size s)
	{
		return new Vector2<T>(((Size)(ref s)).Width.Cast<T, double>(), ((Size)(ref s)).Height.Cast<T, double>());
	}

	public static implicit operator Size(Vector2<T> v)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		return new Size(v.X.Cast<double, T>(), v.Y.Cast<double, T>());
	}

	public static explicit operator Vector2<T>(Size s)
	{
		return new Vector2<T>(s.Width.Cast<T, int>(), s.Height.Cast<T, int>());
	}

	public static implicit operator Size(Vector2<T> v)
	{
		return new Size(v.X.Cast<int, T>(), v.Y.Cast<int, T>());
	}

	public static implicit operator POINT(Vector2<T> v)
	{
		POINT result = default(POINT);
		result.X = v.X.Cast<int, T>();
		result.Y = v.Y.Cast<int, T>();
		return result;
	}

	public static explicit operator Vector2<T>(POINT pt)
	{
		return new Vector2<T>(pt.X.Cast<T, int>(), pt.Y.Cast<T, int>());
	}
}
