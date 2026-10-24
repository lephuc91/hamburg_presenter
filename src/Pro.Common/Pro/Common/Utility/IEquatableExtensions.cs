using System;

namespace Pro.Common.Utility;

public static class IEquatableExtensions
{
	public static bool NullableEquals<T>(this T? lhs, T? rhs) where T : class, IEquatable<T>
	{
		return lhs.NullableEquals(rhs, (T lhs, T rhs) => lhs.Equals(rhs));
	}

	public static bool NullableEquals<T>(this T? lhs, T? rhs, Func<T, T, bool> comparison) where T : class
	{
		if (lhs == null || rhs == null)
		{
			return lhs == rhs;
		}
		return comparison(lhs, rhs);
	}
}
