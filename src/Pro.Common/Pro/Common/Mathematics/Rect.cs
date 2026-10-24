using System;
using System.Diagnostics;
using System.Windows;
using Pro.Common.Operations;
using Pro.Common.Utility;
using Pro.Common.Win32;

namespace Pro.Common.Mathematics;

[DebuggerDisplay("X: {Position.X}, Y: {Position.Y}, W: {Size.X}, H: {Size.Y} | {typeof(T).Name,nq}")]
public struct Rect<T> : IEquatable<Rect<T>>
{
	public static readonly Rect<T> Empty = new Rect<T>(Vector2<T>.Zero, Vector2<T>.Zero);

	private Vector2<T> _position;

	private Vector2<T> _size;

	public Vector2<T> Position
	{
		get
		{
			return _position;
		}
		set
		{
			_position = value;
		}
	}

	public Vector2<T> Size
	{
		get
		{
			return _size;
		}
		set
		{
			_size = value;
		}
	}

	public T Left
	{
		get
		{
			return _position.X;
		}
		set
		{
			_position.X = value;
		}
	}

	public T Right
	{
		get
		{
			return Left.Add(Width);
		}
		set
		{
			Width = value.Subtract(Left);
		}
	}

	public T Top
	{
		get
		{
			return _position.Y;
		}
		set
		{
			_position.Y = value;
		}
	}

	public T Bottom
	{
		get
		{
			return Top.Add(Height);
		}
		set
		{
			Height = value.Subtract(Top);
		}
	}

	public T Width
	{
		get
		{
			return _size.X;
		}
		set
		{
			_size.X = value;
		}
	}

	public T Height
	{
		get
		{
			return _size.Y;
		}
		set
		{
			_size.Y = value;
		}
	}

	public Vector2<T> TopLeft => Position;

	public Vector2<T> TopCenter => new Vector2<T>(Left.Add(Width.Halve()), Top);

	public Vector2<T> TopRight => new Vector2<T>(Right, Top);

	public Vector2<T> RightCenter => new Vector2<T>(Right, Top.Add(Height.Halve()));

	public Vector2<T> BottomRight => Position + Size;

	public Vector2<T> BottomCenter => new Vector2<T>(Left.Add(Width.Halve()), Bottom);

	public Vector2<T> BottomLeft => new Vector2<T>(Left, Bottom);

	public Vector2<T> LeftCenter => new Vector2<T>(Left, Top.Add(Height.Halve()));

	public Vector2<T> Center => new Vector2<T>(Left.Add(Width.Halve()), Top.Add(Height.Halve()));

	public LineSegment<T> TopEdge => new LineSegment<T>(TopLeft, TopRight);

	public LineSegment<T> RightEdge => new LineSegment<T>(TopRight, BottomRight);

	public LineSegment<T> BottomEdge => new LineSegment<T>(BottomLeft, BottomRight);

	public LineSegment<T> LeftEdge => new LineSegment<T>(TopLeft, BottomLeft);

	public Rect(T x, T y, T w, T h)
		: this(new Vector2<T>(x, y), new Vector2<T>(w, h))
	{
	}

	public Rect(Vector2<T> size)
		: this(Vector2<T>.Zero, size)
	{
	}

	public Rect(Vector2<T> position, Vector2<T> size)
	{
		_position = position;
		_size = size;
	}

	public override bool Equals(object? obj)
	{
		if (obj is Rect<T> other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(Rect<T> other)
	{
		if (Position == other.Position)
		{
			return Size == other.Size;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return HashCodeHelper.GenerateHashCode(_position, _size);
	}

	public Rect<K> Cast<K>()
	{
		return new Rect<K>(Position.Cast<K>(), Size.Cast<K>());
	}

	public override string ToString()
	{
		return $"{{X:{Position.X},Y:{Position.Y},W:{Size.X},H:{Size.Y}}}";
	}

	public static bool operator ==(Rect<T> a, Rect<T> b)
	{
		return a.Equals(b);
	}

	public static bool operator !=(Rect<T> a, Rect<T> b)
	{
		return !a.Equals(b);
	}

	public static explicit operator Rect<T>(Rect r)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		if (!((Rect)(ref r)).IsEmpty)
		{
			return new Rect<T>((Vector2<T>)((Rect)(ref r)).TopLeft, (Vector2<T>)((Rect)(ref r)).Size);
		}
		return Empty;
	}

	public static explicit operator Rect<T>(Size s)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		return new Rect<T>((Vector2<T>)s);
	}

	public static implicit operator Rect(Rect<T> r)
	{
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		return new Rect((Point)r.TopLeft.Cast<double>(), (Point)r.BottomRight.Cast<double>());
	}

	public static explicit operator Rect<T>(RECT r)
	{
		return new Rect<T>(r.Left.Cast<T, int>(), r.Top.Cast<T, int>(), (r.Right - r.Left).Cast<T, int>(), (r.Bottom - r.Top).Cast<T, int>());
	}

	public static implicit operator RECT(Rect<T> r)
	{
		Rect<int> rect = r.Cast<int>();
		RECT result = default(RECT);
		result.Left = rect.Left;
		result.Top = rect.Top;
		result.Right = rect.Right;
		result.Bottom = rect.Bottom;
		return result;
	}
}
