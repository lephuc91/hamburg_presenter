using System;
using Microsoft.Data.Sqlite;
using Pro.Common.Extensions;

namespace Pro.Data.SQLite;

public sealed class ColumnSchema
{
	public long ColumnID { get; }

	public object DefaultValue { get; }

	public bool IsNotNull { get; }

	public bool IsPrimaryKey { get; }

	public string Name { get; }

	public Type Type { get; private set; }

	public ColumnSchema(SqliteDataReader reader)
	{
		ColumnID = (long)reader.GetValue(0);
		Name = (string)reader.GetValue(1);
		Type = ParseType((string)reader.GetValue(2));
		IsNotNull = ((long)reader.GetValue(3)).TypeConversionCast<bool>();
		DefaultValue = reader.GetValue(4);
		IsPrimaryKey = ((long)reader.GetValue(5)).TypeConversionCast<bool>();
	}

	public ColumnSchema(long columnID, string name, Type type, bool isNotNull, object defaultValue, bool isPrimaryKey)
	{
		ColumnID = columnID;
		Name = name;
		Type = type;
		IsNotNull = isNotNull;
		DefaultValue = defaultValue;
		IsPrimaryKey = isPrimaryKey;
	}

	public bool Equals(Column column)
	{
		if (column.Name != Name)
		{
			return false;
		}
		return CheckTypeCompatibility(column.Type);
	}

	public static Type ParseType(string type)
	{
		if (string.Compare(type, "INTEGER", StringComparison.InvariantCultureIgnoreCase) == 0)
		{
			return typeof(long);
		}
		if (string.Compare(type, "REAL", StringComparison.InvariantCultureIgnoreCase) == 0)
		{
			return typeof(double);
		}
		if (string.Compare(type, "BLOB", StringComparison.InvariantCultureIgnoreCase) == 0)
		{
			return typeof(byte[]);
		}
		if (string.Compare(type, "TEXT", StringComparison.InvariantCultureIgnoreCase) == 0)
		{
			return typeof(string);
		}
		if (type.IndexOf("TEXT", StringComparison.InvariantCultureIgnoreCase) == 0)
		{
			return typeof(string);
		}
		if (string.Compare(type, "VARCHAR", StringComparison.InvariantCultureIgnoreCase) == 0)
		{
			return typeof(string);
		}
		if (type.IndexOf("VARCHAR", StringComparison.InvariantCultureIgnoreCase) == 0)
		{
			return typeof(string);
		}
		if (string.Compare(type, "FLOAT", StringComparison.InvariantCultureIgnoreCase) == 0)
		{
			return typeof(float);
		}
		throw new DatabaseException("The type " + type + " is not supported.");
	}

	internal bool CheckTypeCompatibility(Type type)
	{
		if (type == Type)
		{
			return true;
		}
		if (type.IsEnum && Type == typeof(long))
		{
			return true;
		}
		if (type == typeof(Guid) && Type == typeof(string))
		{
			return true;
		}
		if ((type == typeof(int) || type == typeof(long) || type == typeof(uint) || type == typeof(ulong) || type == typeof(bool)) && Type == typeof(long))
		{
			return true;
		}
		if ((type == typeof(float) || type == typeof(double)) && Type == typeof(double))
		{
			return true;
		}
		if (type == typeof(DateTime) && Type == typeof(string))
		{
			return true;
		}
		return false;
	}
}
