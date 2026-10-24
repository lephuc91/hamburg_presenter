using System;
using System.Diagnostics;
using Pro.Common.Operations;
using Pro.Common.Utility;

namespace Pro.Common.Mathematics;

[DebuggerDisplay("IA: {InvertedCartesianValue}, CA: {CartesianValue} | {typeof(T).Name,nq}")]
public readonly struct Angle<T> : IEquatable<Angle<T>>
{
	private static readonly T ThreeSixty = 360.Cast<T, int>();

	public static readonly Angle<T> Zero = new Angle<T>(Constants<T>.Zero);

	private readonly T _invertedValue;

	public T Value { get; }

	public bool IsCartesian { get; }

	public T CartesianValue
	{
		get
		{
			if (!IsCartesian)
			{
				return _invertedValue;
			}
			return Value;
		}
	}

	public T InvertedCartesianValue
	{
		get
		{
			if (IsCartesian)
			{
				return _invertedValue;
			}
			return Value;
		}
	}

	public Angle(T value, bool isCartesian = false)
	{
		Value = value.Mod(ThreeSixty);
		_invertedValue = Value.Negate().Mod(ThreeSixty);
		IsCartesian = isCartesian;
	}

	public Angle(Angle<T> angle, bool isCartesian = false)
	{
		Value = (isCartesian ? angle.CartesianValue : angle.InvertedCartesianValue);
		_invertedValue = ((!isCartesian) ? angle.CartesianValue : angle.InvertedCartesianValue);
		IsCartesian = isCartesian;
	}

	public override bool Equals(object? obj)
	{
		if (obj is Angle<T> other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(Angle<T> other)
	{
		return CartesianValue.Equal(other.CartesianValue);
	}

	public override int GetHashCode()
	{
		return HashCodeHelper.GenerateHashCode(CartesianValue);
	}

	public Angle<K> Cast<K>()
	{
		return new Angle<K>(Value.Cast<K, T>(), IsCartesian);
	}

	public static Angle<T> operator +(Angle<T> lhs, Angle<T> rhs)
	{
		return new Angle<T>(lhs.CartesianValue.Add(rhs.CartesianValue), isCartesian: true);
	}

	public static Angle<T> operator -(Angle<T> lhs, Angle<T> rhs)
	{
		return new Angle<T>(lhs.CartesianValue.Subtract(rhs.CartesianValue), isCartesian: true);
	}

	public static Angle<T> operator -(Angle<T> angle)
	{
		return new Angle<T>(angle.CartesianValue.Negate(), isCartesian: true);
	}

	public static bool operator ==(Angle<T> lhs, Angle<T> rhs)
	{
		return lhs.Equals(rhs);
	}

	public static bool operator !=(Angle<T> lhs, Angle<T> rhs)
	{
		return !lhs.Equals(rhs);
	}
}
