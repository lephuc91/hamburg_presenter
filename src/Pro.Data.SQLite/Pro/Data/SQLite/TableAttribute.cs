using System;

namespace Pro.Data.SQLite;

[AttributeUsage(AttributeTargets.Class)]
public class TableAttribute : Attribute
{
	public string TableName { get; }

	public TableAttribute(string tableName)
	{
		if (string.IsNullOrEmpty(tableName))
		{
			throw new ArgumentNullException("tableName");
		}
		TableName = tableName;
	}
}
