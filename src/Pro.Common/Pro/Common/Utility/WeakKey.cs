using System;
using Pro.Common.Operations;

namespace Pro.Common.Utility;

public class WeakKey<T> : IEquatable<WeakKey<T>?> where T : class
{
	private readonly WeakReference<T> _weakReference;

	private readonly int _hashCode;

	public bool IsValid => _weakReference.IsValid();

	public T? Target => _weakReference.GetTarget();

	public WeakKey(T target)
	{
		_weakReference = new WeakReference<T>(target);
		_hashCode = target.GetHashCode();
	}

	public override int GetHashCode()
	{
		return _hashCode;
	}

	public override bool Equals(object? obj)
	{
		if (obj is WeakKey<T> other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(WeakKey<T>? other)
	{
		return Target.Equal<T>(((object)other != null) ? other.Target : null);
	}

	public static bool operator ==(WeakKey<T> lhs, WeakKey<T> rhs)
	{
		return lhs.NullableEquals<WeakKey<T>>(rhs);
	}

	public static bool operator !=(WeakKey<T> lhs, WeakKey<T> rhs)
	{
		return !lhs.NullableEquals<WeakKey<T>>(rhs);
	}
}
