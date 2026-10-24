using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Pro.Common.Nullability;

public static class ObjectExtensions
{
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void ThrowWhenNull([NotNull] this object? obj, [CallerArgumentExpression("obj")] string? paramName = null)
	{
	}
}
