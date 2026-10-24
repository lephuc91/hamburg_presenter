using Jab;

namespace ProPresenter.DO.Updates.DependencyInjection;

[Jab.ServiceProviderModule]
[Jab.Transient<IAppDownloadFactory, AppDownloadFactory>]
[Jab.Singleton<IAppUpdateService, AppUpdateService>]
internal interface IUpdatesServiceProviderModule
{
}
