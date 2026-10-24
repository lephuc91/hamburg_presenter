using System;

namespace Pro.Common.Utility;

public static class GuidExtensions
{
	public static bool IsEmpty(this Guid id)
	{
		return id == Guid.Empty;
	}

	public static Guid ToGuidOrEmpty(this string? s)
	{
		if (!Guid.TryParse(s, out var result))
		{
			return Guid.Empty;
		}
		return result;
	}
}
