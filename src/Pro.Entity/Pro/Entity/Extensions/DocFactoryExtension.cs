using Pro.Entity.Factory;

namespace Pro.Entity.Extensions;

public static class DocFactoryExtension
{
	public static T Create<T>(this IDocFactory<T> factory, ulong peerId) where T : IEntityDocument
	{
		return factory.CreateInstance(peerId);
	}
}
