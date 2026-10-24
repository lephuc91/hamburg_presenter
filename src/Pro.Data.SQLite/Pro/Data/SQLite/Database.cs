using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.Data.Sqlite;
using Pro.Common.Extensions;
using Pro.Common.Nullability;

namespace Pro.Data.SQLite;

public class Database : IDatabase, IDatabaseInternal
{
	[CompilerGenerated]
	private sealed class _003CProcessSelectMany_003Ed__62 : IEnumerable<object>, IEnumerable, IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public Database _003C_003E4__this;

		private Type entityType;

		public Type _003C_003E3__entityType;

		private object[] primaryKeys;

		public object[] _003C_003E3__primaryKeys;

		private ITable _003Ctable_003E5__2;

		private SqliteDataReader _003Creader_003E5__3;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CProcessSelectMany_003Ed__62(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
			_003C_003El__initialThreadId = Environment.CurrentManagedThreadId;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			_003Ctable_003E5__2 = null;
			_003Creader_003E5__3 = null;
			_003C_003E1__state = -2;
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			Database database = _003C_003E4__this;
			if (num != 0)
			{
				if (num != 1)
				{
					return false;
				}
				_003C_003E1__state = -1;
			}
			else
			{
				_003C_003E1__state = -1;
				if (!database._tables.ContainsKey(entityType))
				{
					return false;
				}
				SqliteCommand sqliteCommand = database.Connection.CreateCommand();
				_003Ctable_003E5__2 = database._tables[entityType];
				sqliteCommand.CommandText = $"SELECT {((ITableInternal)_003Ctable_003E5__2).GenerateColumnsList(wrapInParenthesis: false, addColumnInfo: false)} FROM {_003Ctable_003E5__2.Name} {((ITableInternal)_003Ctable_003E5__2).GenerateWherePrimaryKey(primaryKeys.ToList())}";
				_003Creader_003E5__3 = sqliteCommand.ExecuteReader();
				if (!_003Creader_003E5__3.HasRows)
				{
					goto IL_013c;
				}
			}
			if (_003Creader_003E5__3.Read())
			{
				_003C_003E2__current = database.ReadRow(entityType, _003Creader_003E5__3, _003Ctable_003E5__2.Columns);
				_003C_003E1__state = 1;
				return true;
			}
			goto IL_013c;
			IL_013c:
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		IEnumerator<object> IEnumerable<object>.GetEnumerator()
		{
			_003CProcessSelectMany_003Ed__62 _003CProcessSelectMany_003Ed__;
			if (_003C_003E1__state == -2 && _003C_003El__initialThreadId == Environment.CurrentManagedThreadId)
			{
				_003C_003E1__state = 0;
				_003CProcessSelectMany_003Ed__ = this;
			}
			else
			{
				_003CProcessSelectMany_003Ed__ = new _003CProcessSelectMany_003Ed__62(0)
				{
					_003C_003E4__this = _003C_003E4__this
				};
			}
			_003CProcessSelectMany_003Ed__.entityType = _003C_003E3__entityType;
			_003CProcessSelectMany_003Ed__.primaryKeys = _003C_003E3__primaryKeys;
			return _003CProcessSelectMany_003Ed__;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<object>)this).GetEnumerator();
		}
	}

	private const string UPDATE_TABLE_POST_FIX = "_old";

	private readonly ConcurrentDictionary<Type, ITable> _tables = new ConcurrentDictionary<Type, ITable>();

	private SqliteTransaction? _transaction;

	public string Alias { get; }

	public SqliteConnection Connection { get; }

	public bool IsOpen { get; private set; }

	public string Path { get; }

	public Database(string path, string alias)
	{
		if (string.IsNullOrEmpty(path))
		{
			throw new ArgumentNullException("path");
		}
		if (string.IsNullOrEmpty(alias))
		{
			throw new ArgumentNullException("alias");
		}
		Path = path;
		Alias = alias;
		InitializePath(path);
		SqliteConnectionStringBuilder sqliteConnectionStringBuilder = new SqliteConnectionStringBuilder
		{
			DataSource = Path,
			Mode = SqliteOpenMode.ReadWriteCreate,
			Cache = SqliteCacheMode.Default,
			ForeignKeys = true
		};
		Connection = new SqliteConnection(sqliteConnectionStringBuilder.ConnectionString);
	}

	public int Attach(string path, string alias)
	{
		if (string.IsNullOrEmpty(path))
		{
			throw new ArgumentNullException("path");
		}
		if (string.IsNullOrEmpty(alias))
		{
			throw new ArgumentNullException("alias");
		}
		SqliteCommand sqliteCommand = Connection.CreateCommand();
		try
		{
			((IDatabaseInternal)this).ValidateQuery("Attach");
			sqliteCommand.CommandText = "ATTACH DATABASE '" + path + "' AS " + alias;
			return sqliteCommand.ExecuteNonQuery();
		}
		catch (Exception innerException)
		{
			throw CreateDatabaseMethodException(innerException, "Attach");
		}
		finally
		{
			((IDatabaseInternal)this).FinalizeQuery("Attach");
			sqliteCommand.Dispose();
		}
	}

	public int Attach(IDatabase database)
	{
		if (database == null)
		{
			throw new ArgumentNullException("database");
		}
		return Attach(database.Path, database.Alias);
	}

	public void Close()
	{
		if (IsOpen)
		{
			Connection.Close();
			IsOpen = false;
		}
	}

	public int Count(Type entityType)
	{
		if (entityType == null)
		{
			throw new ArgumentNullException("entityType");
		}
		SqliteCommand sqliteCommand = Connection.CreateCommand();
		try
		{
			((IDatabaseInternal)this).ValidateQuery("Count");
			string tableName = Table.GetTableName(entityType);
			if (TableExists(tableName))
			{
				sqliteCommand.CommandText = "SELECT COUNT(*) FROM " + tableName;
				return sqliteCommand.ExecuteNonQuery();
			}
			return 0;
		}
		catch (Exception innerException)
		{
			throw CreateDatabaseMethodException(innerException, "Count");
		}
		finally
		{
			((IDatabaseInternal)this).FinalizeQuery("Count");
			sqliteCommand.Dispose();
		}
	}

	public int Count<TEntity>()
	{
		return Count(typeof(TEntity));
	}

	public int CreateOrUpdateTable(Type entityType)
	{
		if (entityType == null)
		{
			throw new ArgumentNullException("entityType");
		}
		SqliteCommand sqliteCommand = Connection.CreateCommand();
		SqliteCommand sqliteCommand2 = Connection.CreateCommand();
		SqliteCommand sqliteCommand3 = Connection.CreateCommand();
		try
		{
			((IDatabaseInternal)this).ValidateQuery("CreateOrUpdateTable");
			Table table = Table.Create(entityType, this);
			string text = table.Name + "__old";
			if (TableExists(text))
			{
				sqliteCommand.CommandText = "DROP TABLE IF EXISTS " + text;
				sqliteCommand.ExecuteNonQuery();
			}
			if (!TableExists(table.Name))
			{
				return CreateTable(entityType);
			}
			_tables.AddOrUpdate(entityType, table, (Type t, ITable i) => table);
			TableSchema schema = table.GetSchema(suppressCloseDatabase: true);
			if (schema.Equals(table))
			{
				return 0;
			}
			sqliteCommand2.CommandText = "ALTER TABLE " + table.Name + " RENAME TO " + text;
			sqliteCommand2.ExecuteNonQuery();
			CreateTable(entityType);
			sqliteCommand3.CommandText = $"INSERT INTO {table.Name} {schema.GenerateColumnsList()} SELECT {schema.GenerateColumnsList(wrapInParenthesis: false)} FROM {text}";
			sqliteCommand3.ExecuteNonQuery();
			if (TableExists(text))
			{
				sqliteCommand.CommandText = "DROP TABLE IF EXISTS " + text;
				sqliteCommand.ExecuteNonQuery();
			}
			return 1;
		}
		catch (Exception innerException)
		{
			throw CreateDatabaseMethodException(innerException, "CreateOrUpdateTable");
		}
		finally
		{
			((IDatabaseInternal)this).FinalizeQuery("CreateOrUpdateTable");
			sqliteCommand.Dispose();
			sqliteCommand2.Dispose();
			sqliteCommand3.Dispose();
		}
	}

	public int CreateOrUpdateTable<TEntity>()
	{
		return CreateOrUpdateTable(typeof(TEntity));
	}

	public int CreateTable<TEntity>()
	{
		return CreateTable(typeof(TEntity));
	}

	public int CreateTable(Type entityType)
	{
		if (entityType == null)
		{
			throw new ArgumentNullException("entityType");
		}
		SqliteCommand sqliteCommand = Connection.CreateCommand();
		try
		{
			((IDatabaseInternal)this).ValidateQuery("CreateTable");
			ITable table = Table.Create(entityType, this);
			if (!TableExists(table.Name))
			{
				sqliteCommand.CommandText = "CREATE TABLE " + table.Name + " " + ((ITableInternal)table).GenerateColumnsList(wrapInParenthesis: true, addColumnInfo: true);
				return sqliteCommand.ExecuteNonQuery();
			}
			_tables.AddOrUpdate(entityType, table, (Type t, ITable i) => table);
			return 0;
		}
		catch (Exception innerException)
		{
			throw CreateDatabaseMethodException(innerException, "CreateTable");
		}
		finally
		{
			((IDatabaseInternal)this).FinalizeQuery("CreateTable");
			sqliteCommand.Dispose();
		}
	}

	public int CreateTableIfNotExists<TEntity>()
	{
		return CreateTableIfNotExists(typeof(TEntity));
	}

	public int CreateTableIfNotExists(Type entityType)
	{
		if (entityType == null)
		{
			throw new ArgumentNullException("entityType");
		}
		SqliteCommand sqliteCommand = Connection.CreateCommand();
		try
		{
			((IDatabaseInternal)this).ValidateQuery("CreateTableIfNotExists");
			ITable table = Table.Create(entityType, this);
			if (!TableExists(table.Name))
			{
				sqliteCommand.CommandText = "CREATE TABLE IF NOT EXISTS " + table.Name + " " + ((ITableInternal)table).GenerateColumnsList(wrapInParenthesis: true, addColumnInfo: true);
				return sqliteCommand.ExecuteNonQuery();
			}
			_tables.AddOrUpdate(entityType, table, (Type t, ITable i) => table);
			return 0;
		}
		catch (Exception innerException)
		{
			throw CreateDatabaseMethodException(innerException, "CreateTableIfNotExists");
		}
		finally
		{
			((IDatabaseInternal)this).FinalizeQuery("CreateTableIfNotExists");
			sqliteCommand.Dispose();
		}
	}

	public int Delete(object entity)
	{
		SqliteCommand sqliteCommand = Connection.CreateCommand();
		try
		{
			((IDatabaseInternal)this).ValidateQuery("Delete");
			Type type = entity.GetType();
			ITable table = null;
			if (_tables.ContainsKey(type))
			{
				table = _tables[type];
			}
			if (table != null && TableExists(table.Name))
			{
				sqliteCommand.CommandText = "DELETE FROM " + table.Name + " " + ((ITableInternal)table).GenerateWherePrimaryKey(entity);
				return sqliteCommand.ExecuteNonQuery();
			}
			return 0;
		}
		catch (Exception innerException)
		{
			throw CreateDatabaseMethodException(innerException, "Delete");
		}
		finally
		{
			((IDatabaseInternal)this).FinalizeQuery("Delete");
			sqliteCommand.Dispose();
		}
	}

	public int Detach(string alias)
	{
		if (string.IsNullOrEmpty(alias))
		{
			throw new ArgumentNullException("alias");
		}
		SqliteCommand sqliteCommand = Connection.CreateCommand();
		try
		{
			((IDatabaseInternal)this).ValidateQuery("Detach");
			sqliteCommand.CommandText = "DETACH DATABASE '" + alias + "'";
			return sqliteCommand.ExecuteNonQuery();
		}
		catch (Exception innerException)
		{
			throw CreateDatabaseMethodException(innerException, "Detach");
		}
		finally
		{
			((IDatabaseInternal)this).FinalizeQuery("Detach");
			sqliteCommand.Dispose();
		}
	}

	public int Detach(IDatabase database)
	{
		if (database == null)
		{
			throw new ArgumentNullException("database");
		}
		return Detach(database.Alias);
	}

	public int DropTable(Type entityType)
	{
		if (entityType == null)
		{
			throw new ArgumentNullException("entityType");
		}
		SqliteCommand sqliteCommand = Connection.CreateCommand();
		try
		{
			((IDatabaseInternal)this).ValidateQuery("DropTable");
			string tableName = Table.GetTableName(entityType);
			if (TableExists(tableName))
			{
				sqliteCommand.CommandText = "DROP TABLE IF EXISTS " + tableName;
				return sqliteCommand.ExecuteNonQuery();
			}
			return 0;
		}
		catch (Exception innerException)
		{
			throw CreateDatabaseMethodException(innerException, "DropTable");
		}
		finally
		{
			((IDatabaseInternal)this).FinalizeQuery("DropTable");
			sqliteCommand.Dispose();
		}
	}

	public int DropTable<TEntity>()
	{
		return DropTable(typeof(TEntity));
	}

	public bool EntityExists(Type type, params object[] primaryKeys)
	{
		return Select(type, primaryKeys.ToArray()) != null;
	}

	public bool EntityExists<TEntity>(params object[] primaryKeys)
	{
		return EntityExists(typeof(TEntity), primaryKeys.ToArray());
	}

	public int ExecuteNonQuery(Type entityType, string commandText)
	{
		if (entityType == null)
		{
			throw new ArgumentNullException("entityType");
		}
		if (string.IsNullOrEmpty(commandText))
		{
			throw new ArgumentNullException("commandText");
		}
		SqliteCommand sqliteCommand = Connection.CreateCommand();
		try
		{
			((IDatabaseInternal)this).ValidateQuery("ExecuteNonQuery");
			if (!_tables.ContainsKey(entityType))
			{
				return -1;
			}
			_ = _tables[entityType];
			sqliteCommand.CommandText = commandText;
			return sqliteCommand.ExecuteNonQuery();
		}
		catch (Exception innerException)
		{
			throw CreateDatabaseMethodException(innerException, "ExecuteNonQuery");
		}
		finally
		{
			((IDatabaseInternal)this).FinalizeQuery("ExecuteNonQuery");
			sqliteCommand.Dispose();
		}
	}

	public int ExecuteNonQuery<TEntity>(string commandText)
	{
		return ExecuteNonQuery(typeof(TEntity), commandText);
	}

	public IEnumerable<QueryResult> ExecuteQuery(string commandText)
	{
		if (string.IsNullOrEmpty(commandText))
		{
			throw new ArgumentNullException("commandText");
		}
		SqliteCommand sqliteCommand = Connection.CreateCommand();
		try
		{
			sqliteCommand.CommandText = commandText;
			sqliteCommand.Prepare();
			SqliteDataReader sqliteDataReader = sqliteCommand.ExecuteReader();
			List<QueryResult> list = new List<QueryResult>();
			if (sqliteDataReader.HasRows)
			{
				while (sqliteDataReader.Read())
				{
					list.Add(new QueryResult(sqliteDataReader));
				}
			}
			return list;
		}
		catch (Exception innerException)
		{
			throw CreateDatabaseMethodException(innerException, "ExecuteQuery");
		}
		finally
		{
			((IDatabaseInternal)this).FinalizeQuery("ExecuteQuery");
			sqliteCommand?.Dispose();
		}
	}

	public IEnumerable<object> ExecuteQuery(Type entityType, string commandText)
	{
		if (entityType == null)
		{
			throw new ArgumentNullException("entityType");
		}
		if (string.IsNullOrEmpty(commandText))
		{
			throw new ArgumentNullException("commandText");
		}
		SqliteCommand sqliteCommand = Connection.CreateCommand();
		try
		{
			((IDatabaseInternal)this).ValidateQuery("ExecuteQuery");
			if (!_tables.ContainsKey(entityType))
			{
				CreateTableIfNotExists(entityType);
			}
			ITable table = _tables[entityType];
			sqliteCommand.CommandText = commandText;
			sqliteCommand.Prepare();
			SqliteDataReader sqliteDataReader = sqliteCommand.ExecuteReader();
			List<object> list = new List<object>();
			if (sqliteDataReader.HasRows)
			{
				while (sqliteDataReader.Read())
				{
					list.Add(ReadRow(entityType, sqliteDataReader, table.Columns));
				}
			}
			return list;
		}
		catch (Exception innerException)
		{
			throw CreateDatabaseMethodException(innerException, "ExecuteQuery");
		}
		finally
		{
			((IDatabaseInternal)this).FinalizeQuery("ExecuteQuery");
			sqliteCommand?.Dispose();
		}
	}

	public IEnumerable<TEntity> ExecuteQuery<TEntity>(string commandText)
	{
		return ExecuteQuery(typeof(TEntity), commandText).Cast<TEntity>();
	}

	public long ExecuteScaler<TEntity>(string commandText)
	{
		return ExecuteScaler(typeof(TEntity), commandText);
	}

	public long ExecuteScaler(Type entityType, string commandText)
	{
		if (entityType == null)
		{
			throw new ArgumentNullException("entityType");
		}
		if (string.IsNullOrEmpty(commandText))
		{
			throw new ArgumentNullException("commandText");
		}
		SqliteCommand sqliteCommand = Connection.CreateCommand();
		try
		{
			((IDatabaseInternal)this).ValidateQuery("ExecuteScaler");
			if (!_tables.ContainsKey(entityType))
			{
				return -1L;
			}
			sqliteCommand.CommandText = commandText;
			return (long)(object)Convert.ToInt64(sqliteCommand.ExecuteScalar());
		}
		catch (Exception innerException)
		{
			throw CreateDatabaseMethodException(innerException, "ExecuteScaler");
		}
		finally
		{
			((IDatabaseInternal)this).FinalizeQuery("ExecuteScaler");
			try
			{
				sqliteCommand?.Dispose();
			}
			catch
			{
			}
		}
	}

	public ITable? GetTable(Type entityType)
	{
		if (entityType == null)
		{
			throw new ArgumentNullException("entityType");
		}
		if (_tables.ContainsKey(entityType))
		{
			return _tables[entityType];
		}
		return null;
	}

	public ITable? GetTable<TEntity>()
	{
		return GetTable(typeof(TEntity));
	}

	public int Insert(object entity)
	{
		if (entity == null)
		{
			throw new ArgumentNullException("entity");
		}
		SqliteCommand sqliteCommand = Connection.CreateCommand();
		try
		{
			((IDatabaseInternal)this).ValidateQuery("Insert");
			Type type = entity.GetType();
			if (!_tables.ContainsKey(type))
			{
				CreateTableIfNotExists(type);
			}
			ITable table = _tables[type];
			sqliteCommand.CommandText = $"INSERT INTO {table.Name} {((ITableInternal)table).GenerateColumnsList(wrapInParenthesis: true, addColumnInfo: false)} {((ITableInternal)table).GenerateValuesList(entity)}";
			foreach (Column column in table.Columns)
			{
				if (column.Type == typeof(byte[]))
				{
					SqliteParameter value = new SqliteParameter(column.ParameterName, SqliteType.Blob)
					{
						Value = column.GetValue(entity)
					};
					sqliteCommand.Parameters.Add(value);
				}
			}
			return sqliteCommand.ExecuteNonQuery();
		}
		catch (Exception innerException)
		{
			throw CreateDatabaseMethodException(innerException, "Insert");
		}
		finally
		{
			((IDatabaseInternal)this).FinalizeQuery("Insert");
			sqliteCommand.Dispose();
		}
	}

	public int InsertOrReplace(object entity)
	{
		if (entity == null)
		{
			throw new ArgumentNullException("entity");
		}
		SqliteCommand sqliteCommand = Connection.CreateCommand();
		try
		{
			((IDatabaseInternal)this).ValidateQuery("InsertOrReplace");
			Type type = entity.GetType();
			if (!_tables.ContainsKey(type))
			{
				CreateTableIfNotExists(type);
			}
			ITable table = _tables[type];
			sqliteCommand.CommandText = $"INSERT OR REPLACE INTO {table.Name} {((ITableInternal)table).GenerateColumnsList(wrapInParenthesis: true, addColumnInfo: false)} {((ITableInternal)table).GenerateValuesList(entity)}";
			foreach (Column column in table.Columns)
			{
				if (column.Type == typeof(byte[]))
				{
					SqliteParameter value = new SqliteParameter(column.ParameterName, SqliteType.Blob)
					{
						Value = column.GetValue(entity)
					};
					sqliteCommand.Parameters.Add(value);
				}
			}
			return sqliteCommand.ExecuteNonQuery();
		}
		catch (Exception innerException)
		{
			throw CreateDatabaseMethodException(innerException, "InsertOrReplace");
		}
		finally
		{
			((IDatabaseInternal)this).FinalizeQuery("InsertOrReplace");
			sqliteCommand.Dispose();
		}
	}

	public int InsertOrUpdate(object entity)
	{
		if (entity == null)
		{
			throw new ArgumentNullException("entity");
		}
		SqliteCommand sqliteCommand = Connection.CreateCommand();
		try
		{
			((IDatabaseInternal)this).ValidateQuery("InsertOrUpdate");
			Type type = entity.GetType();
			if (!_tables.ContainsKey(type))
			{
				CreateTableIfNotExists(type);
			}
			ITable table = _tables[type];
			sqliteCommand.CommandText = $"INSERT INTO {table.Name} {((ITableInternal)table).GenerateColumnsList(wrapInParenthesis: true, addColumnInfo: false)} {((ITableInternal)table).GenerateValuesList(entity)} ON CONFLICT ({((ITableInternal)table).GeneratePrimaryKeyNameList()}) DO UPDATE {((ITableInternal)table).GenerateSetValuesList(entity)} {((ITableInternal)table).GenerateWherePrimaryKey(entity)}";
			foreach (Column column in table.Columns)
			{
				if (column.Type == typeof(byte[]))
				{
					SqliteParameter value = new SqliteParameter(column.ParameterName, SqliteType.Blob)
					{
						Value = column.GetValue(entity)
					};
					sqliteCommand.Parameters.Add(value);
				}
			}
			return sqliteCommand.ExecuteNonQuery();
		}
		catch (Exception innerException)
		{
			throw CreateDatabaseMethodException(innerException, "InsertOrUpdate");
		}
		finally
		{
			((IDatabaseInternal)this).FinalizeQuery("InsertOrUpdate");
			sqliteCommand.Dispose();
		}
	}

	public void Open()
	{
		try
		{
			if (!IsOpen)
			{
				Connection.Open();
				IsOpen = true;
			}
		}
		catch (Exception innerException)
		{
			throw CreateDatabaseMethodException(innerException, "Open");
		}
	}

	public void PerformInTransaction(Action action)
	{
		if (action == null)
		{
			throw new ArgumentNullException("action");
		}
		try
		{
			((IDatabaseInternal)this).ValidateQuery("PerformInTransaction");
			if (_transaction != null)
			{
				throw new InvalidOperationException("The database is currently performing a transaction.");
			}
			_transaction = Connection.BeginTransaction();
			action();
			_transaction.Commit();
		}
		catch (Exception innerException)
		{
			_transaction?.Rollback();
			throw CreateDatabaseMethodException(innerException, "PerformInTransaction");
		}
		finally
		{
			_transaction?.Dispose();
			_transaction = null;
		}
	}

	public IEnumerable<object> Select(Type entityType)
	{
		if (entityType == null)
		{
			throw new ArgumentNullException("entityType");
		}
		SqliteCommand sqliteCommand = Connection.CreateCommand();
		try
		{
			((IDatabaseInternal)this).ValidateQuery("Select");
			if (!_tables.ContainsKey(entityType))
			{
				return Enumerable.Empty<object>();
			}
			ITable table = _tables[entityType];
			sqliteCommand.CommandText = "SELECT " + ((ITableInternal)table).GenerateColumnsList(wrapInParenthesis: false, addColumnInfo: false) + " FROM " + table.Name;
			SqliteDataReader sqliteDataReader = sqliteCommand.ExecuteReader();
			List<object> list = new List<object>();
			if (sqliteDataReader.HasRows)
			{
				while (sqliteDataReader.Read())
				{
					list.Add(ReadRow(entityType, sqliteDataReader, table.Columns));
				}
			}
			return list;
		}
		catch (Exception innerException)
		{
			throw CreateDatabaseMethodException(innerException, "Select");
		}
		finally
		{
			((IDatabaseInternal)this).FinalizeQuery("Select");
			sqliteCommand.Dispose();
		}
	}

	public IEnumerable<TEntity> Select<TEntity>()
	{
		return Select(typeof(TEntity)).Cast<TEntity>();
	}

	public object? Select(Type entityType, params object[] primaryKeys)
	{
		if (entityType == null)
		{
			throw new ArgumentNullException("entityType");
		}
		if (primaryKeys.Any((object k) => k == null))
		{
			throw new ArgumentException("One or more of the primary keys is null.");
		}
		SqliteCommand sqliteCommand = Connection.CreateCommand();
		try
		{
			((IDatabaseInternal)this).ValidateQuery("Select");
			if (!_tables.ContainsKey(entityType))
			{
				return entityType.Default();
			}
			ITable table = _tables[entityType];
			sqliteCommand.CommandText = $"SELECT {((ITableInternal)table).GenerateColumnsList(wrapInParenthesis: false, addColumnInfo: false)} FROM {table.Name} {((ITableInternal)table).GenerateWherePrimaryKey(primaryKeys.ToList())}";
			SqliteDataReader sqliteDataReader = sqliteCommand.ExecuteReader();
			if (sqliteDataReader.HasRows && sqliteDataReader.Read())
			{
				return ReadRow(entityType, sqliteDataReader, table.Columns);
			}
			return entityType.Default();
		}
		catch (Exception innerException)
		{
			throw CreateDatabaseMethodException(innerException, "Select");
		}
		finally
		{
			((IDatabaseInternal)this).FinalizeQuery("Select");
			sqliteCommand.Dispose();
		}
	}

	public TEntity? Select<TEntity>(params object[] primaryKeys)
	{
		return Select(typeof(TEntity), primaryKeys).TypeConversionCast<TEntity>();
	}

	public IEnumerable<object> SelectMany(Type entityType, params object[] primaryKeys)
	{
		if (entityType == null)
		{
			throw new ArgumentNullException("entityType");
		}
		if (primaryKeys.Any((object k) => k == null))
		{
			throw new ArgumentException("One or more of the primary keys is null.");
		}
		SqliteCommand sqliteCommand = Connection.CreateCommand();
		try
		{
			((IDatabaseInternal)this).ValidateQuery("SelectMany");
			return ProcessSelectMany(entityType, primaryKeys);
		}
		catch (Exception innerException)
		{
			throw CreateDatabaseMethodException(innerException, "SelectMany");
		}
		finally
		{
			((IDatabaseInternal)this).FinalizeQuery("SelectMany");
			sqliteCommand.Dispose();
		}
	}

	public IEnumerable<TEntity> SelectMany<TEntity>(params object[] primaryKeys)
	{
		return SelectMany(typeof(TEntity), primaryKeys).Cast<TEntity>();
	}

	public object SelectOrCreate(Type entityType, object primaryKey)
	{
		if (entityType == null)
		{
			throw new ArgumentNullException("entityType");
		}
		try
		{
			((IDatabaseInternal)this).ValidateQuery("SelectOrCreate");
			if (primaryKey == null)
			{
				object? obj = Activator.CreateInstance(entityType);
				obj.ThrowWhenNull("instance");
				return obj;
			}
			if (primaryKey is Guid && (Guid)primaryKey == Guid.Empty)
			{
				object? obj2 = Activator.CreateInstance(entityType);
				obj2.ThrowWhenNull("instance");
				return obj2;
			}
			bool flag = false;
			object obj3 = Select(entityType, primaryKey);
			if (obj3 == null)
			{
				obj3 = Activator.CreateInstance(entityType);
				obj3.ThrowWhenNull("value");
				flag = true;
			}
			EntityBase entityBase = obj3 as EntityBase;
			if (entityBase != null && flag)
			{
				entityBase.PrimaryKey = Guid.NewGuid();
				entityBase.Database = this;
			}
			return obj3;
		}
		catch (Exception innerException)
		{
			throw CreateDatabaseMethodException(innerException, "SelectOrCreate");
		}
	}

	public TEntity SelectOrCreate<TEntity>(Guid primaryKey)
	{
		return (TEntity)SelectOrCreate(typeof(TEntity), primaryKey);
	}

	public bool TableExists(string tableName)
	{
		if (string.IsNullOrEmpty(tableName))
		{
			throw new ArgumentNullException("tableName");
		}
		SqliteCommand sqliteCommand = Connection.CreateCommand();
		try
		{
			((IDatabaseInternal)this).ValidateQuery("TableExists");
			sqliteCommand.CommandText = "SELECT name FROM sqlite_master WHERE type='table' AND name='" + tableName + "'";
			return sqliteCommand.ExecuteReader().HasRows;
		}
		catch (Exception innerException)
		{
			throw CreateDatabaseMethodException(innerException, "TableExists");
		}
		finally
		{
			((IDatabaseInternal)this).FinalizeQuery("TableExists");
			sqliteCommand.Dispose();
		}
	}

	public int Update(object entity)
	{
		if (entity == null)
		{
			throw new ArgumentNullException("entity");
		}
		SqliteCommand sqliteCommand = Connection.CreateCommand();
		try
		{
			((IDatabaseInternal)this).ValidateQuery("Update");
			Type type = entity.GetType();
			if (!_tables.ContainsKey(type))
			{
				CreateTableIfNotExists(type);
			}
			ITable table = _tables[type];
			sqliteCommand.CommandText = $"UPDATE {table.Name} {((ITableInternal)table).GenerateSetValuesList(entity)} {((ITableInternal)table).GenerateWherePrimaryKey(entity)}";
			return sqliteCommand.ExecuteNonQuery();
		}
		catch (Exception innerException)
		{
			throw CreateDatabaseMethodException(innerException, "Update");
		}
		finally
		{
			((IDatabaseInternal)this).FinalizeQuery("Update");
			sqliteCommand.Dispose();
		}
	}

	void IDatabaseInternal.FinalizeQuery(string memberName)
	{
	}

	private void InitializePath(string path)
	{
		string directoryName = System.IO.Path.GetDirectoryName(path);
		if (!string.IsNullOrEmpty(directoryName) && !Directory.Exists(directoryName))
		{
			Directory.CreateDirectory(directoryName);
		}
	}

	private void InitializeTable(Type entityType)
	{
		if (!_tables.ContainsKey(entityType))
		{
			ITable table = Table.Create(entityType, this);
			_tables.AddOrUpdate(entityType, table, (Type t, ITable i) => table);
		}
	}

	[IteratorStateMachine(typeof(_003CProcessSelectMany_003Ed__62))]
	private IEnumerable<object> ProcessSelectMany(Type entityType, params object[] primaryKeys)
	{
		//yield-return decompiler failed: Unexpected instruction in Iterator.Dispose()
		return new _003CProcessSelectMany_003Ed__62(-2)
		{
			_003C_003E4__this = this,
			_003C_003E3__entityType = entityType,
			_003C_003E3__primaryKeys = primaryKeys
		};
	}

	private object ReadRow(Type type, SqliteDataReader reader, List<Column> columns)
	{
		if (reader.FieldCount == columns.Count)
		{
			object obj = Activator.CreateInstance(type);
			obj.ThrowWhenNull("entity");
			foreach (Column column in columns)
			{
				column.SetValue(obj, reader[column.Name]);
			}
			if (obj is EntityBase entityBase)
			{
				entityBase.Database = this;
			}
			return obj;
		}
		return new QueryResult(reader, type);
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

	void IDatabaseInternal.ValidateQuery(string memberName)
	{
		if (!IsOpen)
		{
			throw new DatabaseException("Open must be called before " + memberName + ".");
		}
	}
}
