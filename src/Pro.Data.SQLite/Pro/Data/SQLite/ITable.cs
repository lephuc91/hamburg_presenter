using System;
using System.Collections.Generic;

namespace Pro.Data.SQLite;

public interface ITable
{
	List<Column> Columns { get; }

	IDatabase Database { get; }

	Type EntityType { get; }

	string Name { get; }

	int CopyTo(ITable table);

	string? GetColumnNameFor(string propertyName);

	TableSchema GetSchema(bool suppressCloseDatabase = false);

	void SynchronizeWith(ITable source);
}
