using Jab;
using Pro.Localization.Services;

namespace Pro.Localization.DependencyInjection;

[Jab.ServiceProviderModule]
[Jab.Transient<ILocalization, Pro.Localization.Services.Localization>]
public interface ILocalizationServiceProviderModule
{
}
