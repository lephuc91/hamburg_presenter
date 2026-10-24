using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Pro.Common.Nullability;

namespace ProPresenter.DO.Themes;

public static class TemplateMappingHelper
{
	public static IEnumerable<string?> GetTemplateMappingNames<TEnum>(this IEnumerable<TEnum> value) where TEnum : Enum
	{
		return from v in value
			select v.GetTemplateMapping()?.Name into v
			where v != null
			select v;
	}

	public static IEnumerable<string> GetTemplateMappingTokens<TEnum>(this IEnumerable<TEnum> value) where TEnum : Enum
	{
		return from v in value
			select v.GetTemplateMapping() into v
			where v?.IsCustomToken ?? false
			select v into x
			select x?.Name ?? string.Empty;
	}

	public static TemplateMappingAttribute? GetTemplateMapping<TEnum>(this TEnum value) where TEnum : Enum
	{
		return value.GetType().GetField(value.ToString())?.GetCustomAttributes(typeof(TemplateMappingAttribute), inherit: false)?.Cast<TemplateMappingAttribute>().FirstOrDefault();
	}

	public static TEnum? GetEnumValueFromMapping<TEnum>(string description) where TEnum : Enum
	{
		FieldInfo[] fields = typeof(TEnum).GetFields();
		foreach (FieldInfo fieldInfo in fields)
		{
			TemplateMappingAttribute templateMappingAttribute = Attribute.GetCustomAttribute(fieldInfo, typeof(TemplateMappingAttribute)) as TemplateMappingAttribute;
			if ((!(templateMappingAttribute?.Name).NullableIsNullOrEmpty() && templateMappingAttribute.Name == description) || fieldInfo.Name == description)
			{
				return (TEnum)fieldInfo.GetValue(null);
			}
		}
		return default(TEnum);
	}
}
