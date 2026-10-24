using System;
using Pro.Common.Utility;

namespace Pro.Common.Reflection;

public class PropertyKey : IEquatable<PropertyKey?>
{
	public Type OwnerType { get; }

	public string PropertyName { get; }

	internal PropertyKey(Type ownerType, string propertyName)
	{
		OwnerType = ownerType;
		PropertyName = propertyName;
	}

	public override int GetHashCode()
	{
		return HashCodeHelper.GenerateHashCode(OwnerType, PropertyName);
	}

	public override bool Equals(object? obj)
	{
		if (obj is PropertyKey other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(PropertyKey? other)
	{
		if (OwnerType == other?.OwnerType)
		{
			return PropertyName == other.PropertyName;
		}
		return false;
	}

	public static bool operator ==(PropertyKey lhs, PropertyKey rhs)
	{
		return lhs.NullableEquals<PropertyKey>(rhs);
	}

	public static bool operator !=(PropertyKey lhs, PropertyKey rhs)
	{
		return !lhs.NullableEquals<PropertyKey>(rhs);
	}
}
