using System;

namespace Pro.Data.SQLite;

public static class SqliteCommandHelper
{
	public static string GetSqlType(Type type)
	{
		if (type == typeof(short) || type == typeof(int) || type == typeof(long) || type.IsEnum || type == typeof(bool) || type == typeof(uint) || type == typeof(ulong))
		{
			return "INTEGER";
		}
		if (type == typeof(float) || type == typeof(double) || type == typeof(decimal))
		{
			return "REAL";
		}
		if (type == typeof(char) || type == typeof(string) || type == typeof(Guid) || type == typeof(DateTime) || type == typeof(Guid?))
		{
			return "TEXT";
		}
		if (type == typeof(byte[]))
		{
			return "BLOB";
		}
		throw new NotSupportedException($"The Type {type} cannot be converted to a SQLite type.");
	}
}
