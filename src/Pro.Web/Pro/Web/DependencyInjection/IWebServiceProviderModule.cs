using Jab;
using Pro.Web.Cookies;
using Pro.Web.Services;

namespace Pro.Web.DependencyInjection;

[Jab.ServiceProviderModule]
[Jab.Singleton<ICookieManagerService, CookieManagerService>]
[Jab.Transient<IRegistrationWebResourceService, RegistrationWebResourceService>]
[Jab.Transient<IApiService, ApiService>]
public interface IWebServiceProviderModule
{
}
