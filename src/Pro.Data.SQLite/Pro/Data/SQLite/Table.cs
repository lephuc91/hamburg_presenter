using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.Data.Sqlite;
using Pro.Common.Nullability;

namespace Pro.Data.SQLite;

public abstract class Table : ITable, ITableInternal
{
	public List<Column> Columns { get; private set; }

	public IDatabase Database { get; private set; }

	public Type EntityType { get; }

	public string Name { get; private set; }

	protected Table(Type entityType, IDatabase database)
	{
		EntityType = entityType;
		Database = database;
		Name = GetTableName(entityType);
		Columns = InitializeColumns(entityType);
	}

	public int CopyTo(ITable table)
	{
		if (!table.GetSchema().Equals(this))
		{
			throw new InvalidOperationException($"The table {table.Name} is not equivalent to this table {Name}.");
		}
		SqliteCommand sqliteCommand = Database.Connection.CreateCommand();
		try
		{
			((IDatabaseInternal)Database).ValidateQuery("Table.CopyTo");
			bool flag = false;
			if (table.Database == Database)
			{
				sqliteCommand.CommandText = $"INSERT OR REPLACE INTO {table.Name} {((ITableInternal)table).GenerateColumnsList(wrapInParenthesis: true, addColumnInfo: false)} SELECT {((ITableInternal)this).GenerateColumnsList(wrapInParenthesis: false, addColumnInfo: false)} FROM {Name}";
			}
			else
			{
				sqliteCommand.CommandText = $"INSERT OR REPLACE INTO {table.Database.Alias}.{table.Name} {((ITableInternal)table).GenerateColumnsList(wrapInParenthesis: true, addColumnInfo: false)} SELECT {((ITableInternal)this).GenerateColumnsList(wrapInParenthesis: false, addColumnInfo: false)} FROM {Name}";
				if (!Database.TableExists(table.Database.Alias ?? ""))
				{
					Database.Attach(table.Database);
					flag = true;
				}
			}
			int result = sqliteCommand.ExecuteNonQuery();
			if (flag)
			{
				Database.Detach(table.Database);
			}
			return result;
		}
		catch (Exception innerException)
		{
			throw CreateDatabaseMethodException(innerException, "CopyTo");
		}
		finally
		{
			((IDatabaseInternal)Database).FinalizeQuery("Table.CopyTo");
			sqliteCommand.Dispose();
		}
	}

	public static Table Create(Type entityType, IDatabase database)
	{
		Table obj = Activator.CreateInstance(typeof(Table<>).MakeGenericType(entityType), database) as Table;
		obj.ThrowWhenNull("result");
		return obj;
	}

	public string? GetColumnNameFor(string propertyName)
	{
		return Columns.FirstOrDefault((Column c) => c.Name == propertyName)?.Name;
	}

	public TableSchema GetSchema(bool suppressCloseDatabase = false)
	{
		SqliteCommand sqliteCommand = Database.Connection.CreateCommand();
		try
		{
			((IDatabaseInternal)Database).ValidateQuery("Table.GetSchema");
			if (!Database.TableExists(Name))
			{
				throw new DatabaseException("Table with name " + Name + " was not found");
			}
			TableSchema tableSchema = new TableSchema(Name);
			StringBuilder stringBuilder = new StringBuilder();
			StringBuilder stringBuilder2 = stringBuilder;
			StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(19, 1, stringBuilder2);
			handler.AppendLiteral("PRAGMA table_info(");
			handler.AppendFormatted(Name);
			handler.AppendLiteral(")");
			stringBuilder2.Append(ref handler);
			sqliteCommand.CommandText = stringBuilder.ToString();
			SqliteDataReader sqliteDataReader = sqliteCommand.ExecuteReader();
			while (sqliteDataReader.Read())
			{
				tableSchema.AddColumn(new ColumnSchema(sqliteDataReader));
			}
			return tableSchema;
		}
		catch (Exception ex)
		{
			if (!(ex is DatabaseException))
			{
				throw;
			}
			throw new DatabaseException("There was an error executing the GetSchema method.", ex);
		}
		finally
		{
			((IDatabaseInternal)Database).FinalizeQuery("Table.GetSchema");
			sqliteCommand.Dispose();
		}
	}

	public void SynchronizeWith(ITable source)
	{
		if (source.EntityType != EntityType)
		{
			throw new InvalidOperationException($"The table information entity type {EntityType} does not match the entity type {source.EntityType} to synchronize with.");
		}
		Name = source.Name;
		Columns = source.Columns;
		Database = source.Database;
	}

	internal static string GetTableName(Type type)
	{
		TableAttribute customAttribute = type.GetCustomAttribute<TableAttribute>();
		if (customAttribute == null)
		{
			return type.Name;
		}
		return customAttribute.TableName;
	}

	string ITableInternal.GenerateColumnsList(bool wrapInParenthesis, bool addColumnInfo)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (wrapInParenthesis)
		{
			stringBuilder.Append("(");
		}
		for (int i = 0; i < Columns.Count; i++)
		{
			Column column = Columns[i];
			StringBuilder stringBuilder2 = stringBuilder;
			StringBuilder stringBuilder3 = stringBuilder2;
			StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(0, 1, stringBuilder2);
			handler.AppendFormatted(column.Name);
			stringBuilder3.Append(ref handler);
			if (addColumnInfo)
			{
				stringBuilder2 = stringBuilder;
				StringBuilder stringBuilder4 = stringBuilder2;
				handler = new StringBuilder.AppendInterpolatedStringHandler(1, 1, stringBuilder2);
				handler.AppendLiteral(" ");
				handler.AppendFormatted(SqliteCommandHelper.GetSqlType(column.Type));
				stringBuilder4.Append(ref handler);
				if (column.IsPrimaryKey)
				{
					stringBuilder.Append(" PRIMARY KEY");
				}
				if (column.IsUnique)
				{
					stringBuilder.Append(" UNIQUE");
				}
				if (column.IsNotNull)
				{
					stringBuilder.Append(" NOT NULL");
				}
				if (column.HasDefaultValue)
				{
					stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder5 = stringBuilder2;
					handler = new StringBuilder.AppendInterpolatedStringHandler(9, 1, stringBuilder2);
					handler.AppendLiteral(" DEFAULT ");
					handler.AppendFormatted<object>(column.DefaultValue);
					stringBuilder5.Append(ref handler);
				}
			}
			if (i < Columns.Count - 1)
			{
				stringBuilder.Append(", ");
			}
		}
		if (wrapInParenthesis)
		{
			stringBuilder.Append(")");
		}
		return stringBuilder.ToString();
	}

	string ITableInternal.GeneratePrimaryKeyExpression(List<object> primaryKeys)
	{
		StringBuilder stringBuilder = new StringBuilder();
		List<Column> list = (from c in Columns
			where c.IsPrimaryKey
			orderby c.PrimaryKeyOrder
			select c).ToList();
		if (list.Count != primaryKeys.Count)
		{
			throw new InvalidOperationException("The number of supplied primary keys does not match the entity schema.");
		}
		for (int i = 0; i < list.Count; i++)
		{
			Column column = list[i];
			StringBuilder stringBuilder2 = stringBuilder;
			StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(3, 2, stringBuilder2);
			handler.AppendFormatted(column.Name);
			handler.AppendLiteral(" = ");
			handler.AppendFormatted(column.FormatValueString(primaryKeys[i]));
			stringBuilder2.Append(ref handler);
			if (i < list.Count - 1)
			{
				stringBuilder.Append(" AND ");
			}
		}
		return stringBuilder.ToString();
	}

	string ITableInternal.GeneratePrimaryKeyNameList()
	{
		StringBuilder stringBuilder = new StringBuilder();
		List<Column> list = (from c in Columns
			where c.IsPrimaryKey
			orderby c.PrimaryKeyOrder
			select c).ToList();
		for (int i = 0; i < list.Count; i++)
		{
			Column column = list[i];
			StringBuilder stringBuilder2 = stringBuilder;
			StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(0, 1, stringBuilder2);
			handler.AppendFormatted(column.Name);
			stringBuilder2.Append(ref handler);
			if (i < list.Count - 1)
			{
				stringBuilder.Append(", ");
			}
		}
		return stringBuilder.ToString();
	}

	string ITableInternal.GenerateSetValuesList(object entity)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("SET ");
		for (int i = 0; i < Columns.Count; i++)
		{
			Column column = Columns[i];
			object value = column.FormatValueString(column.PropertyInfo.GetValue(entity));
			StringBuilder stringBuilder2 = stringBuilder;
			StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(3, 2, stringBuilder2);
			handler.AppendFormatted(column.Name);
			handler.AppendLiteral(" = ");
			handler.AppendFormatted<object>(value);
			stringBuilder2.Append(ref handler);
			if (i < Columns.Count - 1)
			{
				stringBuilder.Append(", ");
			}
		}
		return stringBuilder.ToString();
	}

	string ITableInternal.GenerateValuesList(object entity)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("VALUES (");
		for (int i = 0; i < Columns.Count; i++)
		{
			Column column = Columns[i];
			object value = column.FormatValueString(column.PropertyInfo.GetValue(entity));
			stringBuilder.Append(value);
			if (i < Columns.Count - 1)
			{
				stringBuilder.Append(", ");
			}
		}
		stringBuilder.Append(")");
		return stringBuilder.ToString();
	}

	string ITableInternal.GenerateWherePrimaryKey(List<object> primaryKeys)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("WHERE ");
		stringBuilder.Append(((ITableInternal)this).GeneratePrimaryKeyExpression(primaryKeys));
		return stringBuilder.ToString();
	}

	string ITableInternal.GenerateWherePrimaryKey(object entity)
	{
		List<Column> source = (from c in Columns
			where c.IsPrimaryKey
			orderby c.PrimaryKeyOrder
			select c).ToList();
		return ((ITableInternal)this).GenerateWherePrimaryKey(source.Select((Column c) => c.PropertyInfo.GetValue(entity)).ToList());
	}

	private static List<Column> InitializeColumns(Type type)
	{
		List<Column> list = new List<Column>();
		PropertyInfo[] properties = type.GetProperties();
		foreach (PropertyInfo propertyInfo in properties)
		{
			if (propertyInfo.GetCustomAttribute<IgnoreAttribute>() == null)
			{
				Column column = new Column(propertyInfo);
				if (column.IsEntityName && list.Any((Column col) => col.IsEntityName))
				{
					throw new InvalidOperationException("The table cannot contain more then one EntityName column.");
				}
				list.Add(column);
			}
		}
		if (!list.Any())
		{
			throw new InvalidOperationException($"The Type {type} has no columns defined.");
		}
		return (from c in list
			orderby c.Order, c.PrimaryKeyOrder, c.Name
			select c).ToList();
	}

	private Exception CreateDatabaseMethodException(Exception innerException, [CallerMemberName] string? memberName = null)
	{
		if (innerException == null)
		{
			return new ArgumentNullException("innerException");
		}
		if (innerException is DatabaseException)
		{
			return innerException;
		}
		return new DatabaseException("There was an error executing the " + memberName + " method.", innerException);
	}
}
public class Table<TEntity> : Table
{
	public Table(IDatabase database)
		: base(typeof(TEntity), database)
	{
	}

	public IEnumerable<TEntity> ExecuteQuery(string commandText)
	{
		return base.Database.ExecuteQuery<TEntity>(commandText);
	}
}
