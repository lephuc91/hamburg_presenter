namespace Pro.Data.SQLite.Migration;

public interface IMigrationSource
{
	void MigrateBackward(IDatabaseService databaseService, MigrationTypes types);

	void MigrateForward(IDatabaseService databaseService);
}
