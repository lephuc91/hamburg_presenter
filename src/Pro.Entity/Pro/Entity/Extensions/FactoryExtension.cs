using Pro.Entity.Factory;

namespace Pro.Entity.Extensions;

public static class FactoryExtension
{
	public static T Create<T>(this IFactory<T> factory)
	{
		return factory.CreateInstance();
	}
}
