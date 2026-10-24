namespace Pro.Data.SQLite;

internal interface IDatabaseInternal
{
	void FinalizeQuery(string memberName);

	void ValidateQuery(string memberName);
}
