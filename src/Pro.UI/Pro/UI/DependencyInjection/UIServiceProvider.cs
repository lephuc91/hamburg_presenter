using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Pro.Common.Nullability;

namespace Pro.UI.DependencyInjection;

public static class UIServiceProvider
{
	private static IServiceProvider? _serviceProvider;

	private static IServiceProvider ServiceProvider => _serviceProvider ?? (_serviceProvider = GetServiceProvider());

	public static T GetService<T>() where T : notnull
	{
		return ServiceProvider.GetRequiredService<T>();
	}

	public static object GetService(Type type)
	{
		return ServiceProvider.GetRequiredService(type);
	}

	private static IServiceProvider GetServiceProvider()
	{
		IServiceProvider obj = Application.Current?.Properties["ApplicationServiceProviderPropertyName"] as IServiceProvider;
		obj.ThrowWhenNull("provider");
		return obj;
	}
}
