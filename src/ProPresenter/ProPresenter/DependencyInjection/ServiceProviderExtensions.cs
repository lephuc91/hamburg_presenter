using Jab;

namespace ProPresenter.DependencyInjection;

internal static class ServiceProviderExtensions
{
	public static T GetTypedService<T>(this Jab.IServiceProvider<T> provider)
	{
		return provider.GetService();
	}

	public static T GetTypedService<T>(this Jab.INamedServiceProvider<T> provider, string name)
	{
		return provider.GetService(name);
	}
}
