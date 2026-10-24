using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Pro.Data.SQLite;

public class CommandBuilder
{
	private readonly List<Tuple<CommandType, string>> _commandQueue = new List<Tuple<CommandType, string>>();

	public CommandBuilder Distinct(string columnName)
	{
		_commandQueue.Add(new Tuple<CommandType, string>(CommandType.Distinct, columnName));
		return this;
	}

	public CommandBuilder From(string tableName)
	{
		_commandQueue.Add(new Tuple<CommandType, string>(CommandType.From, tableName ?? ""));
		return this;
	}

	public CommandBuilder Select()
	{
		_commandQueue.Add(new Tuple<CommandType, string>(CommandType.Select, ""));
		return this;
	}

	public CommandBuilder Select(params string[] columns)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < columns.Length; i++)
		{
			stringBuilder.Append(columns[i]);
			if (i != columns.Length - 1)
			{
				stringBuilder.Append(", ");
			}
		}
		_commandQueue.Add(new Tuple<CommandType, string>(CommandType.Select, stringBuilder.ToString()));
		return this;
	}

	public CommandBuilder SelectAll()
	{
		_commandQueue.Add(new Tuple<CommandType, string>(CommandType.Select, "*"));
		return this;
	}

	public CommandBuilder Sum(string columnName)
	{
		_commandQueue.Add(new Tuple<CommandType, string>(CommandType.Sum, columnName ?? ""));
		return this;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		CommandType? commandType = null;
		foreach (Tuple<CommandType, string> item in _commandQueue)
		{
			if (commandType.HasValue)
			{
				stringBuilder.Append(" ");
			}
			switch (item.Item1)
			{
			case CommandType.Select:
				if (string.IsNullOrEmpty(item.Item2))
				{
					stringBuilder.Append("SELECT");
				}
				else
				{
					StringBuilder stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder8 = stringBuilder2;
					StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(7, 1, stringBuilder2);
					handler.AppendLiteral("SELECT ");
					handler.AppendFormatted(item.Item2);
					stringBuilder8.Append(ref handler);
				}
				commandType = CommandType.Select;
				break;
			case CommandType.Where:
				if (commandType == CommandType.Where || commandType == CommandType.And)
				{
					StringBuilder stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder6 = stringBuilder2;
					StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(4, 1, stringBuilder2);
					handler.AppendLiteral("AND ");
					handler.AppendFormatted(item.Item2);
					stringBuilder6.Append(ref handler);
					commandType = CommandType.And;
				}
				else
				{
					StringBuilder stringBuilder2 = stringBuilder;
					StringBuilder stringBuilder7 = stringBuilder2;
					StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(6, 1, stringBuilder2);
					handler.AppendLiteral("WHERE ");
					handler.AppendFormatted(item.Item2);
					stringBuilder7.Append(ref handler);
					commandType = CommandType.Where;
				}
				break;
			case CommandType.OrderBy:
				throw new NotImplementedException();
			case CommandType.Skip:
				throw new NotImplementedException();
			case CommandType.Take:
				throw new NotImplementedException();
			case CommandType.Count:
				throw new NotImplementedException();
			case CommandType.Sum:
			{
				StringBuilder stringBuilder2 = stringBuilder;
				StringBuilder stringBuilder5 = stringBuilder2;
				StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(5, 1, stringBuilder2);
				handler.AppendLiteral("SUM(");
				handler.AppendFormatted(item.Item2);
				handler.AppendLiteral(")");
				stringBuilder5.Append(ref handler);
				commandType = CommandType.Sum;
				break;
			}
			case CommandType.From:
			{
				StringBuilder stringBuilder2 = stringBuilder;
				StringBuilder stringBuilder4 = stringBuilder2;
				StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(5, 1, stringBuilder2);
				handler.AppendLiteral("FROM ");
				handler.AppendFormatted(item.Item2);
				stringBuilder4.Append(ref handler);
				commandType = CommandType.From;
				break;
			}
			case CommandType.Distinct:
			{
				StringBuilder stringBuilder2 = stringBuilder;
				StringBuilder stringBuilder3 = stringBuilder2;
				StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(9, 1, stringBuilder2);
				handler.AppendLiteral("DISTINCT ");
				handler.AppendFormatted(item.Item2);
				stringBuilder3.Append(ref handler);
				commandType = CommandType.Distinct;
				break;
			}
			}
		}
		return stringBuilder.ToString();
	}

	public CommandBuilder Where<TEntity>(Expression<Func<TEntity, bool>> predicate)
	{
		Tuple<CommandType, string> tuple = _commandQueue.Last();
		CommandType item = ((tuple.Item1 != CommandType.Where || tuple.Item1 != CommandType.And) ? CommandType.Where : CommandType.And);
		_commandQueue.Add(new Tuple<CommandType, string>(item, SqlCommandExpressionHelper.ParseExpression(predicate.Body, isUnary: true)));
		return this;
	}

	public CommandBuilder Where(string clause)
	{
		_commandQueue.Add(new Tuple<CommandType, string>(CommandType.Where, clause ?? ""));
		return this;
	}
}
