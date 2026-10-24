using Jab;

namespace ProPresenter.DO.Downloads.DependencyInjection;

[Jab.ServiceProviderModule]
[Jab.Transient<IFileDownloadObserverFactory, FileDownloadObserverFactory>]
internal interface IDownloadsServiceProviderModule
{
}
