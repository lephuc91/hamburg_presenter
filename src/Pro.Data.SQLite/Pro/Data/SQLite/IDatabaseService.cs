using System;

namespace Pro.Data.SQLite;

public interface IDatabaseService
{
	void PerformDatabaseOperationWithLogging(Action<IDatabase> action);
}
