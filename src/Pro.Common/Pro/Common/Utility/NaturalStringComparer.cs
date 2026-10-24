using System;
using System.Collections;
using System.Collections.Generic;
using Pro.Common.Win32;

namespace Pro.Common.Utility;

public class NaturalStringComparer : IComparer<string>
{
	public int Compare(string? x, string? y)
	{
		return WindowsFunctions.StrCmpLogicalW(x ?? string.Empty, y ?? string.Empty);
	}
}
public class NaturalStringComparer<T> : IComparer, IComparer<T>
{
	private readonly Func<T?, string?> _convert;

	public NaturalStringComparer(Func<T?, string?> convert)
	{
		_convert = convert;
	}

	public int Compare(T? x, T? y)
	{
		return WindowsFunctions.StrCmpLogicalW(convert(x), convert(y));
		string convert(T? v)
		{
			return _convert(v) ?? string.Empty;
		}
	}

	public int Compare(object? x, object? y)
	{
		return Compare((T)x, (T)y);
	}
}
