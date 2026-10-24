using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pro.Data.SQLite;

public sealed class TableSchema
{
	private readonly List<ColumnSchema> _columns;

	public IReadOnlyList<ColumnSchema> Columns => _columns;

	public string TableName { get; }

	public TableSchema(string tableName)
	{
		TableName = tableName ?? throw new ArgumentNullException("tableName");
		_columns = new List<ColumnSchema>();
	}

	public bool ContainsColumn(Column column)
	{
		return Columns.FirstOrDefault((ColumnSchema c) => c.Name == column.Name) != null;
	}

	public bool Equals(Table table)
	{
		if (table.Name != TableName)
		{
			return false;
		}
		if (Columns.Count != table.Columns.Count)
		{
			return false;
		}
		foreach (Column ci in table.Columns)
		{
			if (!Columns.Any((ColumnSchema cs) => cs.Equals(ci)))
			{
				return false;
			}
		}
		return true;
	}

	internal void AddColumn(ColumnSchema column)
	{
		_columns.Add(column);
	}

	internal string GenerateColumnsList(bool wrapInParenthesis = true)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (wrapInParenthesis)
		{
			stringBuilder.Append("(");
		}
		for (int i = 0; i < Columns.Count; i++)
		{
			ColumnSchema columnSchema = Columns[i];
			StringBuilder stringBuilder2 = stringBuilder;
			StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(0, 1, stringBuilder2);
			handler.AppendFormatted(columnSchema.Name);
			stringBuilder2.Append(ref handler);
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
}
