using Jab;
using Pro.Text.Fills;
using ProPresenter.DO.Media.Properties.File;

namespace ProPresenter.DO.Media.DependencyInjection;

[Jab.ServiceProviderModule]
[Jab.Transient<ITextFillMediaFactory, TextFillMediaFactory>]
[Jab.Transient<IRemoteFileLoader, RemoteFileLoader>]
internal interface IMediaServiceProviderModule
{
}
