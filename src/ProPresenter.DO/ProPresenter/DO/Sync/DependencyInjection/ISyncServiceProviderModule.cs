using Jab;
using ProPresenter.DO.Sync.Local;

namespace ProPresenter.DO.Sync.DependencyInjection;

[Jab.ServiceProviderModule]
[Jab.Transient<ISyncRepository<ISyncData>, RemoteFileRepository>(Name = "RemoteFileRepositoryKey")]
[Jab.Transient<ISyncDataProvider, SyncDataProvider>]
[Jab.Transient<IFileProvider, FileProvider>]
[Jab.Transient<ISyncActionProvider, SyncActionProvider>]
public interface ISyncServiceProviderModule
{
	const string RemoteFileRepositoryKey = "RemoteFileRepositoryKey";

	const string LocalFileRepositoryKey = "LocalFileRepositoryKey";
}
