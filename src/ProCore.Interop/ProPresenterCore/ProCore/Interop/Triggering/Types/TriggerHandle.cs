using System;
using Pro.Common.Utility;

namespace ProPresenterCore.ProCore.Interop.Triggering.Types;

public sealed class TriggerHandle : IEquatable<TriggerHandle>
{
	public static readonly TriggerHandle Invalid = new TriggerHandle(0uL);

	public ulong RawValue { get; }

	public TriggerHandle(ulong value)
	{
		RawValue = value;
	}

	public override int GetHashCode()
	{
		return RawValue.GetHashCode();
	}

	public override bool Equals(object? obj)
	{
		if (obj is TriggerHandle other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(TriggerHandle? other)
	{
		if ((object)other != null)
		{
			return RawValue == other.RawValue;
		}
		return false;
	}

	public static bool operator ==(TriggerHandle? lhs, TriggerHandle? rhs)
	{
		return lhs.NullableEquals(rhs);
	}

	public static bool operator !=(TriggerHandle? lhs, TriggerHandle? rhs)
	{
		if ((object)lhs == null)
		{
			return false;
		}
		return !lhs.NullableEquals(rhs);
	}
}
