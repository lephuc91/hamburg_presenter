using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using Pro.Common.Operations;

namespace Pro.Common.Utility;

public static class EnumExtensions
{
	public static IEnumerable<string> GetDescriptions<TEnum>(this IEnumerable<TEnum> value) where TEnum : Enum
	{
		return from v in value
			select v.GetEnumDescription() into v
			where v != null
			select v;
	}

	public static string GetEnumDescription<TEnum>(this TEnum value) where TEnum : Enum
	{
		return value.GetAttribute<TEnum, DescriptionAttribute>()?.Description ?? value.ToString();
	}

	public static string GetEnumMemberValue<TEnum>(this TEnum value) where TEnum : Enum
	{
		return value.GetAttribute<TEnum, EnumMemberAttribute>()?.Value ?? value.ToString();
	}

	public static IEnumerable<TAttribute> GetAttributes<TEnum, TAttribute>(this TEnum value) where TEnum : Enum where TAttribute : Attribute
	{
		return value.GetType().GetField(value.ToString())?.GetCustomAttributes<TAttribute>() ?? Enumerable.Empty<TAttribute>();
	}

	public static TAttribute? GetAttribute<TEnum, TAttribute>(this TEnum value) where TEnum : Enum where TAttribute : Attribute
	{
		return value.GetAttributes<TEnum, TAttribute>().FirstOrDefault();
	}

	public static bool AnyFlags<TEnum>(this TEnum value, TEnum flags)
	{
		return (value.Cast<ulong, TEnum>() & flags.Cast<ulong, TEnum>()) != 0;
	}
}
