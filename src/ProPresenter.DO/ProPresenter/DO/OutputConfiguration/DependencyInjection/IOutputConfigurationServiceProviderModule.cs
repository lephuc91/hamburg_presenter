using Jab;

namespace ProPresenter.DO.OutputConfiguration.DependencyInjection;

[Jab.ServiceProviderModule]
[Jab.Transient<IPhysicalDeviceProvider, PhysicalDeviceProvider>]
internal interface IOutputConfigurationServiceProviderModule
{
}
