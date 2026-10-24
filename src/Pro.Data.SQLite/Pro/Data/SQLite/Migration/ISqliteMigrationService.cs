namespace Pro.Data.SQLite.Migration;

public interface ISqliteMigrationService
{
	void MigrateBack(MigrationTypes types);

	void MigrateForward();

	void RegisterSource(IMigrationSource source);
}
