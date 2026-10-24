using System;
using System.Globalization;

namespace Pro.Common.Utility;

public static class BooleanExtensions
{
	public static string Encode(bool value)
	{
		return value.ToString(CultureInfo.InvariantCulture).ToLowerInvariant();
	}

	public static bool Decode(string value)
	{
		switch (value.ToLowerInvariant())
		{
		case "0":
		case "false":
			return false;
		case "1":
		case "true":
			return true;
		default:
			throw new Exception("String was not in the correct format for a boolean");
		}
	}

	public static void Then(this bool value, Action action)
	{
		if (value)
		{
			action();
		}
	}

	public static T? Then<T>(this bool value, Func<T> func)
	{
		if (!value)
		{
			return default(T);
		}
		return func();
	}
}
