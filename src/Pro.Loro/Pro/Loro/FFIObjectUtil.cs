using System;
using System.Collections.Generic;

namespace Pro.Loro;

internal static class FFIObjectUtil
{
	public static void DisposeAll(params object?[] list)
	{
		for (int i = 0; i < list.Length; i++)
		{
			Dispose(list[i]);
		}
	}

	private static void Dispose(dynamic? obj)
	{
		if (obj == null)
		{
			return;
		}
		if (obj is IDisposable disposable)
		{
			disposable.Dispose();
			return;
		}
		dynamic type = obj.GetType();
		if (!((type != null) ? true : false) || !(type.IsGenericType ? true : false))
		{
			return;
		}
		if (type.GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>)))
		{
			foreach (dynamic item in obj)
			{
				FFIObjectUtil.Dispose(item);
			}
			return;
		}
		if (!(type.GetGenericTypeDefinition().IsAssignableFrom(typeof(Dictionary<, >)) ? true : false))
		{
			return;
		}
		foreach (dynamic item2 in obj.Values)
		{
			FFIObjectUtil.Dispose(item2);
		}
	}
}
