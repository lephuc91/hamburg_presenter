using System;
using System.Text.Json.Serialization;

namespace Pro.Common.Serialization.Enum;

[AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
public sealed class JsonStringEnumValueAttribute : JsonAttribute
{
	public string Value { get; }

	public JsonStringEnumValueAttribute(string value)
	{
		Value = value;
	}
}
