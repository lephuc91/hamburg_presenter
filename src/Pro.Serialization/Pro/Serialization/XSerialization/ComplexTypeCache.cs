using System;
using Pro.Common.Cache;

namespace Pro.Serialization.XSerialization;

internal class ComplexTypeCache : Cache<Type, ComplexType>
{
	private Func<Type, ComplexType> _generator;

	public ComplexTypeCache(Func<Type, ComplexType> generator)
	{
		_generator = generator;
	}

	protected override ComplexType GenerateValue(Type target)
	{
		return _generator(target);
	}
}
