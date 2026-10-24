using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Pro.Common.Nullability;

public static class StringExtensions
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool NullableIsNullOrEmpty([NotNullWhen(false)] this string? data)
	{
		return string.IsNullOrEmpty(data);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool NullableIsNullOrWhiteSpace([NotNullWhen(false)] this string? data)
	{
		return string.IsNullOrWhiteSpace(data);
	}
}
