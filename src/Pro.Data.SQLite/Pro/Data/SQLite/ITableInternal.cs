using System.Collections.Generic;

namespace Pro.Data.SQLite;

internal interface ITableInternal
{
	string GenerateColumnsList(bool wrapInParenthesis, bool addColumnInfo);

	string GeneratePrimaryKeyExpression(List<object> primaryKeys);

	string GeneratePrimaryKeyNameList();

	string GenerateSetValuesList(object entity);

	string GenerateValuesList(object entity);

	string GenerateWherePrimaryKey(List<object> primaryKeys);

	string GenerateWherePrimaryKey(object entity);
}
