using System;

namespace Pro.Data.SQLite;

[AttributeUsage(AttributeTargets.Property)]
public class PrimaryKeyAttribute : Attribute
{
	public int Order { get; }

	public PrimaryKeyAttribute()
	{
	}

	public PrimaryKeyAttribute(int order)
	{
		Order = order;
	}
}
