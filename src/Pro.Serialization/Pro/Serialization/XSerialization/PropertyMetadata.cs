using System;
using System.Collections.Generic;
using Pro.Common.Reflection;

namespace Pro.Serialization.XSerialization;

internal class PropertyMetadata
{
	public string? NameAlias { get; }

	public Type? TypeAlias { get; }

	public bool IsOptional { get; }

	public bool IsEscaped { get; }

	public bool IsNameDisplayed { get; }

	public KeyValuePair<string, string>[] StaticHeaders { get; }

	public PropertyGetter? Getter { get; }

	public PropertySetter? Setter { get; }

	public PropertyMetadata(string? nameAlias, Type? typeAlias, bool isOptional, bool isEscaped, bool isNameDisplayed, KeyValuePair<string, string>[] staticHeaders, PropertyGetter? getter, PropertySetter? setter)
	{
		NameAlias = nameAlias;
		TypeAlias = typeAlias;
		IsOptional = isOptional;
		IsEscaped = isEscaped;
		IsNameDisplayed = isNameDisplayed;
		StaticHeaders = staticHeaders;
		Getter = getter;
		Setter = setter;
	}
}
