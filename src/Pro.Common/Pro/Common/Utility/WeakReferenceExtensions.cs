using System;

namespace Pro.Common.Utility;

public static class WeakReferenceExtensions
{
	public static T? GetTarget<T>(this WeakReference<T> reference) where T : class
	{
		T target = null;
		if (reference == null || !reference.TryGetTarget(out target))
		{
			return null;
		}
		return target;
	}

	public static bool IsValid<T>(this WeakReference<T> reference) where T : class
	{
		T target;
		return reference?.TryGetTarget(out target) ?? false;
	}
}
