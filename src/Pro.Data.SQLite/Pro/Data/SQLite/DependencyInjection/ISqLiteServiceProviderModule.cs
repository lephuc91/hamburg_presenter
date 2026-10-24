using Jab;
using Pro.Data.SQLite.Migration;

namespace Pro.Data.SQLite.DependencyInjection;

[Jab.ServiceProviderModule]
[Jab.Singleton<ISqliteMigrationService, SqliteMigrationService>]
public interface ISqLiteServiceProviderModule
{
}
