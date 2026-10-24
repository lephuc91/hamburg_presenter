using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Data.Sqlite;
using Pro.Common.Nullability;

namespace Pro.Data.SQLite;

public class QueryResult
{
	private readonly Dictionary<string, Tuple<Type, object>> _values = new Dictionary<string, Tuple<Type, object>>();

	public Type EntityType { get; }

	public object this[string columnName] => _values[columnName].Item2;

	public object? this[int index]
	{
		get
		{
			if (!_values.Any())
			{
				return null;
			}
			return _values.ToList()[index].Value.Item2;
		}
	}

	public QueryResult(SqliteDataReader reader)
		: this(reader, typeof(object))
	{
	}

	public QueryResult(SqliteDataReader reader, Type entityType)
	{
		for (int i = 0; i < reader.FieldCount; i++)
		{
			_values.Add(reader.GetName(i), new Tuple<Type, object>(reader.GetFieldType(i), reader.GetValue(i)));
		}
		EntityType = entityType;
	}

	public object AsEntity()
	{
		object obj = Activator.CreateInstance(EntityType);
		obj.ThrowWhenNull("entity");
		foreach (KeyValuePair<string, Tuple<Type, object>> value in _values)
		{
			PropertyInfo property = EntityType.GetProperty(value.Key);
			if (property != null)
			{
				if (!property.PropertyType.IsAssignableFrom(value.Value.Item1))
				{
					throw new InvalidCastException($"The column type {property.PropertyType} is not assignable from the type {value.Value.Item1}.");
				}
				property.SetValue(obj, value.Value.Item2);
				continue;
			}
			FieldInfo field = EntityType.GetField(value.Key);
			if (field != null)
			{
				if (!field.FieldType.IsAssignableFrom(value.Value.Item1))
				{
					throw new InvalidCastException($"The column type {field.FieldType} is not assignable from the type {value.Value.Item1}.");
				}
				field.SetValue(obj, value.Value.Item2);
				continue;
			}
			throw new MissingMemberException($"The entity type {EntityType} does not have a member named '{value.Key}'.");
		}
		return obj;
	}

	public T? GetValue<T>()
	{
		return GetValue<T>(0);
	}

	public T? GetValue<T>(int index)
	{
		object obj = this[index];
		if (obj is T)
		{
			return (T)obj;
		}
		return default(T);
	}

	public IEnumerable<T> ToList<T>()
	{
		return _values.Select<KeyValuePair<string, Tuple<Type, object>>, Tuple<Type, object>>((KeyValuePair<string, Tuple<Type, object>> kvp) => kvp.Value).OfType<T>().ToList();
	}
}
