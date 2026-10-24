using System;

namespace Pro.Data.SQLite;

[AttributeUsage(AttributeTargets.Property)]
public class DefaultValueAttribute : Attribute
{
	public object Value { get; }

	public DefaultValueAttribute(object value)
	{
		Value = value;
	}
}
