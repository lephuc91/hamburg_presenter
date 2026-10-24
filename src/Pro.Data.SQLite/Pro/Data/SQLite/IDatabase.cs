using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace Pro.Data.SQLite;

public interface IDatabase
{
	string Alias { get; }

	SqliteConnection Connection { get; }

	bool IsOpen { get; }

	string Path { get; }

	int Attach(string path, string alias);

	int Attach(IDatabase database);

	void Close();

	int Count(Type entityType);

	int Count<TEntity>();

	int CreateOrUpdateTable(Type entityType);

	int CreateOrUpdateTable<TEntity>();

	int CreateTable(Type entityType);

	int CreateTable<TEntity>();

	int CreateTableIfNotExists(Type entityType);

	int CreateTableIfNotExists<TEntity>();

	int Delete(object entity);

	int Detach(string alias);

	int Detach(IDatabase database);

	int DropTable(Type entityType);

	int DropTable<TEntity>();

	bool EntityExists(Type type, params object[] primaryKeys);

	bool EntityExists<TEntity>(params object[] primaryKeys);

	int ExecuteNonQuery(Type entityType, string commandText);

	int ExecuteNonQuery<TEntity>(string commandText);

	IEnumerable<QueryResult> ExecuteQuery(string commandText);

	IEnumerable<object> ExecuteQuery(Type entityType, string commandText);

	IEnumerable<TEntity> ExecuteQuery<TEntity>(string commandText);

	long ExecuteScaler<TEntity>(string commandText);

	long ExecuteScaler(Type entityType, string commandText);

	ITable? GetTable(Type entityType);

	ITable? GetTable<TEntity>();

	int Insert(object entity);

	int InsertOrReplace(object entity);

	int InsertOrUpdate(object entity);

	void Open();

	void PerformInTransaction(Action action);

	IEnumerable<TEntity> Select<TEntity>();

	object? Select(Type entityType, params object[] primaryKeys);

	TEntity? Select<TEntity>(params object[] primaryKeys);

	IEnumerable<object> SelectMany(Type entityType, params object[] primaryKeys);

	IEnumerable<TEntity> SelectMany<TEntity>(params object[] primaryKeys);

	object SelectOrCreate(Type entityType, object primaryKey);

	TEntity SelectOrCreate<TEntity>(Guid primaryKey);

	bool TableExists(string tableName);

	int Update(object entity);
}
