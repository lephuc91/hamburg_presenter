using System.IO.Abstractions;
using Jab;
using Pro.Web.Services;

namespace ProPresenter.DO.Resi.DependencyInjection;

[Jab.ServiceProviderModule]
[Jab.Singleton<IResiWebClient, ResiWebClient>]
[Jab.Singleton<IResiCustomEndpointsStore>(Factory = "GetResiCustomEndpointsStore")]
[Jab.Transient<IResiEndpoints>(Factory = "GetResiEndpoints")]
[Jab.Singleton<IUpdateClient, UpdateClient>]
public interface IResiServiceProviderModule
{
	static IResiCustomEndpointsStore GetResiCustomEndpointsStore(IFileSystem fileSystem)
	{
		return new ResiCustomEndpointsStore(fileSystem, CommonPaths.Preferences);
	}

	static IResiEndpoints GetResiEndpoints(IResiCustomEndpointsStore endpointsStore, IApiService apiService)
	{
		return new ResiEndpoints(endpointsStore, apiService.GetTargetRedirectHost(includeProtocol: true));
	}
}
