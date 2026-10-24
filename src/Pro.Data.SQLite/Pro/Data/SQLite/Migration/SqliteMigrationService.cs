namespace Pro.Data.SQLite.Migration;

public class SqliteMigrationService : ISqliteMigrationService
{
	private readonly IDatabaseService _databaseService;

	private IMigrationSource? _migrationSource;

	public SqliteMigrationService(IDatabaseService datebaseService)
	{
		_databaseService = datebaseService;
	}

	public void MigrateBack(MigrationTypes types)
	{
		_migrationSource?.MigrateBackward(_databaseService, types);
	}

	public void MigrateForward()
	{
		_migrationSource?.MigrateForward(_databaseService);
	}

	public void RegisterSource(IMigrationSource source)
	{
		_migrationSource = source;
	}
}
