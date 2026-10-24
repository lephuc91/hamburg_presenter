using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using Pro.Common.Utility;

namespace Pro.Data.SQLite;

public class QueryBuilder<TEntity>
{
	private readonly List<string> _command = new List<string>();

	private readonly IDatabase _database;

	private readonly List<Tuple<CommandType, object?>> _queryQueue = new List<Tuple<CommandType, object>>();

	private readonly Table<TEntity> _table;

	public QueryBuilder(IDatabase database)
	{
		_database = database;
		_table = new Table<TEntity>(database);
	}

	public QueryBuilder<TEntity> Count()
	{
		if (_queryQueue.Any((Tuple<CommandType, object> q) => q.Item1 == CommandType.Select))
		{
			throw new InvalidOperationException("Select has already been called.");
		}
		if (_queryQueue.Any((Tuple<CommandType, object> q) => q.Item1 == CommandType.Count))
		{
			throw new InvalidOperationException("Count has already been called.");
		}
		_command.Add("SELECT COUNT(*) FROM " + _table.Name);
		_queryQueue.Add(new Tuple<CommandType, object>(CommandType.Count, null));
		return this;
	}

	public long Count(Expression<Func<TEntity, bool>> predicate)
	{
		Count().Where(predicate);
		QueryResult queryResult = (QueryResult)_database.ExecuteQuery(typeof(TEntity), GenerateCommand()).FirstOrDefault();
		if (queryResult == null)
		{
			return -1L;
		}
		return ((long?)queryResult[0]).GetValueOrDefault();
	}

	public IEnumerable<TEntity> ExecuteQuery()
	{
		Validate("ExecuteQuery");
		IEnumerable<TEntity> enumerable = _database.ExecuteQuery<TEntity>(GenerateCommand());
		return enumerable ?? Enumerable.Empty<TEntity>();
	}

	public long ExecuteScaler()
	{
		string text = GenerateCommand();
		if (string.IsNullOrEmpty(text) || string.IsNullOrWhiteSpace(text))
		{
			return -1L;
		}
		return _database.ExecuteScaler(typeof(TEntity), text);
	}

	public TEntity? FirstOrDefault()
	{
		return ExecuteQuery().FirstOrDefault();
	}

	public QueryBuilder<TEntity> OrderBy(Expression<Func<TEntity, object>> predicate, OrderByDirection direction = OrderByDirection.Ascending)
	{
		Validate("OrderBy");
		StringBuilder stringBuilder = new StringBuilder();
		string name = ExpressionHelper.GetMemberExpression(predicate).Member.Name;
		Tuple<CommandType, object> tuple = _queryQueue.Last();
		stringBuilder.Append((tuple.Item1 != CommandType.OrderBy) ? " ORDER BY " : ", ");
		stringBuilder.Append(name);
		stringBuilder.Append((direction == OrderByDirection.Ascending) ? " ASC" : " DESC");
		_command.Add(stringBuilder.ToString());
		_queryQueue.Add(new Tuple<CommandType, object>(CommandType.OrderBy, direction));
		return this;
	}

	public QueryBuilder<TEntity> Select()
	{
		if (_queryQueue.Any((Tuple<CommandType, object> q) => q.Item1 == CommandType.Select))
		{
			throw new InvalidOperationException("Select has already been called.");
		}
		if (_queryQueue.Any((Tuple<CommandType, object> q) => q.Item1 == CommandType.Count))
		{
			throw new InvalidOperationException("Count has already been called.");
		}
		_command.Add("SELECT " + ((ITableInternal)_table).GenerateColumnsList(wrapInParenthesis: false, addColumnInfo: false) + " FROM " + _table.Name);
		_queryQueue.Add(new Tuple<CommandType, object>(CommandType.Select, null));
		return this;
	}

	public IEnumerable<long> SelectRowId(Expression<Func<TEntity, bool>> predicate)
	{
		if (_queryQueue.Any((Tuple<CommandType, object> q) => q.Item1 == CommandType.Select))
		{
			throw new InvalidOperationException("Select has already been called.");
		}
		if (_queryQueue.Any((Tuple<CommandType, object> q) => q.Item1 == CommandType.Count))
		{
			throw new InvalidOperationException("Count has already been called.");
		}
		_command.Add("SELECT rowid FROM " + _table.Name);
		_queryQueue.Add(new Tuple<CommandType, object>(CommandType.Select, null));
		Where(predicate);
		QueryResult queryResult = (QueryResult)_database.ExecuteQuery(typeof(TEntity), GenerateCommand()).FirstOrDefault();
		if (queryResult == null)
		{
			return Enumerable.Empty<long>();
		}
		return queryResult.ToList<long>();
	}

	public QueryBuilder<TEntity> Skip(int count)
	{
		Validate("Skip");
		_command.Add($" LIMIT -1 OFFSET {count}");
		_queryQueue.Add(new Tuple<CommandType, object>(CommandType.Skip, count));
		return this;
	}

	public QueryBuilder<TEntity> Take(int count)
	{
		Validate("Take");
		Tuple<CommandType, object> tuple = _queryQueue.Last();
		if (tuple.Item1 == CommandType.Skip)
		{
			_command.Remove(_command.Last());
			_command.Add($" LIMIT {count} OFFSET {tuple.Item2}");
		}
		else
		{
			_command.Add($" LIMIT {count}");
		}
		_queryQueue.Add(new Tuple<CommandType, object>(CommandType.Take, count));
		return this;
	}

	public QueryBuilder<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
	{
		Validate("Where");
		StringBuilder stringBuilder = new StringBuilder();
		Tuple<CommandType, object> tuple = _queryQueue.Last();
		stringBuilder.Append((tuple.Item1 != CommandType.Where) ? " WHERE " : " AND ");
		stringBuilder.Append(SqlCommandExpressionHelper.ParseExpression(predicate.Body, isUnary: true, _table));
		_command.Add(stringBuilder.ToString());
		_queryQueue.Add(new Tuple<CommandType, object>(CommandType.Where, null));
		return this;
	}

	private string GenerateCommand()
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (string item in _command)
		{
			stringBuilder.Append(item);
		}
		return stringBuilder.ToString();
	}

	private static bool IsEnumerableType(Type type)
	{
		return type.GetInterfaces().Any((Type i) => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEnumerable<>));
	}

	private void Validate([CallerMemberName] string? memberName = null)
	{
		if (memberName == "Select" || _queryQueue.Contains(new Tuple<CommandType, object>(CommandType.Select, null)) || _queryQueue.Contains(new Tuple<CommandType, object>(CommandType.Count, null)))
		{
			return;
		}
		throw new InvalidOperationException($"Either {"Select"} or {"Count"} must be called before {memberName} can be invoked.");
	}
}
